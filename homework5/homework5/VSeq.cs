// Name: Rueben Tiow
// Last Modification: 3/9/2017
// File: VSeq.cs
// Version: 2.0
// Purpose: This is an VSeq class that is derived from an Inverter interface 
// and a sequenceEnum class. The purpose of a VSeq class is to inherit all 
// the functions from sequenceEnum class and implement the methods from the 
// Inverter interface (IInverter).
//
// Class Invariants:
// - Minimum 1 possible VSeq object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the base 
//		 class.(SequenceEnum class)
//       Cardinality: 1 to 1.
// - All VSeq objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - An object's state cannot be changed after becoming Inactive.
//
// Interface Invariants:
// - Constructor and all methods are only allowed to be passed by value.
// - An VSeq object state is always active, and will only become inactive
//   once an VSeq object call GetInvertVariant exceeds NUMOFGETWORDS(4).
//   (GetState)
// - Once an VSeq object is turned off(inactive), it will no longer 
//   produce any variations of the word. (ModifyIfActive)
// - An inactive Inverter object's will no longer produce any inversions of 
//   the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Every integer passed into this object must be more than or equal to 0 
//   and less than the length of the word.
//
// Implementation Invariants:
// - All data members declared protected provide internal functionality to 
//   derived class (VSeq).
// - randNum and randNumModifier are used to produce randomness within the 
//   variations applied onto the encapsulated word. It is to mimic a 
//   seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices when 
//   getting variants of word.
// - All numbers must be an integer that is more than or equal to 0 and 
//   less than the length of the word, in order to have correct 
//   indices when getting inversions of word.
using homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class VSeq : sequenceEnum, IInverter
    {
        //Constant Variables
        private const int NUMOFGETWORDS = 4;

        //Member Variables
        private int InvertIndex;
        private bool IIsStateActive;
        private int TrackState;

        public VSeq(string AnyWord, int AnyIndex) : base(AnyWord)
        //Overload constructor
        // PRE: - AnyWord must be a string that is in english lowercase 
        //        alphabets and at least 4 characters long.
        // POST: - Fire the base class constructor (sequenceEnum) 
        //       - Initializes all inherited protected data members and 
        //         VariWord encapsualted a word and state is set to active.
        //       - All protected data members are initialized, AnyIndex 
        //         encapsulated a integer, and state is set to active.
        {
            if (AnyIndex >= 0)
                InvertIndex = AnyIndex;
            IIsStateActive = true;
            TrackState = 0;
        }
        public string GetInvertVariant(string AnyWord)
        // GetInvertVariant: This function is intended to invert the two 
        // elements from a given sequence(AnyWord) at indices i and i+1 
        // and emit the inverted word.
        // PRE: - All words must be 4 characters long and be in english 
        //        lowercase alphabet letters.
        //		- State must be active to use function
        // POST: - State remains active until exceeding NUMOFGETWORDS(4).
        //		 - An inactive state will produce an empty string.
        //		 - SwapWord state has been altered, string adopted same data 
        //         as encapsulated word.
        //		 - IIsStateActive state has been altered, value set to true
        //		   to false once calling GetInvertVariant more than 
        //         NUMOFGETWORDS(4).
        {
            string SwapWord = "";
            if (IIsStateActive)
            {
                if (InvertIndex <= (AnyWord.Length))
                {
                    if (TrackState <= NUMOFGETWORDS)
                    {
                        char[] Swaped = AnyWord.ToCharArray(); 
                        char FirstIndexChar = Swaped[InvertIndex];

                        Swaped[InvertIndex] = Swaped[InvertIndex 
                            + NEXTLETTERINDEX];

                        Swaped[InvertIndex + NEXTLETTERINDEX] = 
                            FirstIndexChar;

                        SwapWord = new string(Swaped);
                        TrackState++;
                        IIsStateActive = true;
                    }
                    else
                    {
                        IIsStateActive = false;
                    }
                }
            }
            return SwapWord;
        }
        public bool GetState()
        // GetState: This function is intended to return the current state 
        // of the object.
        // PRE: - N/A
        // POST: - N/A
        {
            return IIsStateActive;
        }
    }
}
