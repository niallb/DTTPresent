using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WintabDN;
using OverlayPaint;
using System.Threading;

namespace OverlayPaint
{
    public class TabletLaunch
    {
        OverlayPaintArea pa;
        TextBox textBox1;
        PointF zp2;
        internal bool zpNeedsInit = true;
        public bool capturing { get; private set; }

        public TabletLaunch(OverlayPaintArea opa, TextBox tb)
        {
            pa = opa;
            textBox1 = tb;
            capturing = false;
        }

        public TabletLaunch(OverlayPaintArea opa)
        {
            pa = opa;
            textBox1 = null;
            capturing = false;
        }

        #region WintabDN_related

        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private UInt32 m_maxPkts = 1;   // max num pkts to capture/display at a time

        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;

        private const int MultFactor = 5;

        private int lastX;
        private int lastY;
        private int lastZ;

        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            try
            {
                if ((m_maxPkts == 1)&&(m_wtData!=null))
                {
                    uint pktID = (uint)eventArgs_I.Message.WParam;
                    //WintabPacketExt pkt2 = m_wtData.GetDataPacketExt((uint)eventArgs_I.Message.LParam, pktID);
                    WintabPacket pkt = m_wtData.GetDataPacket((uint)eventArgs_I.Message.LParam, pktID);
                    //WintabPacket pkt = m_wtData.GetDataPacket(pktID);
                    if(textBox1 != null)
                    {
                        textBox1.Text = "Bamboo point " + pkt.pkX.ToString() + ", " + pkt.pkY.ToString() + ", Z:" + pkt.pkZ.ToString() + ", p:" + pkt.pkNormalPressure.ToString();

                        textBox1.Text += "\r\nMouse: "+Cursor.Position.X.ToString()+", "+Cursor.Position.Y.ToString();
                    }
                    if ((pkt.pkContext != 0) && ((pkt.pkX != lastX) || (pkt.pkY != lastY)))
                    {
                        capturing = pkt.pkZ < 512;
                        
                        
                        lastX = pkt.pkX;
                        lastY = pkt.pkY;
                        lastZ = pkt.pkZ;

                        // New version to use cursor to correct offset
                        PointF pt;
                        if (zpNeedsInit && capturing)
                        {
                            /*PointF detected = new PointF(pkt.pkX / MultFactor, pkt.pkY / MultFactor);                            
                            pt = pa.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                            zp2 = new PointF(pt.X - detected.X, pt.Y - detected.Y);*/
                            zp2 = pa.PointToClient(new Point(0, 0));
                            pt = new PointF(pkt.pkX / MultFactor + zp2.X, pkt.pkY / MultFactor + zp2.Y);
                            zpNeedsInit = false;
                        }
                        else
                        {
                            pt = new PointF(pkt.pkX / MultFactor + zp2.X, pkt.pkY / MultFactor + zp2.Y);
                        }//*/

                        //Cursor.Position = new Point(lastX/10, lastY/10);
                        //Point zp = pa.PointToClient(new Point(0,0));
                        //PointF pt = Cursor.Position.X, (uint)Cursor.Position.Y

                        // The version that works well at home...
                        //   PointF pt = new PointF(pkt.pkX / MultFactor + zp.X, pkt.pkY / MultFactor + zp.Y);

                        // Point pt = pa.PointToClient(new Point(lastX / 10, lastY / 10));
                        //Using mouse co-ords
                        //PointF pt = pa.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)); 
                        pa.showPointer((int)pt.X, (int)pt.Y);
                        uint m_pressure = pkt.pkNormalPressure;

                        if (textBox1 != null)
                        {
                            textBox1.Text += "\r\n" + pt.X.ToString() + "," + pt.Y.ToString();
                            textBox1.Text += "\r\nHWND = " + eventArgs_I.Message.HWnd.ToString();
                            textBox1.Text += "\r\nTime = " + pkt.pkTime.ToString();
                        }
                        if (m_pressure > 1)
                        {
                            if (pa.drawing)
                            {
                                pa.DrawTo(pt.X, pt.Y, (int)m_pressure);
                                //pa.DrawTo((uint)Cursor.Position.X, (uint)Cursor.Position.Y, (int)m_pressure);
                            }
                            else
                            {
                                pa.startDrawing(pt.X, pt.Y, (int)m_pressure);
                                //pa.startDrawing((uint)Cursor.Position.X, (uint)Cursor.Position.Y, (int)m_pressure);
                            }
                            //    mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else
                        {
                            if (pa.drawing)
                            {
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
            catch(Exception ex)
            {
               // MessageBox.Show("Lost tablet context.");
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // Helper functions
        //

        ///////////////////////////////////////////////////////////////////////
        public void InitDataCapture(Screen forScreen, int ctxWidth_I = m_TABEXTX, int ctxHeight_I = m_TABEXTY, bool ctrlSysCursor_I = true)
        {
            try
            {
                // Close context from any previous test.
                CloseCurrentContext();

                m_logContext = OpenTestSystemContext(forScreen, ctxWidth_I, ctxHeight_I, ctrlSysCursor_I);

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
        private CWintabContext OpenTestSystemContext(Screen forScreen, 
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
                ctrlSysCursor = false;//#tmp test
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;                  
                }
                else
                {
                    logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;
                }
                logContext.PktMode = 0;
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
                //# this is how to set higher resolution
                /*logContext.OutOrgY = logContext.OutOrgY * MultFactor;
                logContext.OutExtX = logContext.OutExtX * MultFactor;
                logContext.OutOrgX = logContext.OutOrgX * MultFactor;
                logContext.OutExtY = logContext.OutExtY * MultFactor;*/

                logContext.OutOrgY = forScreen.Bounds.Y * MultFactor;
                logContext.OutExtX = forScreen.Bounds.Width * MultFactor;
                logContext.OutOrgX = forScreen.Bounds.X * MultFactor;
                logContext.OutExtY = forScreen.Bounds.Height * MultFactor;

                //logContext.PktRate = 25;


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
