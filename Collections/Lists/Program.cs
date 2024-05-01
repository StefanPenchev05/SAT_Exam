namespace Lists;

class Program
{
    // Create new list of integers, List<T>, while T is generic

    private List<int> ints = new List<int>();
    static void Main(string[] args)
    {
        Program program = new Program();
        program.BasicUse();
        program.AddElement();
    }

    private void BasicUse()
    {
        // Add elements in the list
        ints.Add(1);
        ints.Add(3);
        ints.Add(7);
        ints.Add(10);

        // Access an elemtens by index
        Console.WriteLine(ints[0]); // 1

        // Modify an elements by index
        ints[0] = 400;
        Console.WriteLine("Numbers after modification: " + string.Join(", ", ints));


        // Remove an element by index
        ints.RemoveAt(2);
        Console.WriteLine("Numbers after removing element at index 1: " + string.Join(", ", ints));

        // Count the number of elements in the list        
        Console.WriteLine($"Count: {ints.Count}");

        // Check if the list contains a certain value
        Console.WriteLine($"{ints.Contains(10)}"); // true

        PrintList();

    }

    private void AddElement()
    {
        // Add method: Adds an element at the end of the list
        ints.Add(4);

        // Insert Method: Inserts an element at specific position(index)
        ints.Insert(0, 10);

        // AddRange method: Adds the elements of the specified collection at the end of the list
        ints.AddRange(new int[] { 3, 7, 2, 8 });

        // InsertRange method: Inserts the element of specified collection at specific position(index)
        ints.InsertRange(3, new List<int> {2345,5654});

        PrintList();
    }

    private void PrintList()
    {
        // The most command use for printing or iterating over the list is with for and foreach loops or string.Join

        // For loop
        Console.Write("Printing list with For loop: ");
        for (int i = 0; i < ints.Count - 1; i++)
        {
            Console.Write($"{ints[i]} ");
        }

        Console.WriteLine();

        // Foreach loop
        Console.Write("Printing list with ForEach loop: ");
        foreach (var el in ints)
        {
            Console.Write($"{el} ");

        }

        Console.WriteLine();


        Console.WriteLine($"Printig list with string.Join: {string.Join(" ", ints)}");
    }
}
