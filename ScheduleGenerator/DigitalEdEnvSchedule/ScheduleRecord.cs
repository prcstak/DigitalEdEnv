namespace DigitalEdEnvSchedule;

public class ScheduleRecord
{
    
    public ScheduleRecord(String lesson, String group)
    {

        var r = new Random();
        var room = Values.Room[r.Next(Values.Room.Count)];
        var lessonNum = r.Next(6);

        this.Lesson = lesson;
        this.Group = group;
        this.Room = room;
        this.LessonNum = lessonNum;
    }
    
    public ScheduleRecord(String Lesson, String Group, int Room, int LessonNum)
    {
        this.Lesson = Lesson;
        this.Group = Group;
        this.Room = Room;
        this.LessonNum = LessonNum;
    }

    public String Lesson { get; set; }
    public String Group { get; set; }
    public int Room { get; set; }
    public int LessonNum { get; set; }

    public void Deconstruct(out String Lesson, out String Group, out int Room, out int LessonNum)
    {
        Lesson = this.Lesson;
        Group = this.Group;
        Room = this.Room;
        LessonNum = this.LessonNum;
    }
    
    
}