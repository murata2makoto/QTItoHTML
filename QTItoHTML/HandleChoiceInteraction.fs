module QTItoHTML.HandleChoiceInteraction
open System.Xml
open System.Xml.Linq
open System.Xml.XPath
open Giraffe.ViewEngine
open HtmlOrSvgElements
open CustomElementsAndAttributes
open HandleQTIFreeHTML


let createLiFromSimpleChoice (simpleChoice: XElement) (mng: XmlNamespaceManager) =
    let simpleChoiceID = simpleChoice.Attribute(XNamespace.None + "identifier").Value
    let simpleChoiceValue = simpleChoice.Value
    
    let simpleChoiceID = System.Guid.NewGuid().ToString("N").Substring(0, 13);

    li [_class "qti-choice qti-simpleChoice"
        _data_identifier simpleChoiceValue
        _data_serial simpleChoiceID]
       [div [_class "pseudo-label-box"]
            [label [_class "real-label"]
                   [input [_type "checkbox" 
                           _name ("response-" + simpleChoiceID)
                           _value simpleChoiceValue
                           _tabindex "1"];
                    span [_class "icon-checkbox"] []];
             div [_class "label-box"]
                 [div [_class "label-content clear" 
                       _contenteditable "false"
                       _id ("choice-" + simpleChoiceValue)]
                      [div [_class "qti-block"] 
                           [Giraffe.ViewEngine.HtmlElements.Text(simpleChoiceValue)];
                  svg [_class "overlay-answer-eliminator"]
                      [line [_x1 "0"; _y1 "100%"; _x2 "100%"; _y2 "0"] [];
                       line [_x1 "0"; _y1 "0"; _x2 "100%"; _y2 "100%"] []]]]];
          label [_data_eliminable "container"; _data_label "Eliminate"]
                [span [_data_eliminable"trigger"; _class "icon-checkbox"] []]];;

    
let handleChoiceInteraction (elem: System.Xml.Linq.XElement) (mng: XmlNamespaceManager): 
        Giraffe.ViewEngine.HtmlElements.XmlNode =
        
    let choiceInteractionID = System.Guid.NewGuid().ToString("N").Substring(0, 19);
    div [_class "qti-interaction qti-blockInteraction qti-choiceInteraction";
         _data_serial "i621fe4a4584c6"; //この値はなんだか分からない
         _data_qti_class "choiceInteraction"]
        [div [_class "qti-prompt-container";
              _data_html_editable_container ""]
             [div [_class "qti-prompt";
                   _data_serial ("prompt_" + choiceInteractionID);
                   _data_html_editable "";
                   _id ("prompt-prompt_" + choiceInteractionID)
                  ]
                  [for child in elem.XPathSelectElements("./qtiv2p2:prompt/*", mng)
                    -> handleQTIFreeHTML child]];
         div [_class "instruction-container"] [];
         ol [_class "plain block-listing solid choice-area";
             _aria_labelledby ("prompt-prompt_" + choiceInteractionID)] 
            [for simpleChoice in elem.XPathSelectElements("./qtiv2p2:simpleChoice", mng) ->
                createLiFromSimpleChoice simpleChoice mng];
         div [_class "notification-container"] []];