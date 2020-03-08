// Name: Rueben Tiow
// Last Modification: 2/11/2017
// File: seqExtract.cs
// Version: 1.0
// Purpose: This is an seqExtract class that is derived from SequenceEnum. The purpose of this class is to contain 
// all the functions in SequenceEnum and implements additional features that overrides existing functionalities 
// from the base class. seqExtract encapsulates a word, and extracts a subsequence from the encapsulated word.
//
// Class Invariants:
// - Minimum 1 possible seqExtract object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the base class.
//                    (sequenceEnum class)
//       Cardinality: 1 to 1.
// - All seqExtract objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, seqExtract class
//   has a total of one variation that can be performed. (GetVariant(string sub))
//
// Interface Invariants:
// - All virtual functionality reused in seqExtract are overriden.
// - All Interface invariants in base class is implied for derive class (seqExtract).
//
// Implementation Invariants:
// - NOP if GetVariant(string sub) invoked for seqExtract object.
// - All data members declared protected provide internal functionality to derived class (seqExtract).
// - GetVariant(string sub) is overriden from the base class to support individual functionality
//   separate from the parent's method, that is, it removes a subsequence of the string and returns the
//   remaining characters.
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
    public class seqExtract: SequenceEnum
    {
        //Overload constructor
        public seqExtract(string AnyWord = "") : base(AnyWord)
        {
            // PRE: AnyWord must be a string that is in english lowercase alphabets and at least 4 characters long.
            // POST: - Fire the base class constructor (sequenceEnum) 
            //       - Initializes all inherited protected data members and VariWord encapsualted a word and state is set to active.
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
            // object between active and inactive within the seqExtract class. It inherits
            // all functionalities pre-existing from the base class (sequenceEnum).
            // PRE: - Choice must be an integer between 1 or 2
            // POST: - Modifies the current state to true when Choice is 1
            //       - Modifies the current state to false when Choice is 2
            //       - Return the current state of the object
            return base.ModifyIfActive(Choice);
        }
        
        public override string GetVariant()
        {
            // GetVariant: This function is intended to be overriden in the base class (sequenceEnum).
            // PRE: - N/A
            // POST: - Returns NOP.
            return "";
        }

        public override string GetVariant(string sub)
        {
            // GetVariant: This function is intended to extract a subsequence of the encapsulated
            // word, if the subsequence is found.
            // PRE: - sub must be a string that contains english lower case alphabets
            //      - sub must also contain a sequence of letters contiguously
            //      - sub must be a substring of the encapsulated word
            // POST: - Returns the string with the substring removed
            //       - The string prints all remaining characters without the substring
            string DisplayWord = "";
            if (IsStateActive == true)
            {
                DisplayWord = new string(VariWord);
                int index = DisplayWord.IndexOf(sub);
                if (index >= 0)
                {
                    DisplayWord = DisplayWord.Remove(index, sub.Length);
                }
                else
                {
                    DisplayWord = "";
                }
            }
            return DisplayWord;
        }
    }
}

