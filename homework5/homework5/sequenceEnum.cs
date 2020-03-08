// Name: Rueben Tiow
// Last Modification: 3/9/2017
// File: sequenceEnum.cs
// Version: 2.0
// Purpose: This is an SequenceEnum class that lays the foundation for 
// two other child classes. The purpose of this class is to contain the 
// functions intended to be used in the driver. This has a class heirarchy 
// of SequenceEnums where each SequenceEnum object encapsulates a word, 
// and responds to inquiries. The encapsulated word is mixed around 
// seemingly arbitrarily.
//
// Class Invariants:
// - Minimum 1 possible sequenceEnum object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the derived 
//                    classes.(Parent to seqExtract & spasEnum class)
//       Cardinality: 1 to 1.
// - All sequenceEnum objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, sequenceEnum
//   class has a total of 5 variations that can be performed. 
//   (RepeatedSequence1(), RepeatSequence2(), RepeatSequence3(), 
//    RepeatSequence4(), RepeatSequence5())
//
// Interface Invariants:
// - Constructor and all methods are only allowed to be passed by value.
// - Once an sequenceEnum object is turned off(inactive), it will no longer 
//   produce any variations of the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Application programmer responsible for checking whether if word passed 
//   in appropriate to avoid out of index bounds.
//
// Implementation Invariants:
// - All data members are declared protected to provide internal access 
//   to derived classes.
// - randNum and randNumModifier are used to produce randomness within 
//   the variations applied onto the encapsulated word. It is to mimic 
//   a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices 
//   when getting variants of word.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class sequenceEnum
    {
        //Constant Variables
        protected const int RANDNUM = 2;
        protected const int RANDNUMAPPLIER = 4;
        protected const int NEXTLETTERINDEX = 1;
        protected const int RANDNUMMODIFIER = 3;
        protected const int MINWORDSIZE = 4;
        protected const int INDEXAPPLY = 2;
        protected const int SETACTIVECOND = 1;
        protected const int SETINACTIVECOND = 2;
        protected const int INVALIDRANDNUM = 0;

        //Private Member Variables
        private int CurRandCount;
        private int AnyOption;
        private int randNumModifier;
        private int randNum;
        private int NumOfOptions;
        private int WordLength;

        //Protected Member Variables
        protected char[] VariWord;
        protected bool UserGuess;
        protected bool IsStateActive;

        //Overloaded constructor
        public sequenceEnum(string AnyWord = "")
        {
            //Overloaded constructor
            // PRE: - AnyWord must be a string that is in english lowercase 
            //        alphabets and at least 4 characters long.
            // POST: - All protected data members are initialized, VariWord 
            //         encapsulated a word and state is set to active.
            VariWord = new char[AnyWord.Length];
            IsStateActive = true;
            UserGuess = false;
            CurRandCount = 1;
            AnyOption = 1;
            WordLength = AnyWord.Length;
            randNumModifier = (WordLength - 1);
            randNum = 0;
            NumOfOptions = 4;
            if (WordLength >= MINWORDSIZE)
            {
                for (int i = 0; i < WordLength; i++)
                {
                    VariWord[i] = Convert.ToChar(AnyWord[i]);
                }
            }
        }

        //Public Methods
        public string GetVariant()
        {
            // GetVariant: This function is intended to be cycle through 
            // the variations from sequenceRepeat, and emit variations of 
            // the encapsulated word.
            // PRE: - N/A
            // POST: - print state has been altered, value replaced with a 
            //         RepeatSequence
            //		 - AnyOption state has been altered, value increased.
            //		 - CurRandCount state has been altered, value increased.
            string print = "";
            if (AnyOption == 1)
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence1(CurRandCount);
            }
            else if (AnyOption == 2)
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence2(CurRandCount);
            }
            else if (AnyOption == 3)
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence3(CurRandCount);
            }
            else
            {
                CurRandCount = CurRandCount + RANDNUMAPPLIER;
                print = RepeatSequence4(CurRandCount);
            }
            AnyOption = ((AnyOption + 1) % NumOfOptions);
            return print;
        }

        public bool CheckUserGuess(string AnyGuess)
        {
            // CheckUserGuess: This function is intended to determine whether 
            // the user has guessed the word correctly in the base class 
            // (sequenceEnum).
            // PRE: - AnyGuess must be string that only contains lower-case 
            //        English alphabets
            //      - The string should also be reasonable and appropriate 
            //        for processing
            // POST: - UserGuess state has been altered, value replaced with 
            //         a user's guess. True if correct and False if 
            //         incorrect.
            string StoredWord = new string(VariWord);
            if (AnyGuess == StoredWord)
            {
                UserGuess = true;
            }
            else
                UserGuess = false;
            return UserGuess;
        }

        public bool ModifyIfActive(int Choice)
        {
            // ModifyIfActive: This function is intended to modify the state
            // of the object between active and inactive.
            // PRE: - Choice must be an integer between 1 or 2
            //		- If left unchanged, state remains as Active
            // POST: - IsStateActive state has been altered, value set to
            //         true when Choice is equal to 1.
            //		 - IsStateActive state has been altered, value set to 
            //         false when Choice is equal to 2.
            //		 - IsStateActive state remains unchanged, value is still 
            //         false when Choice is any integer besides 1 or 2.
            if (Choice == SETACTIVECOND)
                IsStateActive = true;
            else if (Choice == SETINACTIVECOND)
                IsStateActive = false;
            else
                IsStateActive = true;
            return IsStateActive;
        }

        //Private Methods
        private string RepeatSequence1(int Choice)
        {
            // RepeatSequence1: This function is intended repeat a sequence 
            // from the encapsulated word. It takes two characters from the 
            // word and repeats the characters a random number of times 
            // between the interval 0 to the length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal 
            //        to 1.
            //		- State must be active to use function
            // POST: - randNum state has been altered, value adjusted in 
            //         random fashion.
            //		 - variate state has been altered, string manipulated for 
            //         a variation.
            //		 - sequenceRepeat state has been altered, string adopted 
            //         same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some 
            //         new 
            //         character(s).
            //		 - letter and letter2 state has been altered, values 
            //         adopted multiple repeats of its own character.
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
                string Repeated = new string(VariWord);
                string letter = new string(anyLetter[0], randNum); 
                string letter2 = new string(anyLetter[1], randNum); 
                string combo = letter2 + letter;
                string variate = Repeated + combo;
                return variate;
            }
            else
                return "";
        }

        private string RepeatSequence2(int Choice)
        {
            // RepeatSequence2: This function is intended repeat a sequence 
            // from the encapsulated word. It takes two characters from the 
            // word and repeats the characters a random number of times 
            // between the interval 0 to the length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal 
            //        to 1.
            //		- State must be active to use function
            // POST: - randNum state has been altered, value adjusted in 
            //         random fashion.
            //		 - variate state has been altered, string manipulated for 
            //         a variation.
            //		 - sequenceRepeat state has been altered, string adopted 
            //         same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some 
            //         new 
            //         character(s).
            //		 - letter and letter2 state has been altered, values 
            //         adopted multiple repeats of its own character.
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum];
                anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
                string Repeated = new string(VariWord);
                string letter = new string(anyLetter[0], randNum); 
                string letter2 = new string(anyLetter[1], randNum); 
                string combo = letter2 + letter;
                string variate = combo + Repeated;
                return variate;
            }
            else
                return "";
        }

        private string RepeatSequence3(int Choice)
        {
            // RepeatSequence3: This function is intended repeat a sequence 
            // from the encapsulated word. It takes one character from the 
            // word and repeats the character a random number of times between 
            // the interval 0 to the length of the encapsulated word.
            // PRE: - Choice is allowed to be any number more than or equal 
            //        to 1.
            //		- State must be active to use function
            // POST: - randNum state has been altered, value adjusted in 
            //         random fashion.
            //		 - variate state has been altered, string manipulated for 
            //         a variation.
            //		 - sequenceRepeat state has been altered, string adopted 
            //         same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some 
            //         new 
            //         character(s).
            //		 - letter and letter2 state has been altered, values 
            //         adopted multiple repeats of its own character.
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] sequenceRepeat = new char[WordLength];
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum];
                string Repeated = new string(VariWord); 
                string letter = new string(anyLetter[0], randNum);
                int index = 0;
                if (VariWord.Length <= MINWORDSIZE)
                    index = randNum;
                else
                    index = randNum + INDEXAPPLY;
                string variate = Repeated.Insert(index, letter);
                return variate;
            }
            else
                return "";
        }

        private string RepeatSequence4(int Choice)
        {
            // RepeatSequence4: This function is intended to inverse the word,
            // that is a palindrome. In addition, it takes a single character 
            // from the word and is inserted randomly in the newly palindrome 
            // string.
            // PRE: - Choice is allowed to be any number more than or equal 
            //        to 1.
            //		- State must be active to use function
            // POST: - randNum state has been altered, value adjusted in 
            //         random fashion.
            //		 - variate state has been altered, string manipulated for 
            //         a variation.
            //		 - sequenceRepeat state has been altered, string adopted 
            //         same data 
            //         as encapsulated word.
            //		 - anyLetter state has been altered, values adopted some 
            //         new 
            //         character(s).
            //		 - letter and letter2 state has been altered, values 
            //         adopted multiple repeats of its own character.
            if (IsStateActive == true)
            {
                randNum = (Choice % randNumModifier);
                if (randNum == INVALIDRANDNUM)
                    randNum = RANDNUM;
                char[] sequenceRepeat = new char[WordLength];
                char[] anyLetter = new char[WordLength];
                anyLetter[0] = VariWord[randNum];
                int j = 0;
                for (int i = VariWord.Length - 1; i >= 0; i--)
                {
                    sequenceRepeat[j] = VariWord[i];
                    j++;
                }
                string Repeated = new string(sequenceRepeat);
                string letter = Convert.ToString(anyLetter[0]);
                string variate = Repeated.Insert(randNum, letter);
                return variate;
            }
            else
                return "";
        }
    }
}

