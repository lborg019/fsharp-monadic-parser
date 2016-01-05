type Exp =
    | Num of int            //number of integers
    | Neg of  Exp            //negation
    | Sum  of Exp * Exp     //sum
    | Diff of Exp * Exp     //difference
    | Prod of Exp * Exp     //product
    | Quot of Exp * Exp;;   //quotient

let rec evaluate = function
    | Num n        -> Some n
    | Neg e        -> match evaluate e with
                      | Some(e) -> Some(-e)
                      | _ -> None
    | Sum (e1,e2)  -> match evaluate e1, evaluate e2 with
                      | Some e1, Some e2 -> Some(e1+e2)
                      | _ -> None
    | Diff(e1,e2)  -> match evaluate e1, evaluate e2 with
                      | Some e1, Some e2 -> Some(e1-e2)
                      | _ -> None
    | Prod(e1,e2)  -> match evaluate e1, evaluate e2 with
                      | Some e1, Some e2 -> Some(e1*e2)
                      | _ -> None
    | Quot(e1,e2)  -> match evaluate e1, evaluate e2 with
                      | Some e1, Some(0) -> None
                      | Some e1, Some e2 -> Some(e1/e2)
                      | _ -> None;;

(*
    For this program we notice that only one type
    yields a type int. All other operations happen on 
    an type Exp (Exp * Exp). In order to get the right
    operation, we substitute the Exp for the recursirve
    call and use the correct math operator accordingly.

    The recursive call will eventually transform the type
    Exp into an int and operate on it accordingly.

    examples:

    3 * (5 - 1):
    > evaluate(Prod(Num 3, Diff(Num 5, Num 1)));;
    val it : int = Some 12

    3 - [5 / (7 * 0)]
    > evaluate(Diff(Num 3, Quot(Num 5, Prod(Num 7, Num 0))));;
    val it : int option = None;
*)



