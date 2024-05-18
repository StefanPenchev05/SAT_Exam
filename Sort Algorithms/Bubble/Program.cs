using System.Security.Cryptography.X509Certificates;

namespace Bubble;

/// <summary>
/// This is the main class of the Bubble Sort program.
/// The Bubble Sort algorithm works by repeatedly stepping through the list,
/// comparing each pair of adjacent items and swapping them if they are in the wrong order.
/// The pass through the list is repeated until no more swaps are needed, indicating that the list is sorted.
/// Despite its simplicity, Bubble Sort is not efficient for large lists, and is primarily used for educational purposes.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = makeRandomArray();

        BubbeSort(numbers);

        foreach (int num in numbers)
        {
            Console.Write(" {0}", num);
        }
    }

    static int[] makeRandomArray()
    {
        Random rand = new Random();
        int[] array = new int[10];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 100);
        }

        return array;
    }

    static void BubbeSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
    }
}
