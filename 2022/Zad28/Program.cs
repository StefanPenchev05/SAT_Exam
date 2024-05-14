namespace Zad28;

class Program
{
    static void Main(string[] args)
    {
        
    }

    static void RemoveElementsDivisibleByK(ref List<int> nums, int k)
    {
        for (int i = nums.Count - 1; i >= 0; i--)
        {
            int currentNum = nums[i];
            int sumOfNums = 0;
            while (currentNum > 0)
            {
                sumOfNums += currentNum % 10;
                currentNum /= 10;
            }

            if (sumOfNums % k == 0)
            {
                nums.RemoveAt(i);
            }
        }
    }
}
