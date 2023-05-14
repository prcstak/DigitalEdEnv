module ConsoleApp1.QuestionsList

open ConsoleApp1.Entities

let question5: question =
    { text =
        @"
       Так как вы потратили много времени на задачу,
       вы не успели выполнить план на сегодня. Ваши действия?"
      answers =
        [ { text = "Уйти домой т.к. рабочий день закончился"
            statsDelta =
              { communication = 0
                fortitude = 1
                initiative = 0 } }
          { text = "Задержаться"
            statsDelta =
              { communication = 0
                fortitude = 0
                initiative = 0 } }
          { text = "Согласовать с руководителем, куда можно вставить выполнение этой задачи
            исходя из моего рабочего графика"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 0 } } 
          ] }

let question4: question =
    { text =
        @"
       Руководство утверждает, что вы 
       слишком медленно выполняете задачи"
      answers =
        [ { text = "Пообещать работать над собой"
            statsDelta =
              { communication = 0
                fortitude = 0
                initiative = 0 } }
          { text = "Объяснить почему так происходит, и попросить больше помощи\времени\обучения"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 1 } } ] }

let question3: question =
    { text =
        @"
        Из-за того вы долго разбирались с задачей,
        вы не успеваете выполнить ее в срок."
      answers =
        [ { text = "Постараюсь работать быстрее"
            statsDelta =
              { communication = 0
                fortitude = 0
                initiative = 0 } }
          { text = "Объясню ситуацию наставнику, мы вместе найдем решение"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 0 } } ] }

let question2: question =
    { text =
        @"
        Коллега\аналитик объяснил вам суть
        задачи, но вы в чем-то с ним не согласны (совместимость\
        сложность реализации и т.д.)"
      answers =
        [ { text = "Согласиться и взять задачу в разработку"
            statsDelta =
              { communication = 1
                fortitude = 0
                initiative = 0 } }
          { text = "Выразить свое мнение"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 1 } } ] }

let question1: question =
    { text =
        @"
      Вам пришла задача от аналитика.
      Вы не уверены, что поняли ее правильно.
      Ваши действия?"
      answers =
        [
          { text = "Пойду разбираться к аналитику"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 1 } }
          { text = "Обращусь к более опытному коллеге"
            statsDelta =
              { communication = 1
                fortitude = 1
                initiative = 0 } }
          { text = "Постараюсь разобраться самостоятельно"
            statsDelta =
              { communication = 0
                fortitude = 0
                initiative = 1 } } ] }
