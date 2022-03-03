module QTItoHTML.HandleAssessmentItem

open System.Xml
open System.Xml.Linq
open System.Xml.XPath
open Giraffe.ViewEngine
open HtmlOrSvgElements
open CustomElementsAndAttributes
open HandleChoiceInteraction
open HandleItemBodyContent

let handleAssementItem (doc: XDocument) (mng: XmlNamespaceManager): Giraffe.ViewEngine.HtmlElements.XmlNode =
    div [_class "qti-item tao-scope runtime" 
         _data_serial "i621fe4a458120"
         _data_identifier "i1563354164228217055" 
         _lang "en-US"]
        [div [_class "qti-itemBody"; _dir "ltr"]
             [ for child in doc.XPathSelectElements(".//qtiv2p2:itemBody/*",mng) ->
                 handleItemBodyContent child mng]
         div [_id "modalFeedbacks"] []]
