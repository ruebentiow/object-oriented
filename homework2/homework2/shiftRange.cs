// Name: Rueben Tiow
// Last Modification: 1/26/2017
// File: shiftRange.cs
// Version: 1.0
// Purpose: This is an shiftRange class that supports a collection of encryptWord objects. 
// Each objects contains its own random shift value, and grant guessing for all of them.
//
// Class Invariants:
// - Minimum 1 possible encryptWord objects
// - Relationship:
//       Association: This class has a Holds-A relationship with the subObject 
//                    (encryptWord class)
//       Cardinality: From zero to the maximum number of objects
// - All encryptWord objects are initialize upon construction.
//
// Interface Invariants:
// - Default constructor suppressed.
// - Once an encryptWord is Removed, it will not be accessible anymore to any shiftRange objects.
// - Every integer number used within this object fall 
//   between 0 to 25.
// - Every string passed into this object must be in lowercase 
//   alphabet letters.
// - Application programmer responsible for checking whether if object index is out of range.
//   (i.e CheckUserGuess())
//
// Implementation Invariants:
// - Nop if RemoveFoundWord invoked for empty object
// - Removal of any object is permanent, and irreversible.
// - ENCRYPTSIZE must be larger than SIZE to encompass the size of multiple statistic arrays.
// - MostUsedShift, CounterShiftArray, MostUsedWord, CounterWordArray must be same size.
//

