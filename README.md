# fsharp-monadic-parser
Simple monadic parser for mathematical expressions
###How to compile it?
Paste the code and run it in [Visual Studio's F# Interactive](https://msdn.microsoft.com/en-us/library/dd233175.aspx) or [SublimeText's REPL](https://github.com/wuub/SublimeREPL)
###How to run it?
I put some examples in the code's comments, it works the following way:

3 * (5 - 1) = 12
> evaluate(Prod(Num 3, Diff(Num 5, Num 1)));; <br/>
val it : int = Some 12


3 - [5 / (7 * 0)] = Undefined, can't divide by 0
> evaluate(Diff(Num 3, Quot(Num 5, Prod(Num 7, Num 0))));;<br/>
val it : int option = None;
