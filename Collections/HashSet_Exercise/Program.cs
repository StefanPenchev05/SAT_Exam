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
                    case "remove":
                        bool isRemoved = RemoveContact();
                        if (isRemoved) Console.WriteLine("Contact Removed Successfully");
                        break;
                    case "exists":
                        bool exists = Exists();
                        if(exists) Console.WriteLine("This contact exists");
                        else Console.WriteLine("This contact does not exist");
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
}
