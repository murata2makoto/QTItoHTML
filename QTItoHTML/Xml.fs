module QTItoHTML.Xml
open System.Xml
open System.Xml.XPath
open System.IO
open System.Xml.Linq

let qtiNamespace = XNamespace.Get("http://www.imsglobal.org/xsd/imsqti_v2p2")

let loadFile (fileStream: FileStream) = 
    let doc = XDocument.Load(fileStream)
    let nav = doc.CreateNavigator()
    let manager = new XmlNamespaceManager(nav.NameTable)
    manager.AddNamespace("", "http://www.imsglobal.org/xsd/imsqti_v2p2")
    manager.AddNamespace("qtiv2p2", "http://www.imsglobal.org/xsd/imsqti_v2p2")
    manager.AddNamespace("m", "http://www.w3.org/1998/Math/MathML")
    (doc, manager)
