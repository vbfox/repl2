(**
Minimal application showing how to use Elmish
You can find more info about Emish architecture and samples at https://elmish.github.io/
NOTE: The API in Fable's REPL may differ from Fable.Elmish & Fable.React nuget libraries.
        The generated JS code won't be as optimized as when using dotnet-fable.
*)

open Fable.Repl.Lib
open Elmish
open React
open React.Props
open Fable.Core.JsInterop

// MODEL

type Model =
    { Value : string }

type Msg =
    | ChangeValue of string

let init () = { Value = "" }, Cmd.none

// UPDATE

let update (msg:Msg) (model:Model) =
    match msg with
    | ChangeValue newValue ->
        { Value = newValue }, Cmd.none

// VIEW (rendered with React)

let view model dispatch =
    div [ Class "main-container" ]
        [ input [ Class "input"
                  Value model.Value
                  OnChange (fun ev -> ev.target?value |> string |> ChangeValue |> dispatch) ]
          span [ ]
            [ str "Hello, "
              str model.Value
              str "!" ] ]

// App
Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.run
