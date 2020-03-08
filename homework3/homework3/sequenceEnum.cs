// Name: Rueben Tiow
// Last Modification: 2/11/2017
// File: sequenceEnum.cs
// Version: 1.0
// Purpose: This is an SequenceEnum class that lays the foundation for two other child classes. The purpose
// of this class is to contain the functions intended to be used in the driver. This has a class heirarchy of
// SequenceEnums where each SequenceEnum object encapsulates a word, and responds to inquiries. The encapsulated
// word is mixed around seemingly arbitrarily.
//
// Class Invariants:
// - Minimum 1 possible sequenceEnum object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the derived classes.
//                    (seqExtract & spasEnum class)
//       Cardinality: 1 to 1.
// - All sequenceEnum objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, sequenceEnum class
//   has a total of 5 variations that can be performed. (RepeatedSequence1(),
//   RepeatSequence2(), RepeatSequence3(), RepeatSequence4(), RepeatSequence5())
//
// Interface Invariants:
// - All public functions are declare virtual to provide functionality to derived classes.
// - Constructor and all methods are only allowed to be passed by value.
// - Once an sequenceEnum object is turned off(inactive), it will no longer produce any variations 
//   of the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Application programmer responsible for checking whether if word passed in appropriate to avoid out of
// - index bounds.
//
// Implementation Invariants:
// - NOP if GetVariant(string sub) invoked for sequenceEnum object.
// - All data members are declared protected to provide internal access to derived classes.
// - randNum and randNumModifier are used to produce randomness within the variations applied 
//   onto the encapsulated word. It is to mimic a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices when getting variants of word.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    public class SequenceEnum
    {

        //Member Variables
        protected int CurRandCount;
        protected int AnyOption;
        protected char[] VariWord;
        protected bool IsStateActive;
        protected bool UserGuess;
        protected int randNumModifier;
        protected int randNum;

        //Overloaded constructor
        public SequenceEnum(string AnyWord = "")
        {
            // PRE: AnyWord must be a string that is in english lowercase alphabets and at least 4 characters long.
            // POST: All protected data members are initialized, VariWord encapsualted a word and state is set to active.
            VariWord = new char[AnyWord.Length];
            IsStateActive = true;
            UserGuess = false;
            AnyOption = 1;
            randNum = 0;
            randNumModifier = AnyWord.Length - 1;
            CurRandCount = 0;
            if (AnyWord.Length >= 4)
            {
                for(int i = 0; i < AnyWord.Length; i++)
                {
                    VariWord[i] = Convert.ToChar(AnyWord[i]);
                }
            }
        }

        public virtual string GetVariant(string sub)
        {
            // GetVariant: This function is intended to be overriden in the child class (seqExtract).
            // PRE: - sub can be a string of any length of mixed lower case alphabets and of length less than encapsulated word.
            // POST: - Returns NOP.
            return "";
        }

        public virtual string GetVariant()
        {
            // GetVariant: This function is intended to be cycle through the variations
            // from sequenceRepeat, and emit variations of the encapsulated word.
            // PRE: -N/A
            // POST: - Returns a string from six possible variations of the encapsulated
            // word
            int NumOfOptions = 5;
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
            else if (AnyOption == 4)
            {
                CurRandCount = CurRandCount + 2;
                print = RepeatSequence4(CurRandCount);
            }
            else
            {
                CurRandCount = CurRandCount + 2;
                print = RepeatSequence5(CurRandCount);
            }
            AnyOption = ((AnyOption + 1) % NumOfOptions);
            return print;
        }

        protected virtual string RepeatSequence1(int Choice)
        {
            // RepeatSequence1: This function is intended repeat a sequence from the
            // encapsulated word. It takes two characters from the word and repeats 
            // the characters a random number of times between the interval 0 to the 
            // length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with two characters appended on the end  of 
            //         the string if state is active
            //       - Returns an empty string if state is inactive
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if(randNum == 0)
                {
                    randNum = 2;
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum + 1];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat); // Convert char back to string
                string letter = new string(anyLetter[0], randNum); //repeats letter
                string letter2 = new string(anyLetter[1], randNum); // repeats lettter
                string combo = letter + letter2;
                string variate = Repeated + combo;
                return variate;
            }
            else
                return "";
        }

        protected virtual string RepeatSequence2(int Choice)
        {
            // RepeatSequence2: This function is intended repeat a sequence from the
            // encapsulated word. It takes two characters from the word and repeats 
            // the characters a random number of times between the interval 0 to the 
            // length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with two characters appended on the front
            //          of the string if state is active
            //       - Returns an empty string if state is inactive
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = 2;
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum - 1];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat); // Convert char back to string
                string letter = new string(anyLetter[0], randNum); //repeats letter
                string letter2 = new string(anyLetter[1], randNum); // repeats lettter
                string combo = letter + letter2;
                string variate = combo + Repeated;
                return variate;
            }
            else
                return "";
        }

        protected virtual string RepeatSequence3(int Choice)
        {
            // RepeatSequence3: This function is intended repeat a sequence from the
            // encapsulated word. It takes two characters from the word and repeats 
            // the characters a random number of times between the interval 0 to the 
            // length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with two characters appended on the front and 
            //         on the end  of the string if state is active
            //       - Returns an empty string if state is inactive
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = 2;
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum - 1];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }
                string Repeated = new string(sequenceRepeat); // Convert char back to string
                string letter = new string(anyLetter[0], randNum); //repeats letter
                string letter2 = new string(anyLetter[1], randNum); // repeats lettter
                string combo = letter + letter2;
                string variate = combo + Repeated + combo;
                return variate;
            }
            else
                return "";
        }

        protected virtual string RepeatSequence4(int Choice)
        {
            // RepeatSequence4: This function is intended repeat a sequence from the
            // encapsulated word. It takes one character from the word and repeats 
            // the character a random number of times between the interval 0 to the 
            // length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns a string with random amounts of a single character 
            //         appended randomly in the middle  of the string if state is 
            //         active
            //       - Returns an empty string if state is inactive
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = 2;
                }
                char[] sequenceRepeat = new char[VariWord.Length];
                char[] anyLetter = new char[VariWord.Length];
                string myletter = Convert.ToString(VariWord[randNum]);
                char[] repeater = new char[100];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                for (int i = 0; i < VariWord.Length; i++)
                {
                    sequenceRepeat[i] = VariWord[i];
                }

                string Repeated = new string(sequenceRepeat); // Convert char back to string
                string letter = new string(anyLetter[0], randNum); //repeats letter
                int index = 0;
                if (VariWord.Length <= 3)
                {
                    index = randNum;
                }
                else
                {
                    index = randNum + 2;
                }
                string variate = Repeated.Insert(index, letter);
                return variate;
            }
            else
                return "";
        }

        protected virtual string RepeatSequence5(int Choice)
        {
            // RepeatSequence5: This function is intended to inverse the word, that 
            // is a palindrome. In addition, it takes a single character from the 
            // word and is inserted randomly in the newly palindrome string.
            // PRE: - Choice is allowed to be any number more than or equal to 1.
            // POST: - Returns the palindrome of the string with one single character
            //         appended randomly within the string if state is active
            //       - Returns an empty string if state is inactive
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == 0)
                {
                    randNum = 2;
                }
                int x = VariWord.Length + 3;
                char[] sequenceRepeat = new char[x];
                char[] anyLetter = new char[x];
                string myletter = Convert.ToString(VariWord[randNum]);
                char[] repeater = new char[100];
                if (VariWord.Length <= 3)
                {
                    randNumModifier = 2;
                }
                anyLetter[0] = VariWord[randNum];
                int j = 0;
                for (int i = VariWord.Length-1; i >= 0; i--)
                {
                    sequenceRepeat[j] = VariWord[i];
                    j++;
                }

                string Repeated = new string(sequenceRepeat); // Convert char back to string
                string letter = Convert.ToString(anyLetter[0]);
                string variate = Repeated.Insert(randNum, letter);
                return variate;
            }
            else
                return "";
        }

        public virtual bool CheckUserGuess(string AnyGuess)
        {
            // CheckUserGuess: This function is intended to determine whether 
            // the user has guessed the word correctly in the base class (sequenceEnum).
            // PRE: - AnyGuess must be string that only contains lower-case English alphabets
            //      - The string should also be reasonable and appropriate for processing
            // POST: - Returns true when the user has made a correct guess
            //       - Returns false when the user has made an incorrect guess
            string StoredWord = new string(VariWord);
            if (AnyGuess == StoredWord)
            {
                UserGuess = true;
            }
            else
                UserGuess =  false;
            return UserGuess;
        }
        
        public virtual bool ModifyIfActive(int Choice)
        {
            // ModifyIfActive: This function is intended to modify the state of the
            // object between active and inactive.
            // PRE: - Choice must be an integer between 1 or 2
            // POST: - Modifies the current state to true when Choice is 1
            //       - Modifies the current state to false when Choice is 2
            //       - Return the current state of the object
            if (Choice == 1)
            {
                IsStateActive = true;
            }
            else if (Choice == 2)
            {
                IsStateActive = false;
            }
            else
                IsStateActive = true;
            return IsStateActive;
        }

    }
}

