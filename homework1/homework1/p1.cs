using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Name: Rueben Tiow
// Last Modification: 1/24/2017
// Version: 1.2
// File: encryptWord.cs
// Purpose: The purpose of this class is the to exercise the functions
// created in the encryptWord class. That is, this is the driver that
// sets up and executes the encryptWord class methods. In essence, my driver will
// show that each method implemented in the class works as intended: Applying the 
// Caesar Shift, Turning on or off the Caesar Shift, displaying user statistics, 
// and checking user's guess functions.

namespace homework1
{
    class Driver
    {
        const string WORD1 = "cat";
        const string WORD2 = "zebra";
        static void Main(string[] args)
        {
            // GenerateShiftValue: This is to generate a random shift value in between 0 to 25. I excluded
            // 26 because that is the same answer as giving 0. 
            Random rnd = new Random();
            int ShiftValue = rnd.Next(0, 25);
            encryptWord MyEncryptWord = new encryptWord(ShiftValue);

            // Testing the random function generated in the driver to ensure a number was
            // generated between 0 to 25.
            Console.WriteLine("Testing to confirm that in fact a random number was generated between 0 to 25");
            Console.WriteLine("The ShiftValue is: {0} \n", ShiftValue);

            // Testing the ApplyCaesarShift function here to show that words less than 4 are not accepted
            Console.WriteLine("Testing the ApplyCaesarShift function with WORD1 stored.");
            Console.WriteLine("The word {0} encrypted is: {1}\n", WORD1, MyEncryptWord.ApplyCaesarShift(WORD1));

            Console.WriteLine("Testing the ApplyCaesarShift function with WORD2 stored");
            Console.WriteLine("The word {0} encrypted is: {1}", WORD2, MyEncryptWord.ApplyCaesarShift(WORD2));

            string five = MyEncryptWord.ApplyCaesarShift(WORD2);
            
            Console.WriteLine("Testing the decryptWord function with WORD2 stored");
            Console.WriteLine("The word {0} decrypted is: {1}", five, MyEncryptWord.decryptWord(five));

            // Testing the CheckUserGuess function to validate correct outputs from the user's guess.
            // Testing 10 guesses.
            Console.WriteLine("Testing the CheckUserGuess function to see if guessed correctly or wrongly");
            Console.WriteLine("The number guessed is 3 and the result is: {0}", MyEncryptWord.CheckUserGuess(3));
            Console.WriteLine("The number guessed is 4 and the result is: {0}", MyEncryptWord.CheckUserGuess(4));
            Console.WriteLine("The number guessed is 5 and the result is: {0}", MyEncryptWord.CheckUserGuess(5));
            Console.WriteLine("The number guessed is 6 and the result is: {0}", MyEncryptWord.CheckUserGuess(6));
            Console.WriteLine("The number guessed is 7 and the result is: {0}", MyEncryptWord.CheckUserGuess(7));
            Console.WriteLine("The number guessed is 25 and the result is: {0}", MyEncryptWord.CheckUserGuess(25));
            Console.WriteLine("The number guessed is 24 and the result is: {0}", MyEncryptWord.CheckUserGuess(24));
            Console.WriteLine("The number guessed is 23 and the result is: {0}", MyEncryptWord.CheckUserGuess(23));
            Console.WriteLine("The number guessed is 22 and the result is: {0}", MyEncryptWord.CheckUserGuess(22));
            Console.WriteLine("The number guessed is 21 and the result is: {0}", MyEncryptWord.CheckUserGuess(21));

            // This portion of CheckUserGuess is to check values that are out of bounds. Integers
            // given from the user that are outside the range of 0 to 25 will not be accepted as an answer.
            // This is assumed that they decided to guess outside the bounds of 0 to 25.
            Console.WriteLine("The number guessed is 27 and the result is: {0}", MyEncryptWord.CheckUserGuess(27));
            Console.WriteLine("The number guessed is -7 and the result is: {0}\n", MyEncryptWord.CheckUserGuess(-7));

            //Testing the DisplayStatistics Function here to print our results
            Console.WriteLine("Testing the DisplayStatistics function, to print each individual statistic");
            Console.WriteLine("The number of queries are: {0}", MyEncryptWord.DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", MyEncryptWord.DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", MyEncryptWord.DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", MyEncryptWord.DisplayStatistics(4));

            //Testing the game with the Caesar Cipher Shift applied onto the provided word
            Console.WriteLine("Testing PerformOnOffState function:");
            Console.WriteLine("Turning on the Caesar Shift");
            MyEncryptWord.PerformOnOffState(1);
            Console.WriteLine("Testing the ApplyCaesarShift function with WORD2 stored and Caesar Shift turned on");
            Console.WriteLine("The word {0} encrypted is: {1}", WORD2, MyEncryptWord.ApplyCaesarShift(WORD2));

            //Testing the game with the Caesar Cipher Shift not applied onto the provided word
            Console.WriteLine("Turning off the Caesar Shift");
            MyEncryptWord.PerformOnOffState(2);
            Console.WriteLine("Testing the ApplyCaesarShift function with WORD2 stored and Caesar Shift turned off");
            Console.WriteLine("The word {0} encrypted is: {1}\n", WORD2, MyEncryptWord.ApplyCaesarShift(WORD2));

            //Testing the Reset Function here
            Console.WriteLine("Resetting the entire game");
            MyEncryptWord.PerformOnOffState(3);
            //Testing the DisplayStatistics Function here to confirm that the game indeed has reset.
            Console.WriteLine("The statistics have reset:");
            Console.WriteLine("The number of queries are: {0}", MyEncryptWord.DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", MyEncryptWord.DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", MyEncryptWord.DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", MyEncryptWord.DisplayStatistics(4));
            MyEncryptWord.PerformOnOffState(3);

        }
    }
}
