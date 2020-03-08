// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: Inverter.cpp
// Version: 1.0
// Purpose: This is an Inverter class that lays the foundation for 
// one other child class. The purpose of this class is to contain the 
// functions intended to be used in the driver. This has a class heirarchy 
// of Inverter where each Inverter object encapsulates an integer(index), 
// and responds to inquiries. The encapsulated integer(index) inverts two 
// elements of a given sequence at indices i and i+1. That is if the 
// encapsulate integer(index) was 2, i would be 2 and i+1 would be 3.
//
// Implementation Invariants:
// - All data members are declared protected to provide internal access 
//   to derived classes.
// - All words must be 4 characters long in order to have correct indices 
//   when getting inversions of word.
// - All numbers must be an integer that is more than or equal to 0 and 
//   less than the length of the word, in order to have correct 
//   indices when getting inversions of word.
#include "Inverter.h"
Inverter::Inverter(int AnyIndex = 0) 
{
	if (AnyIndex >= 0)
		InvertIndex = AnyIndex;
	IsStateActive = true;
	TrackState = 0;
}

string Inverter::GetInvertVariant(string AnyWord)
{
	string SwapWord = AnyWord;
	if (IsStateActive)
	{
		if (InvertIndex <= int(AnyWord.size()))
		{
			if (TrackState <= NUMOFGETWORDS)
			{
				swap(SwapWord[InvertIndex], SwapWord[InvertIndex + 1]);
				TrackState++;
				IsStateActive = true;
			}
			else
			{
				IsStateActive = false;
				SwapWord = "";
			}
		}
	}
	else
		SwapWord = "";
	return SwapWord;
}

bool Inverter::GetState()
{
	return IsStateActive;
}
