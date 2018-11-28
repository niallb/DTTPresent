/* cls_penSet.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-penSet
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-penSet

namespace DesktopTeacherTools
{
    public partial class cls_penSet : cls_DTTPresentation_part
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string name = "";
        private string id = "";
        private List<cls_penDefinition> m_penDefinition;
        #endregion
//USERCODE-SECTION-penSet-uservars
// Put code here.
//ENDUSERCODE-SECTION-penSet-uservars

        #region XMLpg_generated_code

        public cls_penSet() : this(null) { }

        public cls_penSet(cls_DTTPresentation_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_penDefinition = new List<cls_penDefinition>();
        }

        public string M_name
        {
            get { return name; }
            set { name = value; }
        }

        public string M_id
        {
            get { return id; }
            set { id = value; }
        }

        public List<cls_penDefinition> M_penDefinition
        {
            get { return m_penDefinition; }
            set
            {
                m_penDefinition = value;
                foreach (cls_penDefinition tmp_penDefinition in m_penDefinition)
                {
                    tmp_penDefinition.setOwner(__owner);
                    tmp_penDefinition.setParent(this);
                }
            }
        }

        public bool Add_penDefinition(cls_penDefinition n_penDefinition)
        {
            n_penDefinition.setParent(this);
            n_penDefinition.setOwner(__owner);
            m_penDefinition.Add(n_penDefinition);
            return true;
        }

        internal override void setOwner(cls_DTTPresentation n_owner)
        {
            __owner = n_owner;
            foreach (cls_penDefinition tmp_penDefinition in m_penDefinition)
            {
                tmp_penDefinition.setOwner(__owner);
            }
        }

        public string toXML(bool neat, string binaryPath = null)
        {
            return toXML(neat, 0, binaryPath);
        }     
        
        public string toXML(bool neat, int indent, string binaryPath = null)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "";
            if (neat) output += "\n" +  pad;
            output += "<penSet";
            // attributes
            output += " name=\"" + name.ToString().Replace("\"", "&quot;") + "\"";
            output += " id=\"" + id.ToString().Replace("\"", "&quot;") + "\"";
            output += ">";
            // content
            foreach (cls_penDefinition tmp_penDefinition in m_penDefinition)
            {
                output += tmp_penDefinition.toXML(neat, indent + 1, binaryPath);
            }
            if (neat) output += "\n" + pad;
            output += "</penSet>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "penSet";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                case DTTPresentation_parser.ID_penDefinition:
                    cls_penDefinition tmp_penDefinition = new cls_penDefinition(this);
                    tmp_penDefinition.parseAttributes(atts);
                    m_penDefinition.Add(tmp_penDefinition);
                    return tmp_penDefinition;
                    //break;
                default:
                    throw new Exception("Unexpected element " + elementname + " in penSet");
                    //break;
            }
            //return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("name"))
            {
                name = atts["name"];
            }
            if (atts.ContainsKey("id"))
            {
                id = atts["id"];
            }
        }

        public override void content(string chars, int elementid)
        {
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("penSet")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-penSet
// Put code here.
//ENDUSERCODE-SECTION-endElement-penSet
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-penSet
// Put code here.
//ENDUSERCODE-SECTION-userMethods-penSet
    }
}

