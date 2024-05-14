using System.Drawing;

namespace Zad26;

class Program
{
    static void Main(string[] args)
    {
        int len_of_list = GetUserInputAndValidate("Please enter the length of the list of items:",
            n =>
            {
                int tryValue;
                if (int.TryParse(n, out tryValue))
                {
                    return tryValue;
                }

                return default;
            },
            "Invalid Input. Please enter a number"
        );

        ItemList itemList = new ItemList();
        for (int i = 0; i < len_of_list; i++)
        {
            (string, int) input_item = GetUserInputAndValidate("Please enter the description and the price for the item: ",
                validate: i =>
                {
                    string[] des_and_price = i.Split(' ');
                    if (string.IsNullOrEmpty(des_and_price[0]) || string.IsNullOrEmpty(des_and_price[1]))
                    {
                        return default;
                    }
                    string description = des_and_price[0];

                    int price;
                    if (!int.TryParse(des_and_price[1], out price))
                    {
                        throw new ArgumentException("The price can only be a number");
                    }

                    return (description, price);
                },
                "The Description and the Price cannot be empty"
            );

            Item item = new Item(input_item.Item1, input_item.Item2);
            itemList.Add(item);
        }

        PrintItems(itemList);
    }

    static public T GetUserInputAndValidate<T>(string welcomeMessage, Func<string, T> validate, string? argumentMessage = null)
    {
        T? returnValue = default;
        while (true)
        {
            try
            {
                Console.WriteLine(welcomeMessage);
                string value = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Input cannot be empty");
                }

                T? TResult = validate(value);

                if (TResult?.Equals(default(T)) == true)
                {
                    throw new ArgumentException(argumentMessage);
                }

                returnValue = TResult;
                break;
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine("Argument Exception: {0}", err.Message);
            }
        }

        return returnValue;
    }

    static void PrintItems(ItemList itemList)
    {
        for (int i = 0; i < itemList.Size(); i++)
        {
            Item item = itemList.Get(i);
            Console.WriteLine(item.ToString());
        }
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
        if (descriptionComparison == 0)
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
    private List<Item> Items { get; set; }

    public ItemList()
    {
        Items = new List<Item>();
    }

    public int Size()
    {
        return Items.Count();
    }

    public Item Get(int index)
    {
        if (index > Items.Count || index < 0)
            throw new ArgumentException("Index is not valid");

        return Items[index];
    }

    public void Add(Item item)
    {
        if (Items.Contains(item))
        {
            throw new ArgumentException("Item is already in the list");
        }

        Items.Add(item);
        Items.Sort();
    }


}