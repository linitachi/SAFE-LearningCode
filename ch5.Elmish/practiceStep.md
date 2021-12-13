# Elmish Practice

## Environment install

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* [NPM](https://www.npmjs.com/get-npm)

## pre-requisites

* Open cmd on the `practice` folder.

* Run the following command:

* Installs the .NET local tools that are in scope for the current directory.

```powershell
dotnet tool restore
```

* Run the app

```powershell
dotnet run
```

## Add Reset button to app

Our target is adding reset button to counter app, all code change on Client/index.fs

1. Add Reset to Msg type.

    ```fsharp
    type Msg =
        | Increment
        | Decrement
        | Reset
    ```

2. Add Reset condition to update method

    ```fsharp
    let update (msg: Msg) (model: Model) =
        match msg with
        | Increment -> model + 1
        | Decrement -> model - 1
        | Reset -> 0
    ```

3. Add Button to view method and

    ```fsharp
    let view (model: Model) dispatch =
    div [] [
        button [ OnClick(fun _ -> dispatch Increment) ] [
            str "+"
        ]
        div [] [ str (string model) ]
        button [ OnClick(fun _ -> dispatch Decrement) ] [
            str "-"
        ]
        button [ OnClick(fun _ -> dispatch Reset) ] [
            str "Reset"
        ]
    ]
    ```

## References

* <https://thesharperdev.com/getting-started-with-elmish/>
* <https://www.compositional-it.com/news-blog/ui-programming-with-elmish-in-f/>
