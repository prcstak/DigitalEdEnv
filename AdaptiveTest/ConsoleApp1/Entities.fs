module ConsoleApp1.Entities

type stats = {
        communication: int
        fortitude: int
        initiative: int
    }

type answer = {
        text: string
        statsDelta: stats
    }

and question = {
          text: string
          answers: List<answer>
     }


