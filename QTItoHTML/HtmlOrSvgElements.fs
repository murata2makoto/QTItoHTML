﻿module QTItoHTML.HtmlOrSvgElements

let isHtmlOrSvgElement localName = 
  let htmlTagNames = 
    ["a"; "abbr"; "address"; "area"; "article"; "aside"; "audio"; 
    "b"; "base"; "bdi"; "bdo"; "blockquote"; "body"; "br"; "button"; 
    "canvas"; "caption"; "cite"; "code"; "col"; "colgroup"; "data"; 
    "datalist"; "dd"; "del"; "details"; "dfn"; "dialog"; "div"; "dl"; 
    "dt"; "em"; "embed"; "fieldset"; "figcaption"; "figure"; 
    "footer"; "form"; "h1"; "h2"; "h3"; "h4"; "h5"; "h6"; 
    "head"; "header"; "hgroup"; "hr"; "i"; "iframe"; "img"; 
    "input"; "ins"; "kbd"; "label"; "legend"; "li"; "link"; "main"; 
    "map"; "mark"; "menu"; "menuitem"; "meta"; "meter"; "nav"; 
    "noscript"; "object"; "ol"; "optgroup"; "option"; "output"; 
    "p"; "param"; "picture"; "pre"; "progress"; "q"; "rp"; "rt"; 
    "rtc"; "ruby"; "s"; "samp"; "script"; "section"; "select"; 
    "slot"; "small"; "source"; "span"; "strong"; "style"; "sub"; 
    "summary"; "sup"; "table"; "tbody"; "td"; "template"; "textarea"; 
    "tfoot"; "th"; "thead"; "time"; "title"; "tr"; "track"; 
    "u"; "ul"; "var"; "video"; "wbr"; "rb"; "rt"]
  let svgTagNames = ["svg"; "line"]
  List.contains localName htmlTagNames || 
  List.contains localName svgTagNames