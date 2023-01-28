using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

internal class CardGame
{
    private static string? line;

    public static IOrderedEnumerable<int> Array { get; private set; }

    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"C:\Users\Matthew\Desktop\CardPlayers.txt");
        Console.WriteLine("Contents of CardPlayers.txt = ");
        var allPlayerHands = GetPlayerDetails(lines);

        Console.WriteLine("Press any key to exit.");

        //Console.ReadKey();

        //var line = "Player1:JS,2S,6C,3C,2H";
        // var winner = CalculateWinner(new List<string> { line });
        //var A = Console.ReadLine();
        Console.ReadLine();
    }
    //var str = "2D,AS,AD,9H,3C";

    //var cards = str.Split(',');
    //        foreach (var card in cards)
    //        {
    //            //construct an int array that correlates to the values of the cards ignoring the suit
    //            //
    //            var intArray = new List<int>();
    //            switch (card[0])
    //            {
    //                case 'a':
    //                    intArray.Add(11);
    //                    break;
    //            }
    //            /*
    //             * more code here
    //             * 
    //             */
    //        }
    //        var i = new int[] { 2, 11, 11, 9, 3 };
    public class PlayerResult
    {
       public string Name { get; set; }
       public int score { get; set; }
    }
    private static List<PlayerHand> GetPlayerDetails(string[] lines)
    {

        //        Outside of all your loops, create an object to hold them maybe a dictionary < string,in> for < name, score >

        //Or a list of PlayerResult

        //Publoc class PlayerResult
        //    {
        //        String name …;
        //        Int score …;
        //    }
        //    And then add each player name and result to that list

        int winnerScore = 0;
        string winnerName = "";
        int actualWinner = 0;
        int win = 0;

        //var result = new List<PlayerHand>();
        var allPlayers = new List<PlayerHand>();

        foreach (string line in lines)
        {
            var player = line.Substring(0, line.IndexOf(':'));
            var cards = line.Substring(line.IndexOf(':') + 1).Split(',').ToList();
            int score = CardGame.CalculateScore(cards);

            if (winnerScore <= score)
            {
                if (winnerScore == score)
                {
                    winnerName = winnerName + "," + player;
                }
                else
                {
                    winnerName = player;
                }
                winnerScore = score;
                //if (winnerScore <= win)
                //{
                //    if (winnerScore == win)
                //    {
                //        winnerName = winnerName + "," + player;
                //    }
                //    else 
                //    { 
                //        winnerName = player; 
                //    }
                //    win = winnerScore;
                //    actualWinner = CardGame.CalculateWinner(cards);
                //    if (actualWinner.Equals(actualWinner))
                //    {

                //        Console.WriteLine(winnerName + ": It is a tie.");
                //        Console.WriteLine(actualWinner);
                //    }
                //}
            }

            Console.WriteLine(winnerScore);
            Console.WriteLine(winnerName);
            Console.WriteLine(actualWinner);

            //card use switch case
            //var card = line.Substring();
            //var d = cards.Distinct();



            //allPlayers.Add(new PlayerHand { Name = player, Cards = cards });

        }
        return allPlayers;
    }

    private static int CalculateScore(List<string> cards)
    {
        var intArray = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            //construct an int array that correlates to the values of the cards ignoring the suit
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
                //case '1':
                //    intArray.Add(10);
                //    break;
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
        intArray.Sort();
        intArray.Reverse();

        int score = intArray.Take(3).Sum();
        return score;
    }

    private static int CalculateWinner(List<string> cards)
    {
        //foreach (var item in list)
        //{
        //    var index = item.IndexOf(':');
        //    var name = item.Substring(0, index - 1);
        //    // split the rest of the string starting at the index, split the rest of the sting from JS to 2H.
        //    // split method to do the splitting, it will generate a string array.
        //    //char[] separator = { ',', ' ' };
        //    //string[] cards = item.Split((char)index);
        //    //string[] card = item.Split(separator);
        //}


        var intArray = new List<int>();
        for (int i = 0; i < cards.Count; i++)
        {
            //construct an int array that correlates to the values of the cards ignoring the suit
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
        intArray.Sort();
        intArray.Reverse();

        int score = intArray.Take(3).Sum();
        return score;

    }
}

public class PlayerHand
{
    public string Name { get; set; }
    public List<string> Cards { get; set; }
}

//internal class Program
//{

//}
//public class Program
//{

//    //Player1:JS,2S,6C,3C,2H
//    //Player2:6D,8C,6D,AH,8H
//    //Player3:5H,AC,4D,9S,10C
//    //Player4:3C,8S,5D,JC,8D
//    //Player5:KC,2C,QD,7H,4H


//    public static void Main()
//    {

//        string[] playerData = Program.readDataFromFile();
//        int winnerScore = 0;
//        string winnerName = "";
//        for (int i = 0; i < 5; i++)
//        {
//            string[] data = playerData[i].Split(':');
//            string player = data[0];
//            string cards = data[1];
//            int score = Program.calculateScore(cards);

//            if (winnerScore <= score)
//            {
//                if (winnerScore == score)
//                {
//                    winnerName = winnerName + "," + player;
//                }
//                else
//                {
//                    winnerName = player;
//                }
//                winnerScore = score;
//            }
//        }

//        System.Console.WriteLine(winnerScore);
//        System.Console.WriteLine(winnerName);
//    }

//    public static string[] readDataFromFile()
//    {
//        return new string[5] {
//        "Player1:JS,2S,6C,3C,2H",
//        "Player2:6D,8C,6D,AH,8H",
//        "Player3:5H,AC,4D,9S,10C",
//        "Player4:3C,8S,5D,JC,8D",
//        "Player5:KC,2C,QD,7H,4H"};
//    }

//    public static int calculateScore(string data)
//    {
//        string[] cards = data.Split(',');

//        int score = 0;
//        for (int i = 0; i < 5; i++)
//        {
//            char cardValue = cards[i][0];

//            switch (cardValue)
//            {
//                case 'A':
//                    score += 11;
//                    break;
//                case '2':
//                    score += 2;
//                    break;
//                case '3':
//                    score += 3;
//                    break;
//                case '4':
//                    score += 4;
//                    break;
//                case '5':
//                    score += 5;
//                    break;
//                case '6':
//                    score += 6;
//                    break;
//                case '7':
//                    score += 7;
//                    break;
//                case '8':
//                    score += 8;
//                    break;
//                case '9':
//                    score += 9;
//                    break;
//                //case "10":
//                //    score += 10;
//                //    break;
//                case 'J':
//                    score += 11;
//                    break;
//                case 'Q':
//                    score += 12;
//                    break;
//                case 'K':
//                    score += 13;
//                    break;
//            }
//        }
//        return score;
//    }

//    public void SaveToFile(string data)
//    {
//    }
//}