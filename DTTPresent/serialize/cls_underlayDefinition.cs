/* cls_underlayDefinition.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-underlayDefinition
using System.Drawing;
using System.Windows.Forms;
//ENDUSERCODE-SECTION-extra-includes-underlayDefinition

namespace DesktopTeacherTools
{
    public partial class cls_underlayDefinition : cls_DTTPresentation_part
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string name = "";
        private string id = "";
        private string imagename;
        private int decadesAcross;
        private bool logAcross;
        private int decadesDown;
        private bool logDown;
        private underlayPosition position;
        #endregion
//USERCODE-SECTION-underlayDefinition-uservars
// Put code here.
//ENDUSERCODE-SECTION-underlayDefinition-uservars

        public enum underlayPosition {full, left, right, top, bottom };

        #region XMLpg_generated_code

        public cls_underlayDefinition() : this(null) { }

        public cls_underlayDefinition(cls_DTTPresentation_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            imagename = null;
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

        public string M_imagename
        {
            get { return imagename; }
            set { imagename = value; }
        }

        public int M_decadesAcross
        {
            get { return decadesAcross; }
            set { decadesAcross = value; }
        }

        public bool M_logAcross
        {
            get { return logAcross; }
            set { logAcross = value; }
        }

        public int M_decadesDown
        {
            get { return decadesDown; }
            set { decadesDown = value; }
        }

        public bool M_logDown
        {
            get { return logDown; }
            set { logDown = value; }
        }

        public cls_underlayDefinition.underlayPosition M_position
        {
            get { return position; }
            set { position = value; }
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
            output += "<underlayDefinition";
            // attributes
            output += " name=\"" + name.ToString().Replace("\"", "&quot;") + "\"";
            output += " id=\"" + id.ToString().Replace("\"", "&quot;") + "\"";
            if (imagename != null)
                output += " imagename=\"" + imagename.ToString().Replace("\"", "&quot;") + "\"";
            output += " decadesAcross=\"" + decadesAcross.ToString() + "\"";
            if (logAcross)
                output += " logAcross=\"true\"";
            else
                output += " logAcross=\"false\"";
            output += " decadesDown=\"" + decadesDown.ToString() + "\"";
            if (logDown)
                output += " logDown=\"true\"";
            else
                output += " logDown=\"false\"";
            output += " position=\"" + position.ToString().Replace("\"", "&quot;") + "\"";
            output += "/>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "underlayDefinition";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                default:
                    throw new Exception("Unexpected element " + elementname + " in underlayDefinition");
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
            if (atts.ContainsKey("imagename"))
            {
                imagename = atts["imagename"];
            }
            else
            {
                imagename = null;
            }
            if (atts.ContainsKey("decadesAcross"))
            {
                decadesAcross = int.Parse(atts["decadesAcross"]);
            }
            if ((atts["logAcross"].Equals("true", StringComparison.OrdinalIgnoreCase))
                        || (atts["logAcross"].Equals("yes", StringComparison.OrdinalIgnoreCase))
                        || (atts["logAcross"].Equals("1")))
                logAcross = true;
            else
                logAcross = false;
            if (atts.ContainsKey("decadesDown"))
            {
                decadesDown = int.Parse(atts["decadesDown"]);
            }
            if ((atts["logDown"].Equals("true", StringComparison.OrdinalIgnoreCase))
                        || (atts["logDown"].Equals("yes", StringComparison.OrdinalIgnoreCase))
                        || (atts["logDown"].Equals("1")))
                logDown = true;
            else
                logDown = false;
            if (atts.ContainsKey("position"))
            {
                position = (underlayPosition)Enum.Parse(typeof(underlayPosition), atts["position"]); 
            }
        }

        public override void content(string chars, int elementid)
        {
            // read chars into empty 
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("underlayDefinition")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-underlayDefinition
// Put code here.
//ENDUSERCODE-SECTION-endElement-underlayDefinition
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-underlayDefinition
        public cls_underlayDefinition(int decadesAcross, bool logAcross, int decadesDown, bool logDown, underlayPosition position) : this(null) 
        {
            this.decadesAcross = decadesAcross;
            this.logAcross = logAcross;
            this.decadesDown = decadesDown;
            this.logDown = logDown;
            this.position = position;
        }


//ENDUSERCODE-SECTION-userMethods-underlayDefinition
    }
}

