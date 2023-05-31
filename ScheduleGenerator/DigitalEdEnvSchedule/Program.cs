using DigitalEdEnvSchedule;

var schedule = new Schedule();
var iteration = 0;

while (schedule.Quality > 2)
{
    var r = schedule.Mix(new Schedule());
    if (r.Quality < schedule.Quality)
    {
        schedule = r;
    }

    if (iteration == 1000)
    {
        schedule = new Schedule();
        iteration = 0;
    }

    iteration++;
}

schedule.Records.Sort((a,b) => a.LessonNum.CompareTo( b.LessonNum));

foreach (var record in schedule.Records)
{
    Console.WriteLine($"{record.LessonNum + 1} {record.Lesson} {record.Room} {record.Group}");
}

Console.WriteLine(iteration);
