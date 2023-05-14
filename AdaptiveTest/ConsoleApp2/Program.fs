namespace ConsoleApp1

open System
open ConsoleApp1.Entities
open ConsoleApp1.Test
open ConsoleApp1.Utils
open ConsoleApp1.QuestionsList
open ConsoleApp1.Results

module Main =

    let rec readAnswer (answers: List<answer>) =
        let num = Console.ReadKey().KeyChar
        printfn ""
        match $"{num}" with
        | Int result when result <= answers.Length -> result - 1
        | _ ->
            printf "\b \b"
            readAnswer answers

    let ask (question: question) (test: testState) =

        printfn $"{question.text}"
        printfn ""
        
        question.answers
        |> List.mapi (fun i element -> printfn $"{i + 1}. {element.text}")
        |> ignore
        printfn ""
        
        printf "Введите номер ответа: "
        let answer = readAnswer question.answers
        
        { user = test.user ++ question.answers[answer].statsDelta
          answer = answer }
        
    let getLucky ( stats : stats ) q1 q2 ( coeff : double ) =
        let lucky = Random().NextDouble()
        printf $"{lucky}"
        match ( lucky < coeff ) with
        | true -> q1
        | _ -> q2
    


    [<EntryPoint>]
    let main argv =
        let test =
            { user =
                { communication = 0
                  fortitude = 0
                  initiative = 0 }
              answer = 0 }
        
        let testState = ask question1 test
        if
            testState.answer = 0 || testState.answer = 1
        then
            let testState = ask question2 testState
            if testState.answer = 0
            then
                let statSum = testState.user.communication + testState.user.fortitude + testState.user.initiative
                let coef =
                    match statSum with
                    | 4 -> 0.7
                    | 3 -> 0.5
                    | _ -> failwith "todo"
                printf $"{coef}"
                let result = getLucky testState.user result1 result2 coef
                printfn $"{testState.user} \n {result}"
            if testState.answer = 1
            then
                printfn $"{testState.user} \n {result3}"
        
        if testState.answer = 2
        then
            let testState = ask question3 testState
            let coef = match testState.answer with
                        | 0 -> 0.2
                        | 1 -> 0.6
                        | _ -> failwith "todo"
            let result = getLucky testState.user question5 question4 coef
            if result = question5
            then
                let testState = ask question5 testState
                match testState.answer with
                | 0 -> printf $"{testState.user} \n {result7}"
                | 1 -> printf $"{testState.user} \n {result6}"
                | 2 -> printf $"{testState.user} \n {result5}"
                | _ -> failwith "todo"
            if result = question4
            then
                let testState = ask question4 testState
                if testState.answer = 0 
                then
                    let testState = ask question5 testState
                    match testState.answer with
                    | 0 -> printf $"{testState.user} \n {result7}"
                    | 1 -> printf $"{testState.user} \n {result6}"
                    | 2 -> printf $"{testState.user} \n {result5}"
                    | _ -> failwith "todo"
                if testState.answer = 1
                then
                     printf $"{testState.user} \n {result4}"
        
        
        0