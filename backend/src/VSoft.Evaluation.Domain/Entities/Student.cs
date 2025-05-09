using VSoft.Evaluation.Domain.ValueObjects;

namespace VSoft.Evaluation.Domain.Entities;

public class Student
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public DateOnly DateBirth { get; protected set; }
    public Cpf Cpf { get; protected set; } = string.Empty;
    public Email Email { get; protected set; } = string.Empty;
    public string Registration { get; protected set; } = string.Empty;

    public IEnumerable<Lesson> Lessons { get;  set; } 

    protected Student() { }
    public Student(string name, DateOnly dateBirth, Cpf cpf, Email email, string registration) : this()
    {
        Name = name;
        DateBirth = dateBirth;
        Cpf = cpf;
        Email = email;
        Registration = registration;
    }



    public int Progress => Lessons.Count(x => x.Concluded);
    public bool CanSchedule => Lessons.Count() < Lesson.MaximumNumberLesson;
    public bool CanLessonsPractical => Lessons.Count(x => x.Concluded) >= Lesson.MinimumNumberLesson;
}
