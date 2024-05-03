namespace Stack;

/// <summary>
/// Stack<T>
/// A generic collection that represents a last-in, first-out collection of objects.
/// Elements are added to the top of the Stack and removed from the top.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.BasicUse();
    }

    private void BasicUse()
    {
        // Create a new Stack
        Stack<int> numbers = new Stack<int>();

        // Push: Adds an object to the top of the Stack<T>.
        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        numbers.Push(4);

        // The stack now contains: 4, 3, 2, 1

        // Pop: Removes and returns the object at the top of the Stack<T>.
        int top = numbers.Pop(); // top = 4

        // The stack now contains: 3, 2, 1

        // Peek: Returns the object at the top of the Stack<T> without removing it.
        int peek = numbers.Peek(); // peek = 3

        // The stack still contains: 3, 2, 1

        // Count: Gets the number of elements contained in the Stack<T>.
        int count = numbers.Count; // count = 3

        // Clear: Removes all objects from the Stack<T>.
        //numbers.Clear();

        // The stack is now empty

        // Check if stack contains a number
        bool contains = numbers.Contains(2); // contains = true

        // Enumerate the stack
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
