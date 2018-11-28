/* cls_DTTPresentation.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-DTTPresentation
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-DTTPresentation

namespace DesktopTeacherTools
{
    public partial class cls_DTTPresentation : cls_DTTPresentation_part
    {
        #region XMLpg_generated_variables

        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string title = "";
        private string author = "";
        private List<cls_page> m_page;
        private Dictionary<string, cls_penSet> m_penSet;
        private Dictionary<string, cls_underlayDefinition> m_underlayDefinition;
        #endregion
//USERCODE-SECTION-DTTPresentation-uservars
// Put code here.
//ENDUSERCODE-SECTION-DTTPresentation-uservars

        public enum pageType {slide, application, board, web };

        #region XMLpg_generated_code

        public cls_DTTPresentation() : this(null) { }

        public cls_DTTPresentation(cls_DTTPresentation_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = this;
            else
                __owner = __parent.getOwner();
            m_page = new List<cls_page>();
            m_penSet = new Dictionary<string, cls_penSet>();
            m_underlayDefinition = new Dictionary<string, cls_underlayDefinition>();
        }

        public string M_title
        {
            get { return title; }
            set { title = value; }
        }

        public string M_author
        {
            get { return author; }
            set { author = value; }
        }

        public List<cls_page> M_page
        {
            get { return m_page; }
            set
            {
                m_page = value;
                foreach (cls_page tmp_page in m_page)
                {
                    ((cls_DTTPresentation_part)tmp_page).setOwner(__owner);
                    ((cls_DTTPresentation_part)tmp_page).setParent(this);
                }
            }
        }

        public void Add_page(cls_page value)
        {
            ((cls_DTTPresentation_part)value).setOwner(__owner);
            ((cls_DTTPresentation_part)value).setParent(this);
            m_page.Add(value);
        }

        public Dictionary<string, cls_penSet> M_penSet
        {
            get { return m_penSet; }
            set
            {
                m_penSet = value;
                foreach (KeyValuePair<string, cls_penSet> tmp_penSet in m_penSet)
                {
                    tmp_penSet.Value.setOwner(__owner);
                    tmp_penSet.Value.setParent(this);
                }
            }
        }

        public bool Add_penSet(cls_penSet n_penSet)
        {
            n_penSet.setParent(this);
            n_penSet.setOwner(__owner);
            m_penSet.Add(n_penSet.M_id, n_penSet);
            return true;
        }

        public cls_penSet get_penSet(string penSet_id)
        {
            return m_penSet[penSet_id];
        }

        public Dictionary<string, cls_underlayDefinition> M_underlayDefinition
        {
            get { return m_underlayDefinition; }
            set
            {
                m_underlayDefinition = value;
                foreach (KeyValuePair<string, cls_underlayDefinition> tmp_underlayDefinition in m_underlayDefinition)
                {
                    tmp_underlayDefinition.Value.setOwner(__owner);
                    tmp_underlayDefinition.Value.setParent(this);
                }
            }
        }

        public bool Add_underlayDefinition(cls_underlayDefinition n_underlayDefinition)
        {
            n_underlayDefinition.setParent(this);
            n_underlayDefinition.setOwner(__owner);
            m_underlayDefinition.Add(n_underlayDefinition.M_id, n_underlayDefinition);
            return true;
        }

        public cls_underlayDefinition get_underlayDefinition(string underlayDefinition_id)
        {
            return m_underlayDefinition[underlayDefinition_id];
        }

        internal override void setOwner(cls_DTTPresentation n_owner)
        {
            __owner = n_owner;
            foreach (KeyValuePair<string, cls_penSet> tmp_penSet in m_penSet)
            {
                tmp_penSet.Value.setOwner(__owner);
            }
            foreach (KeyValuePair<string, cls_underlayDefinition> tmp_underlayDefinition in m_underlayDefinition)
            {
                tmp_underlayDefinition.Value.setOwner(__owner);
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
            string output = "<?xml version=\"1.0\"?>";
            if (neat) output += "\n" +  pad;
            output += "<DTTPresentation";
            // attributes
            output += " title=\"" + title.ToString().Replace("\"", "&quot;") + "\"";
            output += " author=\"" + author.ToString().Replace("\"", "&quot;") + "\"";
            output += ">";
            // content
            foreach (cls_page tmp_page in m_page)
            {
                output += tmp_page.toXML(neat, indent + 1, binaryPath);
            }
            foreach (cls_penSet tmp_penSet in m_penSet.Values)
            {
                output += tmp_penSet.toXML(neat, indent + 1, binaryPath);
            }
            foreach (cls_underlayDefinition tmp_underlayDefinition in m_underlayDefinition.Values)
            {
                output += tmp_underlayDefinition.toXML(neat, indent + 1, binaryPath);
            }
            if (neat) output += "\n" + pad;
            output += "</DTTPresentation>";
            if(binaryPath != null)
                saveBinaryData(binaryPath);
            return output;
        }

        public override string getElementName()
        {
            return "DTTPresentation";
        }

        public override cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
            switch (elementid)
            {
                case DTTPresentation_parser.ID_slide:
                    cls_slide tmp_slide = new cls_slide(this);
                    tmp_slide.parseAttributes(atts);
                    m_page.Add(tmp_slide);
                    return tmp_slide;
                    //break;
                case DTTPresentation_parser.ID_application:
                    cls_application tmp_application = new cls_application(this);
                    tmp_application.parseAttributes(atts);
                    m_page.Add(tmp_application);
                    return tmp_application;
                    //break;
                case DTTPresentation_parser.ID_board:
                    cls_board tmp_board = new cls_board(this);
                    tmp_board.parseAttributes(atts);
                    m_page.Add(tmp_board);
                    return tmp_board;
                    //break;
                case DTTPresentation_parser.ID_web:
                    cls_web tmp_web = new cls_web(this);
                    tmp_web.parseAttributes(atts);
                    m_page.Add(tmp_web);
                    return tmp_web;
                    //break;
                case DTTPresentation_parser.ID_penSet:
                    cls_penSet tmp_penSet = new cls_penSet(this);
                    tmp_penSet.parseAttributes(atts);
                    m_penSet.Add(tmp_penSet.M_id, tmp_penSet);
                    return tmp_penSet;
                    //break;
                case DTTPresentation_parser.ID_underlayDefinition:
                    cls_underlayDefinition tmp_underlayDefinition = new cls_underlayDefinition(this);
                    tmp_underlayDefinition.parseAttributes(atts);
                    m_underlayDefinition.Add(tmp_underlayDefinition.M_id, tmp_underlayDefinition);
                    return tmp_underlayDefinition;
                    //break;
                default:
                    throw new Exception("Unexpected element " + elementname + " in DTTPresentation");
                    //break;
            }
            //return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("title"))
            {
                title = atts["title"];
            }
            if (atts.ContainsKey("author"))
            {
                author = atts["author"];
            }
        }

        public override void content(string chars, int elementid)
        {
        }

        public override void endElement(string name, string binaryPath)
        {
            if((binaryPath != null) && (name.Equals("DTTPresentation")))
                loadBinaryData(binaryPath);
//USERCODE-SECTION-endElement-DTTPresentation
// Put code here.
//ENDUSERCODE-SECTION-endElement-DTTPresentation
        }
        #endregion

        partial void saveBinaryData(string binaryPath);
        partial void loadBinaryData(string binaryPath);

//USERCODE-SECTION-userMethods-DTTPresentation
// Put code here.
//ENDUSERCODE-SECTION-userMethods-DTTPresentation
    }
}

