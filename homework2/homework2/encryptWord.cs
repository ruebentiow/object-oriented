// Name: Rueben Tiow
// Last Modification: 1/26/2017
// File: encryptWord.cs
// Version: 1.1
// Purpose: This is an encryptWord class that supports multiples functions. The purpose of this
// class is to contain the functions intended to be used in the driver. The class essentially
// implements methods for a Caesar Cipher Shift: Applying the Caesar Shift, Turning on or off 
// the Caesar Shift, displaying user statistics, and checking user's guess functions.
// The data being used and operations done within the class is emphasizing OOP tenets: abstraction, 
// encapsulation, and information hiding.
//
// Class Invariants:
// - Maximum 2 possible states in each object: ON(true) and OFF(false)
// - ON: When an encryptWord object is turned on, the shift value is valid,
//   encrypt word, guessing and updating statistic functions become available.
// - OFF: When an encryptWord object is turned off, encrypt word, guessing and 
//   updating statistics functions become unavailable, while retaining statistics
//   collected up to the point of turning 'off'.
//
// Interface Invariants:
// - State can be altered through PerformOnOffState()
// - Every integer number used within this object fall 
//   between 0 to 25.
// - Every string passed into this object must be in lowercase 
//   alphabet letters.
// - Application programmer responsible for checking whether
//   object is empty prior to function calls. (i.e CheckUserGuess())
// - RndShiftVal cannot be changed after initial construction.
//
// Implementation Invariants:
// - Array implemention used to return encrptWords 
// - Array implemention used to return the average guess
// - SIZE is set to 100 to adequately satisfy any given English word
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class encryptWord
    {
        //Constant Variables
        private const int SIZE = 100;

        //Member Variables
        private char[] ShiftedWord;
        private int NumQueries;
        private int NumHighGuess;
        private int NumLowGuess;
        private int NumAvgGuess;
        private bool OnOffState;
        private int SumOfGuesses;
        private int TotalGuesses;
        private int RndShiftVal;
        private int UserGuessAns;

        //Default constructor suppressed.
        public encryptWord() { }


        // Overload constructor
        public encryptWord(int val)
        // PRE: N/A
        // POST: N/A
        // FUNCTIONS: N/A
        // IN: val
        // OUT: N/A
        // MOD: RndShiftVal, NumQueries, NumHighGuess, NumLowGuess,
        // NumAvgGuess, OnOffState, SumOfGuesses, TotalGuesses
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

        // Member Methods
        
        public string ApplyCaesarShift(string AnyWord)
        // ApplyCaesarShift: This function is used for the application programmer to pass in any
        // word and applys a caesar ciper shift based on the shiftvalue. If the word passed into
        // the function is less than 4 letters, it will not be accepted. Otherwise it will determine
        // whether you have turned on the CaesarCipher Shift or not, before finally applying the shift.
        //
        // PRE: - AnyWord must be in lowercase alphabets and be more than 3 letters
        // POST: - Returns the word shifted according to the shift value stored
        // FUNCTIONS: N/A
        // IN: AnyWord
        // OUT: encryptedWord
        // MOD: ShiftedWord        
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

        public string DecryptWord(string AnyWord)
        // DecryptWord: Simply the reverse of the ApplyCaesarShift function that decrypts it.
        // PRE: - AnyWord must be in lowercase alphabets and be more than 3 letters
        // POST: - Returns the word unshifted according to the shift value stored
        // FUNCTIONS: N/A
        // IN: AnyWord
        // OUT: DecryptedWord
        // MOD: ShiftedWord  
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
                string DecryptedWord = new string(ShiftedWord); // Convert char back to string
                return DecryptedWord;
            }

        }

        public int CheckUserGuess(int GuessNum)
        // CheckUserGuess: This function is used to check the users guess of the Caesar cipher
        // shift matches correctly with the actual shifted value applied onto the given word.
        // This function also returns an integer that indicates the result. 
        // PRE: - Object must not be empty. 
        //      - GuessNum must be an integer from 0 to 25
        // POST: - Returns a number that indicates a correct or an incorrect guess
        //       - Returns 1 if Correctly guessed
        //       - Returns 2 if Incorrectly guessed too high 
        //       - Returns 3 if Incorrectly guessed too low
        //       - AvgGuessNum is being calculated and adjusted from every entry
        // FUNCTIONS: N/A
        // IN: AnyWord
        // OUT: TheAns
        // MOD: ShiftedWord, NumQueries, NumHighGuess, NumLowGuess, NumAvgGuess
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
                NumAvgGuess = SumOfGuesses / TotalGuesses; 

                UserGuessAns = TheAns;
                return TheAns;
            }
        }

        public int DisplayStatistics(int WhichStatistic)
        // DisplayStatistics: This function is used to pass in a number that represents a specific
        // statics that user would like to print out. A menu will be display to direct what number
        // represents which kind of statistic.
        // NumQueries = 1 
        // NumHighGuess = 2
        // NumLowGuess = 3
        // NumAvgGuess = 4
        // PRE: - WhichStatistic must be an integer from 0 to 4
        // POST: - Returns a number that displays corresponding staticstics(i.e NumQueries)
        //       - If passed in prior to guessing at least once, it will show default statistics.
        // FUNCTIONS: N/A
        // IN: WhichStatistic
        // OUT: NumQueries, NumHighGuess, NumLowGuess, NumAvgGuess
        // MOD: N/A
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

        public void PerformOnOffState(int ChosenState)
        //PerformOnOffState: This function is used to adjust the state of the program.
        // The user is allowed to choose to turn on or off the Caesar Cipher shift or,
        // apply an entire reset.
        // Shift State turned on = 1 
        // Shift State turned off = 2
        // Full game reset = 3
        // PRE: - ChosenState must be an integer from 1 to 3
        // POST: - Returns nothing, changes the state of Caesar Shift between on and off, or a full game reset
        // FUNCTIONS: N/A
        // IN: WhichStatistic
        // OUT: N/A
        // MOD: NumQueries, NumHighGuess, NumLowGuess, NumAvgGuess, 
        // OnOffState, SumOfGuesses, TotalGuesses
        {
            if (ChosenState == 1) 
                OnOffState = true;
            else if (ChosenState == 2) 
                OnOffState = false;
            else if (ChosenState == 3)
            {
                //Resetting makes the game restarts the game from the beginning
                NumQueries = 0;
                NumHighGuess = 0;
                NumLowGuess = 0;
                NumAvgGuess = 0;
                OnOffState = true; // true for on. false for off
                SumOfGuesses = 0;
                TotalGuesses = 0;
            }
        }

        public int DisplayShift()
        // DisplayShift: Returns the correct shift value to the application programmer.
        // PRE: N/A
        // POST: - Returns the Random Shift Value
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: RndShiftVal
        // MOD: N/A
        {
            return RndShiftVal;
        }

        public bool DisplayState()
        // DisplayState: Returns the correct state to the application programmer.
        // PRE: N/A
        // POST: - Returns the OnOffState
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: OnOffState
        // MOD: N/A
        {
            return OnOffState;
        }

        public bool DisplayUserGuessAns()
        // DisplayUserGuessAns: Returns the correct shift to the application programmer.
        // PRE: - Object must be non empty
        //      - Must have guessed at least once
        // POST: - Returns the answer of the guess
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: DisplayUserGuessAns
        // MOD: N/A
        {
            return (UserGuessAns == 1);
        }
    }
}
