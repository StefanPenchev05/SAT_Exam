using Microsoft.VisualBasic;

namespace QuerySyntax
{
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

            // Call the QuerySyntax method with the list of students
            QuerySyntax(students);

            // Use the Where method to get students with a grade of 90 or above and introduce them
            Console.WriteLine("-----Impl Linq Method Where-----");
            var studentsWithA = students.Where(s => s.Grade >= 90);
            foreach (var student in studentsWithA)
            {
                student.Introduce();
            }

            // Use the Select method to get the name and age of each student and print them
            Console.WriteLine("-----Impl Linq Method Select-----");
            var selectedUser = students.Select(s => new { s.Name, s.Age });
            foreach (var student in selectedUser)
            {
                Console.WriteLine($"{student.Name} --> {student.Age}");
            }
        }

        // Method to perform various queries on the list of students
        public static void QuerySyntax(List<Student> students)
        {
            // Get passing students and introduce them
            IEnumerable<Student> passingStudents = GetPassingStudents(students);
            Console.WriteLine("-----Passing Students-----");
            foreach (var student in passingStudents)
            {
                student.Introduce();
            }

            // Get failing students and introduce them
            IEnumerable<Student> failingStudents = GetFailingStudents(students);
            Console.WriteLine("-----Failing Students-----");
            foreach (var student in failingStudents)
            {
                student.Introduce();
            }

            // Order students by name and age and introduce them
            IEnumerable<Student> orderedStudent = OrderStudentsByNameAndAge(students);
            Console.WriteLine("-----Ordered Students-----");
            foreach (var student in orderedStudent)
            {
                student.Introduce();
            }
        }

        // Method to get students with a grade above 80
        public static IEnumerable<Student> GetPassingStudents(List<Student> students)
        {
            return from student in students where student.Grade > 80 select student;
        }

        // Method to get students with a grade below 60
        public static IEnumerable<Student> GetFailingStudents(List<Student> students)
        {
            return from student in students where student.Grade < 60 select student;
        }

        // Method to order students by name and age
        public static IEnumerable<Student> OrderStudentsByNameAndAge(List<Student> students)
        {
            return from student in students orderby student.Name, student.Age descending select student;
        }
    }

    // Static class LinqMethodImpl that contains extension methods for IEnumerable<T>
    static class LinqMethodImpl
    {
        // Method to filter values based on a query
        public static IEnumerable<T> Where<T>(this List<T> values, Func<T, bool> query)
        {
            foreach (var value in values)
            {
                if (query(value))
                {
                    yield return value;
                }
            }
        }

        // Define a generic extension method Select for IEnumerable<T>
        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> values, Func<T, TResult> query)
        {
            // Create a new list to store the results
            List<TResult> newList = new List<TResult>();

            // Iterate over each value in the input sequence
            foreach (var value in values)
            {
                // Apply the query function to the value and add the result to the new list
                newList.Add(query(value));
            }

            // Return the new list as an IEnumerable<TResult>
            return newList;
        }
    }
}