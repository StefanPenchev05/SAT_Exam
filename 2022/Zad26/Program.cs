using System.Drawing;

namespace Zad26;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Item : IComparable<Item>
{
    private string _description;
    public string Description
    {
        get { return _description; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }

            _description = value;
        }
    }

    private int _price;
    public int Price
    {
        get { return _price; }
        set
        {
            if (!(value >= 0))
            {
                throw new ArgumentException("Price cannot be negative number");
            }

            _price = value;
        }
    }

    public Item(string description, int price)
    {
        Description = description;
        Price = price;
    }

    public int CompareTo(Item? other)
    {
        if (other == null)
            return 1;

        int descriptionComparison = this.Description.CompareTo(other.Description);
        if(descriptionComparison == 0)
            return this.Price.CompareTo(other.Price);
        else
            return descriptionComparison;
    }

    public override string ToString()
    {
        return $"{this.Description} ({this.Price})";
    }
}

class ItemList
{
    private List<Item> Items = new List<Item>();

    public int Size()
    {
        return Items.Count();
    }

    public Item Get(int index)
    {
        if(index > Items.Count || index < Items.Count)
            throw new ArgumentException("Index is not valid");

        return Items[index];
    }


}