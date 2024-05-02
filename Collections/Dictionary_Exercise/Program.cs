namespace Dictionary_Exercise;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("1) With List\n2)Without List");
        string choice = Console.ReadLine();
        if(choice == "1")
        {
            program.withList();
        }else{

        }
    }

    private void withList()
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
        // This is some exmaple sentace. -> ["This", "is", "some" ... "sentence."]

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

        foreach (KeyValuePair<string, int> kvp in words)
        {
            Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
        }
    }

    
}
