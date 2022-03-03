module  QTItoHTML.HandleQTIFreeHTML

open System.Xml
open System.Xml.Linq
open HtmlOrSvgElements
open CustomElementsAndAttributes

let rec handleQTIFreeHTML (elem: XElement) =
    if isHtmlOrSvgElement elem.Name.LocalName then
      let elementCreator = 
        Giraffe.ViewEngine.HtmlElements.tag (elem.Name.LocalName)
      let attributes =
        [for attr in elem.Attributes() ->
            let lnm = attr.Name.LocalName
            let vl = attr.Value
            Giraffe.ViewEngine.HtmlElements.attr lnm vl]
      let children =
        [for child in elem.Nodes() do
                match child with 
                | :? XElement as xelem ->
                  yield handleQTIFreeHTML xelem 
                | :? XText as xtext ->
                  yield Giraffe.ViewEngine.HtmlElements.Text(xtext.Value)
                | :? XComment | :? XProcessingInstruction -> ()
                | _ -> failwith "hen"] 
      elementCreator attributes children
    else failwith "hen"