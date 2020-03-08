// Name: Rueben Tiow
// Last Modification: 2/11/2017
// File: spasEnum.cs
// Version: 1.0
// Purpose: This is an spasEnum class that is derived from SequenceEnum. The purpose of this class is to contain 
// all the functions in SequenceEnum and implements additional features that overrides existing functionalities 
// from the base class. spasEnums encapsulates a word, and concatenates an internal subsequence, seemingly 
// arbitrarily.
//
// Class Invariants:
// - Minimum 1 possible spasEnum object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the base class.
//                    (sequenceEnum class)
//       Cardinality: 1 to 1.
// - All spasEnum objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, spasEnum class
//   has a total of 5 variations that can be performed. (RepeatedSequence1(),
//   RepeatSequence2(), RepeatSequence3(), RepeatSequence4() and TruncateWord())
//
// Interface Invariants:
// - All virtual functionality reused in spasEnum are overriden.
// - All Interface invariants in base class is implied for derive class (spasEnum).
// - Once an spasEnum object is turned off(inactive), it will no longer produce any variations 
//   of the word, rather returns the word truncated.
//
// Implementation Invariants:
// - All data members declared protected provide internal functionality to derived class (spasEnum).
// - randNum and randNumModifier are used to produce randomness within the variations applied 
//   onto the encapsulated word. It is to mimic a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices when getting variants of word.
//
using homework3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    public class spasEnum : SequenceEnum
    {
        //Member Variables
        //string StoredWord = new string(VariWord);
        //Overloaded constructor
        public spasEnum(string AnyWord = "") : base(AnyWord)
        {
            // PRE: AnyWord must be a string that is in english lowercase alphabets and at least 4 characters long.
            // POST: - Fire the base class constructor (sequenceEnum) 
            //       - Initializes all inherited protected data members and VariWord encapsualted a word and state is set to active.
        }


        public override string GetVariant()
        {
            // GetVariant: This function is intended to be cycle through the variations
            // from sequenceRepeat, and emit variations of the encapsulated word. These 
            // sequenceRepeat variations are different from the base class and is overriden
            // with its own functionality.
            // PRE: -N/A
            // POST: - Returns a string from four possible variations of the encapsulated
            // word
            int NumOfOptions = 4;
            string print = "";
            if (AnyOption == 1)
            {
                CurRandCount = CurRandCount + 3;
                print = RepeatSequence1(CurRandCount);
            }
            else if (AnyOption == 2)
            {
                CurRandCount = CurRandCount + 3;
                print = RepeatSequence2(CurRandCount);
            }
            else if (AnyOption == 3)
            {
                CurRandCount = CurRandCount + 2;
                print = RepeatSequence3(CurRandCount);
            }
            else
            {
                CurRandCount = CurRandCount + 2;
                print = RepeatSequence4(CurRandCount);
            }
            AnyOption = ((AnyOption + 1) % NumOfOptions);
            return print;
        }
        
        
        protected override string RepeatSequence1(int Choice)
        {
            // RepeatSequence1: This function is intended repeat a sequence from the
            // encapsulated word. It takes two characters from the word and repeats 
            // the each character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with two characters repeated once appended on 
            //         the front of the string if state is active
            //       - Returns a truncated substring of the word if state is inactive
            string temp = "";
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = ((Choice * 3) % randNumModifier);
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum + 1];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat);
                string letter = Convert.ToString(anyLetter[0]);
                string letter2 = Convert.ToString(anyLetter[1]);
                string combo = letter + letter2;
                string variate = combo + Repeated;
                return variate;
            }
            else
            {
                string StoredWord = new string(VariWord);
                randNum = (CurRandCount % StoredWord.Length);
                if (randNum < 3)
                {
                    randNum = randNum + 2;
                }
                temp = TruncateWord(StoredWord, randNum);
                return temp;
            }
        }

        protected override string RepeatSequence2(int Choice)
        {
            // RepeatSequence2: This function is intended repeat a sequence from the
            // encapsulated word. It takes two characters from the word and repeats 
            // the each character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with two characters repeated once appended on 
            //         the end of the string if state is active
            //       - Returns a truncated substring of the word if state is inactive
            string temp = "";
            if (IsStateActive == true)
            {
                randNumModifier = 4;
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = ((Choice * 3) % randNumModifier);
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum + 1];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat);
                string letter = Convert.ToString(anyLetter[0]);
                string letter2 = Convert.ToString(anyLetter[1]);
                string combo = letter + letter2;
                string variate = Repeated + combo;
                return variate;
            }
            else
            {
                string StoredWord = new string(VariWord);
                randNum = (CurRandCount % StoredWord.Length);
                if (randNum < 3)
                {
                    randNum = randNum + 2;
                }
                temp = TruncateWord(StoredWord, randNum);
                return temp;
            }
        }


        protected override string RepeatSequence3(int Choice)
        {
            // RepeatSequence3: This function is intended repeat a sequence from the
            // encapsulated word. It takes one character from the word and repeats 
            // the character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with one character repeated once appended on 
            //         the front of the string if state is active
            //       - Returns a truncated substring of the word if state is inactive
            string temp = "";
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = ((Choice * 3) % randNumModifier);
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat);
                string letter = Convert.ToString(anyLetter[0]);
                string combo = letter;
                string variate = combo + Repeated;
                return variate;
            }
            else
            {
                string StoredWord = new string(VariWord);
                randNum = (CurRandCount % StoredWord.Length);
                if (randNum < 3)
                {
                    randNum = randNum + 2;
                }
                temp = TruncateWord(StoredWord, randNum);
                return temp;
            }
        }

        protected override string RepeatSequence4(int Choice)
        {
            // RepeatSequence3: This function is intended repeat a sequence from the
            // encapsulated word. It takes one character from the word and repeats 
            // the character once.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with one character repeated once appended on 
            //         the end of the string if state is active
            //       - Returns a truncated substring of the word if state is inactive
            string temp = "";
            if (IsStateActive == true)
            {
                randNumModifier = 4;
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = ((Choice * 3) % randNumModifier);
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat);
                string letter = Convert.ToString(anyLetter[0]);
                string combo = letter;
                string variate = Repeated + combo;
                return variate;
            }
            else
            {
                string StoredWord = new string(VariWord);
                int randNum = (CurRandCount % StoredWord.Length);
                if (randNum < 3)
                {
                    randNum = randNum + 2;
                }
                temp = TruncateWord(StoredWord, randNum);
                return temp;
            }

        }


        public string TruncateWord(string source, int length)
        {
            // TruncateWord: This function is intended truncate a substring from the
            // encapsulated word. Additionally it takes one character from the word 
            // and repeats the character once.
            // PRE: - source must be a string that only contains lower case english alphabets
            //      - source must have a length of at least 4 characters long
            //      - length must be an integer that is in the range of the length of the 
            //        encapsulated word
            // POST: - Returns a string with one character repeated once appended on 
            //         the end of the string if state is active
            //       - Returns a truncated substring of the word if state is inactive
            string TruncatedWord = "";
            if (source.Length > length)
            {
                TruncatedWord = source.Substring(0, length);
                return source.Substring(0, length);
            }
            return TruncatedWord;
        }

        public override bool CheckUserGuess(string UserGuess)
        {
            // CheckUserGuess: This function is intended to determine whether 
            // the user has guessed the word correctly in spasEnum class. It inherits all
            // the functionalities pre-existing from the base class (sequenceEnum).
            // PRE: - AnyGuess must be string that only contains lower-case English alphabets
            //      - The string should also be reasonable and appropriate for processing
            // POST: - Returns true when the user has made a correct guess
            //       - Returns false when the user has made an incorrect guess
            return base.CheckUserGuess(UserGuess);
        }

        public override bool ModifyIfActive(int Choice)
        {
            // ModifyIfActive: This function is intended to modify the state of the
            // object between active and inactive within the spasEnum class. It inherits
            // all functionalities pre-existing from the base class (sequenceEnum).
            // PRE: - Choice must be an integer between 1 or 2
            // POST: - Modifies the current state to true when Choice is 1
            //       - Modifies the current state to false when Choice is 2
            //       - Return the current state of the object
            return base.ModifyIfActive(Choice);
        }
    }
}
