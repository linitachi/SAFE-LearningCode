module Fuber.Routes

open Giraffe
open Saturn


type Profile = { Username: string }

let getProfile next ctx =
    let profile = { Username = "JW" }

    json profile next ctx
// next ctx //return this , pipeline will return getProfile2 result

// never run
let getProfile2 next ctx =
    let profile = { Username = "QQ" }

    json profile next ctx

let setMyHeader = setHttpHeader "myCustomHeader" "abcd"


let headerPipe =
    pipeline {
        plug setMyHeader
        plug getProfile
        plug getProfile2 // never run because getProfile get something, if getProfile return None, pipeline will continue.
    }

let apiRouter = router { get "/profile" headerPipe }

let mutable count = 0

let countController =
    controller {
        index (fun ctx -> "Hello" |> Controller.text ctx)
        show (fun ctx id -> (sprintf "Hello %i" id) |> Controller.text ctx)
    }

let router =
    router {
        forward "/api" apiRouter
        forward "/v1" countController
    }


let app =
    application {
        url "http://0.0.0.0:8080/"
        use_router router
        memory_cache
        use_static "content"
        use_gzip
    }

run app
