using System.Linq.Expressions;

namespace HashSet_Exercise;

class Program
{
    public static Dictionary<string, HashSet<string>> contact_lists = new();
    public static HashSet<string> contacts = new();
    static void Main(string[] args)
    {
        Console.Clear();
        string action = "";
        while (action != "end")
        {
            try
            {
                if (contact_lists.Count == 0)
                {
                    Console.WriteLine("You do not have any lists, you need to create one!");
                    Console.WriteLine("Actions: \n1) Add List");
                }
                else
                {
                    foreach (KeyValuePair<string, HashSet<string>> list in contact_lists)
                    {
                        Console.WriteLine("Group {0} - contacts {1}", list.Key, list.Value.Count);
                    }
                    Console.WriteLine("Actions:\n1) Add List\n2) Remove List");
                }

                Console.Write("Enter Action: ");
                action = Console.ReadLine().Trim().ToLower() ?? "";

                switch (action)
                {
                    case "add":
                        bool isListCreated = CreateList();
                        if (isListCreated) Console.WriteLine("List Created Successfully");
                        break;
                    case "remove":
                        bool isRemoved = RemoveList();
                        if (isRemoved) Console.WriteLine("List Removed Successfully");
                        break;
                    case "end":
                        break;
                    default:
                        throw new Exception("Invalid Command!");
                }
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }
    }

    private static bool CreateList()
    {
        Console.Clear();
        string name;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you do not want this operation!");
                Console.Write("Enter the name of the list: ");
                name = Console.ReadLine().Trim().ToLower() ?? "";

                if (name.Length == 0) throw new Exception("Please enter the name of the list");
                else if (name == "exit") break;

                if (contact_lists.ContainsKey(name)) throw new Exception("This ground already exists");

                contact_lists.Add(name, new() { });
                Console.Clear();

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

    private static bool RemoveList()
    {
        Console.Clear();
        string name;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you do not want this operation!");
                Console.Write("Enter the name of the list: ");
                name = Console.ReadLine().Trim().ToLower() ?? "";

                if (name.Length == 0) throw new Exception("Please enter the name of the list");
                else if (name == "exit") break;

                if (!contact_lists.ContainsKey(name)) throw new Exception("This ground does not exists");

                contact_lists.Remove(name);

                return true;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        return false;
    }

    private static void OperationOnSpecificList()
    {
        string action = "";

        while (action != "end")
        {
            try
            {
                Console.WriteLine("Available actions: \nAdd\nRemove\nExsists\nDispaly");
                Console.Write("Please choose one of them: ");
                action = Console.ReadLine().Trim() ?? "";

                if (action.Length == 0) throw new Exception("Action cannot be empty!");

                switch (action)
                {
                    case "add":
                        bool isAdded = AddContact();
                        if (isAdded) Console.WriteLine("Contact Added Successfully");
                        break;
                    case "remove":
                        bool isRemoved = RemoveContact();
                        if (isRemoved) Console.WriteLine("Contact Removed Successfully");
                        break;
                    case "exists":
                        bool exists = Exists();
                        if (exists) Console.WriteLine("This contact exists");
                        else Console.WriteLine("This contact does not exist, yet");
                        break;
                    case "display":
                        DispalyAll();
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
                Console.WriteLine("Enter exit, if you do not want to add a new contact");
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

    private static bool RemoveContact()
    {
        Console.Clear();
        string contact;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you do not want to remove a contact");
                Console.Write("Please enter the number of the contact: ");
                contact = Console.ReadLine() ?? "";

                if (contact.Length == 0) throw new Exception("You have to pass the number of the contact!");
                else if (contact == "exit") break;

                bool isRemoved = contacts.Remove(contact);
                if (!isRemoved) throw new Exception("This contact does not exists");

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

    private static bool Exists()
    {
        Console.Clear();
        string contact;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you want to exit of this operation");
                Console.Write("Please enter the number of the contact: ");
                contact = Console.ReadLine() ?? "";

                if (contact.Length == 0) throw new Exception("You have to pass the number of contact!");
                else if (contact == "exit") break;

                bool exists = contacts.Contains(contact);

                return exists;

            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }
        return false;
    }

    private static void DispalyAll()
    {
        Console.Clear();
        if (contacts.Count() == 0)
        {
            Console.WriteLine("You does not have any contact in the list");
            return;
        }

        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    private static string GetUserInputAndValidate(string onEmptyInput, string onInvalidInput, Func<string, bool> check)
    {
        while(true)
        {

        }
    }
}
