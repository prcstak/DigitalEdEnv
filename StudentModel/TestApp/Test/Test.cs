namespace TestApp;

public class Test
{
    public Test(List<Unit> units)
    {
        Units = units;
    }

    public List<Question> Questions { get; init; }
    public List<Unit> Units { get; init; }

    public void AddQuestion(String Text, int UnitId, List<Answer> Answers)
    {
        Questions.Add(new Question(
            Text, UnitId, Answers));
    }

}