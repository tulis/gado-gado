import Html exposing (text)
import Graphics.Element exposing (show)

type alias UserName = String
type User = Anonymous | LoggedIn UserName
type alias Path = String

userPhoto : User -> Path
userPhoto user =
    case user of
        Anonymous ->
            "anon.png"
        LoggedIn userName ->
            "users/" ++ userName ++ "/photo.png"

activeUsers : List User
activeUsers = [Anonymous, LoggedIn "Alice", LoggedIn "Bob", Anonymous]

userPhotoPaths = List.map userPhoto activeUsers

main =
    show userPhotoPaths


{-
    Output:
    photoPaths : List Path
    photoPaths = ["anon.png", "users/Alice/photo.png", "users/Bob/photo.png"]
-}
