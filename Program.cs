using System;
using System.Collections.Generic;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string winner = null;
            do
            {

                int random = RandomValue();
                int userGuesses = 0;
                int tickDown = 100;
                int randomAlgorithmTries = 0;
                int bruteForceAlgorithmTries = 0;
                int eliminationAlgorithmTries = 0;
                int randomAlgorithm = RandomValue();
                int numToGuess = EliminationAlg(userGuesses);
                int bruteForceAlgorithm = BruteForce(tickDown, random);
                int eliminationAlgorithm = EliminationAlg(numToGuess);

                do
                {
                    int userGuess = GetUserGuess();
                    randomAlgorithmTries++;
                    bruteForceAlgorithmTries++;
                    eliminationAlgorithmTries++;
                    tickDown--;
                    if (randomAlgorithm == random)
                    {
                        Console.WriteLine($"It took {randomAlgorithmTries} for the Random algorithm to find the number");
                        winner = "Random Algorithm";
                        break;
                    }
                    else if (bruteForceAlgorithm == random)
                    {
                        Console.WriteLine($"It took {bruteForceAlgorithmTries} for the Random algorithm to find the number");
                        winner = "Brute Force Algorithm";
                        break;
                    }
                    else if (eliminationAlgorithm == random)
                    {
                        Console.WriteLine($"It took {eliminationAlgorithmTries} for the Random algorithm to find the number");
                        winner = "Elimination Algorithm";
                        break;
                    }
                    else if (userGuess == random)
                    {
                        winner = "user";
                        break;
                    }
                    else
                    {
                        Console.WriteLine(Guess(userGuess, random));

                    }

                } 
                while (randomAlgorithm != random && eliminationAlgorithm != random && randomAlgorithm != random);
                Console.WriteLine($"It took {winner} tries to find the correct number");
            } 
            while (true);

        }


        public static int GetUserGuess()
        {
            while (true)
            {
                Console.WriteLine("Please guess a number between 1 and 100 and I will tell how close you are");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num < 1)
                    {
                        throw new Exception("That number is too small, please input a number between 1 and 100");
                    }
                    else if (num > 100)
                    {
                        throw new Exception("That number is too large, please input a number between 1 and 100");
                    }
                    return num;

                }
                catch (FormatException)
                {
                    Console.WriteLine("That was not a valid number please try again");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        public static string Guess(int guess, int secretNum)
        {
            if (guess == secretNum)
            {
                return "Match!";
            }
            int diff = guess - secretNum;
            diff = Math.Abs(diff);

            if (guess > secretNum)
            {
                if (diff > 10)
                {
                    return "Way too high!";
                }
                else
                {
                    return "too high!";
                }
            }
            else
            {
                if (diff > 10)
                {
                    return "Way too low!";
                }
                else
                {
                    return "too low!";
                }
            }
        }
        public static int RandomValue()
        {
            Random random = new Random();

            int rgv = random.Next(1, 101);

//rgv stands for randomly generated value
            return rgv;

        }
        public static int EliminationAlg(int numToGuess)
        {
            int computerGuess = 0;
            int guesses = 0;
            numToGuess = 0;
            List<int> exclude = new List<int>();
            while (computerGuess != numToGuess)
            {
                guesses++;
                Random Guess = new Random();
                computerGuess = Guess.Next(1, 101);
                if (!exclude.Contains(computerGuess))
                {
                    exclude.Add(computerGuess);
                    Console.WriteLine($"Computer Guess: {computerGuess}");
                }
                else if (computerGuess == numToGuess)
                {
                    Console.WriteLine($"Guess #{guesses}");

                }

            }
            return guesses;
        }
        public static int BruteForce(int tickDown,int random)
        {
            int tries = 0;
            while (tickDown != random)
            {
                tickDown--;
                tries++;

            }
            Console.WriteLine($"it took you {tries} to guess {random}");
            return tickDown;
        }
    }
}