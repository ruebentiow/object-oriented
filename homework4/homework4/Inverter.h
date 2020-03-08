// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: Inverter.h
// Version: 1.0
// Purpose: This is an Inverter class that lays the foundation for 
// one other child class. The purpose of this class is to contain the 
// functions intended to be used in the driver. This has a class heirarchy 
// of Inverter where each Inverter object encapsulates an integer(index), 
// and responds to inquiries. The encapsulated integer(index) inverts two 
// elements of a given sequence at indices i and i+1. That is if the 
// encapsulate integer(index) was 2, i would be 2 and i+1 would be 3.
//
// Class Invariants:
// - Minimum 1 possible Inverter object(s)
// - Relationship:
//       Association: This class has a Is-A relationship with the derived 
//		 class.(VSeq class)
//       Cardinality: 1 to 1.
// - All Inverter objects are initialize upon construction.
// - An object cannot be both Inactive and Active.
// - An objects state cannot be changed after becoming Inactive.
// - All functions are made virtual to provide access to descendants or to any 
//   potential children classes
//
// Interface Invariants:
// - All public functions are declare virtual to provide functionality to derived 
//   class.
// - Constructor and all methods are only allowed to be passed by value.
// - An Inverter object state is always active, and will only become inactive
//   once an Inverter object exceeds NUMOFGETWORDS(4).
// - An inactive Inverter object's will no longer produce any inversions of the word.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
// - Every integer passed into this object must be more than or equal to 0 and less 
//   than the length of the word.
#include <iostream>
#include <stdlib.h>
#include<string>
#ifndef _INVERTER_H
#define _INVERTER_H
using namespace std;
class Inverter
{
protected:
	//Constant Variables
	static const int NUMOFGETWORDS = 4;
	//Member Variables
	int InvertIndex;
	bool IsStateActive;
	int TrackState;
public:
	virtual ~Inverter() { }
	//Default Destructor Suppressed.
	//PRE: - N/A
	//POST: - N/A
	Inverter(int AnyIndex);
	//Overloaded constructor
	// PRE: - AnyIndex must be an integer that is more than or equal to 0 and 
	//		  less than the length of the word.
	// POST: - All protected data members are initialized, AnyIndex encapsulated 
	//         a integer, and state is set to active.
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
	bool GetState();
	// GetState: This function is intended to return the current state of the object.
	// PRE: - N/A
	// POST: - Returns the current state of the object
};
#endif

