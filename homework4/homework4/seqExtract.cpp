// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: seqExtract.cpp
// Version: 1.0
// Purpose: This is an seqExtract class that is derived from SequenceEnum. 
// The purpose of this class is to contain all the functions in SequenceEnum 
// and implements additional features that overrides existing functionalities 
// from the base class. seqExtract encapsulates a word, and extracts a subsequence 
// from the encapsulated word.
//
// Implementation Invariants:
// - NOP if GetVariant(string sub) invoked for seqExtract object.
// - All data members declared protected provide internal functionality to 
//   derived class (seqExtract).
// - GetVariant(string sub) is overriden from the base class to support 
//   individual functionality separate from the parent's method, that is, 
//   it removes a subsequence of the string and returns the remaining 
//   characters.
// - randNum and randNumModifier are used to produce randomness within the 
//   variations applied onto the encapsulated word. It is to mimic a 
//   seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices when 
//   getting variants of word.
#include "seqExtract.h"
seqExtract::seqExtract(string AnyWord = "") :sequenceEnum(AnyWord)
{
	VariWord = AnyWord;
}

string seqExtract::GetVariant(string sub)
{
	string DisplayWord = "";
	if (IsStateActive)
	{
		DisplayWord = VariWord;
		size_t index = DisplayWord.find(sub);
		if(index != string::npos)
			DisplayWord = DisplayWord.erase(index, sub.size());
		else
			DisplayWord = "";
	}
	return DisplayWord;
}

string seqExtract::GetVariant()
{
	return "";
}
