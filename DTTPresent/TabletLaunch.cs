using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WintabDN;
using OverlayPaint;

namespace DTTPresent
{
    class TabletLaunch
    {
        bool drawing;
        OverlayPaintArea pa;
        TextBox textBox1;

        
        public TabletLaunch(OverlayPaintArea opa, TextBox tb)
        {
            pa = opa;
            textBox1 = tb;
        }

        #region WintabDN_related

        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private UInt32 m_maxPkts = 1;   // max num pkts to capture/display at a time

        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;

        private int lastX;
        private int lastY;
        private int lastZ;

        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            if (m_maxPkts == 1)
            {
                uint pktID = (uint)eventArgs_I.Message.WParam;
                WintabPacket pkt = m_wtData.GetDataPacket((uint)eventArgs_I.Message.LParam, pktID);
                //WintabPacket pkt = m_wtData.GetDataPacket(pktID);

                if ((pkt.pkContext != 0) && ((pkt.pkX != lastX) || (pkt.pkY != lastY)))
                {
                    lastX = pkt.pkX;
                    lastY = pkt.pkY;
                    lastZ = pkt.pkZ;
                    //Cursor.Position = new Point(lastX/10, lastY/10);
                    Point pt = pa.PointToClient(new Point(pkt.pkX, pkt.pkY));
                   // Point pt = pa.PointToClient(new Point(lastX / 10, lastY / 10));
                    pa.showPointer(pt.X, pt.Y);
                    uint m_pressure = pkt.pkNormalPressure;

                    textBox1.Text = "Bamboo point " + pkt.pkX.ToString() + ", " + pkt.pkY.ToString() + ", Z:" + pkt.pkZ.ToString() + ", p:" + m_pressure.ToString();
                    textBox1.Text += "\r\nTP:" + pkt.pkTangentPressure.ToString();
                    textBox1.Text += "\r\nTime:" + pkt.pkTime.ToString();
                    textBox1.Text += "\r\nContext:" + pkt.pkContext.ToString();
                    textBox1.Text += "\r\nStatus:" + pkt.pkStatus.ToString();
                    textBox1.Text += "\r\n" + pt.X.ToString() + "," + pt.Y.ToString();
                    textBox1.Text += "\r\nHWND = " + eventArgs_I.Message.HWnd.ToString();

                    if(m_pressure > 1)
                    {
                        if (drawing)
                        {
                            pa.DrawTo(pt.X, pt.Y, (int)m_pressure);
                        }
                        else
                        {
                            drawing = true;
                            pa.startDrawing(pt.X, pt.Y, (int)m_pressure);
                        }
                        //    mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    }
                    else
                    {
                        if(drawing)
                        {
                            drawing = false;
                            pa.endDrawing();
                        }
                      //  mouse_event(MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    }
                    //textBox1.Text = "Data: X=" + lastX.ToString() + "; Y=" + lastY.ToString() + "; Z=" + lastZ.ToString() + "; P=" + m_pressure.ToString()+"\r\n";
                    //textBox1.SelectionStart = textBox1.Text.Length;
                    //textBox1.ScrollToCaret();
                    //m_pkTime = pkt.pkTime;
                }
            }

        }
        ///////////////////////////////////////////////////////////////////////
        // Helper functions
        //

        ///////////////////////////////////////////////////////////////////////
        public void InitDataCapture(int ctxWidth_I = m_TABEXTX, int ctxHeight_I = m_TABEXTY, bool ctrlSysCursor_I = true)
        {
            try
            {
                // Close context from any previous test.
                CloseCurrentContext();

                m_logContext = OpenTestSystemContext(ctxWidth_I, ctxHeight_I, ctrlSysCursor_I);

                if (m_logContext == null)
                {
                    return;
                }

                // Create a data object and set its WT_PACKET handler.
                m_wtData = new CWintabData(m_logContext);
                m_wtData.SetWTPacketEventHandler(MyWTPacketEventHandler);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////
        public void CloseCurrentContext()
        {
            try
            {
                if (m_logContext != null)
                {
                    m_logContext.Close();
                    m_logContext = null;
                    m_wtData = null;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private CWintabContext OpenTestSystemContext(
            int width_I = m_TABEXTX, int height_I = m_TABEXTY, bool ctrlSysCursor = true)
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default system context.
                // Default is to receive data events.
                //logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                logContext = CWintabInfo.GetDefaultSystemContext(ECTXOptionValues.CXO_MESSAGES);

                // Set system cursor if caller wants it.
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;
                }
                else
                {
                    logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;
                }

                if (logContext == null)
                {
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Event Data Context";

                WintabAxis tabletX = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X);
                WintabAxis tabletY = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y);

                logContext.InOrgX = 0;
                logContext.InOrgY = 0;
                logContext.InExtX = tabletX.axMax;
                logContext.InExtY = tabletY.axMax;

                // SetSystemExtents() is (almost) a NO-OP redundant if you opened a system context.
                SetSystemExtents(ref logContext);

                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();

            }
            catch (Exception ex)
            {
            }

            return logContext;
        }

        private void SetSystemExtents(ref CWintabContext logContext)
        {
            logContext.OutExtY = -logContext.OutExtY;
        }
        #endregion
    }
}
