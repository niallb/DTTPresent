/* cls_DTTPresentation_part.cs */

using System;
using System.Collections.Generic;
using System.Text;
//USERCODE-SECTION-extra-includes-DTTPresentation-part
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-DTTPresentation-part

namespace DesktopTeacherTools
{
    public abstract class cls_DTTPresentation_part
    {
        internal cls_DTTPresentation_part __parent;
        internal cls_DTTPresentation __owner;

        public cls_DTTPresentation_part getParent()
        {
            return __parent;
        }

        public cls_DTTPresentation getOwner()
        {
            return __owner;
        }

        internal void setParent(cls_DTTPresentation_part n_parent)
        {
            __parent = n_parent;
        }

        abstract internal void setOwner(cls_DTTPresentation n_owner);
        abstract public cls_DTTPresentation_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname);
        abstract public void endElement(string name, string binaryPath);
        abstract public void parseAttributes(Dictionary<string, string> atts);
        abstract public void content(string chars, int elementid);
        abstract public string getElementName();

//USERCODE-SECTION-userMethods-DTTPresentation-part
// Put code here.
//ENDUSERCODE-SECTION-userMethods-DTTPresentation-part
    }
}
