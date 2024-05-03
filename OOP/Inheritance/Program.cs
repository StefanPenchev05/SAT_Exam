namespace Inheritance;

// The base class in this example is Person. This class has properties for Name, Gender, and Age, 
// and a method for Introduce. The Introduce method is marked as virtual, which means it can be 
// overridden by any class that inherits from Person.
public class Person
{
    private string Name { get; set; }
    private enum GenderEnum { Male, Female, Unknow }
    private string Gender { get; set; } = GenderEnum.Unknow.ToString();
    private int Age { get; set; }

    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public virtual void Introduce()
    {
        Console.WriteLine("Hello, my name is {0} and I am {1} years old and I am {2}", Name, Age, Gender);
    }
}


// Student is a derived class that inherits from Person. It has an additional property, Major. 
// It also overrides the Introduce method from Person to provide its own implementation, 
// which includes the value of Major. This is an example of method overriding, which is a key 
// feature of inheritance.
class Student : Person
{
    private string Major { get; set; }

    public Student(string name, int age, string gender, string major) : base(name, age, gender)
    {
        Major = major;
    }

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine("I am studying {0}", Major);
    }
}


// Teacher is another derived class that inherits from Person. It has an additional property, Subject. 
// Like Student, it also overrides the Introduce method from Person to provide its own implementation, 
// which includes the value of Subject. This is another example of method overriding.
class Teacher : Person
{
    private string Subject{get;set;}

    public Teacher(string name, int age, string gender, string subject): base(name, age, gender)
    {
        Subject = subject;
    }

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine("I am teaching {0}", Subject);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("Stefan Penchev", 18, "Male", "Math");
        student.Introduce();
    }
}
