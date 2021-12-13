module Index

open Fable.React
open Fable.React.Props

type Model = int

type Msg =
    | Increment
    | Decrement

let init () : Model = 0

let update (msg: Msg) (model: Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

let view (model: Model) dispatch =

    div [] [
        button [ OnClick(fun _ -> dispatch Increment) ] [
            str "+"
        ]
        div [] [ str (string model) ]
        button [ OnClick(fun _ -> dispatch Decrement) ] [
            str "-"
        ]
    ]
