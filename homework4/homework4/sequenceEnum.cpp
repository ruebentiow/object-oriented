// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: sequenceEnum.cpp
// Version: 1.0
// Purpose: This is an SequenceEnum class that lays the foundation for 
// two other child classes. The purpose of this class is to contain the 
// functions intended to be used in the driver. This has a class heirarchy 
// of SequenceEnums where each SequenceEnum object encapsulates a word, 
// and responds to inquiries. The encapsulated word is mixed around 
// seemingly arbitrarily.
//
// Implementation Invariants:
// - NOP if GetVariant(string sub) invoked for sequenceEnum object.
// - All data members are declared protected to provide internal access 
//   to derived classes.
// - randNum and randNumModifier are used to produce randomness within 
//   the variations applied onto the encapsulated word. It is to mimic 
//   a seemingly arbritary pattern.
// - All words must be 4 characters long in order to have correct indices 
//   when getting variants of word.
#include "sequenceEnum.h"
sequenceEnum::sequenceEnum(string AnyWord = "")
{
	if (int(AnyWord.size()) >= MINWORDSIZE)
		VariWord = AnyWord;
	IsStateActive = true;
	UserGuess = false;
	CurRandCount = 1;
	AnyOption = 1;
	WordLength = int(AnyWord.size());
	randNumModifier = (WordLength - 1);
	randNum = 0;
	NumOfOptions = 4;
}

string sequenceEnum::GetVariant(string sub)
{
	return "";
}

string sequenceEnum::GetVariant()
{
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


string sequenceEnum::RepeatSequence1(int Choice)
{
	if (IsStateActive)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = RANDNUM;
		string sequenceRepeat = VariWord;
		string anyLetter[2];
		anyLetter[0] = VariWord[randNum];
		anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
		string letter;
		string letter2;
		for (int i = 0; i < randNum; i++)
		{
			letter += anyLetter[0];
			letter2 += anyLetter[1];
		}
		string combo = letter2 + letter;
		string variate = sequenceRepeat + combo;
		return variate;
	}
	else
		return "";
}

string sequenceEnum::RepeatSequence2(int Choice)
{
	if (IsStateActive)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = RANDNUM;
		string sequenceRepeat = VariWord;
		string anyLetter[2];
		anyLetter[0] = VariWord[randNum];
		anyLetter[1] = VariWord[randNum + NEXTLETTERINDEX];
		string letter;
		string letter2;
		for (int i = 0; i < randNum; i++)
		{
			letter += anyLetter[0];
			letter2 += anyLetter[1];
		}
		string combo = letter2 + letter;
		string variate = combo + sequenceRepeat;
		return variate;
	}
	else
		return "";
}

string sequenceEnum::RepeatSequence3(int Choice) 
{
	if (IsStateActive)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = RANDNUM;
		string sequenceRepeat = VariWord;
		string anyLetter[1];
		anyLetter[0] = VariWord[randNum];
		string letter;
		for (int i = 0; i < randNum; i++)
			letter += anyLetter[0];
		int index = 0;
		if (int(VariWord.size()) <= MINWORDSIZE)
			index = randNum;
		else
			index = randNum + INDEXAPPLY;
		sequenceRepeat.insert(index, letter);
		return sequenceRepeat;
	}
	else
		return "";
}

string sequenceEnum::RepeatSequence4(int Choice) 
{
	if (IsStateActive)
	{
		randNum = (Choice % randNumModifier);
		if (randNum == INVALIDRANDNUM)
			randNum = RANDNUM;
		string sequenceRepeat = VariWord;
		string anyLetter[1];
		anyLetter[0] = VariWord[randNum];
		string letter;
		for (int i = 0; i < randNum; i++)
			letter += anyLetter[0];
		int j = 0;
		for (int i = (int(VariWord.size())) - 1; i >= 0; i--)
		{
			sequenceRepeat[j] = VariWord[i];
			j++;
		}
		sequenceRepeat.insert(randNum, letter);
		return sequenceRepeat;
	}
	else
		return "";
}

bool sequenceEnum::CheckUserGuess(string AnyGuess)
{
	if (AnyGuess == VariWord)
		UserGuess = true;
	else
		UserGuess = false;
	return UserGuess;
}

bool sequenceEnum::ModifyIfActive(int Choice)
{
	if (Choice == SETACTIVECOND)
		IsStateActive = true;
	else if (Choice == SETINACTIVECOND)
		IsStateActive = false;
	else
		IsStateActive = true;
	return IsStateActive;
}