namespace Dictionary_Exercise;

class Program
{
    static void Main(string[] args)
    {
        ;
        Console.WriteLine("1) With List\n2) Without List");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            withList();
        }
        else
        {
            withOutList();
        }
    }

    private static void withList()
    {
        List<string> sentence = new();
        while (true)
        {
            Console.Write("Please enter your sentence: ");
            sentence = Console.ReadLine().Split(' ').ToList();
            sentence = sentence.FindAll(x => !(x.Length == 0));
            sentence.TrimExcess();

            if (sentence.Count == 0)
            {
                Console.WriteLine("Sorry, you have to write sentence");
                continue;
            }

            break;
        }

        List<string> formettedSentence = new();

        foreach (string word in sentence)
        {
            if (word[word.Length - 1].ToString() == "." ||
                word[word.Length - 1] == '-' ||
                word[word.Length - 1] == '?' ||
                word[word.Length - 1] == ',')
            {
                formettedSentence.Add(word.Substring(0, word.Length - 1));
                continue;
            }

            formettedSentence.Add(word);
        }

        Dictionary<string, int> words = new();

        string word_to_lowwer;
        foreach (var word in formettedSentence)
        {
            word_to_lowwer = word.Trim().ToLower();
            if (words.ContainsKey(word_to_lowwer))
            {
                words[word_to_lowwer] += 1;
                continue;
            }

            words.Add(word_to_lowwer, 1);
        }

        foreach (KeyValuePair<string, int> entry in words)
        {
            Console.WriteLine($"Word: {entry.Key}, Frequency: {entry.Value}");
        }
    }

    private static void withOutList()
    {
        string sentence;
        string[] words = { };
        while (true)
        {
            Console.Write("Please, enter your sentence: ");
            sentence = Console.ReadLine().ToLower();
            if (sentence.Length == 0)
            {
                Console.WriteLine("Sorry, you have to write sentence");
                continue;
            }

            words = sentence.Split(' ');
            break;
        }

        for(int i = 0; i <= words.Length - 1; i++)
        {
            string word = words[i];
            if(word[word.Length - 1] == '.')
            {
                words[i] = word.Substring(0, word.Length - 1);
            }
        }

        Dictionary<string, int> wordFrequency = new();
        foreach (var word in words)
        {
            if (wordFrequency.ContainsKey(word))
            {
                wordFrequency[word]++;
                continue;
            }

            wordFrequency.Add(word, 1);
        }

        foreach (KeyValuePair<string, int> entry in wordFrequency)
        {
            Console.WriteLine($"Word: {entry.Key}, Frequency: {entry.Value}");
        }
    }
}
