namespace Lists;

class Program
{
    static void Main(string[] args)
    {
        BasicUse();
    }

    private static void BasicUse()
    {
        // Create new list of integers, List<T>, while T is generic
        List<int> ints = new List<int>();

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

        // Iterate over the list
        Console.WriteLine("Iterating over the list: ");
        foreach(var el in ints)
        {
            Console.WriteLine(el);
        }

    }
}
