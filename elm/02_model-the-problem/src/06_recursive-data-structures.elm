import Html exposing (text)
import Graphics.Element exposing (show)

type LinkedList any = Empty | Node any (LinkedList any)

numbers : LinkedList Int
numbers = Node 3 (Node 2 (Node 1 Empty))

sum : LinkedList Int -> Int
sum numbers =
    case numbers of
        Empty ->
            0

        Node first rest ->
            first + sum rest

main =
    show (toString (sum numbers))

{-
    Output:
        "6"
-}
