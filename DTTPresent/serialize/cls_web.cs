/* cls_web.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-web
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-web

namespace DesktopTeacherTools
{
    public partial class cls_web : cls_page
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private bool displayURL;
        private string m_url;
        #endregion
//USERCODE-SECTION-web-uservars
// Put code here.
//ENDUSERCODE-SECTION-web-uservars

        #region XMLpg_generated_code

        public cls_web() : this(null) { }

        public cls_web(cls_DTTPresentation_part parent) : base (parent)
        {
            m_url = "";
        }

        public bool M_displayURL
        {
            get { return displayURL; }
            set { displayURL = value; }
        }

        public string M_url
        {
            get { return m_url; }
            set { m_url = value; }
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
            output += "<web";
            // attributes
            output += base.xmlAttributes();
            if (displayURL)
                output += " displayURL=\"true\"";
            else
                output += " displayURL=\"false\"";
            output += ">";
            // content
            output += base.xmlContent(neat, indent);
            if (neat) output += "\n" + pad + "    ";
            output += "<url>" + m_url.ToString() + "</url>";
            if (neat) output += "\n" + pad;
            output += "</web>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "web";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                default:
                    return base.startElement(elementid, atts, nsuri, elementname);    
                    //break;
            }
            //return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            base.parseAttributes(atts);
            if ((atts["displayURL"].Equals("true", StringComparison.OrdinalIgnoreCase))
                        || (atts["displayURL"].Equals("yes", StringComparison.OrdinalIgnoreCase))
                        || (atts["displayURL"].Equals("1")))
                displayURL = true;
            else
                displayURL = false;
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case DTTPresentation_parser.ID_url:
                    m_url += chars;
                    break;
                default:
                    base.content(chars, elementid);
                    break;
                }
            }
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("web")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-web
// Put code here.
//ENDUSERCODE-SECTION-endElement-web
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-web
// Put code here.
//ENDUSERCODE-SECTION-userMethods-web
    }
}

