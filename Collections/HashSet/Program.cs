namespace HashSet;

/// <summary>
/// HashSet<T>
/// A generic collection that stores unique elements, similar to a set in mathematics.
/// Elements must be unique, duplicates are not allowed.
/// Elements cannot be accessed by index like an array or list, because elements are not stored in a specific order.
/// Provides high performance set operations like union, intersection, and is a subset of.
/// </summary>
class Program
{

    static HashSet<int> nums = new() { 4, 5, 6, 7, 8 };
    static void Main(string[] args)
    {
        Program program = new Program();
        program.BasicUse();
        program.SetOperations();
        //program.PrintHash(nums);
    }

    private void BasicUse()
    {
        // Adding Elements
        nums.Add(9);
        nums.Add(10);
        nums.Add(11);
        nums.Add(5); // remember, the elemets must be unique, so it will not add the element

        // Check if the element is successfully added
        bool added = nums.Add(5); // returns true
        added = nums.Add(20); // returns flase

        // Remove Elemets
        nums.Remove(20);

        // Check if the elemets in successfully removed
        bool removed = nums.Remove(10); // returs true
        removed = nums.Remove(1); // returns false because 1 does not exists in the hash

        // Check if element exists
        bool contains = nums.Contains(4); // returns true
    }

    private void SetOperations()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 2, 3, 4 };

        /// UnionWith method: 
        /// modifies the current HashSet<T> object to ensure that it contains all elements 
        /// that are present in itself, the specified collection, or both, without duplicates. 
        set1.UnionWith(set2); // {1, 2, 3, 4}
        PrintHash(set1);

        /// IntersectWith method:
        /// modifies the current HashSet<T> object to contain only elements that are present in that object 
        /// and in the specified collection.
        HashSet<int> set3 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set4 = new HashSet<int> { 2, 3, 4 };
        set3.IntersectWith(set4); // {2, 3}
        PrintHash(set3);

        /// ExceptWith
        /// modifies the current HashSet<T> object to contain only elements that are present in that object 
        /// and in the specified collection.
        HashSet<int> set5 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set6 = new HashSet<int> { 2, 3, 4 };
        set5.ExceptWith(set6); // {1}
        PrintHash(set5);

    }

    private void PrintHash<T>(HashSet<T> hash)
    {
        foreach (var el in hash)
        {
            Console.Write("{0} ", el);
        }

        Console.WriteLine();
    }
}
