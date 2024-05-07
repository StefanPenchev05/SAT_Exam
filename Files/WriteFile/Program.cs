namespace WriteFile;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        string path = "./TextFile.txt";
        // program.AppendText(path);
        // program.AddingTextUsingArrays(path);
        program.Write(path);



    }

    // This method appends text to a file at the specified path.
    public void AppendText(string path)
    {
        // Create a StreamWriter that appends text to the file.
        using (StreamWriter sw = File.AppendText(path))
        {
            // Prompt the user to enter text.
            Console.WriteLine("Enter text(or exit to quit): ");

            // Read the first line of text from the user.
            string input = Console.ReadLine();

            // Continue reading lines from the user until they enter "exit".
            while (input.Trim().ToLower() != "exit")
            {
                // Write the user's input to the file.
                sw.WriteLine(input);

                // Read the next line of text from the user.
                input = Console.ReadLine();
            }
        }

        // Notify the user that the text has been written to the file.
        Console.WriteLine("Text written to file successfully.");
    }

    // This method writes an array of strings and a single string to a file at the specified path.
    public void AddingTextUsingArrays(string path)
    {
        // Define an array of words to write to the file.
        string[] words = { "Hello", ",my", "name", "is", "Vladimir", ",I study in Germany" };

        // Write the array of words to the file, overwriting any existing content.
        File.WriteAllLines(path, words);

        // Define a sentence to write to the file.
        string sentence = "I dont know what to write, basically nothing";

        // Write the sentence to the file, overwriting any existing content.
        File.WriteAllText(path, sentence);

        // Notify the user that the text has been written to the file.
        Console.WriteLine("Text written to file successfully.");
    }

    public void Write(string path)
    {
        // Create a StreamWriter that writes to the file at the specified path.
        StreamWriter sm = new StreamWriter(path);

        // Write a string to the file. This does not add a newline at the end.
        sm.Write("Some text i am writing");

        // Write another string to the file. This will be appended directly after the previous string.
        sm.Write("Some text i am writing - 2");

        // Write a third string to the file. This will be appended directly after the previous string.
        sm.Write("Some text i am writing - 3");

        // Close the StreamWriter. This flushes any remaining data to the file, releases any system resources
        // associated with the writer, and makes the file available for reading by other processes.
        sm.Close();
    }
}
