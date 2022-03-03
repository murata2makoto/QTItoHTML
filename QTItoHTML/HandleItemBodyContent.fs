module  QTItoHTML.HandleItemBodyContent

open System.Xml
open System.Xml.Linq
open HtmlOrSvgElements
open CustomElementsAndAttributes
open HandleChoiceInteraction

let rec handleItemBodyContent (elem: XElement) (mng: XmlNamespaceManager) =
    match elem.Name.LocalName with 
    | localName when isHtmlOrSvgElement localName ->
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
                  yield handleItemBodyContent xelem mng
                | :? XText as xtext ->
                  yield Giraffe.ViewEngine.HtmlElements.Text(xtext.Value)
                | :? XComment | :? XProcessingInstruction -> ()
                | _ -> failwith "hen"] 
      elementCreator attributes children
    | "choiceInteraction" ->
      handleChoiceInteraction elem mng
    | _ -> failwith "hen"