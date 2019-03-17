using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While_loops_and_complex_logic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user to think of a number between 0 and 100
            Console.WriteLine("I want you to think of a number between 0 an 100. OK?");
            Console.ReadLine();

            // Definder maximum number the user can guess
            int max = 100;

            // Keep track of number of guesses
            int guesses = 0;

            // The start guess from
            int guessMin = 0;

            // The start guess to (half of the max)
            int guessMax = max / 2;

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
                else
                {
                    Console.WriteLine($"You anwsered no");
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
