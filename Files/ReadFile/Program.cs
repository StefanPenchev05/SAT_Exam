namespace ReadFile;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        string path = "./TextFile.txt";

        program.ReadText(path);
        program.ReadCharacters(path);
    }

    public void ReadText(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line = "";

        while((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }

        sr.Close();
    }

    public void ReadCharacters(string path)
    {
        StreamReader sr = new StreamReader(path);
        char c;

        while((c = (char)sr.Read()) != -1)
        {
            Console.WriteLine(c);
        }

        sr.Close();
    }

}
