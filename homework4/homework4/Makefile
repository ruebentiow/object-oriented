#Makefile
OBJS = sequenceEnum.o spasEnum.o seqExtract.o Inverter.o VSeq.o main.o 
CC = g++
DEBUG = -g
CFLAGS = -Wall -c $(DEBUG)
LFLAGS = -Wall $(DEBUG)

main: $(OBJS)
	$(CC) $(LFLAGS) $(OBJS) -o main

main.o: main.cpp sequenceEnum.h spasEnum.h seqExtract.h Inverter.h VSeq.h
	$(CC) $(CFLAGS) main.cpp

sequenceEnum.o: sequenceEnum.cpp sequenceEnum.h
	$(CC) $(CFLAGS) sequenceEnum.cpp

spasEnum.o: spasEnum.cpp spasEnum.h
	$(CC) $(CFLAGS) spasEnum.cpp

seqExtract.o: seqExtract.cpp seqExtract.h
	$(CC) $(CFLAGS) seqExtract.cpp

Inverter.o: Inverter.cpp Inverter.h
	$(CC) $(CFLAGS) Inverter.cpp

VSeq.o: VSeq.cpp VSeq.h
	$(CC) $(CFLAGS) VSeq.cpp

clean:
	\rm *.o main
