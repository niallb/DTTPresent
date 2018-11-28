/* cls_board.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-board
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-board

namespace DesktopTeacherTools
{
    public partial class cls_board : cls_page
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private logopos lpos;
        private bool allowScroll;
        private string m_boardColour;
        private string m_lineColour;
        private string m_logo;
        private string m_underlayID;
        #endregion
//USERCODE-SECTION-board-uservars
// Put code here.
//ENDUSERCODE-SECTION-board-uservars

        public enum logopos {none, topleft, topcentre, topright, bottomleft, bottomcentre, bottomright };

        #region XMLpg_generated_code

        public cls_board() : this(null) { }

        public cls_board(cls_DTTPresentation_part parent) : base (parent)
        {
        }

        public cls_board.logopos M_lpos
        {
            get { return lpos; }
            set { lpos = value; }
        }

        public bool M_allowScroll
        {
            get { return allowScroll; }
            set { allowScroll = value; }
        }

        public string M_boardColour
        {
            get { return m_boardColour; }
            set { m_boardColour = value; }
        }

        public string M_lineColour
        {
            get { return m_lineColour; }
            set { m_lineColour = value; }
        }

        public string M_logo
        {
            get { return m_logo; }
            set { m_logo = value; }
        }

        public string M_underlayID
        {
            get { return m_underlayID; }
            set { m_underlayID = value; }
        }

        internal override void setOwner(cls_DTTPresentation n_owner)
        {
            __owner = n_owner;
        }

        public override string toXML(bool neat, string binaryPath = null)
        {
            return toXML(neat, 0, binaryPath);
        }     
        
        public override string toXML(bool neat, int indent, string binaryPath = null)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "";
            if (neat) output += "\n" +  pad;
            output += "<board";
            // attributes
            output += base.xmlAttributes();
            output += " lpos=\"" + lpos.ToString().Replace("\"", "&quot;") + "\"";
            if (allowScroll)
                output += " allowScroll=\"true\"";
            else
                output += " allowScroll=\"false\"";
            output += ">";
            // content
            output += base.xmlContent(neat, indent);
            if (m_boardColour != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<boardColour>" + m_boardColour.ToString() + "</boardColour>";
            }
            if (m_lineColour != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<lineColour>" + m_lineColour.ToString() + "</lineColour>";
            }
            if (m_logo != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<logo>" + m_logo.ToString() + "</logo>";
            }
            if (m_underlayID != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<underlayID>" + m_underlayID.ToString() + "</underlayID>";
            }
            if (neat) output += "\n" + pad;
            output += "</board>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "board";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                case DTTPresentation_parser.ID_boardColour:
                    m_boardColour = "";
                    return this;
                    //break;
                case DTTPresentation_parser.ID_lineColour:
                    m_lineColour = "";
                    return this;
                    //break;
                case DTTPresentation_parser.ID_logo:
                    m_logo = "";
                    return this;
                    //break;
                case DTTPresentation_parser.ID_underlayID:
                    m_underlayID = "";
                    return this;
                    //break;
                default:
                    return base.startElement(elementid, atts, nsuri, elementname);    
                    //break;
            }
            //return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            base.parseAttributes(atts);
            if (atts.ContainsKey("lpos"))
            {
                lpos = (logopos)Enum.Parse(typeof(logopos), atts["lpos"]); 
            }
            if ((atts["allowScroll"].Equals("true", StringComparison.OrdinalIgnoreCase))
                        || (atts["allowScroll"].Equals("yes", StringComparison.OrdinalIgnoreCase))
                        || (atts["allowScroll"].Equals("1")))
                allowScroll = true;
            else
                allowScroll = false;
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case DTTPresentation_parser.ID_boardColour:
                    m_boardColour = chars;
                    break;
                case DTTPresentation_parser.ID_lineColour:
                    m_lineColour = chars;
                    break;
                case DTTPresentation_parser.ID_logo:
                    m_logo = chars;
                    break;
                case DTTPresentation_parser.ID_underlayID:
                    m_underlayID = chars;
                    break;
                default:
                    base.content(chars, elementid);
                    break;
                }
            }
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("board")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-board
// Put code here.
//ENDUSERCODE-SECTION-endElement-board
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-board
// Put code here.
//ENDUSERCODE-SECTION-userMethods-board
    }
}

