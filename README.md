<h1>Runtime Model Loader System</h1>
This project includes the "Runtime Model Loader System" (RMLS) which allows the developer to load glTF 3d models from an external source it requires glTFast unity library to work and it has optional built in support for JSON using JSON.Net.

The way the Runtime Model Loader works is by defining a repository of models, the default is File System but it can also work over internet with a rest API.

The RMLS is made with consideration for flexibility. The builtin processors allows the RMLS to understand a variety of files in JSON (but easily adaptable to any other custom syntax).

<h2>Header Files</h2>
Header files offer a short info on the Model such as title and description and its interpreted using the "HeaderParserContentProcessor".

```json
{
  "title":"title example",
  "description":"description example"
}
```

<h2>Property Files</h2>
Property files when loaded will construct Unity Components on the loaded Model GameObjects their syntax (JSON) is simple.

```json
[
  {
    "type":"light",
    "properties": {
        "intensity":2,
        "color":{"r":0.3,"g":0.2,"b":0.9}
      }
  }
]
```
<h2>Scripts</h2>
A script loader exists by default but with not builtin implementation, its made with scripting in mind such as Moonsharp (lua) or MiniScript.

<h3>Loading the data</h3>
To load the data from the outside (file or internet) the "ReadContentProcessor" is required and its builtin implementation is made for the file system.
