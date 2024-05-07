namespace MethodSyntax;

    // Abstract class Person with properties Name and Age
    abstract class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            // Throw an exception if the name is null
            set { name = value ?? throw new Exception("Name cannot be null"); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                // Throw an exception if the age is null
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

        // Constructor for Person
        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Abstract method Introduce
        public abstract void Introduce();
    }

    // Class Student that inherits from Person and adds properties Subject and Grade
    class Student : Person
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        // Constructor for Student
        public Student(string name, int age, string subject, int grade) : base(name, age)
        {
            Subject = subject;
            Grade = grade;
        }

        // Override the Introduce method to introduce the student
        public override void Introduce()
        {
            Console.WriteLine($"I am a student,{Name} and {Age} years old, studying {Subject}, with grade {Grade}");
        }
    }



class Program
{
    static void Main(string[] args)
    {
       // Create a list of students
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

        var mathStudents = students
            .Where(s => s.Grade > 80 && s.Subject == "History")
            .ToList();
        
        var topScoringStudents = students
            .OrderByDescending(s => s.Grade)
            .First();
    }
}
