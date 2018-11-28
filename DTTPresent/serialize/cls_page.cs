/* cls_page.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-page
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-page

namespace DesktopTeacherTools
{
    public partial class cls_page : cls_DTTPresentation_part
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string uniqueID = "";
        private string title = "";
        private string penSetID = "";
        #endregion
//USERCODE-SECTION-page-uservars
// Put code here.
//ENDUSERCODE-SECTION-page-uservars

        #region XMLpg_generated_code

        public cls_page() : this(null) { }

        public cls_page(cls_DTTPresentation_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
        }

        public string M_uniqueID
        {
            get { return uniqueID; }
            set { uniqueID = value; }
        }

        public string M_title
        {
            get { return title; }
            set { title = value; }
        }

        public string M_penSetID
        {
            get { return penSetID; }
            set { penSetID = value; }
        }

        internal override void setOwner(cls_DTTPresentation n_owner)
        {
            __owner = n_owner;
        }

        public virtual string toXML(bool neat, string binaryPath = null)
        {
            return toXML(neat, 0, binaryPath);
        }     
        
        internal string xmlAttributes()
        {
            string output = "";
            output += " uniqueID=\"" + uniqueID.ToString().Replace("\"", "&quot;") + "\"";
            output += " title=\"" + title.ToString().Replace("\"", "&quot;") + "\"";
            output += " penSetID=\"" + penSetID.ToString().Replace("\"", "&quot;") + "\"";
            return output;
        }
        
        internal string xmlContent(bool neat, int indent)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "";
            return output;
        }
        
        public virtual string toXML(bool neat, int indent, string binaryPath = null)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "";
            if (neat) output += "\n" +  pad;
            output += "<page";
            // attributes
            output += xmlAttributes();
            output += "/>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "page";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                default:
                    throw new Exception("Unexpected element " + elementname + " in page");
                    //break;
            }
            //return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("uniqueID"))
            {
                uniqueID = atts["uniqueID"];
            }
            if (atts.ContainsKey("title"))
            {
                title = atts["title"];
            }
            if (atts.ContainsKey("penSetID"))
            {
                penSetID = atts["penSetID"];
            }
        }

        public override void content(string chars, int elementid)
        {
            // read chars into empty 
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("page")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-page
// Put code here.
//ENDUSERCODE-SECTION-endElement-page
        }
        #endregion

        public virtual string getUniqueID()
        {
//USERCODE-SECTION-page::getUniqueID
throw new Exception("Not implemented yet");
//ENDUSERCODE-SECTION-page::getUniqueID
        }

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-page
// Put code here.
//ENDUSERCODE-SECTION-userMethods-page
    }
}

