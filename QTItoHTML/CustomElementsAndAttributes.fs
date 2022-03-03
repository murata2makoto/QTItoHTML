﻿module QTItoHTML.CustomElementsAndAttributes

open Giraffe.ViewEngine
let svg = tag "svg"
let line = tag "line"
let ruby = tag "ruby"
let rb = tag "rb"
let rt = tag "rt"
let _aria_labelledby = attr "aria-labelledby"
let _data_eliminable  = attr "data-eliminable"
let _data_html_editable_container = attr "data-html-editable-container"
let _data_html_editable = attr "data-html-editable"
let _data_identifier = attr "data-identifier"
let _data_label = attr "data-label"
let _data_qti_class = attr "data-qti-class"
let _data_serial = attr "data_serial"
let _x1 = attr "x1"
let _x2 = attr "x2"
let _y1 = attr "y1"
let _y2 = attr "y2"