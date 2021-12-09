module Feliz.ReactSpeedometer

open Feliz
open Fable.Core.JsInterop

let reactSpeedometer: obj = importDefault "react-d3-speedometer"

type CustomSegmentLabelPosition =
    | Outside
    | Inside
    static member toJSValue =
        function
        | Outside -> "OUTSIDE"
        | Inside -> "INSIDE"

type CustomSegmentLabel =
    { Text: string
      Position: CustomSegmentLabelPosition
      FontSize: string
      Color: string }

    // new code to add below
    static member toJSObj customLabel =
        {| text = customLabel.Text
           position =
            customLabel.Position
            |> CustomSegmentLabelPosition.toJSValue
           fontSize = customLabel.FontSize
           color = customLabel.Color |}

type ReactSpeedometer =

    static member inline Value(number: int) = "value" ==> number
    static member inline MinValue(number: int) = "minValue" ==> number
    static member inline MaxValue(number: int) = "maxValue" ==> number
    static member inline Segments(number: int) = "segments" ==> number

    static member inline CustomSegmentLabels(customSegmentLabels: CustomSegmentLabel []) =
        let jsCustomSegmentLabels =
            customSegmentLabels
            |> Array.map CustomSegmentLabel.toJSObj

        "customSegmentLabels" ==> jsCustomSegmentLabels

    static member inline create props =
        Interop.reactApi.createElement (reactSpeedometer, createObj !!props)
