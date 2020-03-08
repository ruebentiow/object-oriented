// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: seqExtract.h
// Version: 1.0
// Purpose: This is an seqExtract class that is derived from SequenceEnum. 
// The purpose of this class is to contain all the functions in SequenceEnum 
// and implements additional features that overrides existing functionalities 
// from the base class. seqExtract encapsulates a word, and extracts a subsequence 
// from the encapsulated word.
//
// Class Invariants:
// - Minimum 1 possible seqExtract object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the base class.
//                    (Child of sequenceEnum class and Parent of VSeq Class)
//       Cardinality: 1 to 1.
// - All seqExtract objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, seqExtract class
//   has a total of one variation that can be performed. (GetVariant(string sub))
// - All functions are made virtual to provide access to descendants or to any 
//   potential children classes
//
// Interface Invariants:
// - All virtual functionality reused in seqExtract are overriden.
// - Constructor and all methods are only allowed to be passed by value.
// - All Interface invariants in base class is implied for derive class (seqExtract).
// - Once an seqExtract object is turned off(inactive), it will no longer produce 
//   any variations of the word.
#include <iostream>
#include <stdlib.h>
#include<string>
#include "sequenceEnum.h"
#ifndef _SEQEXTRACT_H
#define _SEQEXTRACT_H
using namespace std;
class seqExtract : public virtual sequenceEnum
{
public:
	virtual ~seqExtract() { }
	//Default Destructor Suppressed.
	//PRE: - N/A
	//POST: - N/A
	seqExtract(string AnyWord);
	//Overload constructor
	// PRE: - AnyWord must be a string that is in english lowercase alphabets and 
	//		  at least 4 characters long.
	// POST: - Fire the base class constructor (sequenceEnum) 
	//       - Initializes all inherited protected data members and VariWord 
	//		encapsulated a word and state is set to active.
	virtual string GetVariant(string sub);
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
	virtual string GetVariant();
	// GetVariant: This function is intended to be overriden in the base class 
	//             (sequenceEnum).
	// PRE: - N/A
	// POST: - Returns NOP.
};
#endif
