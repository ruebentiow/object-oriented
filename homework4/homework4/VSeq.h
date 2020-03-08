// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: VSeq.h
// Version: 1.0
// Purpose: This is an VSeq class that is derived from Inverter, SpasEnum and
// SeqExtract class. The purpose of a VSeq class is to inherit all the functions 
// from Inverter, SpasEnum and SeqExtract.
//
// Class Invariants:
// - Minimum 1 possible Inverter object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the derived 
//		 class.(VSeq class)
//       Cardinality: 1 to 1.
// - All VSeq objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - An objects state cannot be changed after becoming Inactive.
// - All functions are made virtual to provide access to descendants or to any 
//   potential children classes
//
// Interface Invariants:
// - All public functions are declare virtual to provide functionality to derived 
//   class. (VSeq)
// - Constructor and all methods are only allowed to be passed by value.
// - An VSeq object state is always active, and will only become inactive
//   once an VSeq object exceeds NUMOFGETWORDS(4).
// - An inactive Inverter object's will no longer produce any inversions of the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Every integer passed into this object must be more than or equal to 0 and less 
//   than the length of the word.
//
#include <iostream>
#include <stdlib.h>
#include<string>
#include "spasEnum.h"
#include "seqExtract.h"
#include "Inverter.h"
#ifndef _VSEQ_H
#define _VSEQ_H
using namespace std;
class VSeq : public spasEnum, public seqExtract, public Inverter
{
private:
	string VariWord;
	int InvertIndex;
public:	
	~VSeq() { }
	//Default Destructor Suppressed.
	//PRE: - N/A
	//POST: - N/A
	VSeq(string AnyWord , int AnyIndex);
	//Overload constructor
	// PRE: - AnyWord must be a string that is in english lowercase alphabets and 
	//		  at least 4 characters long.
	// POST: - Fire the base class constructor (Inverter, seqExtract, spasEnum in order) 
	//       - Initializes all inherited protected data members and VariWord 
	//		encapsualted a word and state is set to active.
	string GetVariant();
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
	string GetVariant(string AnyWord);
	// GetVariant: This function is intended to extract a subsequence of the 
	// encapsulated word, if the subsequence is found.
	// PRE: - sub must be a string that contains english lower case alphabets
	//      - sub must also contain a sequence of letters contiguously
	//      - sub must be a substring of the encapsulated word
	//		- State must be active to use function
	// POST: - Returns the string with the substring removed
	//       - The string prints all remaining characters without the substring
	//		 - DisplayWord state has been altered, string manipulated for a 
	//		   internal subsequence of encapsulated string.
	string GetInvertVariant(string AnyWord);
	// GetInvertVariant: This function is intended to invert the two elements from
	// from a given sequence(AnyWord) at indices i and i+1 and emit the inverted word.
	// PRE: - All words must be 4 characters long and be in english lowercase 
	//		  alphabet letters.
	//		- State must be active to use function
	// POST: - Returns a string inverted at the encapsulated index and the index + 1.
	//		 - State remains active until exceeding NUMOFGETWORDS(4).
	//		 - An inactive state will produce an empty string.
	//		 - SwapWord state has been altered, string adopted same data 
	//         as encapsulated word.
	//		 - IsStateActive state has been altered, value set to true
	//		   to false once calling GetInvertVariant more than NUMOFGETWORDS(4).
};
#endif