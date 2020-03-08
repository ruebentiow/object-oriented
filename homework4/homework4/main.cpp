// Name: Rueben Tiow
// Last Modification: 2/24/2017
// File: main.cpp
// Version: 1.0
// Purpose: This is the driver intended to implement and test all functionalities 
// from sequenceEnum.h, seqExtract.h, spasEnum.h, Inverter.h, and VSeq.h. 
// It tests each object individually as well as using four heterogeneous collections:
// First) Heterogeneous collection of type sequenceEnum: spasEnum, seqExtract and sequenceEnum
// Second) Heterogeneous collection of type spasEnum: spasEnum, seqExtract and Inverter
// Third) Heterogeneous collection of seqExtact: spasEnum, seqExtract and Inverter
// Fourth) Heterogeneous collection of Inverter: spasEnum, seqExtract and Inverter
#include "sequenceEnum.h"
#include "spasEnum.h"
#include "seqExtract.h"
#include "Inverter.h"
#include "VSeq.h"
#include <cctype>
#include <fstream>
//Constant Variables
const string WORD1 = "octopus";
const string WORD2 = "kangaroo";
const string WORD3 = "reptile";
const string WORD4 = "training";
const string WORD5 = "furniture";
const string WORD6 = "flying";
const string WORD7 = "rejuvenation";
const string WORD8 = "ultimatum";
const string WORD9 = "correctness";
const string WORD10 = "international";
const string WORD11 = "future";
const string WORD12 = "backpacking";
const string WORD13 = "attainable";
const string WORD14 = "softwares";
const string WORD15 = "availability";
const string WORD16 = "earthling";
const string WORD17 = "percentile";
const string WORD18 = "blanket";
const string WORD19 = "projectile";
const string WORD20 = "entity";
const string SUB1 = "to";
const string SUB2 = "ro";
const string SUB3 = "re";
const string SUB4 = "ing";
const string SUB5 = "ity";
const string SUB6 = "ion";
const string SUB7 = "rid";
const string SUB8 = "ena";
const string SUB9 = "ion";
const string SUB10 = "tile";
const string SUB11 = "pro";
const string SUB12 = "per";
const string SUB13 = "fut";
const string SUB14 = "ness";
const string SUB15 = "ab";
const string SUB16 = "ar";
const string SUB17 = "an";
const string SUB18 = "ec";
const string SUB19 = "en";
const string SUB20 = "juv";
const string SUB21 = "til";
const int NUMOFWORDS = 20;
const int NUMOFSUBSEQ = 21;
const int NUMOFSUBSEQ2 = 20;
const int NUMOFOBJSIZE = 3;
const int NUMOFGETVARIANTSIZE = 5;
const int NUMOFGUESSES = 5;
const int NUMOFHETSIZE = 6;
const int NUMOFHETSIZE2 = 4;
const int NUMOFHETOBJSIZE = 2;
const int NUMOFINDEX = 6;
const int SETACTIVE = 1;
const int SETINACTIVE = 2;
int main()
{
	ofstream outputFile;
	outputFile.open("p4.txt");
	sequenceEnum* MySequenceEnum[NUMOFOBJSIZE];
	seqExtract* MySeqExtract[NUMOFOBJSIZE];
	spasEnum* MySpasEnum[NUMOFOBJSIZE];
	Inverter* MyInverter[NUMOFOBJSIZE];
	VSeq* MyVSeq[NUMOFOBJSIZE];
	
	sequenceEnum* HeterogeneousArray[NUMOFHETSIZE];
	seqExtract* HeterogeneousSeqArray[NUMOFHETSIZE2];
	spasEnum* HeterogeneousSpasArray[NUMOFHETSIZE2];
	Inverter* HeterogeneousInvertArray[NUMOFHETSIZE2];
	
	string StoredWords[NUMOFWORDS] = { WORD1, WORD2, WORD3, WORD4, WORD5, 
		WORD6, WORD7, WORD8, WORD9, WORD10, WORD11, WORD12, WORD13, WORD14, 
		WORD15, WORD16, WORD17, WORD18, WORD19, WORD20 };
	string StoredSub[NUMOFSUBSEQ] = { SUB1, SUB2, SUB3, SUB4, SUB5, SUB6, 
		SUB7, SUB8, SUB9, SUB10, SUB11, SUB12, SUB13, SUB14, SUB15, SUB16, 
		SUB17, SUB18, SUB19, SUB20, SUB21 };
	//Creating array of encapsulated words and indexes in HeterogeneousSeqArray,
	//HeterogeneousSpasArray, and HeterogeneousInvertArray
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		if (i < NUMOFHETOBJSIZE)
		{
			HeterogeneousSeqArray[i] = new seqExtract(StoredWords[rand() % (NUMOFWORDS)]);
			HeterogeneousSpasArray[i] = new spasEnum(StoredWords[rand() % (NUMOFWORDS)]);
			HeterogeneousInvertArray[i] = new Inverter(rand() % NUMOFINDEX);
		}
		else
		{
			HeterogeneousSeqArray[i] = new VSeq(StoredWords[rand() % (NUMOFWORDS)], rand() % (NUMOFINDEX));
			HeterogeneousSpasArray[i] = new VSeq(StoredWords[rand() % (NUMOFWORDS)], rand() % (NUMOFINDEX));
			HeterogeneousInvertArray[i] = new VSeq(StoredWords[rand() % (NUMOFWORDS)], rand() % (NUMOFINDEX));
		}
	}

	//Creating array of encapsulated words in HeterogeneousArray
	for (int i = 0; i < NUMOFHETSIZE; i++)
	{
		if (i < NUMOFHETOBJSIZE)
		{
			sequenceEnum* NewSequenceEnum = new sequenceEnum(StoredWords[rand() % (NUMOFWORDS)]);
			HeterogeneousArray[i] = NewSequenceEnum;
		}
		else if (i < (NUMOFHETOBJSIZE * 2))
		{
			seqExtract* NewSeqExtract = new seqExtract(StoredWords[rand() % (NUMOFWORDS)]);
			HeterogeneousArray[i] = NewSeqExtract;
		}
		else
		{
			spasEnum* NewSpasEnum = new spasEnum(StoredWords[rand() % (NUMOFWORDS)]);
			HeterogeneousArray[i] = NewSpasEnum;
		}
	}

	//Creating array of encapsulated words and indexes in 
	// MyVSeq ,MySequenceEnum, MySeqExtract, MySpasEnum,
	// and  MyInverter
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		MySequenceEnum[i] = new sequenceEnum(StoredWords[rand() % (NUMOFWORDS)]);
		MySeqExtract[i] = new seqExtract(StoredWords[rand() % (NUMOFWORDS)]);
		MySpasEnum[i] = new spasEnum(StoredWords[rand() % (NUMOFWORDS)]);
		MyVSeq[i] = new VSeq(StoredWords[rand() % (NUMOFWORDS)], rand() % NUMOFINDEX);
		MyInverter[i] = new Inverter(rand() % NUMOFINDEX);
	}
	
	//Test for SequenceEnum
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing SequenceEnum OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: " 
			<< MySequenceEnum[i]->ModifyIfActive(SETACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MySequenceEnum[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MySequenceEnum[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MySequenceEnum[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< MySequenceEnum[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % NUMOFWORDS;
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: " << MySequenceEnum[i]
				->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: " 
			<< MySequenceEnum[i]->ModifyIfActive(SETINACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MySequenceEnum[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MySequenceEnum[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< endl;
	}
	
	//Test for SeqExtract
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		outputFile<< "Testing SeqExtract OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: " 
			<< MySeqExtract[i]->ModifyIfActive(SETACTIVE) << endl;
		outputFile<< MySeqExtract[i]->GetVariant();
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MySeqExtract[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< MySeqExtract[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % NUMOFWORDS;
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: " 
				<< MySeqExtract[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: " 
			<< MySeqExtract[i]->ModifyIfActive(SETINACTIVE) << endl << endl;
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MySeqExtract[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< MySeqExtract[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
	}

	//Test for SpasEnum
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing SpasEnum OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: " 
			<< MySpasEnum[i]->ModifyIfActive(SETACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MySpasEnum[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MySpasEnum[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MySpasEnum[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile << MySpasEnum[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % (NUMOFWORDS);
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: " 
				<< MySpasEnum[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: " 
			<< MySpasEnum[i]->ModifyIfActive(SETINACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MySpasEnum[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MySpasEnum[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< endl;
	}

	//Test heterogeneous array
	for (int i = 0; i < NUMOFHETSIZE; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing Heterogeneous Array OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: " 
			<< HeterogeneousArray[i]->ModifyIfActive(SETACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousArray[i]->GetVariant();
		}
		outputFile<< "The variations of spasEnum or sequenceEnum:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (HeterogeneousArray[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< "The variations of seqExtract:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (HeterogeneousArray[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< HeterogeneousArray[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % (NUMOFWORDS);
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: " 
				<< HeterogeneousArray[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: " 
			<< HeterogeneousArray[i]->ModifyIfActive(SETINACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousArray[i]->GetVariant();
		}
		outputFile<< "The variations of spasEnum or sequenceEnum:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (HeterogeneousArray[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< "The variations of seqExtract:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (HeterogeneousArray[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< HeterogeneousArray[i]->GetVariant(StoredSub[j]) << endl;
			}
			if (j == NUMOFSUBSEQ2)
			{
				outputFile<< endl;
			}
		}
		outputFile<< endl;
	}

	//Test for Inverter
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing Inverter OBJECT #" << (i + 1) << endl;
		outputFile<< "Current State: " << MyInverter[i]->GetState() << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MyInverter[i]->
				GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (DispVariant[j] != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		MyInverter[i]->GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		outputFile<< "Current State: " << MyInverter[i]->GetState() << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MyInverter[i]->
				GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (DispVariant[j] != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< endl;
	}

	//Test VSeq
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing MyVSeq OBJECT #" << (i + 1) << endl;
		outputFile<< "Testing SpasEnum & SeqExtract Portion" << endl;
		outputFile<< "Modify State To: Active | Current State: " 
			<< MyVSeq[i]->ModifyIfActive(SETACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MyVSeq[i]->GetVariant();
		}
		outputFile<< "The variations of spas:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MyVSeq[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< "The variations of seq:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MyVSeq[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< MyVSeq[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % (NUMOFWORDS);
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: " 
				<< MyVSeq[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: " 
			<< MyVSeq[i]->ModifyIfActive(SETINACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MyVSeq[i]->GetVariant();
		}
		outputFile<< "The variations of spas:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (MyVSeq[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< "The variations of seq:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (MyVSeq[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< MyVSeq[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		outputFile<< "Testing Inverter Portion" << endl;
		outputFile<< "| Inverter Current State : " <<
			MyVSeq[i]->GetState() << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = MyVSeq[i]->GetInvertVariant(StoredWords[j]);
		}
		outputFile<< "The variations of Inverter:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (DispVariant[j] != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
			MyVSeq[i]->GetInvertVariant(StoredWords[j]);
		}

		outputFile<< "| Inverter Current State : " <<
			MyVSeq[i]->GetState() << endl;

		outputFile<< endl << endl;
	}
	
	//Test for HeterogeneousSeqArray
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		outputFile<< "Testing HeterogeneousSeqArray OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: "
			<< HeterogeneousSeqArray[i]->ModifyIfActive(SETACTIVE) << endl;
		outputFile<< HeterogeneousSeqArray[i]->GetVariant();
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (HeterogeneousSeqArray[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< HeterogeneousSeqArray[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % NUMOFWORDS;
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: "
				<< HeterogeneousSeqArray[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: "
			<< HeterogeneousSeqArray[i]->ModifyIfActive(SETINACTIVE) << endl << endl;
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFSUBSEQ; j++)
		{
			if (HeterogeneousSeqArray[i]->GetVariant(StoredSub[j]) != "")
			{
				outputFile<< HeterogeneousSeqArray[i]->GetVariant(StoredSub[j]) << endl;
			}
		}
	}

	//Test for HeterogeneousSpasArray
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing HeterogeneousSpasArray OBJECT #" << (i + 1) << endl;
		outputFile<< "Modify State To: Active | Current State: "
			<< HeterogeneousSpasArray[i]->ModifyIfActive(SETACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousSpasArray[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (HeterogeneousSpasArray[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		for (int j = 0; j < NUMOFGUESSES; j++)
		{
			int index = rand() % (NUMOFWORDS);
			outputFile<< "| Guessed: " << StoredWords[index] << " | Answer: "
				<< HeterogeneousSpasArray[i]->CheckUserGuess(StoredWords[index]) << "|" << endl;
		}
		outputFile<< "Modify State To: Inactive | Current State: "
			<< HeterogeneousSpasArray[i]->ModifyIfActive(SETINACTIVE) << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousSpasArray[i]->GetVariant();
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (HeterogeneousSpasArray[i]->GetVariant() != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< endl;
	}

	//Test for HeterogeneousInvertArray
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		string DispVariant[NUMOFGETVARIANTSIZE];
		outputFile<< "Testing HeterogeneousInvertArray OBJECT #" << (i + 1) << endl;
		outputFile<< "Current State: " << HeterogeneousInvertArray[i]->GetState() << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousInvertArray[i]->
				GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (DispVariant[j] != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		HeterogeneousInvertArray[i]->GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		outputFile<< "Current State: " << HeterogeneousInvertArray[i]->GetState() << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			DispVariant[j] = HeterogeneousInvertArray[i]->
				GetInvertVariant(StoredWords[rand() % (NUMOFWORDS)]);
		}
		outputFile<< "The variations:" << endl;
		for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
		{
			if (DispVariant[j] != "")
			{
				outputFile<< DispVariant[j] << endl;
			}
		}
		outputFile<< endl;
	}
	
	// Delete collection objects
	outputFile<< "Deleting All Objects" << endl;	
	//WORKING
	outputFile << "Deleting MySequenceEnum Objects" << endl;
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		delete MySequenceEnum[i];
	}
	outputFile<< "Deleting MySeqExtract Objects" << endl;
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		delete MySeqExtract[i];
	}
	outputFile<< "Deleting MySpasEnum Objects" << endl;

	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		delete MySpasEnum[i];
	}
	outputFile<< "Deleting MyVSeq Objects" << endl;
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		delete MyVSeq[i];
	}
	outputFile<< "Deleting MyInverter Objects" << endl;
	for (int i = 0; i < NUMOFOBJSIZE; i++)
	{
		delete MyInverter[i];
	}	
	outputFile<< "Deleting HeterogeneousSeqArray Objects" << endl;
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		delete HeterogeneousSeqArray[i];
	}	
	outputFile<< "Deleting HeterogeneousSpasArray Objects" << endl;
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		delete HeterogeneousSpasArray[i];
	}

	outputFile<< "Deleting HeterogeneousArray Objects" << endl;
	for (int i = 0; i < NUMOFHETSIZE; i++)
	{
		delete HeterogeneousArray[i];
	}	
	outputFile<< "Deleting HeterogeneousInvertArray Objects" << endl;
	for (int i = 0; i < NUMOFHETSIZE2; i++)
	{
		delete HeterogeneousInvertArray[i];
	}	

	getchar();
	return 0;
}
