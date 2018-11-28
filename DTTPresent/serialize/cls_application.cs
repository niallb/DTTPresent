/* cls_application.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-application
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-application

namespace DesktopTeacherTools
{
    public partial class cls_application : cls_page
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string m_appname;
        private string m_params;
        #endregion
//USERCODE-SECTION-application-uservars
// Put code here.
//ENDUSERCODE-SECTION-application-uservars

        #region XMLpg_generated_code

        public cls_application() : this(null) { }

        public cls_application(cls_DTTPresentation_part parent) : base (parent)
        {
        }

        public string M_appname
        {
            get { return m_appname; }
            set { m_appname = value; }
        }

        public string M_params
        {
            get { return m_params; }
            set { m_params = value; }
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
            output += "<application";
            // attributes
            output += base.xmlAttributes();
            output += ">";
            // content
            output += base.xmlContent(neat, indent);
            if (m_appname != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<appname>" + m_appname.ToString() + "</appname>";
            }
            if (m_params != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<params>" + m_params.ToString() + "</params>";
            }
            if (neat) output += "\n" + pad;
            output += "</application>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "application";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                case DTTPresentation_parser.ID_appname:
                    m_appname = "";
                    return this;
                    //break;
                case DTTPresentation_parser.ID_params:
                    m_params = "";
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
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case DTTPresentation_parser.ID_appname:
                    m_appname = chars;
                    break;
                case DTTPresentation_parser.ID_params:
                    m_params = chars;
                    break;
                default:
                    base.content(chars, elementid);
                    break;
                }
            }
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("application")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-application
// Put code here.
//ENDUSERCODE-SECTION-endElement-application
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-application
// Put code here.
//ENDUSERCODE-SECTION-userMethods-application
    }
}

