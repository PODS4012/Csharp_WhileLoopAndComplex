using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_WhileLoopAndComplex
{
    /// <summary>
    /// Asks the user to guess a number between a certain range and then guess that number in the fewest possible guesses
    /// </summary>
    public class NumberGuesser
    {
        #region Public Properties

        /// <summary>
        /// The largest number we ask the user to guess, between 0 and this number
        /// </summary>
        public int MaximumNumber { get; set; }

        /// <summary>
        /// The current number of guesses the computer has had
        /// </summary>
        public int CurrentNumberOfGuesses { get; private set; }

        /// <summary>
        /// The current known minimum number the user is thinking of
        /// </summary>
        public int CurrentGuessMinimum { get; private set; }

        /// <summary>
        /// The current known maximum number the user is thinking of
        /// </summary>
        public int CurrentGuessMaximum { get; private set; }

        #endregion

        #region .ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NumberGuesser()
        {
            // Set default maximum number
            this.MaximumNumber = 100;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Asks the user to think of a number between 0 and the maximum number
        /// </summary>
        public void InformUser()
        {
            // Ask user to think of a number between 0 and MaximumNumber.
            Console.WriteLine($"I want you to think of a number between 0 an { this.MaximumNumber }. OK?");
            Console.ReadLine();
        }

        /// <summary>
        /// Ask the user a series of questions to discover the number they are thinking of
        /// </summary>
        public void DiscoverNumber()
        {
            // Clear variables to thier initial values before a discovery
            this.CurrentNumberOfGuesses = 0;
            this.CurrentGuessMinimum = 0;
            this.CurrentGuessMaximum = this.MaximumNumber / 2;

            // While the guess isn't the same as the known maximum value
            while (this.CurrentGuessMinimum != this.CurrentGuessMaximum)
            {

                // Incrase guess amount (by 1)
                this.CurrentNumberOfGuesses++;

                // Ask the user if thier number is between the guess range
                Console.WriteLine($"Is your number between { this.CurrentGuessMinimum } and { this.CurrentGuessMaximum }?");
                string response = Console.ReadLine();

                // If the user confirmed thier number is within the current range...
                //bool hasResponse = (response != null && response.Length > 0);
                //if (hasResponse && (response[0] == 'y' || response[0] == 'Y'))

                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // We know the number is between guessTFrom and guessTo
                    // So set the new maximum number
                    this.MaximumNumber = this.CurrentGuessMaximum;

                    // Change the next guess range to be half of the maximum range
                    this.CurrentGuessMaximum = this.CurrentGuessMaximum - (this.CurrentGuessMaximum - this.CurrentGuessMinimum) / 2;
                }
                // The number is greater than guessMax and less than or equal to max
                else
                {
                    // The new minimum is one above the old maximum
                    this.CurrentGuessMinimum = this.CurrentGuessMaximum + 1;

                    // Guess the bottom half of the new range
                    int remainingDifferance = this.MaximumNumber - this.CurrentGuessMaximum;

                    // Set the guess max to half way between the guessMin and max
                    // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 1,1
                    this.CurrentGuessMaximum += (int)Math.Ceiling(remainingDifferance / 2f);
                }

                // if we only have 2 numbers left, guess one of them
                if (this.CurrentGuessMinimum + 1 == this.MaximumNumber)
                {
                    // Incrase guess amount (by 1)
                    this.CurrentNumberOfGuesses++;

                    // Ask the user if thier number is the lower number
                    Console.WriteLine($"Is your number { this.CurrentGuessMinimum }?");
                    response = Console.ReadLine();

                    //if the user  confirmed thier number is the lower number...
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        // That means the number must be higher of the two
                        this.CurrentGuessMinimum = this.MaximumNumber;
                        break;
                    }
                }
            } // End of while (guessMin != max)

        }

        /// <summary>
        /// Announces the number the user was thinking of and the number of guesses it took 
        /// </summary>
        public void AnnounceResults()
        {
            // Tell the user thier number
            Console.WriteLine($"** Your number is { this.CurrentGuessMinimum } **");

            // Tell the user how many guessys it took
            Console.WriteLine($"Guessed in { this.CurrentNumberOfGuesses } guesses");
            Console.ReadLine();
        }

        #endregion
    }
}
