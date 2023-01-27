using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

internal class Program
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
        string Name;
        int score;
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



            var result = new List<PlayerHand>();
        var allPlayers = new List<PlayerHand>();

        //var player = lines.Substring(0, line.IndexOf(':'));
        //var cards = lines.Substring(line.IndexOf(':') + 1).Split(',').ToList();

        foreach (string line in lines)
        {
            var player = line.Substring(0, line.IndexOf(':'));
            var cards = line.Substring(line.IndexOf(':') + 1).Split(',').ToList();
            var score = 0;
            //card use switch case
            //var card = line.Substring();
            var d = cards.Distinct();

            //var i = new int[] { };
            //var str = cards.Split(',');
            var i = new int[] { };
            //var intArray = new List<int>();
            var intArray = Array.DefaultIfEmpty<int>();
            foreach (var card in cards)
            {
                //construct an int array that correlates to the values of the cards ignoring the suit
                //

                var str = "2D,AS,AD,9H,3C";

                //var cards = str.Split(',');
                //foreach (var card in cards)
                //{
                    //construct an int array that correlates to the values of the cards ignoring the suit
                    //

                    var count = 0;
                    switch (card[0])
                    {
                        case 'A':
                            //intArray.Add(11);
                        i = intArray.Append(11).ToArray();
                        count++;
                        break;
                        case 'J':
                            //intArray.Add(11);
                        i = intArray.Append(11).ToArray();
                        count++;
                        break;
                        case '2':
                        //intArray.Add(2);
                        i = intArray.Append(2).ToArray();
                        count++;
                        break;
                }
                /*
                 * more code here
                 * 
                 */
                
                //}
                
                //i = intArray.Append(11).ToArray();


                //var intArray = new List<int>();
                //switch (card[0])
                //{
                //    case 'A':
                //        intArray.Add(11);
                //        break;
                //    case '2':
                //        intArray.Add(2);
                //        break;
                //    case '3':
                //        intArray.Add(3);
                //        break;
                //    case '4':
                //        intArray.Add(4);
                //        break;
                //    case '5':
                //        intArray.Add(5);
                //        break;
                //    case '6':
                //        intArray.Add(6);
                //        break;
                //    case '7':
                //        intArray.Add(7);
                //        break;
                //    case '8':
                //        intArray.Add(8);
                //        break;
                //    case '9':
                //        intArray.Add(9);
                //        break;
                //case '10':
                //    intArray.Add(10);
                //    break;
                //    case 'J':
                //        intArray.Add(11);
                //       var j = card[0+1];
                //        break;
                //    case 'Q':
                //        intArray.Add(12);
                //        break;
                //    case 'K':
                //        intArray.Add(13);
                //        break;

                //   default:
                //        intArray.Add(10);
                //        break;
                //}
                /*
                 * more code here
                 * 
                 */


                //i = intArray.ToArray();

                //Array = i.Order();

                //var threeMaxNum = array.Take(3);
                //score = i.Sum();
            }
            //var i = new int[] {11, 2, 6, 3, 2};


            foreach (var card in cards)
            {
                //if (card[0] == 'a') {
                //    score += 11;
                //} else if

                //distinct method add all cards to 1 single array. 
                var str = card.Trim();
                switch(str[0])
                {
                    case 'A':
                        score += 11;
                        break;
                    case '2':
                        score += 2;
                        break;
                    case '3':
                        score += 3;
                        break;
                    case '4':
                        score += 4;
                        break;
                    case '5':
                        score += 5;
                        break;
                    case '6':
                        score += 6;
                        break;
                    case '7':
                        score += 7;
                        break;
                    case '8':
                        score += 8;
                        break;
                    case '9':
                        score += 9;
                        break;
                    //case "10":
                    //    score += 10;
                    //    break;
                    case 'J':
                        score += 11;
                        break;
                    case 'Q':
                        score += 12;
                        break;
                    case 'K':
                        score += 13;
                        break;
                }
            }
            

            allPlayers.Add(new PlayerHand { Name = player, Cards = cards });
            score = CalculateScore(cards);
        }
        return allPlayers;
    }

    private static int CalculateScore(List<string> allPlayerHands)
    {

        throw new NotImplementedException();
    }

    private static string CalculateWinner(List<string> list)
    {
        foreach (var item in list)
        {
            var index = item.IndexOf(':');
            var name = item.Substring(0, index-1);
            // split the rest of the string starting at the index, split the rest of the sting from JS to 2H.
            // split method to do the splitting, it will generate a string array.
            //char[] separator = { ',', ' ' };
            //string[] cards = item.Split((char)index);
            //string[] card = item.Split(separator);
        }

        throw new NotImplementedException();
    }
}

public class PlayerHand
{
    public string Name { get; set; }
    public List<string> Cards { get; set; }
}