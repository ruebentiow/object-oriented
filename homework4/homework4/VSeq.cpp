// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: VSeq.cpp
// Version: 1.0
// Purpose: This is an VSeq class that is derived from Inverter, SpasEnum and
// SeqExtract class. The purpose of a VSeq class is to inherit all the functions 
// from Inverter, SpasEnum and SeqExtract.
//
// Implementation Invariants:
// - All data members declared protected provide internal functionality to 
//   derived class (VSeq).
// - GetVariant(string sub) is derived from seqExtract and inherits all of its
//   functionality.
// - GetVariant() is derived from spasEnum and inherits all of its
//   functionality.
// - GetInvertVariant(string AnyWord) is derived from Inverter and inherits all 
//   of its functionality.
// - All words must be 4 characters long in order to have correct indices when 
//   getting variants of word.
// - Every integer passed into this object must be more than or equal to 0 and less 
//   than the length of the word.
#include "VSeq.h"
VSeq::VSeq(string AnyWord, int AnyIndex): spasEnum(AnyWord), 
seqExtract(AnyWord), Inverter(AnyIndex)
{
	VariWord = AnyWord;
	InvertIndex = AnyIndex;
}

string VSeq::GetVariant(string AnyWord)
{
	return seqExtract::GetVariant(AnyWord);
}

string VSeq::GetVariant()
{
	string word = spasEnum::GetVariant();
	return word;
}

string VSeq::GetInvertVariant(string AnyWord)
{
	return Inverter::GetInvertVariant(AnyWord);
}
