using System.Linq.Expressions;

namespace HashSet_Exercise;

class Program
{
    public static Dictionary<string, HashSet<string>> contact_lists = new();
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
                    Console.WriteLine("Actions:\n1) Add List\n2) Remove List\n3) Select Group");
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
                    case "select":
                        SelectGroup();
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
        var (_, isSuccess) = GetUserInputAndValidate("Enter the name of the list",
        "Please enter the name of the list",
        "This ground does not exists",
        (c =>
        {
            if (!contact_lists.ContainsKey(c))
            {
                contact_lists.Add(c, new() { });
                return true;
            };

            Console.Clear();

            return false;
        }));
        return isSuccess;
    }

    private static bool RemoveList()
    {
        Console.Clear();
        var (_, isSuccess) = GetUserInputAndValidate("Enter the name of the list",
        "Please enter the name of the list",
        "This ground does not exists",
        (c =>
        {
            if (!contact_lists.ContainsKey(c)) return false;

            contact_lists.Remove(c);
            Console.Clear();

            return true;
        }));
        return isSuccess;
    }

    private static void SelectGroup()
    {
        Console.Clear();
        foreach (KeyValuePair<string, HashSet<string>> list in contact_lists)
        {
            Console.WriteLine("Group {0} - contacts {1}", list.Key, list.Value.Count);
        }

        var (group_name, _) = GetUserInputAndValidate("Enter a group name",
        "You have to enter the group name",
        "There is no group with that name",
        (c => {
            if(contact_lists.ContainsKey(c)) return true;
            return false;
        }));

        OperationOnSpecificList(group_name);
        Console.Clear();
    }

    private static void OperationOnSpecificList(string nameOfGroup)
    {
        string action = "";

        while (action != "exit")
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
                        bool isAdded = AddContact(nameOfGroup);
                        if (isAdded) Console.WriteLine("Contact Added Successfully");
                        break;
                    case "remove":
                        bool isRemoved = RemoveContact(nameOfGroup);
                        if (isRemoved) Console.WriteLine("Contact Removed Successfully");
                        break;
                    case "exists":
                        bool exists = Exists(nameOfGroup);
                        if (exists) Console.WriteLine("This contact exists");
                        else Console.WriteLine("This contact does not exist, yet");
                        break;
                    case "display":
                        DispalyAll();
                        break;
                    case "exit":
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

    private static bool AddContact(string nameOfGroup)
    {
        Console.Clear();
        var (_, isSuccess) = GetUserInputAndValidate("Please enter the number of the contact",
        "You have to pass the number of the new contact",
        "This contact already exsists",
        (c =>
        {
            HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
            bool isAdded = contacts_from_group.Add(c);
            return isAdded;
        }));

        return isSuccess;
    }

    private static bool RemoveContact(string nameOfGroup)
    {
        Console.Clear();
        var (_, isSuccess) = GetUserInputAndValidate("Please enter the number of the contact",
        "You have to pass the number of the contact!",
        "This contact does not exists",
        (c =>
        {
            HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
            bool isRemoved = contacts_from_group.Remove(c);
            return isRemoved;
        }));
        return isSuccess;
    }

    private static bool Exists(string nameOfGroup)
    {
        Console.Clear();
        var (contact, _) = GetUserInputAndValidate("You have to pass the number of contact!", "Please enter the number of the contact");
        HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
        bool exists = contacts_from_group.Contains(contact);
        if (!exists) return false;

        return true;
    }

    private static void DispalyAll(string nameOfGroup)
    {
        Console.Clear();
        HashSet<string> contacts_of_group = contact_lists[nameOfGroup];
        if (contacts_of_group.Count() == 0)
        {
            Console.WriteLine("You does not have any contact in the list");
            return;
        }

        foreach (var contact in contacts_of_group)
        {
            Console.WriteLine(contact);
        }
    }

    private static (string, bool) GetUserInputAndValidate(string welcomeMessage,
                                                string onEmptyInput,
                                                string? onInvalidInput = null,
                                                Func<string, bool>? check = null)
    {
        string user_input;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter exit, if you want to exit this operation");
                Console.Write($"{welcomeMessage}: ");
                user_input = Console.ReadLine() ?? "";

                if (user_input.Length == 0) throw new Exception(onEmptyInput);
                else if (user_input == "exit") break;

                if (check == null) return (user_input, true);
                else
                {
                    if (check(user_input)) return (user_input, true);
                    else throw new Exception(onInvalidInput);
                }

            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }

        return (user_input, false);
    }
}
