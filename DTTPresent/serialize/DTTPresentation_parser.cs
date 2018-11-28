/* DTTPresentation_parser.cs */

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
//USERCODE-SECTION-extra-includes-DTTPresentation-parser
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-DTTPresentation-parser

/*__source (xdef2 source used to generate code.)
#package DesktopTeacherTools

element DTTPresentation
enum pageType {slide, application, board, web}
attributes title as string, author as string
content (slide, application, board, web)* as page, penSet* as hash<penSet@id, penSet>, underlayDefinition* as hash<underlayDefinition@id, underlayDefinition>

element penSet
attributes name as string, id as string
content penDefinition*

element penDefinition
enum penmasks {softpen, marker, highlighter, brush, spray, airbrush}
attributes name? as string, size as integer, mask as penmasks
content R as integer, G as integer, B as integer, A as integer

element underlayDefinition
enum underlayPosition {full, left, right, top, bottom}
attributes name as string,  id as string, imagename? as string, decadesAcross as integer, logAcross as boolean, decadesDown as integer, logDown as boolean, position as underlayPosition

element slide extends page
enum slideLayout {centre, tc, t1, t2, t11, t21, t12, t21v, t12v, t33}
attributes layout as slideLayout, titleX as int, titleY as int, titleW as int, titleH as int, contentX as int, contentY as int, contentW as int, contentH as int, gap as int;
content background? as string, markdown as string, assest* as string

element application extends page
content appname? as string, params? as string

element board extends page
enum logopos {none, topleft, topcentre, topright, bottomleft, bottomcentre, bottomright}
attributes lpos as logopos, allowScroll as boolean
content boardColour? as string, lineColour? as string, logo? as string, underlayID? as string

element web extends page
attributes displayURL as boolean
content url as string

element page
function getUniqueID() : string
attributes uniqueID as string, title as string, penSetID as string
*/

namespace DesktopTeacherTools
{
    public class DTTPresentation_parser
    {
        public string errors { get; private set; }

        private cls_DTTPresentation the_DTTPresentation;
        private Stack<int> containerids;
        private cls_DTTPresentation_part tmpPart;
        private Dictionary<string, int> elementtable;
        private string[] idtable;

        public const int ID_DTTPresentation = 1;
        public const int ID_slide = 2;
        public const int ID_application = 3;
        public const int ID_board = 4;
        public const int ID_web = 5;
        public const int ID_page = 6;
        public const int ID_penSet = 7;
        public const int ID_underlayDefinition = 8;
        public const int ID_penDefinition = 9;
        public const int ID_R = 10;
        public const int ID_G = 11;
        public const int ID_B = 12;
        public const int ID_A = 13;
        public const int ID_background = 14;
        public const int ID_markdown = 15;
        public const int ID_assest = 16;
        public const int ID_appname = 17;
        public const int ID_params = 18;
        public const int ID_boardColour = 19;
        public const int ID_lineColour = 20;
        public const int ID_logo = 21;
        public const int ID_underlayID = 22;
        public const int ID_url = 23;

        public DTTPresentation_parser()
        {
            containerids = new Stack<int>();
            elementtable = new Dictionary<string, int>();
            elementtable.Add("DTTPresentation", ID_DTTPresentation);
            elementtable.Add("slide", ID_slide);
            elementtable.Add("application", ID_application);
            elementtable.Add("board", ID_board);
            elementtable.Add("web", ID_web);
            elementtable.Add("page", ID_page);
            elementtable.Add("penSet", ID_penSet);
            elementtable.Add("underlayDefinition", ID_underlayDefinition);
            elementtable.Add("penDefinition", ID_penDefinition);
            elementtable.Add("R", ID_R);
            elementtable.Add("G", ID_G);
            elementtable.Add("B", ID_B);
            elementtable.Add("A", ID_A);
            elementtable.Add("background", ID_background);
            elementtable.Add("markdown", ID_markdown);
            elementtable.Add("assest", ID_assest);
            elementtable.Add("appname", ID_appname);
            elementtable.Add("params", ID_params);
            elementtable.Add("boardColour", ID_boardColour);
            elementtable.Add("lineColour", ID_lineColour);
            elementtable.Add("logo", ID_logo);
            elementtable.Add("underlayID", ID_underlayID);
            elementtable.Add("url", ID_url);
            idtable = new string[elementtable.Count+1];
            foreach (KeyValuePair<string, int> entry in elementtable)
            {
                 idtable[entry.Value] = entry.Key;
            }
        }

        public int LookupElementID(string name)
        {
            if (elementtable.ContainsKey(name))
            {
                int elementid = elementtable[name];
                return elementid;
            }
            else
            {
                return 0;
            }
        }

        public string LookupElementName(int id)
        {
            if (id <= idtable.GetUpperBound(0))
            {
                string name = idtable[id];
                return name;
            }
            else
            {
                return null;
            }
        }

        public cls_DTTPresentation parseIn(string source, string binaryPath = null)
        {
            errors = "";
            XmlTextReader parser;
            string elementname;
            StringReader sr = new StringReader(source);
            parser = new XmlTextReader(sr);
            the_DTTPresentation = null;
            while (parser.Read())
            {
                switch (parser.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        break;
                    case XmlNodeType.Element:
                        elementname = parser.LocalName;
                        int elementid = LookupElementID(elementname);
                        containerids.Push(elementid);
                        Dictionary<string, string> atts2 = new Dictionary<string, string>();
                        if (parser.HasAttributes)
                        {
                            while (parser.MoveToNextAttribute())
                            {
                                atts2.Add(parser.Name, parser.Value);
                            }
                            parser.MoveToElement();
                        }
                        if (elementid == ID_DTTPresentation)
                        {
                            tmpPart = new cls_DTTPresentation();
                            tmpPart.parseAttributes(atts2);
                        }
                        else
                        {
                            if (tmpPart != null)
                            {
                                try
                                {
                                    tmpPart = tmpPart.startElement(elementid, atts2, parser.NamespaceURI, elementname);
                                }
                                catch (Exception ex)
                                {
                                    errors += ex.Message + "<br/>\n";
                                }
                            }
                        }
                        if ((parser.IsEmptyElement) && (elementname.Equals(tmpPart.getElementName())))
                        {
                            containerids.Pop();
                            tmpPart.endElement(elementname, binaryPath);
                            tmpPart = tmpPart.getParent();
                        }
                        break;
                    case XmlNodeType.EndElement:
                        containerids.Pop();
                        elementname = parser.LocalName;
                        tmpPart.endElement(elementname, binaryPath);
                        if ((tmpPart.getParent() == null) && (tmpPart.getElementName().Equals("DTTPresentation")) && (elementname.Equals(tmpPart.getElementName())))
                        {
                            the_DTTPresentation = (cls_DTTPresentation)tmpPart;
                            tmpPart = null;
                        }
                        else if (elementname.Equals(tmpPart.getElementName()))
                        {
                            tmpPart = tmpPart.getParent();
                        }
                        break;
                    case XmlNodeType.Whitespace:
                    case XmlNodeType.Text:
                        if (tmpPart != null)
                            tmpPart.content(parser.Value, containerids.Peek());
                        break;
                    default:
                        Console.Out.WriteLine("Node: " + parser.NodeType.ToString());
                        break;
                }
            }
            return the_DTTPresentation;
        }

//USERCODE-SECTION-extraMethods-DTTPresentation_parser
// Put code here.
//ENDUSERCODE-SECTION-extraMethods-DTTPresentation_parser
    }
}

