module ConsoleApp1.Utils

open ConsoleApp1.Entities

let (|Int|_|) (str: string) =
    match System.Int32.TryParse(str) with
    | (true, parsedInt) -> Some parsedInt
    | _ -> None
    
let (++) (current: stats) (delta: stats) =
        { communication = current.communication + delta.communication
          fortitude = current.fortitude + delta.fortitude
          initiative = current.initiative + delta.initiative }
