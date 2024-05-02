namespace Dictionary;

/// <summary>
/// Dictionary<TKey, TValue>
/// Generic type that stores key-value pair, like json 
/// Keys must be unique and cannot be null
/// Values can be null or duplicated
/// Accessing values is done by passing associate key - myDic[key] = value
/// </summary>
class Program
{
    private static Dictionary<int, Dictionary<string, string>> users = new();
    static void Main(string[] args)
    {
        Program program = new Program();
        program.BasicUse();
        program.AddElement();
        program.PrintDic(users);
        program.RemoveElement();
        program.PrintDic(users);

    }

    private void BasicUse()
    {
        // Adding elements in the dictionary
        users.Add(1, new() { { "firstName", "Stefan" }, { "lastName", "Penchev" } });
        users.Add(2, new() { { "firstName", "Petya" }, { "lastName", "Pencheva" } });

        // Access Elemets
        Console.WriteLine(users[1]["firstName"]);

        // Modify elemet
        users[1] = new() { { "firstName", "Viktor" } };
        Console.WriteLine(users[1]["firstName"]);

        // Remove Element
        users.Remove(1); // now the Viktor or Stefan is deleted

        // When deleting a element the privious wont take the position 1
        Console.WriteLine(users[2]["firstName"]); // if try to access 1 is going to be error

        // Count the number of elements in the dictionary
        Console.WriteLine($"Count: {users.Count}"); // 1

        // Check if the dictionary contains a certain key
        Console.WriteLine($"{users.ContainsKey(1)}"); // false
        Console.WriteLine($"{users.ContainsKey(2)}"); // true

        // Check if the dictorionary contains a certain value
        Console.WriteLine(users[2].ContainsValue("Stefan")); // false
        Console.WriteLine(users[2].ContainsValue("Petya")); // true 
    }

    private void AddElement()
        {
            Console.WriteLine("---- Add Elements ----");
            // Add method: Adds an element with a specific key
            users.Add(1, new(){{"firstName", "Stefan"}, {"lastName", "Penchev"}});
            users.Add(3, new(){{"firstName", "Dimitar"}, {"lastName", "Penchev"}});
        }

        private void RemoveElement()
        {
            Console.WriteLine("---- Remove Elements ----");
            // Remove method: Removes the element with a specific key
            users.Remove(3);
        }


    private void PrintDic<TKey, TInnerKey, TValue>(Dictionary<TKey, Dictionary<TInnerKey, TValue>> dic)
    {
        foreach(KeyValuePair<TKey, Dictionary<TInnerKey, TValue>> kvp in dic)
        {
            Console.WriteLine("{0} is key for following value", kvp.Key);
            foreach(KeyValuePair<TInnerKey, TValue> innerKvp in kvp.Value)
            {
                 Console.WriteLine("\t{0} is key for {1} value", innerKvp.Key, innerKvp.Value);
            }
        }
    }   
}
