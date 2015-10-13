import Html exposing (text)
import Graphics.Element exposing (show)

fortyTwo : Int
fortyTwo =
    42

names : List String
names = ["Alice", "Bob", "Charlie", "Dave", "Eve", "Frank"]

emptyName : List String
emptyName = []

firstName : List String -> String
firstName names =
    case List.head names of
        Just name -> name
        Nothing -> "--No Name--"


book : {title: String, author: String, pages: Int}
book =
    {title = "C# in nutshell", author = "Joe Albahari", pages = 1000}

main =
    show (List.append [toString fortyTwo, firstName names, firstName emptyName, toString book] names)

{-
    Output:

    ["42","Alice","--No Name--","{ author = \"Joe Albahari\", pages = 1000, title = \"C# in nutshell\" }","Alice","Bob","Charlie","Dave","Eve","Frank"]
-}
