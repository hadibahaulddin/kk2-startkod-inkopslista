// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
{
    File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
    Console.WriteLine("Listan är sparad.");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Kunde inte spara listan. Programmet har inte behörighet att skriva till filen.");
}
catch (IOException)
{
    Console.WriteLine("Kunde inte spara listan. Filen kanske används av ett annat program.");
}
    }

    // Reads the file back into the list.
            public void Load()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Hittade ingen sparad lista. Börjar med en tom lista.");
            return;
        }

        foreach (string line in File.ReadAllLines(path))
        {
            string[] parts = line.Split(';');
            if (parts.Length < 2) continue;
            items.Add(new Item(parts[1].Trim(), int.Parse(parts[0])));
        }
    }
}
