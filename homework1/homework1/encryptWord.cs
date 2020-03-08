using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Name: Rueben Tiow
// Last Modification: 1/8/2017
// File: encryptWord.cs
// Purpose: This is an encryptWord class that supports multiples functions. The purpose of this
// class is to contain the functions intended to be used in the driver. The class essentially
// implements methods for a Caesar Cipher Shift: Applying the Caesar Shift, Turning on or off 
// the Caesar Shift, displaying user statistics, and checking user's guess functions.
//The data being used and operations done within the class is emphasizing OOP tenets: abstraction, 
//encapsulation, and information hiding.
namespace homework1
{
    class encryptWord
    {
        //Member Variables
        private const int SIZE = 50;
        private char[] ShiftedWord;
        //private string OriginalWord;
        private int NumQueries;
        private int NumHighGuess;
        private int NumLowGuess;
        private int NumAvgGuess;
        private bool OnOffState;
        private int SumOfGuesses;
        private int TotalGuesses;
        private int RndShiftVal;

        // Member Methods
        // Default constructor: This default constructor is used to initialize all the values
        // that will be used in this game
        public encryptWord(int val)
        {
            RndShiftVal = val;
            NumQueries = 0;
            NumHighGuess = 0;
            NumLowGuess = 0;
            NumAvgGuess = 0;
            OnOffState = true; // true for on. false for off. 
            SumOfGuesses = 0;
            TotalGuesses = 0; 
        }
        //ApplyCaesarShift: This function is used for the application programmer to pass in any
        // word and applys a caesar ciper shift based on the shiftvalue. If the word passed into
        // the function is less than 4 letters, it will not be accepted. Otherwise it will determine
        // whether you have turned on the CaesarCipher Shift or not, before finally applying the shift.
        public string ApplyCaesarShift(string AnyWord)
        {
            char[] GivenWord = new char[AnyWord.Length]; // Intended to convert the string and store to char array
            ShiftedWord = new char[AnyWord.Length];
            for (int i = 0; i < AnyWord.Length; i++)
            {
                GivenWord[i] = Convert.ToChar(AnyWord[i]);
            }
            if (AnyWord.Length < 4) // Invalid word, must be 4 letters or more.
            {
                return ""; 
            }
            else 
            {
                if (OnOffState == true) // Makes sure the caesar cipher shift is turned on
                {
                    int result = 0;
                    int AdjustedAns = 0;
                    for (int i = 0; i < AnyWord.Length; i++)
                    {
                        result = Convert.ToInt32(GivenWord[i]) + RndShiftVal; // First convert word to integer and add shift value
                        if (result > 122) // Do not allow to overgrow from Lower case alphabets
                        {
                            AdjustedAns = result - 26;
                            ShiftedWord[i] = Convert.ToChar(AdjustedAns);
                        }
                        else if (result >= 97 && result <= 122)
                        {
                            ShiftedWord[i] = Convert.ToChar(result); // Then convert back each shifted value into a char and store it
                        }
                    }
                }
                else if (OnOffState == false) // Return the word back if the CaesarCiper Shift is turned off.
                {
                    return AnyWord;
                }
                string encryptedWord = new string(ShiftedWord); // Convert char back to string
                return encryptedWord;
            }
        }
        // Description: Simply the reverse of the encryption function that decrypts it
        public string decryptWord(string AnyWord)
        {
            char[] GivenWord = new char[AnyWord.Length]; // Intended to convert the string and store to char array
            ShiftedWord = new char[AnyWord.Length];
            for (int i = 0; i < AnyWord.Length; i++)
            {
                GivenWord[i] = Convert.ToChar(AnyWord[i]);
            }
            if (AnyWord.Length < 4) // Invalid word, must be 4 letters or more.
            {
                return "";
            }
            else
            {
                if (OnOffState == true) // Makes sure the caesar cipher shift is turned on
                {
                    int result = 0;
                    int AdjustedAns = 0;
                    for (int i = 0; i < AnyWord.Length; i++)
                    {
                        result = Convert.ToInt32(GivenWord[i]) - RndShiftVal; // First convert word to integer and add shift value
                        if (result < 97) // Do not allow to overgrow from Lower case alphabets
                        {
                            AdjustedAns = result + 26;
                            ShiftedWord[i] = Convert.ToChar(AdjustedAns);
                        }
                        else if (result >= 97 && result <= 122)
                        {
                            ShiftedWord[i] = Convert.ToChar(result); // Then convert back each shifted value into a char and store it
                        }
                    }
                }
                else if (OnOffState == false) // Return the word back if the CaesarCiper Shift is turned off.
                {
                    return AnyWord;
                }
                string decryptedWord = new string(ShiftedWord); // Convert char back to string
                return decryptedWord;
            }

        }

