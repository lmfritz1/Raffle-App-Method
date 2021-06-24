using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();

        }

        //Start writing your code here
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static string prompt = "Please enter your name:";
        private static string query = "Do you want to add another name?";
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string user = Console.ReadLine();

            while (string.IsNullOrEmpty(user))
            {
                Console.WriteLine("Please enter a name: ");
                user = Console.ReadLine();
            }
            return user;
        }
        private static void GetUserInfo()
        {   
            string name;
            string otherGuest;
            do
            {
                name = GetUserInput(prompt);
                raffleNumber = GenerateRandomNumber(min, max);
                AddGuestsInRaffle(raffleNumber, name);
                otherGuest = GetUserInput(query);
            }
            while (otherGuest == "yes");

        }

        private static int GenerateRandomNumber(int min, int max)
        {
            int randomNum = _rdm.Next(min, max);
            return randomNum;
        }

        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);

        }

        private static void PrintGuestsName()
        {
            foreach (var kvp in guests)
            {
                Console.WriteLine(kvp);
            }


        }

        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            int index = _rdm.Next(guests.Count);
            int key = guests.Keys.ElementAt(index);
            return key;

        }



        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");
        }
        //do
        //{








        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
