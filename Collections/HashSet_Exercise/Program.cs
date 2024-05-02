﻿using System.Linq.Expressions;

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
        string name = GetUserInputAndValidate("Enter the name of the list",
        "Please enter the name of the list",
        "This ground does not exists",
        (c =>
        {
            if (!contact_lists.ContainsKey(c)) 
            {
                contact_lists.Add(c, new(){});
                return true;
            };

            Console.Clear();

            return false;
        }));
        return false;
    }

    private static bool RemoveList()
    {
        Console.Clear();
        string name = GetUserInputAndValidate("Enter the name of the list",
        "Please enter the name of the list",
        "This ground does not exists",
        (c =>
        {
            if (!contact_lists.ContainsKey(c)) return false;

            contact_lists.Remove(c);
            Console.Clear();

            return true;
        }));
        return string.IsNullOrEmpty(name) ? false : true;
    }

    private static void OperationOnSpecificList(string nameOfGroup)
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

    private static bool AddContact(string nameOfGroup)
    {
        Console.Clear();
        string number = GetUserInputAndValidate("Please enter the number of the contact",
        "You have to pass the number of the new contact",
        "This contact already exsists",
        (c =>
        {
            HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
            bool isAdded = contacts_from_group.Add(c);
            return isAdded;
        }));

        return string.IsNullOrEmpty(number) ? false : true;
    }

    private static bool RemoveContact(string nameOfGroup)
    {
        Console.Clear();
        string contact = GetUserInputAndValidate("Please enter the number of the contact",
        "You have to pass the number of the contact!",
        "This contact does not exists",
        (c =>
        {
            HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
            bool isRemoved = contacts_from_group.Remove(c);
            return isRemoved;
        }));
        return string.IsNullOrEmpty(contact) ? false : true;
    }

    private static bool Exists(string nameOfGroup)
    {
        Console.Clear();
        string contact = GetUserInputAndValidate("You have to pass the number of contact!", "Please enter the number of the contact");
        HashSet<string> contacts_from_group = contact_lists[nameOfGroup];
        bool exists = contacts_from_group.Contains(contact);
        if (!exists) return false;

        return true;
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

    private static string GetUserInputAndValidate(string welcomeMessage,
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

                if (check == null) return user_input;
                else
                {
                    if (check(user_input)) return user_input;
                    else throw new Exception(onInvalidInput);
                }

            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
        }

        return user_input;
    }
}
