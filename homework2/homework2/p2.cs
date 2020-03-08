// Name: Rueben Tiow
// Last Modification: 1/26/2017
// File: p2.cs
// Version: 1.0
//
//  This is a driver for the encryptWord class and the shiftRange class.  
//  It tests the default constructors and then random shifts.

using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class p2
    {
        // Constant Variables
        const int SIZE = 5;
        const string word0 = "zebra";
        const string word1 = "infamous";
        const string word2 = "potatoes";


        static void Main(string[] args)
        {
            Random rnd = new Random();
            int ShiftValue;
            shiftRange[] BunchOfShiftRange = new shiftRange[SIZE];
            encryptWord[] BunchOfEncryptWords = new encryptWord[SIZE];


            for (int i = 0; i < SIZE; i++)
            {
                ShiftValue = rnd.Next(0, 25);
                BunchOfShiftRange[i] = new shiftRange(ShiftValue);
            }

            for (int i = 0; i < SIZE; i++)
            {
                ShiftValue = rnd.Next(0, 25);
                BunchOfEncryptWords[i] = new encryptWord(ShiftValue);
            }

            Console.WriteLine("Testing ShiftRange class:");
            //Return ShiftVal
            Console.WriteLine("Testing that we indeed have multiple random shift values stored at index 0");
            Console.WriteLine(BunchOfShiftRange[0].DisplayShiftVal(0));
            Console.WriteLine(BunchOfShiftRange[0].DisplayShiftVal(1));
            Console.WriteLine(BunchOfShiftRange[0].DisplayShiftVal(2));
            Console.WriteLine(BunchOfShiftRange[0].DisplayShiftVal(3));
            Console.WriteLine(BunchOfShiftRange[0].DisplayShiftVal(4));
            Console.WriteLine("Testing that we indeed have multiple random shift values stored at index 1");
            Console.WriteLine(BunchOfShiftRange[1].DisplayShiftVal(0));
            Console.WriteLine(BunchOfShiftRange[1].DisplayShiftVal(1));
            Console.WriteLine(BunchOfShiftRange[1].DisplayShiftVal(2));
            Console.WriteLine(BunchOfShiftRange[1].DisplayShiftVal(3));
            Console.WriteLine(BunchOfShiftRange[1].DisplayShiftVal(4));

            //Print words stored at each location with different shift values
            Console.WriteLine("Here are encrypted words and stored with its individual shift values");
            printWords(BunchOfShiftRange, 0);
            printWords(BunchOfShiftRange, 1);
            printWords(BunchOfShiftRange, 2);
            printWords(BunchOfShiftRange, 3);
            printWords(BunchOfShiftRange, 4);
            Console.WriteLine();
            //Testing DecryptWord function
            Console.WriteLine("Here are encrypted words decrypted with the appropriate shift value");
            string test0 = BunchOfShiftRange[0].DisplayEncryptWord(word0);
            string test1 = BunchOfShiftRange[0].DisplayEncryptWord(word1);
            string test2 = BunchOfShiftRange[1].DisplayEncryptWord(word2);
            Console.WriteLine("The word {0} decrypted is: {1}", test0, BunchOfShiftRange[0].DisplayDecryptWord(test0));
            Console.WriteLine("The word {0} decrypted is: {1}", test1, BunchOfShiftRange[0].DisplayDecryptWord(test1));
            Console.WriteLine("The word {0} decrypted is: {1}\n", test2, BunchOfShiftRange[1].DisplayDecryptWord(test2));
            
            //Testing CheckUserGuess
            Console.WriteLine("Testing the CheckUserGuess function to see if guessed correctly or wrongly");
            Console.WriteLine("The number guessed is 5 and the result is: {0}", BunchOfShiftRange[0].CheckGuessValue(5));
            Console.WriteLine("The number guessed is 6 and the result is: {0}", BunchOfShiftRange[0].CheckGuessValue(6));
            Console.WriteLine("The number guessed is 22 and the result is: {0}", BunchOfShiftRange[0].CheckGuessValue(22));
            Console.WriteLine("The number guessed is 21 and the result is: {0}\n", BunchOfShiftRange[0].CheckGuessValue(21));

            //Testing Most Used Shift
            Console.WriteLine("Testing the MostUsedShift function");
            Console.WriteLine("Most Used Shift: {0}", BunchOfShiftRange[0].DisplayMostUsedShift());
            Console.WriteLine("Most Used Shift: {0}", BunchOfShiftRange[1].DisplayMostUsedShift());
            Console.WriteLine("Most Used Shift: {0}", BunchOfShiftRange[2].DisplayMostUsedShift());
            Console.WriteLine("Most Used Shift: {0}", BunchOfShiftRange[3].DisplayMostUsedShift());
            Console.WriteLine("Most Used Shift: {0}", BunchOfShiftRange[4].DisplayMostUsedShift());
            Console.WriteLine("Testing the MostUsedWord function");
            Console.WriteLine("Most Used Word: {0}", BunchOfShiftRange[0].DisplayMostUsedWord());
            Console.WriteLine("Most Used Word: {0}", BunchOfShiftRange[1].DisplayMostUsedWord());
            Console.WriteLine("Testing the MostUsedWord function on empty object");
            Console.WriteLine("Most Used Word: {0}\n", BunchOfShiftRange[2].DisplayMostUsedWord());

            //Testing Statistics
            Console.WriteLine("Testing the Statistics function");
            DisplayMyStats(BunchOfShiftRange[0].DisplayEncryptWordSatistics(1));
            DisplayMyStats(BunchOfShiftRange[0].DisplayEncryptWordSatistics(2));
            DisplayMyStats(BunchOfShiftRange[0].DisplayEncryptWordSatistics(3));
            DisplayMyStats(BunchOfShiftRange[0].DisplayEncryptWordSatistics(4));
            Console.WriteLine();

            //Testing RemoveFound
            Console.WriteLine("Testing the RemoveFound function and will only delete if word is found");
            BunchOfShiftRange[0].RemoveFoundWord();
            BunchOfShiftRange[1].RemoveFoundWord();
            BunchOfShiftRange[2].RemoveFoundWord();


            //Testing CheckEmpty
            Console.WriteLine("Testing the CheckEmpty function");
            Console.WriteLine("At index 0:{0}", BunchOfShiftRange[0].CheckEmpty());
            Console.WriteLine("At index 1:{0}", BunchOfShiftRange[1].CheckEmpty());
            Console.WriteLine("At index 2:{0}", BunchOfShiftRange[2].CheckEmpty());


            Console.WriteLine("Testing encryptword class");
            //Testing each position has a different random shift value
            for (int i = 0; i < SIZE; i++)
            {
                Console.WriteLine(BunchOfEncryptWords[i].DisplayShift());
            }

            //Print encryptwords stored with shift value
            Console.WriteLine("Testing ApplyCaesarShift");
            Console.WriteLine("The word {0} encrypted is: {1}", word0, BunchOfEncryptWords[0].ApplyCaesarShift(word0));
            Console.WriteLine("The word {0} encrypted is: {1}", word1, BunchOfEncryptWords[0].ApplyCaesarShift(word1));
            Console.WriteLine("The word {0} encrypted is: {1}", word2, BunchOfEncryptWords[0].ApplyCaesarShift(word2));

            Console.WriteLine("The word {0} encrypted is: {1}", word0, BunchOfEncryptWords[1].ApplyCaesarShift(word0));
            Console.WriteLine("The word {0} encrypted is: {1}", word1, BunchOfEncryptWords[1].ApplyCaesarShift(word1));
            Console.WriteLine("The word {0} encrypted is: {1}\n", word2, BunchOfEncryptWords[1].ApplyCaesarShift(word2));

            //Testing DecryptWord function
            Console.WriteLine("Testing DecryptWord");
            string test3 = BunchOfEncryptWords[0].ApplyCaesarShift(word0);
            string test4 = BunchOfEncryptWords[0].ApplyCaesarShift(word1);
            string test5 = BunchOfEncryptWords[0].ApplyCaesarShift(word2);
            Console.WriteLine("The word {0} decrypted is: {1}", test0, BunchOfEncryptWords[0].DecryptWord(test3));
            Console.WriteLine("The word {0} decrypted is: {1}", test1, BunchOfEncryptWords[0].DecryptWord(test4));
            Console.WriteLine("The word {0} decrypted is: {1} \n", test2, BunchOfEncryptWords[0].DecryptWord(test5));

            // Testing the CheckUserGuess function only one word1 and one shift
            Console.WriteLine("Testing the CheckUserGuess function to see if guessed correctly or wrongly");
            Console.WriteLine("The number guessed is 5 and the result is: {0}", BunchOfEncryptWords[0].CheckUserGuess(5));
            Console.WriteLine("The number guessed is 6 and the result is: {0}", BunchOfEncryptWords[0].CheckUserGuess(6));
            Console.WriteLine("The number guessed is 22 and the result is: {0}", BunchOfEncryptWords[0].CheckUserGuess(22));
            Console.WriteLine("The number guessed is 21 and the result is: {0}\n", BunchOfEncryptWords[0].CheckUserGuess(21));

            Console.WriteLine("Testing the CheckUserGuess function to see if guessed correctly or wrongly");
            Console.WriteLine("The number guessed is 5 and the result is: {0}", BunchOfEncryptWords[1].CheckUserGuess(5));
            Console.WriteLine("The number guessed is 6 and the result is: {0}", BunchOfEncryptWords[1].CheckUserGuess(6));
            Console.WriteLine("The number guessed is 22 and the result is: {0}", BunchOfEncryptWords[1].CheckUserGuess(22));
            Console.WriteLine("The number guessed is 21 and the result is: {0}\n", BunchOfEncryptWords[1].CheckUserGuess(21));

            //Testing the DisplayStatistics Function here to print our results
            Console.WriteLine("Testing the DisplayStatistics function, to print each individual statistic at 0 index");
            Console.WriteLine("The number of queries are: {0}", BunchOfEncryptWords[0].DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", BunchOfEncryptWords[0].DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", BunchOfEncryptWords[0].DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", BunchOfEncryptWords[0].DisplayStatistics(4));

            Console.WriteLine("Testing the DisplayStatistics function, to print each individual statistic at 1st index");
            Console.WriteLine("The number of queries are: {0}", BunchOfEncryptWords[1].DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", BunchOfEncryptWords[1].DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", BunchOfEncryptWords[1].DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", BunchOfEncryptWords[1].DisplayStatistics(4));
            
            //Testing no statistics performed
            Console.WriteLine("Testing the DisplayStatistics function, to print each individual statistic at 2nd index");
            Console.WriteLine("The number of queries are: {0}", BunchOfEncryptWords[2].DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", BunchOfEncryptWords[2].DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", BunchOfEncryptWords[2].DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", BunchOfEncryptWords[2].DisplayStatistics(4));

            //Testing the game with the Caesar Cipher Shift applied onto the provided word
            Console.WriteLine("Testing PerformOnOffState function:");
            Console.WriteLine("Turning on the Caesar Shift");
            BunchOfEncryptWords[0].PerformOnOffState(1);
            Console.WriteLine("Testing the ApplyCaesarShift function with WORD2 stored and Caesar Shift turned on");
            Console.WriteLine("The word {0} encrypted is: {1}\n", word0, BunchOfEncryptWords[0].ApplyCaesarShift(word0));

            //Testing the game with the Caesar Cipher Shift not applied onto the provided word
            Console.WriteLine("Turning off the Caesar Shift");
            BunchOfEncryptWords[0].PerformOnOffState(2);
            Console.WriteLine("Testing the ApplyCaesarShift function with WORD2 stored and Caesar Shift turned off");
            Console.WriteLine("The word {0} encrypted is: {1}\n", word0, BunchOfEncryptWords[0].ApplyCaesarShift(word0));

            //Testing the Reset Function here
            Console.WriteLine("Resetting the entire game");
            BunchOfEncryptWords[0].PerformOnOffState(3);
            //Testing the DisplayStatistics Function here to confirm that the game indeed has reset.
            Console.WriteLine("The statistics have reset: Applied to index 0");
            Console.WriteLine("The number of queries are: {0}", BunchOfEncryptWords[0].DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", BunchOfEncryptWords[0].DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", BunchOfEncryptWords[0].DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", BunchOfEncryptWords[0].DisplayStatistics(4));

            Console.WriteLine("The statistics have not reset: Non applied to index 1");
            Console.WriteLine("The number of queries are: {0}", BunchOfEncryptWords[1].DisplayStatistics(1));
            Console.WriteLine("The number of high guesses are: {0}", BunchOfEncryptWords[1].DisplayStatistics(2));
            Console.WriteLine("The number of low guesses are: {0}", BunchOfEncryptWords[1].DisplayStatistics(3));
            Console.WriteLine("The number of average guesses are: {0}\n", BunchOfEncryptWords[1].DisplayStatistics(4));
            
        }

        
        public static void DisplayMyStats(int[] GivenStats)
        {
            Console.Write("Stats:");
            for (int i = 0; i < GivenStats.Length; i++)
            {
                Console.Write(" " + GivenStats[i]);
            }
            Console.WriteLine();
        }

        public static void printWords(shiftRange[] array, int index)
        {
            Console.WriteLine("The index at {0}, shifted the words to:",index);
            Console.WriteLine(array[index].DisplayEncryptWord(word0) + ", " + array[index].DisplayEncryptWord(word1) + ", " + array[index].DisplayEncryptWord(word2));
        }

    }
}

            


