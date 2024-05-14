namespace Zad25_2022;

class Program
{
    static Dictionary<int, int> number_of_digits = new Dictionary<int, int>();
    static void Main(string[] args)
    {
        int len_of_nums = 0;
        while (len_of_nums == 0)
        {
            if (int.TryParse(Console.ReadLine(), out len_of_nums))
            {
                Console.Clear();
                break;
            }
            Console.WriteLine("Invalid input. Enter only Numbers");
        }

        Console.WriteLine(len_of_nums);
        List<int> userInput = new List<int>();
        GetUserInputAndValidate(ref userInput, len_of_nums);

        foreach(var num in userInput)
        {
            if(number_of_digits.ContainsKey(num))
            {
                number_of_digits[num] += 1;
                continue;
            } 
            else
            {
                number_of_digits.Add(num, 1);
            }
        }

        PrintCoutOfDigits();

    }

    static void GetUserInputAndValidate(ref List<int> user_input_list, int len_of_user_input)
    {
        for (int i = 0; i < len_of_user_input; i++)
        {
            while (true)
            {
                int number = 0;
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    user_input_list.Add(number);
                    break;
                }

                Console.WriteLine("Invalid input. Enter only Numbers");
            }
        }
    }

    static void PrintCoutOfDigits()
    {
        foreach(KeyValuePair<int,int> kv in number_of_digits)
        {
            Console.WriteLine("число: {0} , брой: {1}", kv.Key, kv.Value);
        }
    }
}
