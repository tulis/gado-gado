import String exposing(..)
import List exposing(..)
import Graphics.Element exposing (show)

toInteger : String -> Maybe Int
toInteger rawIntegerString =
    case String.toInt rawIntegerString of
        Ok value ->
            Just value
        Err value->
            Nothing

toMonth : String -> Maybe Int
toMonth rawMonth =
    case toInteger rawMonth of
        Nothing ->
            Nothing
        Just month ->
            if month > 0 && month <=12
                then Just month
                else Nothing

main =
    show (List.map toMonth ["4", "alice", "-5", "5.5", "100"])
