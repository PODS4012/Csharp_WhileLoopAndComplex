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

        /// <summary>
        /// Asks the user to think of a number between 0 and the maximum number
        /// </summary>
        public void InformUser()
        {
            // Ask user to think of a number between 0 and MaximumNumber.
            Console.WriteLine($"I want you to think of a number between 0 an { this.MaximumNumber }. OK?");
            Console.ReadLine();
        }
    }
}