using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace homework2
{

    class shiftRange
    {
        //Constant Variables
        private const int SIZE = 100;
        private const int ENCRYPTSIZE = 5;

        //Data Members
        private encryptWord[] MyEncryptedWords;
        private bool UserGuessAns;
        private int[] MostUsedShift;
        private int[] CounterShiftArray;
        private string[] MostUsedWord;
        private int[] CounterWordArray;
        private int[] StoreStatistics;

        //Default constructor suppressed.
        public shiftRange() { }

        //Overloaded Constructor.
        public shiftRange(int ShiftVal = 3)
        // PRE: N/A
        // POST: N/A
        // FUNCTIONS: encryptWord() (From encryptWord)
        // IN: ShiftVal
        // OUT: N/A
        // MOD: UserGuessAns, CounterShiftArray, MostUsedShift, MostUsedWord,
        //  CounterWordArray, MyEncryptedWords, StoreStatistics, UpdateShift()
        {
            UserGuessAns = false;
            CounterShiftArray = new int[SIZE];
            MostUsedShift = new int[SIZE];
            MostUsedWord = new String[SIZE];
            CounterWordArray = new int[SIZE];
            MyEncryptedWords = new encryptWord[ENCRYPTSIZE];
            StoreStatistics = new int[ENCRYPTSIZE];
            for (int i = 0; i < SIZE; i++)
            {
                MostUsedShift[i] = -1;
                CounterShiftArray[i] = 0;
                MostUsedWord[i] = "";
                CounterWordArray[i] = 0;
            }
            for (int i = 0; i < ENCRYPTSIZE; i++)
            {
                UpdateShift(ShiftVal);
                MyEncryptedWords[i] = new encryptWord(ShiftVal);
                ShiftVal = ((ShiftVal * 15) % 26); // Used to create more random numbers to pass into encryptWords.
                StoreStatistics[i] = 0;
            }
        }

        private void UpdateShift(int ShiftVal)
        // UpdateShift: This function is meant to keep a track of the most used Random Shift Value.
        // PRE: - ShiftVal must be an integer in between 0 to 25. 
        // POST: - MostUsedShift and CounterShiftArray are updated
        //       - Properly determines which shift value occured the most frequent and store that
        //         information in MostUsedShift array.
        //       - Keeps a count on the frequency of each shift in CounterShiftArray.
        // FUNCTIONS: N/A
        // IN: ShiftVal
        // OUT: N/A
        // MOD: MostUsedShift, CounterShiftArray
        {
            int i = 0;
            while(MostUsedShift[i] != -1 && MostUsedShift[i] != ShiftVal)
            { 
                i++;
            }
            MostUsedShift[i] = ShiftVal;
            CounterShiftArray[i]++; 
        }

        private void UpdateWord(string AnyWord)
        // UpdateWord: This function is meant to keep a track of the most used Word.
        // PRE: - AnyWord must be a word that uses only lowercase alphabets and be more than 3 letters
        // POST: - MostUsedWord and CounterWordArray are updated
        //       - Properly determines which word occured the most frequent and store that
        //         information in MostUsedWord array.
        //       - Keeps a count on the frequency of each shift in CounterShiftArray.
        // FUNCTIONS: N/A
        // IN: AnyWord
        // OUT: N/A
        // MOD: MostUsedWord, CounterWordArray
        {
            int i = 0;
            while (MostUsedWord[i] != "" && MostUsedWord[i] != AnyWord)
            {
                i++;
            }
            MostUsedWord[i] = AnyWord;
            CounterWordArray[i]++;
        }

        public int DisplayMostUsedShift()
        // DisplayMostUsedShift: This function is meant to display the most common shift used.
        // PRE: - Object must not be empty.
        // POST: - Returns the shift value that occured the most frequent
        //       - Returns the first shift value stored if all the shifts that are used appear an equal amount of times.
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: MostUsedShift
        // MOD: MostUsedShift, CounterShiftArray
        {
            int index = 0;
            int max = 0;
            for (int i = 0; i < SIZE; i++)
            {

                if(CounterShiftArray[i] > max)
                {
                    max = CounterShiftArray[i];
                    index = i;
                }
            }
            return MostUsedShift[index];
        }

        public String DisplayMostUsedWord()
        // DisplayMostUsedWord: This function is meant to display the most common word used.
        // PRE: - Object must not be empty.
        // POST: - Returns the shift value that occured the most frequent
        //       - Returns the first word stored if all the Words that are used appear an equal amount of times.
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: MostUsedShift
        // MOD: MostUsedShift, CounterShiftArray
        {
            int index = 0;
            int max = 0;
            for (int i = 0; i < SIZE; i++)
            {
                if (CounterWordArray[i] > max)
                {
                    max = CounterWordArray[i];
                    index = i;
                }
            }
            return MostUsedWord[index];
        }

        public bool CheckGuessValue(int GuessNum)
        // CheckGuessValue: This function is meant to determine whether the user has guessed a correct shifted value on a given word.
        // PRE: - Object must not be empty.
        //      - GuessNum must be an integer in between 0 to 25. 
        // POST: - Returns a number that indicates a correct or an incorrect guess.
        //       - Returns true if Correctly guessed
        //       - Returns false if Incorrectly guessed
        // FUNCTIONS: CheckUserGuess (from encryptWord)
        // IN: AnyWord
        // OUT: UserGuessAns
        // MOD: UserGuessAns
        {
            int CheckGuess = 0;
            for (int i = 0; i < ENCRYPTSIZE; i++)
            {
                if(MyEncryptedWords[i] != null)
                {
                    CheckGuess = MyEncryptedWords[i].CheckUserGuess(GuessNum);
                    if (CheckGuess == 1)
                    {
                        UserGuessAns = true;
                    }
                    else
                    {
                        UserGuessAns = false;                    }
                }
            }
            return UserGuessAns;
        }

        public string DisplayEncryptWord(string AnyWord)
        // DisplayEncryptWord: This function is meant to apply a caesar cipher shift on to a given word.
        // PRE: - AnyWord must be in lowercase alphabets and be more than 3 letters
        // POST: - Returns the word shifted according to the shift value stored
        //       - UpdateWord will be updated, as a way to keep track of most used word
        // FUNCTIONS: ApplyCaesarShift (from encryptWord)
        // IN: AnyWord
        // OUT: DisplayWord
        // MOD: MyEncryptedWords 
        {
            UpdateWord(AnyWord);
            int i = 0;
            string DisplayWord;
            while(MyEncryptedWords[i] == null)
            {
                i++;
            }
            DisplayWord = MyEncryptedWords[i].ApplyCaesarShift(AnyWord);
            return DisplayWord;
        }

        public string DisplayDecryptWord(string AnyWord)
        // DisplayDecryptWord: This function is meant to unapply a caesar cipher shift on to a given word.
        // PRE: - AnyWord must be in lowercase alphabets and be more than 3 letters
        //      - AnyWord must previously be a word shifted by an encryptWord Object
        //      - AnyWord must still exist, that is, not deleted.
        // POST: - Returns each encryptWord unshifted.
        //       - Returns the collection of correctly unshifted word according to the shift value stored
        // FUNCTIONS: ApplyCaesarShift (from encryptWord)
        // IN: AnyWord
        // OUT: DisplayWord
        // MOD: MyEncryptedWords 
        {
            string DisplayWord = "";
            for(int i = 0; i < ENCRYPTSIZE; i++)
            {
                if (MyEncryptedWords[i] != null)
                {
                    DisplayWord += MyEncryptedWords[i].DecryptWord(AnyWord) + " ";
                }
            }
            return DisplayWord;
        }

        public void RemoveFoundWord()
        // RemoveFoundWord: This function is meant to remove the word that was guessed correctly.
        // PRE: - Object is not empty.
        //      - At least one word guessed correctly.
        //      - Object has not been deleted previously.
        // POST: - Object resets the found word at that index to null.
        //       - Object may be empty.
        // FUNCTIONS: DisplayUserGuessAns (from encryptWord)
        // IN: N/A
        // OUT: N/A
        // MOD: MyEncryptedWords
        {
            //encryptWord[] Temp = new encryptWord[ENCRYPTSIZE];
            for (int i = 0; i < ENCRYPTSIZE; i++)
            {
                if(MyEncryptedWords[i] != null)
                {
                    if (MyEncryptedWords[i].DisplayUserGuessAns() == true)
                    {
                        Console.WriteLine("yo");
                        MyEncryptedWords[i] = null;
                        /*
                        Temp[i] = MyEncryptedWords[i]; // swap to end of array and set to null due to DisplayDecryptWord
                        MyEncryptedWords[i] = MyEncryptedWords[ENCRYPTSIZE - 1];
                        MyEncryptedWords[ENCRYPTSIZE - 1] = Temp[i];
                        */
                    }
                }
            }
        }

        public int[] DisplayEncryptWordSatistics(int WhichStatistic)
        // DisplayEncryptWordSatistics: This function is meant to display the statistics accordingly.
        // PRE: - WhichStatistics must be an integer from 0 to 4
        // POST: - Returns a number that displays corresponding staticstics(i.e NumQueries)
        // FUNCTIONS: DisplayStatistics (from encryptWord)
        // IN: WhichStatistic
        // OUT: StoreStatistics
        // MOD: StoreStatistics
        {
            for (int i = 0; i < ENCRYPTSIZE; i++)
            {
                if(MyEncryptedWords[i] != null)
                {
                        StoreStatistics[i] = Convert.ToInt32(MyEncryptedWords[i].DisplayStatistics(WhichStatistic));
                }
            }
            return StoreStatistics;

        }

        public int DisplayShiftVal(int index)
        // DisplayShiftVal: This function is meant to display the shift value at a given index.
        // PRE: - Object is not empty.
        //      - Index must be a number within bounds of object. (i.e 5 in this particular case)
        // POST: - Returns the shift value at the appropriate index.
        // FUNCTIONS: DisplayShift (from encryptWord)
        // IN: N/A
        // OUT: N/A
        // MOD: N/A
        {
            int print = 0;
            print = MyEncryptedWords[index].DisplayShift();
            return print;
        }


        public bool CheckEmpty()
        // CheckEmpty: This function is meant to check whether there are any objects that have not been removed.
        // PRE: N/A
        // POST: - Returns true if every encryptWord object has been removed
        //       - Returns false is at least one object still exists.
        // FUNCTIONS: N/A
        // IN: N/A
        // OUT: N/A
        // MOD: N/A
        {
            bool IsEmpty = true;
            for (int i = 0; i < ENCRYPTSIZE; i++)
            {
                if (MyEncryptedWords[i] != null)
                {
                    IsEmpty = false;
                }
            } 
            return IsEmpty;
        }
        
    }
}

