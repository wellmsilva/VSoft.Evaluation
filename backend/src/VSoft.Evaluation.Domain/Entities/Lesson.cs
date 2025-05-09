namespace VSoft.Evaluation.Domain.Entities;

public class Lesson
{
    public const int MaximumNumberLesson = 10;
    public const int MinimumNumberLesson = 8;

    protected Lesson() { }

    public Lesson(Guid studentId,int number, DateOnly date, TimeOnly hour):this()
    {
        StudentId = studentId;
        Number = number;
        Date = date;
        Hour = hour;
    }

    public Guid Id { get; set; }
    public Guid StudentId { get; init; }
    public int Number { get; init; }
    public DateOnly Date { get; init; }
    public TimeOnly Hour { get; init; }
    public bool Concluded { get; private set; }

    public Student? Student { get; protected set; }

    public void Conclude()
    {
        Concluded = true;
    }



}
