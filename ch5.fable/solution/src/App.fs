module App

open Browser.Dom
open Fable.Core.JsInterop

// Mutable variable to count the number of times we clicked the button
let mutable count = 0

let validator: obj = importDefault "validator"

printfn "%A" (validator?isEmail ("123"))

type Validator =
    abstract member isEmail : string -> bool

let validator2: Validator = importDefault "validator"

printfn "%A" (validator2.isEmail ("123"))
// Get a reference to our button and cast the Element to an HTMLButtonElement
let myButton =
    document.querySelector (".my-button") :?> Browser.Types.HTMLButtonElement

// Register our listener
myButton.onclick <-
    fun _ ->
        count <- count + 1
        myButton.innerText <- sprintf "You clicked: %i time(s)" count
