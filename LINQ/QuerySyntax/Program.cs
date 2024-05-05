using Microsoft.VisualBasic;

namespace QuerySyntax;

/// <summary>
/// LINQ (Language Integrated Query) is a Microsoft programming model that adds native data querying capabilities to .NET languages.
/// LINQ query syntax allows you to write your queries in a declarative manner, similar to SQL.
/// It consists of a combination of clauses like from, where, select, group, into, orderby etc.
/// Each clause in LINQ query performs a specific function and can be combined to write complex queries.
/// </summary>

abstract class Person
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value ?? throw new Exception("Name cannot be null"); }
    }

    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value == null)
            {
                throw new Exception("Age cannot be null");
            }
            else
            {
                age = value;
            }
        }
    }

    protected Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void Intoduce();
}

class Student : Person
{
    public string Subject { get; set; }
    public int Grade { get; set; }
    public Student(string name, int age, string subject, int grade) : base(name, age)
    {
        Subject = subject;
        Grade = grade;
    }

    public override void Intoduce()
    {
        Console.WriteLine($"I am a student,{Name} and {Age} years old, studying {Subject}, with grade {Grade}");
    }
}

class Program
{

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student("John", 19, "Maths", 43),
            new Student("Jane", 22, "English", 90),
            new Student("Bob", 21, "Science", 78),
            new Student("Alice", 23, "History", 92),
            new Student("Tom", 20, "Geography", 88),
            new Student("Emma", 22, "Biology", 95),
            new Student("Lucas", 21, "Physics", 80),
            new Student("Olivia", 23, "Chemistry", 89),
            new Student("Charlie", 20, "Maths", 35),
            new Student("Sophia", 22, "English", 40),
            new Student("Mason", 21, "Science", 50),
            new Student("Mia", 23, "History", 45),
            new Student("Liam", 20, "Geography", 55),
            new Student("Isabella", 22, "Biology", 60),
            new Student("Noah", 21, "Physics", 65),
            new Student("Ava", 23, "Chemistry", 70),
        };


        IEnumerable<Student> passingStudents =  GetPassingStudents(students);
        Console.WriteLine("-----Passing Students-----");
        
        foreach(var student in passingStudents)
        {
            student.Intoduce();
        }

        IEnumerable<Student> failingStudents = GetFailingStudents(students);
        Console.WriteLine("-----Failing Students-----");
        foreach(var student in failingStudents)
        {
            student.Intoduce();
        }

        IEnumerable<Student> orderedStudent = OrderStudentsByNameAndAge(students);
        Console.WriteLine("-----Ordered Students-----");
        foreach(var student in orderedStudent)
        {
            student.Intoduce();
        }
    }

    public static IEnumerable<Student> GetPassingStudents(List<Student> students)
    {
        return from student in students where student.Grade > 80 select student;
    }

    public static IEnumerable<Student> GetFailingStudents(List<Student> students)
    {
        return from student in students where student.Grade < 60 select student;
    }

    public static IEnumerable<Student> OrderStudentsByNameAndAge(List<Student> students)
    {
        return from student in students orderby student.Name, student.Age descending select student;
    }
}
