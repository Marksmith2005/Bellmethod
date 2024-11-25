using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string sequence = "123456";
        List<string> outputList = new List<string> { sequence };
        HashSet<string> seenSequences = new HashSet<string> { sequence };
        int rowCount = 60; // Number of rows before returning to "123456"
        string filePath = @"C:\Users\cepha\OneDrive\Documents\shit.txt";

        // Initialize the file
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        File.AppendAllText(filePath, sequence + Environment.NewLine);

        while (outputList.Count < rowCount + 1) // +1 to include the final "123456"
        {
            string previousSequence = outputList;//ssad
            string nextSequence = GenerateNextSequence(previousSequence, seenSequences);
            outputList.Add(nextSequence);
            seenSequences.Add(nextSequence);
            File.AppendAllText(filePath, nextSequence + Environment.NewLine);

            // Validate the entire list to ensure it meets the rules
            if (!ValidateSequenceList(outputList))
            {
                outputList.Clear();
                seenSequences.Clear();
                File.Delete(filePath);
                outputList.Add(sequence);
                seenSequences.Add(sequence);
                File.AppendAllText(filePath, sequence + Environment.NewLine);
            }
        }

        // Ensure the final sequence is "123456"
        outputList.Add(sequence);
        File.AppendAllText(filePath, sequence + Environment.NewLine);

        // Output the sequences in a readable format with unchanged positions
        foreach (var seq in outputList)
        {
            string unchangedPositions = GetUnchangedPositions(seq, outputList.IndexOf(seq) > 0 ? outputList[outputList.IndexOf(seq) - 1] : null);
            Console.WriteLine($"{seq}{unchangedPositions}");
        }

        // Keep the console window open
        Console.ReadLine();
    }

    static string GenerateNextSequence(string sequence, HashSet<string> seenSequences)
    {
        char[] seqArray = sequence.ToCharArray();
        Random rand = new Random();
        bool validSequenceFound = false;

        while (!validSequenceFound)
        {
            // Attempt to swap neighbors randomly
            for (int i = 0; i < seqArray.Length - 1; i++)
            {
                if (rand.Next(2) == 0) // Randomly decide whether to swap with neighbor
                {
                    Swap(seqArray, i, i + 1);
                }
            }

            string newSequence = new string(seqArray);

            // Check if the new sequence is valid and unique
            if (!seenSequences.Contains(newSequence) && IsValidSequence(newSequence, sequence))
            {
                validSequenceFound = true;
                return newSequence;
            }

            // Reset the sequence if no valid swap was found
            seqArray = sequence.ToCharArray();
        }

        return sequence; // Fallback to the original sequence if no valid sequence is found
    }

    static void Swap(char[] array, int i, int j)
    {
        char temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static bool IsValidSequence(string newSequence, string previousSequence)
    {
        // Ensure no number moves more than one position
        for (int i = 0; i < newSequence.Length; i++)
        {
            if (Math.Abs(previousSequence.IndexOf(newSequence[i]) - i) > 1)
            {
                return false;
            }
        }
        return true;
    }

    static bool ValidateSequenceList(List<string> sequenceList)
    {
        for (int i = 1; i < sequenceList.Count; i++)
        {
            if (!IsValidSequence(sequenceList[i], sequenceList[i - 1]))
            {
                return false;
            }
        }
        return true;
    }

    static string GetUnchangedPositions(string currentSequence, string previousSequence)
    {
        if (previousSequence == null)
        {
            return string.Empty;
        }

        List<int> unchangedPositions = new List<int>();

        for (int i = 0; i < currentSequence.Length; i++)
        {
            if (currentSequence[i] == previousSequence[i])
            {
                unchangedPositions.Add(i + 1); // Positions are 1-based
            }
        }

        if (unchangedPositions.Count == 0)
        {
            return string.Empty;
        }

        return " -" + string.Join("", unchangedPositions);
    }
}