namespace Classes;

class Program
{
    static void Main(string[] args)
    {
        // Creating an object(instance)
        BasicPerson person1 = new BasicPerson();
        person1.Name = "Stefan";
        person1.Age = 18;
        person1.Introduce();

        BasicPerson person2 = new BasicPerson();
        person2.Name = "Martin";
        person2.Age = 32;
        person2.Introduce();

        // First Constructor
        IntermidatePerson intermidate = new IntermidatePerson("Stefan", 90);
        intermidate.Introduce();

        // Second Constructor
        IntermidatePerson intermidate2 = new IntermidatePerson("Stefan", "Penchev");
        intermidate2.Introduce();

        // Static Count
        AdvancedPerson advancedPerson = new AdvancedPerson("Stefan", 43);
        advancedPerson.Introduce();

        // Static Count
        AdvancedPerson advancedPerson2 = new AdvancedPerson("Stefan", 43);
        advancedPerson2.Introduce();

        advancedPerson.Introduce();

        // Static Method
        int age = AdvancedPerson.RoundAge(32.7);
        Console.WriteLine(age);
    }
}

// Basic class - mostly not used like this
class BasicPerson
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Method
    public void Introduce()
    {
        Console.WriteLine("Hello, my name is {0}, and I am {1} years old", Name, Age);
    }
}


/// <summary>
/// public - the memeber is accessible from anywhere
/// private - the member is only accessible within its own class
/// protected - the member is only accessible within its own class and by classes derived from it(inherit it)
/// </summary>
class IntermidatePerson
{
    // Properties needs to be private, so not to be access 
    private string Name { get; set; }
    private string lastName { get; set; }
    private int Age { get; set; }

    /// <summary>
    /// Constructor
    /// the constructor needs to be with the same name as the class
    /// class can have more than one constructor with different arguments
    /// </summary>

    public IntermidatePerson(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public IntermidatePerson(string name, string lastName)
    {
        Name = name;
        this.lastName = lastName;
    }

    public void Introduce()
    {
        if (Age > 0)
        {
            Console.WriteLine("Hello, my name is {0}, and I am {1} years old", Name, Age);
        }
        else
        {
            Console.WriteLine("Hello, my name is {0}, and my Last Name is {1}", Name, lastName);
        }
    }
}

/// <summary>
/// Static
/// Static member belong to the class itself, not to be any specific object of the class.
/// They can be accessed without creating an instance of the class.
/// </summary>
class AdvancedPerson
{
    /// <summary>
    /// Static Variables - 
    /// varibale that retains its value till the program finishes execution.
    /// Initialized once, at the start of the execution
    /// </summary>

    public static int Count { get; private set; }
    private string Name { get; set; }
    private int Age { get; set; }

    public AdvancedPerson(string name, int age)
    {
        Name = name;
        Age = age;
        Count++;
    }

    /// <summary>
    /// Rounds the age to the nearest whole number.
    /// This is a static method, which means it belongs to the class itself rather than an instance of the class.
    /// It can be called directly from the class and can only access other static members of the same class.
    /// </summary>
    /// <param name="age">The age to round.</param>
    /// <returns>The age rounded to the nearest whole number.</returns>
    public static int RoundAge(double age)
    {
        return (int)Math.Floor((decimal)age);
    }
    // Method
    public void Introduce()
    {
        Console.WriteLine("Hello, my name is {0}, and I am {1} years old", Name, Age);
        Console.WriteLine("Instance of the class AdvancedPerson: {0}", Count);

    }

}
