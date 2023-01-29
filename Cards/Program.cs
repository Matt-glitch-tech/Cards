﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class CardGame
{
    private static void Main(string[] args)
    {
        try
        {
            //Reading all the lines in the CardPlayers.txt file
            string[] lines = File.ReadAllLines(@"C:\Users\Matthew\Desktop\CardPlayers.txt");
            Console.WriteLine("Contents of CardPlayers.txt = ");

            int winnerScore = 0;
            string winnerName = "";
            //int suitScore = 0;
            int win = 0;
            var items = new List<object>();


            foreach (string line in lines)
            {
                var player = line.Substring(0, line.IndexOf(':'));
                var cards = line.Substring(line.IndexOf(':') + 1).Split(',').ToList();
                int playerScore = CardGame.CalculateScore(cards);
                int suitScore = CardGame.CalculateWinner(cards);

                if (winnerScore == playerScore && (suitScore < playerScore))
                {
                    winnerName = player;
                }
                else if (winnerScore < playerScore)
                {
                    winnerName = player;
                    winnerScore = playerScore;
                }
                //if (winnerScore == playerScore)
                //{
                //    winnerName = winnerName + "," + player;
                //}
                //else
                //{
                //    winnerName = player;
                //}
                //winnerScore = playerScore;
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


                //Console.WriteLine(winnerScore);
                Console.WriteLine(winnerName + ": " + winnerScore + " SuitScore: " + suitScore);
                //Console.WriteLine(suitScore);

                items.Add(winnerName + ": " + winnerScore + " SuitScore: " + suitScore);

                //Console.ReadLine();OrderItems.Select(o => o.ToString()
            }

            //List<object> itemResult = new List<object>();
            //var testing = "";

            //for (int i = 0; i < items.Count; i++)
            //{
            //    testing = items[i].ToString();

            //}

            //var displayItems = "";
            //foreach (var itemResult in stringArray)
            //{
            //    Console.WriteLine(itemResult);
            //    displayItems = itemResult;

            //}
            //var test = items.ForEach(item => items.Take(0));

            //
            string item = string.Join("\n", items);
            string createText = "Card Game Results " + Environment.NewLine + item;

            File.WriteAllText(@"C:\Users\Matthew\Desktop\CardGame.txt", createText);
            Console.WriteLine("Press any key to exit.");
        }catch (FileNotFoundException e)
        {
            Console.WriteLine("File does not exist or cannot find the file. Please create the file with random players and their cards.", e.ToString());
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
        // Here I sort the array which sorts it from smallest to biggest, that is why i use the reverse in the next line to change it to biggest to smallest.
        intArray.Sort();
        intArray.Reverse();
        //so that with this next line i can take the first 3 biggest items from the array and then sum them up.
        int playerScore = intArray.Take(3).Sum();
        return playerScore;
    }

    private static int CalculateWinner(List<string> cards)
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