namespace List_Exercise;

class Program
{
    static void Main(string[] args)
    {
        string action = "";

        List<string> list = new List<string>();

        ListActions listActions = new();

        while (action != "end")
        {
            try
            {
                if (list.Count == 0)
                {
                    Console.Write("Enter your List: ");
                    list = Console.ReadLine().Trim().Split(" ").ToList();
                    if (string.IsNullOrEmpty(list[0]))
                    {
                        list.Clear();
                        throw new Exception("List cannot be empty!");
                    }
                }

                Console.Write("\nEnter your action: ");
                action = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(action))
                {
                    throw new Exception("Invalid Action!");
                }

                switch (action)
                {
                    case "mergelists":
                        listActions.MergeLists(list);
                        break;
                    case "removeduplicates":
                        listActions.RemoveDuplicates(list);
                        Console.WriteLine($"{string.Join(" ", list)}");
                        break;
                    default:
                        throw new Exception("Invalid Action!");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

    }
}

class ListActions
{
    public void MergeLists(List<string> main_list)
    {
        Console.Write("How many list to add: ");
        int number_of_lists = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Where to add the list/s: ");
        int placeAt = int.Parse(Console.ReadLine());

        List<string> merging_list = new();

        for (int i = 1; i <= number_of_lists; i++)
        {
            Console.Write($"List {i}: ");
            merging_list.InsertRange(placeAt, Console.ReadLine().Split(" ").ToList());
        }

        main_list.AddRange(merging_list);
    }

    public void RemoveDuplicates(List<string> main_list)
    {
        List<string> unique_state = new List<string>();
        foreach (var el in main_list)
        {
            if(unique_state.Contains(el)) continue;
            unique_state.Add(el);
        }

        main_list.Clear();
        main_list.AddRange(unique_state);
    }
}
