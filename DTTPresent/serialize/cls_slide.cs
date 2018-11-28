/* cls_slide.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-slide
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-slide

namespace DesktopTeacherTools
{
    public partial class cls_slide : cls_page
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private slideLayout layout;
        private int titleX;
        private int titleY;
        private int titleW;
        private int titleH;
        private int contentX;
        private int contentY;
        private int contentW;
        private int contentH;
        private int gap;
        private string m_background;
        private string m_markdown;
        private List<string> m_assest;
        #endregion
//USERCODE-SECTION-slide-uservars
// Put code here.
//ENDUSERCODE-SECTION-slide-uservars

        public enum slideLayout {centre, tc, t1, t2, t11, t21, t12, t21v, t12v, t33 };

        #region XMLpg_generated_code

        public cls_slide() : this(null) { }

        public cls_slide(cls_DTTPresentation_part parent) : base (parent)
        {
            m_markdown = "";
            m_assest = new List<string>();
        }

        public cls_slide.slideLayout M_layout
        {
            get { return layout; }
            set { layout = value; }
        }

        public int M_titleX
        {
            get { return titleX; }
            set { titleX = value; }
        }

        public int M_titleY
        {
            get { return titleY; }
            set { titleY = value; }
        }

        public int M_titleW
        {
            get { return titleW; }
            set { titleW = value; }
        }

        public int M_titleH
        {
            get { return titleH; }
            set { titleH = value; }
        }

        public int M_contentX
        {
            get { return contentX; }
            set { contentX = value; }
        }

        public int M_contentY
        {
            get { return contentY; }
            set { contentY = value; }
        }

        public int M_contentW
        {
            get { return contentW; }
            set { contentW = value; }
        }

        public int M_contentH
        {
            get { return contentH; }
            set { contentH = value; }
        }

        public int M_gap
        {
            get { return gap; }
            set { gap = value; }
        }

        public string M_background
        {
            get { return m_background; }
            set { m_background = value; }
        }

        public string M_markdown
        {
            get { return m_markdown; }
            set { m_markdown = value; }
        }

        public List<string> M_assest
        {
            get { return m_assest; }
            set { m_assest = value; }
        }

        public bool Add_assest(string n_assest)
        {
            m_assest.Add(n_assest);
            return true;
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
            output += "<slide";
            // attributes
            output += base.xmlAttributes();
            output += " layout=\"" + layout.ToString().Replace("\"", "&quot;") + "\"";
            output += " titleX=\"" + titleX.ToString() + "\"";
            output += " titleY=\"" + titleY.ToString() + "\"";
            output += " titleW=\"" + titleW.ToString() + "\"";
            output += " titleH=\"" + titleH.ToString() + "\"";
            output += " contentX=\"" + contentX.ToString() + "\"";
            output += " contentY=\"" + contentY.ToString() + "\"";
            output += " contentW=\"" + contentW.ToString() + "\"";
            output += " contentH=\"" + contentH.ToString() + "\"";
            output += " gap=\"" + gap.ToString() + "\"";
            output += ">";
            // content
            output += base.xmlContent(neat, indent);
            if (m_background != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<background>" + m_background.ToString() + "</background>";
            }
            if (neat) output += "\n" + pad + "    ";
            output += "<markdown>" + m_markdown.ToString() + "</markdown>";
            foreach (string tmp_assest in m_assest)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<assest>" + tmp_assest.ToString() + "</assest>";
            }
            if (neat) output += "\n" + pad;
            output += "</slide>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "slide";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                case DTTPresentation_parser.ID_background:
                    m_background = "";
                    return this;
                    //break;
                case DTTPresentation_parser.ID_assest:
                    m_assest.Add("");
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
            if (atts.ContainsKey("layout"))
            {
                layout = (slideLayout)Enum.Parse(typeof(slideLayout), atts["layout"]); 
            }
            if (atts.ContainsKey("titleX"))
            {
                titleX = int.Parse(atts["titleX"]);
            }
            if (atts.ContainsKey("titleY"))
            {
                titleY = int.Parse(atts["titleY"]);
            }
            if (atts.ContainsKey("titleW"))
            {
                titleW = int.Parse(atts["titleW"]);
            }
            if (atts.ContainsKey("titleH"))
            {
                titleH = int.Parse(atts["titleH"]);
            }
            if (atts.ContainsKey("contentX"))
            {
                contentX = int.Parse(atts["contentX"]);
            }
            if (atts.ContainsKey("contentY"))
            {
                contentY = int.Parse(atts["contentY"]);
            }
            if (atts.ContainsKey("contentW"))
            {
                contentW = int.Parse(atts["contentW"]);
            }
            if (atts.ContainsKey("contentH"))
            {
                contentH = int.Parse(atts["contentH"]);
            }
            if (atts.ContainsKey("gap"))
            {
                gap = int.Parse(atts["gap"]);
            }
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case DTTPresentation_parser.ID_background:
                    m_background = chars;
                    break;
                case DTTPresentation_parser.ID_markdown:
                    m_markdown += chars;
                    break;
                case DTTPresentation_parser.ID_assest:
                    m_assest[m_assest.Count - 1] += chars;
                    break;
                default:
                    base.content(chars, elementid);
                    break;
                }
            }
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("slide")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-slide
// Put code here.
//ENDUSERCODE-SECTION-endElement-slide
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-slide
// Put code here.
//ENDUSERCODE-SECTION-userMethods-slide
    }
}

