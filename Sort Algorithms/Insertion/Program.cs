namespace Insertion;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = makeRandomArray();

        InsertionSort(numbers);

        foreach (int num in numbers)
        {
            Console.Write(" {0}", num);
        }
    }

    static int[] makeRandomArray()
    {
        Random random = new Random();
        int[] nums = new int[5];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = random.Next(1, 30);
        }

        return nums;
    }

    static void InsertionSort(int[] numbers)
    {
        for(int i = 1; i < numbers.Length; i++)
        {
           int left = i - 1;
           int right = i;
           int current = numbers[right];

           while(left > -1 && current < numbers[left])
           {
                numbers[right] = numbers[left];
                left--;
                right--;
           }

           numbers[left + 1] = current;
        }
    }
}
