// Name: Rueben Tiow
// Last Modification: 3/9/2017
// File: p5.cs
// Version: 1.0
// Purpose: This is the driver intended to implement and test all 
// functionalities from sequenceEnum.h, seqExtract.h, spasEnum.h, Inverter.h, 
// and VSeq.h. It tests each object individually as well as using four 
// heterogeneous collections:
// First) Heterogeneous collection of type sequenceEnum: spasEnum, seqExtract 
// and sequenceEnum
// Second) Heterogeneous collection of type spasEnum: spasEnum, seqExtract and
// Inverter
// Third) Heterogeneous collection of seqExtact: spasEnum, seqExtract and
// Inverter
// Fourth) Heterogeneous collection of Inverter: spasEnum, seqExtract and
// Inverter
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class p5
    {
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
        const int NUMOFWORDS = 20;
        const int NUMOFSUBSEQ = 21;
        const int NUMOFSUBSEQ2 = 20;
        const int NUMOFOBJSIZE = 3;
        const int NUMOFGETVARIANTSIZE = 5;
        const int NUMOFGUESSES = 5;
        const int NUMOFHETSIZE = 6;
        const int NUMOFINDEX = 6;

        static void Main(string[] args)
        {
            Random rand = new Random();
            sequenceEnum[] MySequenceEnum = new sequenceEnum
                [NUMOFOBJSIZE];
            VSeq[] MyVSeq = new VSeq[NUMOFOBJSIZE];
            sequenceEnum[] HeterogeneousArray = new sequenceEnum
                [NUMOFHETSIZE];


            String[] StoredWords = new String[NUMOFWORDS] { WORD1, WORD2,
                WORD3, WORD4, WORD5, WORD6, WORD7, WORD8, WORD9, WORD10,
                WORD11, WORD12, WORD13, WORD14, WORD15, WORD16, WORD17,
                WORD18, WORD19, WORD20 };
            String[] StoredSub = new String[NUMOFSUBSEQ] { SUB1, SUB2,
                SUB3, SUB4, SUB5, SUB6, SUB7, SUB8, SUB9, SUB10, SUB11,
                SUB12, SUB13, SUB14, SUB15, SUB16, SUB17, SUB18, SUB19,
                SUB20, SUB21 };
            //Creating array of encapsulated words in HeterogeneousArray
            for (int i = 0; i < NUMOFHETSIZE; i++)
            {
                if (i < NUMOFOBJSIZE)
                {
                    HeterogeneousArray[i] = new sequenceEnum
                        (StoredWords[rand.Next(NUMOFWORDS)]);
                }
                else
                {
                    HeterogeneousArray[i] = new VSeq(StoredWords[rand.
                        Next(NUMOFWORDS)], rand.Next(NUMOFINDEX));
                }
            }

            //Creating array of encapsulated words in MySequenceEnum, 
            //MySeqExtract, MySpasEnum, and MyInverter.
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                MySequenceEnum[i] = new sequenceEnum(StoredWords[rand.
                    Next(NUMOFWORDS)]);
                MyVSeq[i] = new VSeq(StoredWords[rand.
                        Next(NUMOFWORDS)], rand.Next(NUMOFINDEX));
            }

            //Test for SequenceEnum
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine
                    ("Testing SequenceEnum OBJECT #" + (i + 1));
                Console.WriteLine
                    ("Modify State To: Active | Current State: {0}",
                    MySequenceEnum[i].ModifyIfActive(1));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySequenceEnum[i].GetVariant();
                }
                Console.WriteLine
                    ("The variations:\n{0}\n{1}\n{2}\n{3}\n{4}",
                    DispVariant);
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |\n",
                        StoredWords[index], MySequenceEnum[i].
                        CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine
                    ("Modify State To: Inactive | Current State: {0}",
                    MySequenceEnum[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MySequenceEnum[i].GetVariant();
                }
                Console.WriteLine
                    ("The variations:\n{0}\n{1}\n{2}\n{3}\n{4}",
                    DispVariant);
            }

            //Test VSeq
            for (int i = 0; i < NUMOFOBJSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine("Testing VSeq OBJECT #"+(i + 1));
                Console.WriteLine
                    ("Modify State To: Active | Current State: {0}",
                    MyVSeq[i].ModifyIfActive(1));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MyVSeq[i].GetVariant();
                }
                Console.WriteLine
                    ("The variations:\n{0}\n{1}\n{2}\n{3}\n{4}",
                    DispVariant);
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write
                        ("| Guessed: {0} | Answer: {1} |\n",
                        StoredWords[index], MyVSeq[i].
                        CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine
                    ("Modify State To: Inactive | Current State: {0}",
                    MyVSeq[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MyVSeq[i].GetVariant();
                }
                Console.WriteLine
                    ("The variations:\n{0}\n{1}\n{2}\n{3}\n{4}",
                    DispVariant);
                Console.WriteLine("Testing Inverter Portion");
                Console.WriteLine
                    ("| Inverter Current State : {0}", 
                    MyVSeq[i].GetState());
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = MyVSeq[i].GetInvertVariant
                        (StoredWords[rand.Next(NUMOFWORDS)]);
                }
                Console.WriteLine("The variations of Inverter:");
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    if (DispVariant[j] != "")
                    {
                        Console.WriteLine(DispVariant[j]);
                    }
                    MyVSeq[i].GetInvertVariant
                        (StoredWords[rand.Next(NUMOFWORDS)]);
                }
                Console.WriteLine
                    ("| Inverter Current State : {0}", 
                    MyVSeq[i].GetState());
                Console.WriteLine();
            }

            //Test heterogeneous array
            for (int i = 0; i < NUMOFHETSIZE; i++)
            {
                string[] DispVariant = new string[NUMOFGETVARIANTSIZE];
                Console.WriteLine
                    ("Testing Heterogeneous Array OBJECT #"+(i + 1));
                Console.WriteLine
                    ("Modify State To: Active | Current State: {0}",
                    HeterogeneousArray[i].ModifyIfActive(1));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = HeterogeneousArray[i].GetVariant();
                }
                Console.WriteLine("The variations:");
                if (HeterogeneousArray[i].GetVariant() != "")
                {
                    Console.WriteLine
                        ("{0}\n{1}\n{2}\n{3}\n{4}", DispVariant);
                }
                for (int j = 0; j < NUMOFGUESSES; j++)
                {
                    int index = rand.Next(NUMOFWORDS);
                    Console.Write("| Guessed: {0} | Answer: {1} |\n",
                        StoredWords[index], HeterogeneousArray[i].
                        CheckUserGuess(StoredWords[index]));
                }
                Console.WriteLine
                    ("Modify State To: Inactive | Current State: {0}",
                    HeterogeneousArray[i].ModifyIfActive(2));
                for (int j = 0; j < NUMOFGETVARIANTSIZE; j++)
                {
                    DispVariant[j] = HeterogeneousArray[i].GetVariant();
                }
                Console.WriteLine("The variations:");
                if (HeterogeneousArray[i].GetVariant() != "")
                {
                    Console.WriteLine
                        ("{0}\n{1}\n{2}\n{3}\n{4}", DispVariant);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            }
        }
    }

