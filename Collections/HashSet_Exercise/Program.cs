using System.Linq.Expressions;

namespace HashSet_Exercise;

class Program
{
    public static HashSet<string> contacts = new();
    static void Main(string[] args)
    {
        Console.Clear();
        string action = "";

        while (action != "end")
        {
            try
            {
                Console.WriteLine("Available actions: \nAdd\nRemove\nExsists\nAll");
                Console.Write("Please choose one of them: ");
                action = Console.ReadLine() ?? "";

                if (action.Length == 0) throw new Exception("Action cannot be empty!");

                switch (action)
                {
                    case "add":
                        bool isAdded = AddContact();
                        if (isAdded) Console.WriteLine("Contact Added Successfully");
                        break;
                    case "end":
                        break;
                    default:
                        throw new Exception("Invalid Action");
                }
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }
    }

    private static bool AddContact()
    {
        Console.Clear();
        string number;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you do not want to add new contact");
                Console.Write("Please enter the number of the contact: ");
                number = Console.ReadLine() ?? "";

                if (number.Length == 0) throw new Exception("You have to pass the number of the new contact!");
                else if (number == "exit") break;
    

                bool isAdded = contacts.Add(number);
                if (!isAdded) throw new Exception("This contact already exists");

                return true;
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }

        return false;
    }
}
