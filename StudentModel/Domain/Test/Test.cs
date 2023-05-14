namespace TestApp;

public class Test
{
    private readonly Dictionary<int, int> _unitToQuestion = new();
    public List<Question> Questions { get; init; }
    public List<Unit> Units { get; init; }

    public Dictionary<int, int> UnitToQuestion
    {
        get => _unitToQuestion;
        init => _unitToQuestion = value;
    }

    public Test(List<Unit> units, List<Question> questions)
    {
        Units = units;
        Questions = questions;
        units.ForEach(unit => { UnitToQuestion.Add(unit.Id, 0); });
        questions.ForEach(q => q.UnitIds.ForEach(id => _unitToQuestion[id]++));
    }
}