// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: spasEnum.cs
// Version: 2.0
// Purpose: This is an spasEnum class that is derived from SequenceEnum. 
// The purpose of this class is to contain all the functions in SequenceEnum and 
// implements additional features that overrides existing functionalities 
// from the base class. spasEnums encapsulates a word, and concatenates 
// an internal subsequence, seemingly arbitrarily.
//
// Class Invariants:
// - Minimum 1 possible spasEnum object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the base class.
//                    (Child of sequenceEnum class and Parent of VSeq Class)
//       Cardinality: 1 to 1.
// - All spasEnum objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, spasEnum class
//   has a total of 4 variations that can be performed. (RepeatedSequence1(),
//   RepeatSequence2(), RepeatSequence3(), RepeatSequence4() and TruncateWord())
// - All functions are made virtual to provide access to descendants or to any 
//   potential children classes
//
// Interface Invariants:
// - All virtual functionality reused in spasEnum are overriden.
// - Constructor and all methods are only allowed to be passed by value.
// - All Interface invariants in base class is implied for derive class (spasEnum).
// - Once an spasEnum object is turned off(inactive), it will no longer produce 
//   any variations of the word, rather returns the word truncated.
//
// Implementation Invariants:
// - All data members declared protected provide internal functionality 
//   to derived class (spasEnum).
// - randNum and randNumModifier are used to produce randomness within 
//   the variations applied onto the encapsulated word. It is to mimic 
//   a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices
//   when getting variants of word.
using homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class spasEnum : sequenceEnum
    {
        //Member Variables
        private int CurRandCount;
        private int AnyOption;
        private int randNumModifier;
        private int randNum;
        private int NumOfOptions;
        private int WordLength;

        //Overloaded constructor
        public spasEnum(string AnyWord = "") : base(AnyWord)
        {
            // GetVariant: This function is intended to be overriden in the child class 
            // PRE: - sub can be a string of any length of mixed lower case alphabets 
            //        and of length less than encapsulated word.
            // POST: - Returns NOP.
            CurRandCount = 1;
            AnyOption = 1;
            WordLength = AnyWord.Length;
            randNumModifier = (WordLength - 1);
            randNum = 0;
            NumOfOptions = 2;
        }

        //Public methods

        public override string GetVariant()
        {
            // GetVariant: This function is intended to be cycle through the variations
            // from sequenceRepeat, and emit variations of the encapsulated word. These 
            // sequenceRepeat variations are different from the base class and is overriden
            // with its own functionality.
            // PRE: - N/A
            // POST: - Returns a string from two possible variations of the encapsulated
            // word
            //		 - print state has been altered, value replaced with a RepeatSequence
            //		 - AnyOption state has been altered, value increased.
            //		 - CurRandCount state has been altered, value increased.
            string print = "";
            if (AnyOption == 1)
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence1(CurRandCount);
            }
            else
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence2(CurRandCount);
            }
            AnyOption = ((AnyOption + 1) % NumOfOptions);
            return print;
        }

        //Private methods

        private string RepeatSequence1(int Choice)
        {
            // RepeatSequence1: This function is intended repeat a sequence from the
            // encapsulated word. It takes three characters from the word and repeats 
            // each character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            //		- State must be active to use function
            // POST: - Returns a string with two characters repeated once appended on 
            //         the front of the string if state is active
            //       - Invokes TruncateWord() function when state is inactive
            //       - Returns a truncated substring of the word if state is inactive
            //		 - randNum state has been altered, value adjusted in random fashion.
            //		 - variate state has been altered, string manipulated for a variation.
            //		 - sequenceRepeat state has been altered, string adopted same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some new 
            //         character(s).
            //		 - anyLetter state has been altered, values adopted some new 
            //         character(s).
            string Repeated = new string(VariWord); // Convert char back to string
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum - NEXTLETTERINDEX];
                anyLetter[1] = VariWord[randNum];
                anyLetter[2] = VariWord[randNum + NEXTLETTERINDEX];
                string combo = Convert.ToString(anyLetter[0])
                    + Convert.ToString(anyLetter[1]) 
                    + Convert.ToString(anyLetter[2]);
                string variate = combo + Repeated;
                return variate;
            }
            else
            {
                randNum = (CurRandCount % WordLength);
                if (randNum < MINWORDSIZE)
                    randNum = randNum + INDEXAPPLY;
                string temp = TruncateWord(Repeated, randNum);
                return temp;
            }
        }

        private string RepeatSequence2(int Choice)
        {
            // RepeatSequence2: This function is intended repeat a sequence from the
            // encapsulated word. It takes three characters from the word and repeats 
            // each character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            //		- State must be active to use function
            // POST: - Returns a string with two characters repeated once appended on 
            //         the end of the string if state is active
            //       - Invokes TruncateWord() function when state is inactive
            //       - Returns a truncated substring of the word if state is inactive
            //		 - randNum state has been altered, value adjusted in random fashion.
            //		 - variate state has been altered, string manipulated for a variation.
            //		 - sequenceRepeat state has been altered, string adopted same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some new 
            //         character(s).
            string Repeated = new string(VariWord); // Convert char back to string
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum - NEXTLETTERINDEX];
                anyLetter[1] = VariWord[randNum];
                anyLetter[2] = VariWord[randNum + NEXTLETTERINDEX];
                string combo = Convert.ToString(anyLetter[0])
                    + Convert.ToString(anyLetter[1]) 
                    + Convert.ToString(anyLetter[2]);
                string variate = Repeated + combo;
                return variate;
            }
            else
            {
                randNum = (CurRandCount % WordLength);
                if (randNum < MINWORDSIZE)
                    randNum = randNum + INDEXAPPLY;
                string temp = TruncateWord(Repeated, randNum);
                return temp;
            }
        }

        private string TruncateWord(string source, int length)
        {
            // TruncateWord: Regardless of state, this function is intended truncate a 
            // substring from the encapsulated word. 
            // PRE: - source must be a string that only contains lower case english alphabets
            //      - source must have a length of at least 4 characters long
            //      - length must be an integer that is in the range of the length of the 
            //        encapsulated word
            // POST: - Returns a truncated substring of the word when function invoked.
            //       - TruncateWord() invoked when state set to inactive and calling 
            //         RepeatSequence methods.
            string TruncatedWord = "";
            if (source.Length > length)
                TruncatedWord = source.Substring(0, length);
            return TruncatedWord;
        }
    }
}
