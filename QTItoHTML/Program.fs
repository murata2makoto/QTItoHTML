// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open QTItoHTML.Xml
open QTItoHTML.HandleAssessmentItem

[<EntryPoint>]
let main argv =
    let inFileName = argv.[0]
    let outFileName = argv.[1]
    use inFileStream = new FileStream(inFileName, FileMode.Open)
    use outFileStream = new FileStream(outFileName, FileMode.Create)
    use streamWriter = new StreamWriter(outFileStream)
    let (doc, man) = loadFile inFileStream
    let htmlDiv = 
        handleAssementItem doc man 
        |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
    fprintfn streamWriter "%s" htmlDiv 
    0 // return an integer exit code