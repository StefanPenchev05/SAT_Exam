namespace Queue;


/// <summary>
/// Queue<T>
/// A generic collection that represents a first-in, first-out collection object
/// Elements added to the end of the Queue and removed fmro the start.
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
        // Create a new Queue
        Queue<int> numbers = new();

        // Enqueue method: Adds an object to the end of the of the Queue<T>
        numbers.Enqueue(1);
        numbers.Enqueue(2);
        numbers.Enqueue(3);
        numbers.Enqueue(4);

        // The queue now contains {1, 2, 3, 4}

        // Dequeue method: Removes and returns the object at the beginning of the Queue<T>
        int first = numbers.Dequeue(); // first = 1

        // the queue now contains {2, 3, 4}

        // Peek method: Returns the obkect at the beginning of the Queue<T>
        int peek = numbers.Peek(); // peek = 2

        // Count: Gets the number of elements contained in the Queue<T>.
        int count = numbers.Count; // count = 3

        // Clear: Removes all objects from the Queue<T>.
        //numbers.Clear();

        // The queue is now empty

        // Check if queue contains a number
        bool contains = numbers.Contains(2); // contains = true

        // Trim excess
        numbers.TrimExcess();

        // Enumerate the queue
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
