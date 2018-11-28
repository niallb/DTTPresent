/* cls_penDefinition.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-penDefinition
using System.Drawing;
//ENDUSERCODE-SECTION-extra-includes-penDefinition

namespace DesktopTeacherTools
{
    public partial class cls_penDefinition : cls_DTTPresentation_part
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string name;
        private int size;
        private penmasks mask;
        private int m_R;
        private int m_G;
        private int m_B;
        private int m_A;
        #endregion
//USERCODE-SECTION-penDefinition-uservars
// Put code here.
//ENDUSERCODE-SECTION-penDefinition-uservars

        public enum penmasks {softpen, marker, highlighter, brush, spray, airbrush };

        #region XMLpg_generated_code

        public cls_penDefinition() : this(null) { }

        public cls_penDefinition(cls_DTTPresentation_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            name = null;
        }

        public string M_name
        {
            get { return name; }
            set { name = value; }
        }

        public int M_size
        {
            get { return size; }
            set { size = value; }
        }

        public cls_penDefinition.penmasks M_mask
        {
            get { return mask; }
            set { mask = value; }
        }

        public int M_R
        {
            get { return m_R; }
            set { m_R = value; }
        }

        public int M_G
        {
            get { return m_G; }
            set { m_G = value; }
        }

        public int M_B
        {
            get { return m_B; }
            set { m_B = value; }
        }

        public int M_A
        {
            get { return m_A; }
            set { m_A = value; }
        }

        internal override void setOwner(cls_DTTPresentation n_owner)
        {
            __owner = n_owner;
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
            output += "<penDefinition";
            // attributes
            if (name != null)
                output += " name=\"" + name.ToString().Replace("\"", "&quot;") + "\"";
            output += " size=\"" + size.ToString() + "\"";
            output += " mask=\"" + mask.ToString().Replace("\"", "&quot;") + "\"";
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            output += "<R>" + m_R.ToString() + "</R>";
            if (neat) output += "\n" + pad + "    ";
            output += "<G>" + m_G.ToString() + "</G>";
            if (neat) output += "\n" + pad + "    ";
            output += "<B>" + m_B.ToString() + "</B>";
            if (neat) output += "\n" + pad + "    ";
            output += "<A>" + m_A.ToString() + "</A>";
            if (neat) output += "\n" + pad;
            output += "</penDefinition>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "penDefinition";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                default:
                    throw new Exception("Unexpected element " + elementname + " in penDefinition");
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
            else
            {
                name = null;
            }
            if (atts.ContainsKey("size"))
            {
                size = int.Parse(atts["size"]);
            }
            if (atts.ContainsKey("mask"))
            {
                mask = (penmasks)Enum.Parse(typeof(penmasks), atts["mask"]); 
            }
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case DTTPresentation_parser.ID_R:
                    m_R = int.Parse(chars);
                    break;
                case DTTPresentation_parser.ID_G:
                    m_G = int.Parse(chars);
                    break;
                case DTTPresentation_parser.ID_B:
                    m_B = int.Parse(chars);
                    break;
                case DTTPresentation_parser.ID_A:
                    m_A = int.Parse(chars);
                    break;
                }
            }
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("penDefinition")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-penDefinition
// Put code here.
//ENDUSERCODE-SECTION-endElement-penDefinition
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-penDefinition
        public cls_penDefinition(int size, Color colour, cls_penDefinition.penmasks mask) : this(null) 
        {
            M_size = size;
            m_A = colour.A;
            m_R = colour.R;
            m_G = colour.G;
            m_B = colour.B;
            M_mask = mask;         
        }

//ENDUSERCODE-SECTION-userMethods-penDefinition
    }
}

