using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

using CommandLine;
using System.Windows.Input;
using System.Xml.Linq;

//public interface ICommand
//{
//    void Execute();
//}

//Spent some time learning and figuring out how to use this command line parser library
public class SomeOptions
{
    [Option('i', "in", Required = true, HelpText = "Set input path for the generated file.")]
    public string? In { get; set; }

    [Option('o', "out", Required = true, HelpText = "Set output path for the generated file.")]
    public string? Out { get; set; }
}

//[Verb("in", HelpText = "where the file is located")]
//public class InputCommand : ICommand
//{
//    [Option('i', "inPutPath", Required = true, HelpText = "Set input path for the generated file.")]
//    public string? InputPath { get; set; }
//    public void Execute()
//    {
//        Console.WriteLine("Executing Input");
//    }
//}

//[Verb("out", HelpText = "where the file is outputted to")]
//public class OutputCommand : ICommand
//{
//    [Option('o', "outPutPath", Required = true, HelpText = "Set output path for the generated file.")]

//    public string? OutputPath { get; set; }
//    public void Execute()
//    {
//        Console.WriteLine("Executing Output");
//    }
//}
internal class CardGame
{
    public static SomeOptions options { get; private set; }

    private static void Main(string[] args)
    {
        //Parser.Default.ParseArguments<InputCommand, OutputCommand>(args)
        //.WithParsed<ICommand>(t => t.Execute());
        Parser.Default.ParseArguments<SomeOptions>(args)
        .WithParsed(parsed => options = parsed);

        try
        {
            //Reading all the lines in the CardPlayers.txt file
            string[] lines = File.ReadAllLines(@"C:\Users\Matthew\Desktop\CardPlayers.txt");
            int winnerScore = 0;
            string winnerName = "";
            int winnerSuitScore = 0;
            int suitScore = 0;
            var player = "";

            var items = new List<object>();
            var tiePlayer = new List<object>();

            foreach (string line in lines)
            {
                player = line.Substring(0, line.IndexOf(':'));
                var cards = line.ToUpper().Substring(line.IndexOf(':') + 1).Split(',').ToList();
                int playerScore = CardGame.CalculateScore(cards);
                suitScore = CardGame.CalculateSuit(cards);

                if(winnerScore <= playerScore)
                {
                    if (playerScore > winnerScore)
                    {
                        winnerName = player;
                        winnerScore = playerScore;
                        winnerSuitScore = suitScore;
                    }
                    else if (winnerSuitScore > suitScore && playerScore == winnerScore)
                    {
                        winnerScore = playerScore;
                    }
                    else if(playerScore == winnerScore)
                    {
                        winnerName = player;
                        winnerSuitScore = suitScore;
                    }
                }
            }
            if(winnerSuitScore > suitScore)
            {
                Console.WriteLine(winnerName + "," + player + ": " + winnerSuitScore);
                tiePlayer.Add(winnerName + "," + player + ": " + winnerSuitScore);
                string tie = string.Join("\n", tiePlayer);
                string createTieText = "Card Game Results " + Environment.NewLine + tie;

                File.WriteAllText(@"C:\Users\Matthew\Desktop\CardGame.txt", createTieText);
            } 
            else
            {
                Console.WriteLine(winnerName + ": " + winnerScore);
                items.Add(winnerName + ": " + winnerScore);

                /* I tried to display the list of results for each player and their scores. This took me a while to get right because i tried using a foreach loop,
                 to get the data and then display it and save it to a file but then it would only save the last line of the player. So had to google quite a bit to find,
                 different answers and i finally found the join which is so simple that it didn't occure to me the first time to just join them at a new line.
                */
                string item = string.Join("\n", items);
                string createText = "Card Game Results " + Environment.NewLine + item;

                File.WriteAllText(@"C:\Users\Matthew\Desktop\CardGame.txt", createText);
                Console.WriteLine("Press any key to exit.");
            }
            
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File does not exist or cannot find the file. Please create the file with random players and their cards.", e.ToString());
            Console.WriteLine("Press any key to exit.");
        }
    }

    private static int CalculateScore(List<string> cards)
    {
        /*This part took a wile to figure out because I first tried getting each players hands of cards,
        and then going through it with the foreach loop. The foreach loop worked but everytime it stored the value in [0]
        it kept overwriting the next value in the [0]. So the first letter is J which is 11 then it would store 11 in [0].
        then when it goes to the next number which is a 2 then it would store that in [0] and then 11 would be gone so i changed to to a standard
        for loop and it fixed my problem.
        */
        var intArray = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            char cardValue = cards[i][0];
            switch (cardValue)
            {
                case 'A':
                    intArray.Add(11);
                    break;
                case '2':
                    intArray.Add(2);
                    break;
                case '3':
                    intArray.Add(3);
                    break;
                case '4':
                    intArray.Add(4);
                    break;
                case '5':
                    intArray.Add(5);
                    break;
                case '6':
                    intArray.Add(6);
                    break;
                case '7':
                    intArray.Add(7);
                    break;
                case '8':
                    intArray.Add(8);
                    break;
                case '9':
                    intArray.Add(9);
                    break;
                case '1':
                    intArray.Add(10);
                    break;
                case 'J':
                    intArray.Add(11);
                    break;
                case 'Q':
                    intArray.Add(12);
                    break;
                case 'K':
                    intArray.Add(13);
                    break;
            }
        }
        // Here I sort the array which sorts it from smallest to biggest, that is why i use the reverse in the next line to change it to biggest to smallest.
        intArray.Sort();
        intArray.Reverse();
        //so that with this next line i can take the first 3 biggest items from the array and then sum them up.
        int playerScore = intArray.Take(3).Sum();
        return playerScore;
    }

    private static int CalculateSuit(List<string> cards)
    {
        // This is where i calculate the suit value. I used the same logic as in the CalculateScore method.
        var intArray = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            char cardValue = cards[i][1];
            switch (cardValue)
            {
                case 'C':
                    intArray.Add(1);
                    break;
                case 'D':
                    intArray.Add(2);
                    break;
                case 'H':
                    intArray.Add(3);
                    break;
                case 'S':
                    intArray.Add(4);
                    break;
            }
        }
        // Here I sort the array which sorts it from smallest to biggest, that is why i use the reverse in the next line to change it to biggest to smallest.
        intArray.Sort();
        intArray.Reverse();
        //so that with this next line i can take the first 3 biggest items from the array and then sum them up.
        int suitScore = intArray.Take(3).Sum();
        return suitScore;
    }
}