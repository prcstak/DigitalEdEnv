namespace DigitalEdEnvSchedule;

public class Schedule
{
    public List<ScheduleRecord> Records { get; set; } = new();
    public Dictionary<int, ScheduleRecord> Overlaps { get; init; } = new();
    public int Quality { get; set; }

    public Schedule()
    {
        foreach (var group in Values.Groups)
        {
            foreach (var lesson in Values.Lessons)
            {
                Records.Add(new ScheduleRecord(lesson, group));
                Records.Add(new ScheduleRecord(lesson, group));
            }
        }
        AnalyzeSchedule();
    }

    public Schedule(List<ScheduleRecord> records)
    {
        Records = records;
        AnalyzeSchedule();
    }

    public void AnalyzeSchedule()
    {
        for (int i = 0; i < Records.Count; i++)
        {
            for (int j = i + 1; j < Records.Count; j++)
            {
                if (Records[i].Group == Records[j].Group
                    && Records[i].LessonNum == Records[j].LessonNum)
                {
                    Overlaps.TryAdd(i, Records[i]);
                    Quality += 5;
                }

                if (Records[i].LessonNum == Records[j].LessonNum
                    && Records[i].Lesson == Records[j].Lesson)
                {
                    Overlaps.TryAdd(i, Records[i]);
                    Quality += 3;
                }
                
                if (Records[i].LessonNum == Records[j].LessonNum
                    && Records[i].Room == Records[j].Room)
                {
                    Overlaps.TryAdd(i, Records[i]);
                    Quality += 3;
                }
                
                if (Records[i].Group == Records[j].Group
                    && Records[i].Lesson == Records[j].Lesson
                    && Math.Abs(Records[i].LessonNum - Records[j].LessonNum) > 1)
                {
                    Overlaps.TryAdd(i, Records[i]);
                    Quality += 2;
                }
            }
        }
    }

    public Schedule Mix(Schedule rSchedule)
    {
        var r = Records;
        foreach (var (i, record) in  Overlaps)
        {
            r[i].Room = rSchedule.Records[i].Room;
            r[i].LessonNum = rSchedule.Records[i].LessonNum;
        }

        return new Schedule(r);
    }
}