import Html exposing (text)
import Graphics.Element exposing (show)

type Visibility = All | Active | Completed

toString : Visibility -> String
toString visibility =
    case visibility of
        All ->
            "All"
        Active ->
            "Active"
        Completed ->
            "Completed"

main =
    show [toString All, toString Active, toString Completed]

{-
    Output:
    ["All","Active","Completed"]
-}
