internal class Program
{
    private static string line;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // TODO Read input from text file
        string[] lines = File.ReadAllLines(@"C:\Users\Matthew\Desktop\CardPlayers.txt");
        Console.WriteLine("Contents of CardPlayers.txt = ");
        foreach (string line in lines)
        {
            Console.WriteLine("\t" + line);
        }
        Console.WriteLine("Press any key to exit.");
        //Console.ReadKey();

        //var line = "Player1:JS,2S,6C,3C,2H";
        var winner = CalculateWinner(new List<string> { line });
        //var A = Console.ReadLine();
        Console.ReadLine();
    }

    private static string CalculateWinner(List<string> list)
    {
        foreach (var item in list)
        {
            var index = item.IndexOf(':');
            var name = item.Substring(0, index-1);
            // split the rest of the string starting at the index, split the rest of the sting from JS to 2H.
            // split method to do the splitting, it will generate a string array.
            char[] separator = { ',', ' ' };
            string[] cards = item.Split((char)index);
            string[] card = item.Split(separator);
        }

        throw new NotImplementedException();
    }
}

public class PlayerHand
{
    public string Name { get; set; }
    public List<string> Cards { get; set; }
}