// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: sequenceEnum.h
// Version: 1.0
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
//       Association: This class has a Is-A relationship with the derived classes.
//                    (Parent to seqExtract & spasEnum class)
//       Cardinality: 1 to 1.
// - All sequenceEnum objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - Number of options of GetVariant() is dependent on class, sequenceEnum class
//   has a total of 5 variations that can be performed. (RepeatedSequence1(),
//   RepeatSequence2(), RepeatSequence3(), RepeatSequence4(), RepeatSequence5())
// - All functions are made virtual to provide access to descendants or to any 
//   potential children classes
//
// Interface Invariants:
// - All public functions are declare virtual to provide functionality to derived classes.
// - Constructor and all methods are only allowed to be passed by value.
// - Once an sequenceEnum object is turned off(inactive), it will no longer produce 
//   any variations of the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Application programmer responsible for checking whether if word passed in appropriate 
//   to avoid out of index bounds.
#include <iostream>
#include <stdlib.h>
#include<string>
#ifndef _SEQUENCE_ENUM_H
#define _SEQUENCE_ENUM_H
using namespace std;
class sequenceEnum
{
private:
	string RepeatSequence1(int Choice);
	// RepeatSequence1: This function is intended repeat a sequence from the
	// encapsulated word. It takes two characters from the word and repeats 
	// the characters a random number of times between the interval 0 to the 
	// length of the encapsulated word.
	// PRE: - Choice is allowed to be any number more than or equal to 1.
	//		- State must be active to use function
	// POST: - Returns a string with two characters appended on the end  of 
	//         the string if state is active
	//       - Returns an empty string if state is inactive
	//		 - randNum state has been altered, value adjusted in random fashion.
	//		 - variate state has been altered, string manipulated for a variation.
	//		 - sequenceRepeat state has been altered, string adopted same data 
	//         as encapsulated word.
	//		 - anyLetter state has been altered, values adopted some new 
	//         character(s).
	string RepeatSequence2(int Choice);
	// RepeatSequence2: This function is intended repeat a sequence from the
	// encapsulated word. It takes two characters from the word and repeats 
	// the characters a random number of times between the interval 0 to the 
	// length of the encapsulated word.
	// PRE: - Choice is allowed to be any number more than or equal to 1.
	//		- State must be active to use function
	// POST: - Returns a string with two characters appended on the front
	//          of the string if state is active
	//       - Returns an empty string if state is inactive
	//		 - randNum state has been altered, value adjusted in random fashion.
	//		 - variate state has been altered, string manipulated for a variation.
	//		 - sequenceRepeat state has been altered, string adopted same data 
	//         as encapsulated word.
	//		 - anyLetter state has been altered, values adopted some new 
	//         character(s).
	//		 - letter and letter2 state has been altered, values adopted
	//		   multiple repeats of its own character.
	string RepeatSequence3(int Choice);
	// RepeatSequence4: This function is intended repeat a sequence from the
	// encapsulated word. It takes one character from the word and repeats 
	// the character a random number of times between the interval 0 to the 
	// length of the encapsulated word.
	// PRE: - Choice is allowed to be any number more than or equal to 1.
	//		- State must be active to use function
	// POST: - Returns a string with random amounts of a single character 
	//         appended randomly in the middle  of the string if state is 
	//         active
	//       - Returns an empty string if state is inactive
	//		 - randNum state has been altered, value adjusted in random fashion.
	//		 - variate state has been altered, string manipulated for a variation.
	//		 - sequenceRepeat state has been altered, string adopted same data 
	//         as encapsulated word.
	//		 - anyLetter state has been altered, values adopted some new 
	//         character(s).
	//		 - letter and state has been altered, values adopted
	//		   multiple repeats of its own character.
	string RepeatSequence4(int Choice);
	// RepeatSequence5: This function is intended to inverse the word, that 
	// is a palindrome. In addition, it takes a single character from the 
	// word and is inserted randomly in the newly palindrome string.
	// PRE: - Choice is allowed to be any number more than or equal to 1.
	//		- State must be active to use function
	// POST: - Returns the palindrome of the string with one single character
	//         appended randomly within the string if state is active
	//       - Returns an empty string if state is inactive
	//		 - randNum state has been altered, value adjusted in random fashion.
	//		 - variate state has been altered, string manipulated for a variation.
	//		 - sequenceRepeat state has been altered, string adopted same data 
	//         as encapsulated word.
	//		 - anyLetter state has been altered, values adopted some new 
	//         character(s).
	//		 - letter and letter2 state has been altered, values adopted
	//		   multiple repeats of its own character.
	int CurRandCount;
	int AnyOption;
	int randNumModifier;
	int randNum;
	int NumOfOptions;
	int WordLength;
protected:
	//Constant Variables
	static const int RANDNUM = 2;	
	static const int RANDNUMAPPLIER = 3;
	static const int NEXTLETTERINDEX = 1;
	static const int RANDNUMMODIFIER = 3;
	static const int MINWORDSIZE = 4;
	static const int INDEXAPPLY = 2;
	static const int SETACTIVECOND = 1;
	static const int SETINACTIVECOND = 2;
	static const int INVALIDRANDNUM = 0;
	//Member Variables
	string VariWord;	
	bool UserGuess;
	bool IsStateActive;
public:
	sequenceEnum() { }
	//Default Constructor Suppressed.
	//PRE: - N/A
	//POST: - N/A
	virtual ~sequenceEnum() { }
	//Default Destructor Suppressed.
	//PRE: - N/A
	//POST: - N/A
	sequenceEnum(string AnyWord);
	//Overloaded constructor
	// PRE: - AnyWord must be a string that is in english lowercase alphabets and 
	//        at least 4 characters long.
	// POST: - All protected data members are initialized, VariWord encapsulated 
	//         a word and state is set to active.
	virtual string GetVariant(string sub);
	// GetVariant: This function is intended to be overriden in the child class 
	//             (seqExtract).
	// PRE: - sub can be a string of any length of mixed lower case alphabets 
	//        and of length less than encapsulated word.
	// POST: - Returns NOP.
	virtual string GetVariant();
	// GetVariant: This function is intended to be cycle through the variations
	// from sequenceRepeat, and emit variations of the encapsulated word.
	// PRE: - N/A
	// POST: - Returns a string from four possible variations of the encapsulated
	// word
	//		 - print state has been altered, value replaced with a RepeatSequence
	//		 - AnyOption state has been altered, value increased.  
	//		 - CurRandCount state has been altered, value increased.
	bool CheckUserGuess(string AnyGuess);
	// CheckUserGuess: This function is intended to determine whether 
	// the user has guessed the word correctly in the base class (sequenceEnum).
	// PRE: - AnyGuess must be string that only contains lower-case English 
	//		  alphabets
	//      - The string should also be reasonable and appropriate for processing
	// POST: - Returns true when the user has made a correct guess
	//       - Returns false when the user has made an incorrect guess
	//		 - UserGuess state has been altered, value replaced with a user's 
	//	       guess. True if correct and False if incorrect.
	bool ModifyIfActive(int Choice);
	// ModifyIfActive: This function is intended to modify the state of the
	// object between active and inactive.
	// PRE: - Choice must be an integer between 1 or 2
	//		- If left unchanged, state remains as Active
	// POST: - Return the current state of the object
	//		 - IsStateActive state has been altered, value set to true
	//		   when Choice is equal to 1.
	//		 - IsStateActive state has been altered, value set to false
	//		   when Choice is equal to 2.
	//		 - IsStateActive state remains unchanged, value is still false
	//		   when Choice is any integer besides 1 or 2.
};
#endif
