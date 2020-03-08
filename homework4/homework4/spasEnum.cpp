// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: spasEnum.cpp
// Version: 1.0
// Purpose: This is an spasEnum class that is derived from SequenceEnum. 
// The purpose of this class is to contain all the functions in SequenceEnum and 
// implements additional features that overrides existing functionalities 
// from the base class. spasEnums encapsulates a word, and concatenates 
// an internal subsequence, seemingly arbitrarily.
//
// Implementation Invariants:
// - All data members declared protected provide internal functionality 
//   to derived class (spasEnum).
// - randNum and randNumModifier are used to produce randomness within 
//   the variations applied onto the encapsulated word. It is to mimic 
//   a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices
//   when getting variants of word.
#include "spasEnum.h"
spasEnum::spasEnum(string AnyWord) : sequenceEnum(AnyWord)
{
  VariWord = AnyWord;
  CurRandCount = 1;
  AnyOption = 1;
  WordLength = int(AnyWord.size());
  randNumModifier = (WordLength - 1);
  randNum = 0;
  NumOfOptions = 2;
}

string spasEnum::GetVariant(string sub)
{
	return "";
}

string spasEnum::GetVariant()
{
	string print = "";
	if (AnyOption == 1)
	{
		CurRandCount = CurRandCount + RANDNUMAPPLIER;
		print = RepeatSequence1(CurRandCount);
	}
	else
	{
		CurRandCount = CurRandCount + RANDNUMAPPLIER;
		print = RepeatSequence2(CurRandCount);
	}
	AnyOption = ((AnyOption + 1) % NumOfOptions);
	return print;
}

string spasEnum::RepeatSequence1(int Choice)
{
	string sequenceRepeat = VariWord;
	string anyLetter[3];
	if (IsStateActive)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = ((Choice * RANDNUMAPPLIER) % randNumModifier);
		anyLetter[0] = VariWord[randNum];
		anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
		anyLetter[2] = VariWord[randNum + NEXTLETTERINDEX + NEXTLETTERINDEX];
		string combo = anyLetter[0] + anyLetter[1] + anyLetter[2];
		string variate = combo + sequenceRepeat;
		return variate;
	}
	else
	{
		randNum = (CurRandCount % int(sequenceRepeat.size()));
		if (randNum < MINWORDSIZE)
			randNum = randNum + INDEXAPPLY;
		string temp = TruncateWord(sequenceRepeat, randNum);
		return temp;
	}
}

string spasEnum::RepeatSequence2(int Choice)
{
	string sequenceRepeat = VariWord;
	string anyLetter[3];
	if (IsStateActive == true)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = ((Choice * RANDNUMAPPLIER) % randNumModifier);
		anyLetter[0] = VariWord[randNum];
		anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
		anyLetter[2] = VariWord[randNum + NEXTLETTERINDEX + NEXTLETTERINDEX];
		string combo = anyLetter[0] + anyLetter[1] + anyLetter[2];
		string variate = sequenceRepeat + combo;
		return variate;
	}
	else
	{
		randNum = (CurRandCount % int(sequenceRepeat.size()));
		if (randNum < MINWORDSIZE)
			randNum = randNum + INDEXAPPLY;
		string temp = TruncateWord(sequenceRepeat, randNum);
		return temp;
	}
}

string spasEnum::TruncateWord(string source, int length)
{
	string TruncatedWord = "";
	if (int(source.size()) > length)
	{
		TruncatedWord = source.substr(0, length);
	}
	return TruncatedWord;
}
