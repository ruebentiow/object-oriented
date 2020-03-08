// Name: Rueben Tiow
// Last Modification: 2/11/2017
// File: p3.cs
// Version: 1.0
// Purpose: This is the driver intende to implement and test all functionalities 
// from sequenceEnum.cs, seqExtract.cs, and spasEnum.cs. It tests each method individually
// as well as using a heterogeneous collection of all three classes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class p3
    {
        //Constant Variables
        const int NUMOFWORDS = 20;
        const int NUMOFSUBSEQ = 21;
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
        const string WORD13 = "refridgerator";
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

        const int NUMOFOBJSIZE = 3;
        const int NUMOFGETVARIANTSIZE = 5;
        const int NUMOFGUESSES = 5;
        const int NUMOFHETSIZE = 6;
        const int NUMOFHETOBJSIZE = 2;



        static void Main(string[] args)
        {
            Random rand = new Random();
            SequenceEnum[] MySequenceEnum = new SequenceEnum[NUMOFOBJSIZE];
            seqExtract[] MySeqExtract = new seqExtract[NUMOFOBJSIZE];
            spasEnum[] MySpasEnum = new spasEnum[NUMOFOBJSIZE];
            SequenceEnum[] HeterogeneousArray = new SequenceEnum[NUMOFHETSIZE];
            String[] StoredWords = new String[NUMOFWORDS] { WORD1, WORD2, WORD3, WORD4, WORD5, WORD6, WORD7, WORD8, WORD9, WORD10, WORD11, WORD12, WORD13, WORD14, WORD15, WORD16, WORD17, WORD18, WORD19, WORD20 };
            String[] StoredSub = new String[NUMOFSUBSEQ] { SUB1, SUB2, SUB3, SUB4, SUB5, SUB6, SUB7, SUB8, SUB9, SUB10, SUB11, SUB12, SUB13, SUB14, SUB15, SUB16, SUB17, SUB18, SUB19, SUB20, SUB21 };

            //Creating array of encapsulated words in HeterogeneousArray
            for (int i = 0; i < NUMOFHETSIZE; i++)
            {
                if(i < NUMOFHETOBJSIZE)
                {
                    HeterogeneousArray[i] = new SequenceEnum(StoredWords[rand.Next(NUMOFWORDS)]);
                }
                else if( i < (NUMOFHETOBJSIZE * 2))
                {
                    HeterogeneousArray[i] = new seqExtract(StoredWords[rand.Next(NUMOFWORDS)]);
                }
                else
                {
                    HeterogeneousArray[i] = new spasEnum(StoredWords[rand.Next(NUMOFWORDS)]);
                }
            }

            //Creating array of encapsulated words in MySequenceEnum
            //Creating array of encapsulated words in MySeqExtract
            //Creating array of encapsulated words in MySpasEnum
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                MySequenceEnum[i] = new SequenceEnum(StoredWords[rand.Next(NUMOFWORDS)]);
                MySeqExtract[i] = new seqExtract(StoredWords[rand.Next(NUMOFWORDS)]);
                MySpasEnum[i] = new spasEnum(StoredWords[rand.Next(NUMOFWORDS)]);
            }

            //Test for SequenceEnum
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine("Testing SequenceEnum OBJECT #" + (i+1));
                Console.WriteLine("Modify State To: Active | Current State: {0}", MySequenceEnum[i].ModifyIfActive(1));
                for(int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySequenceEnum[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}", DispVariant);
                for (int j = 0; j < NUMOFSUBSEQ; j++)
                {
                    if (MySequenceEnum[i].GetVariant(StoredSub[j]) != "")
                    {
                        Console.Write(MySequenceEnum[i].GetVariant(StoredSub[j]) + " ");
                    }
                }
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |", StoredWords[index], MySequenceEnum[i].CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine("\nModify State To: Inactive | Current State: {0}", MySequenceEnum[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySequenceEnum[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}\n", DispVariant);
            }

            //Test for SeqExtract
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                Console.WriteLine("Testing SeqExtract OBJECT #" + (i + 1));
                Console.WriteLine("Modify State To: Active | Current State: {0}", MySeqExtract[i].ModifyIfActive(1));
                Console.WriteLine(MySeqExtract[i].GetVariant()); //nop
                Console.WriteLine("The variations:");
                for (int j = 0; j < NUMOFSUBSEQ; j++)
                {
                    if (MySeqExtract[i].GetVariant(StoredSub[j]) != "")
                    {
                        Console.Write(MySeqExtract[i].GetVariant(StoredSub[j]) + " ");
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |", StoredWords[index], MySeqExtract[i].CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine("\nModify State To: Inactive | Current State: {0}", MySeqExtract[i].ModifyIfActive(2));
                Console.WriteLine();
            }            //Test for SpasEnum
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine("Testing SpasEnum OBJECT #" + (i + 1));
                Console.WriteLine("Modify State To: Active | Current State: {0}", MySpasEnum[i].ModifyIfActive(1));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySpasEnum[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}", DispVariant);
                for (int j = 0; j < NUMOFSUBSEQ; j++)
                {
                    if (MySpasEnum[i].GetVariant(StoredSub[j]) != "")
                    {
                        Console.Write(MySpasEnum[i].GetVariant(StoredSub[j]) + " ");
                    }
                }
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |", StoredWords[index], MySpasEnum[i].CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine("\nModify State To: Inactive | Current State: {0}", MySpasEnum[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySpasEnum[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}\n", DispVariant);
            }



            //Test heterogeneous array
            for (int i = 0; i < NUMOFHETSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine("Testing Heterogeneous Array OBJECT #" + (i + 1));
                Console.WriteLine("Modify State To: Active | Current State: {0}", HeterogeneousArray[i].ModifyIfActive(1));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = HeterogeneousArray[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}", DispVariant);
                for (int j = 0; j < NUMOFSUBSEQ; j++)
                {
                    if (HeterogeneousArray[i].GetVariant(StoredSub[j]) != "")
                    {
                        Console.Write(HeterogeneousArray[i].GetVariant(StoredSub[j]) + " ");
                    }
                    if (j == NUMOFSUBSEQ - 1)
                    {
                        Console.WriteLine();
                    }
                }
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |", StoredWords[index], HeterogeneousArray[i].CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine("\nModify State To: Inactive | Current State: {0}", HeterogeneousArray[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = HeterogeneousArray[i].GetVariant();
                }
                Console.WriteLine("The variations:{0} {1} {2} {3} {4}\n", DispVariant);
            }

            Console.ReadKey();
        }
    }
}
