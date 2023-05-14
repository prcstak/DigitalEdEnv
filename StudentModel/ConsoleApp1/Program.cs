using System.Drawing;
using System.Net;
using System.Text.Json;
using TestApp;

var units = new List<Unit>()
{
    new(1, "Австралия"),
    new(2, "Ирак"),
    new(3, "Лихтенштейн"),
    new(4, "Сенегал"),
    new(5, "ЮАР"),
};

var questions = new List<Question>()
{
    new(
        "Административная столица ЮАР?",
        new List<int>() {5},
        new List<Answer>()
        {
            new("Кейптаун"),
            new("Претория", true),
            new("Порт-Элизабет"),
            new("Айэм"),
        }
    ),
    new(
        "Столица Австралии?",
        new List<int>() {1},
        new List<Answer>()
        {
            new("Канберра", true),
            new("Сидней"),
            new("Мельбурн"),
            new("Дарвин"),
        }
    ),
    new(
        "Столица Сенегала?",
        new List<int>() {4},
        new List<Answer>()
        {
            new("Амкал"),
            new("Бегал"),
            new("Виндхук"),
            new("Дакар", true),
        }
    ),
    new(
        "Столица Лихтенштейна?",
        new List<int>() {3},
        new List<Answer>()
        {
            new("Бабац"),
            new("Труцуц"),
            new("Вадуц", true),
            new("Лихтенштейн"),
        }
    ),
    new(
        "Столица Ирака?",
        new List<int>() {2},
        new List<Answer>()
        {
            new("Кабул"),
            new("Бейрут"),
            new("Багдад", true),
            new("Тегерак"),
        }
    ),
    new(
        "Какая страна расположена южнее?",
        new List<int>() {2, 4},
        new List<Answer>()
        {
            new("Ирак"),
            new("Сенегал", true),
        }
    ),
    new(
        "Какая страна расположена западнее?",
        new List<int>() {2, 5},
        new List<Answer>()
        {
            new("ЮАР"),
            new("Лихтенштейн", true),
        }
    ),
};


var test = new Test(
    units,
    questions
);

Console.Write("Ваше имя: ");
var user = new Student(Console.ReadLine() ?? $"User{new Guid()}", new Rating(), new Dictionary<int, Rating>());

test.Units.ForEach(unit => { user.Progress.Add(unit.Id, new Rating()); });

foreach (var question in test.Questions)
{
    Console.WriteLine($"\t{question.Text}\n");

    var i = 1;
    question.Answers.ForEach(ans => { Console.WriteLine($"{i++}. {ans.Text}"); });

    Console.Write("Ваш ответ:  ");
    var result = false;
    var answer = 0;
    while (!result )
    {
        Console.Write("\b \b");
        var key = Console.ReadKey().KeyChar.ToString();
        result = int.TryParse(key, out answer);
        result = result ? answer > 0 && answer <= question.Answers.Count : result;
    }
    Console.WriteLine();
    if (result && question.Answers[answer - 1].IsCorrect)
    {
        question.UnitIds.ForEach(id => { user.Progress[id].Value += 1; });
    }
}


Console.WriteLine("\n");
foreach (var (unitId, rating) in user.Progress)
{
    Console.WriteLine($"[{rating.Value}/{test.UnitToQuestion[unitId]}] - {units[unitId - 1].Title}");
}

var path = Path.Combine(Environment.CurrentDirectory, "Students.json");

var aStudents = File.Exists(path) 
    ? JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(path)) 
    : new List<Student>();

aStudents?.Add(user);

Console.WriteLine("\n");
if (aStudents != null)
{
    foreach (var student in aStudents)
    {
        foreach (var (unitId, rating) in student.Progress)
        {
            if (rating.Value == 0)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (rating.Value < test.UnitToQuestion[unitId])
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[\u25A0]");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" - {student.Name}");
    }

    var newJson = JsonSerializer.Serialize(aStudents);
    File.WriteAllText(path, newJson);
}