using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_WhileLoopAndComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of our number guesser class
            var numberGuesser = new NumberGuesser();

            // Change the default maximum number to 200
            numberGuesser.MaximumNumber = 200;

            // Ask the user to think of a number
            numberGuesser.InformUser();



            while (guessMin != max)
            {

                // Incrase guess amount (by 1)
                guesses++;

                // Ask the user if thier number is between the guess range
                Console.WriteLine($"Is your number between { guessMin } and { guessMax }?");
                string response = Console.ReadLine();

                // If the user confirmed thier number is within the current range...
                //bool hasResponse = (response != null && response.Length > 0);
                //if (hasResponse && (response[0] == 'y' || response[0] == 'Y'))

                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // We know the number is between guessTFrom and guessTo
                    // So set the new maximum number
                    max = guessMax;

                    // Change the next guess range to be half of the maximum range
                    guessMax = guessMax - (guessMax - guessMin) / 2;
                }
                // The number is greater than guessMax and less than or equal to max
                else
                {
                    // The new minimum is one above the old maximum
                    guessMin = guessMax + 1;

                    // Guess the bottom half of the new range
                    int remainingDifferance = max - guessMax;

                    // Set the guess max to half way between the guessMin and max
                    // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 1,1
                    guessMax += (int)Math.Ceiling(remainingDifferance / 2f);
                }

                // if we only have 2 numbers left, guess one of them
                if (guessMin + 1 == max)
                {
                    // Incrase guess amount (by 1)
                    guesses++;

                    // Ask the user if thier number is the lower number
                    Console.WriteLine($"Is your number { guessMin }?");
                    response = Console.ReadLine();

                    //if the user  confirmed thier number is the lower number...
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        // That means the number must be higher of the two
                        guessMin = max;
                        break;
                    }
                }
            } // End of while (guessMin != max)
            // Tell the user thier number
            Console.WriteLine($"** Your number is { guessMin } **");

            // Tell the user how many guessys it took
            Console.WriteLine($"Guessed in { guesses } guesses");
            Console.ReadLine();
        }
    }
}
