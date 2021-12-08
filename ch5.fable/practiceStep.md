# Fable Practice

## Environment install

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* [NPM](https://www.npmjs.com/get-npm)

## 1. Install dependencies and start

- Open cmd on the `practice` folder.
- Run the following command:

- Installs the .NET local tools that are in scope for the current directory.

```powershell
dotnet tool restore
```
- Install JS dependencies

```powershell
npm install
```

- Run the app

```powershell
dotnet fable watch src --run webpack-dev-server
```

## Install the validator(npm package)
https://www.npmjs.com/package/validator

- Using `npm` install the `validator` package 

```powershell
npm i validator
```

## Import package

Javascript import like this

```javascript
import validator from 'validator';
```

When we using `Fable`:

```Fsharp
open Fable.Core.JsInterop
let validator : obj = importDefault "validator"
```

## Dynamically accessing properties

`validator` has a lot of methods that can determine if a string is in a certain format:
- isEmail
- isAlphanumeric
- isCreditCard
- isDivisibleBy
- isPassportNumber...

We can use `?` operator to access propertiy of obj.
```
obj?prop(string)
```

Just like:

```
validator?isEmail("123")
```

but it is on an object unsafely. This can result in runtime error if that propertiy does not exist.

## Type safety

We can use an interface to get safety.

1. Declare an interface type called `Validator`.

```fsharp
type Validator
```

2. and it will need an `abstract` member called `isEmail` that is a function of type `string -> bool` .

```fsharp
type Validator =
    abstract member isEmail: string -> bool
```

3. Use the new type Validator to replace obj on `let validator: obj` .

```diff
--  let validator: obj = importDefault "validator"
++  let validator: Validator = importDefault "validator"
```

4. Replace `?` and use `.` notation instead.

```diff
--validator?isEmail("123")
++validator.isEmail("123")
```