        //CheckUserGuess: This function is used to check the users guess of the Caesar cipher
        // shift matches correctly with the actual shifted value applied onto the given word.
        // This function also returns an integer that indicates the result. 
        // Input out of bounds: -1
        // Input in bounds and correctly guessed = 1
        // Input in bounds and incorrectly guessed too high = 2
        // Input in bounds and incorrectly guessed too high = 3
        public int CheckUserGuess(int GuessNum) // Check if your guess is correct for the shift value
        {
            int TheAns = 0;
            int[] Storage = new int[SIZE];

            int CheckValid = GuessNum;
            if (CheckValid < 0) // Invalid input
            {
                return -1;
            }
            else if (CheckValid > 25) // Invalid input
            {
                return -1;
            }
            else // Valid input
            {
                if (GuessNum == RndShiftVal) // Guessed Correctly
                {
                    NumQueries++;
                    Storage[TotalGuesses++] = GuessNum;
                    TheAns = 1;
                }
                else if (GuessNum > RndShiftVal) // Guessed Incorrectly, too high
                {
                    NumQueries++;
                    NumHighGuess++;
                    Storage[TotalGuesses++] = GuessNum;
                    TheAns = 2;
                }
                else if (GuessNum < RndShiftVal) // Guessed Incorrectly, too low
                {
                    NumQueries++;
                    NumLowGuess++;
                    Storage[TotalGuesses++] = GuessNum;
                    TheAns = 3;
                }
                // This part is used to calculate the average guess value that the
                // user guessed from all the guesses they have made
                for (int i = 0; i < Storage.Length; i++)
                {
                    SumOfGuesses += Storage[i];
                }
                NumAvgGuess = SumOfGuesses / TotalGuesses; // Will return integer and not floating point number.

                return TheAns;
            }
        }

        //DisplayStatistics: This function is used to pass in a number that represents a specific
        // statics that user would like to print out. A menu will be display to direct what number
        // represents which kind of statistic.
        public int DisplayStatistics(int WhichStatistic)
        {
            if (WhichStatistic == 1)
                return NumQueries;
            else if (WhichStatistic == 2)
                return NumHighGuess;
            else if (WhichStatistic == 3)
                return NumLowGuess;
            else if (WhichStatistic == 4)
                return NumAvgGuess;
            else
                return 0;
        }

        //PerformOnOffState: This function is used to adjust the state of the program.
        //The user is allowed to choose to turn on or off the Caesar Cipher shift or
        // apply an entire reset.
        public void PerformOnOffState(int ChosenState)
        {
            if (ChosenState == 1) // Will suggest a menu where 1 is to turn on the Caesar cipher shift.
                OnOffState = true;
            else if (ChosenState == 2) // Will suggest a menu where 2 is to turn off the Caesar cipher shift.
                OnOffState = false;
            else if (ChosenState == 3) // Will suggest a menu where 3 is to reset the entire game.
            {
                //Resetting makes the game restarts the game from the beginning
                ShiftedWord = new char[SIZE];
                NumQueries = 0;
                NumHighGuess = 0;
                NumLowGuess = 0;
                NumAvgGuess = 0;
                OnOffState = true;
            }
        }
        //  Description: returns the correct shift to the AP
        public int DisplayShift()
        {
            return RndShiftVal;
        }
    }
}
