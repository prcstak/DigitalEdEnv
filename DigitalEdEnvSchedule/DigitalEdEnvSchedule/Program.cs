using DigitalEdEnvSchedule;

Console.WriteLine("Hello, World!");

//(предмет, группа1, время1)

List<ScheduleRecord> schedule;
var r = new Random();

ScheduleRecord GenerateRecord()
{
    var lesson = Values.Lessons[r.Next(Values.Lessons.Count)];
    var group = Values.Groups[r.Next(Values.Groups.Count)];
    var room = Values.Room[r.Next(Values.Room.Count)];


    return new ScheduleRecord(lesson, group, room, r.Next(6));
}

for (int i = 0; i < 12; i++)
{
    Console.WriteLine(GenerateRecord().ToString());
}