using System;
using System.IO;

class Program
{
    static void BubbleSort(int[] aList)
    {
        for (int i = 0; i < aList.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < aList.Length - i - 1; j++)
            {
                if (aList[j] > aList[j + 1])
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = aList[j];
                    aList[j] = aList[j + 1];
                    aList[j + 1] = temp;

                    swapped = true;
                }
            }

            // If no two elements were swapped in inner loop, the array is already sorted
            if (!swapped)
                break;
        }
    }

    static void MergeSort(int[] arr)
    {
        //Checks if there is only one element in the array
        if (arr.Length <= 1)
            return;

        int middle = arr.Length / 2;
        int[] left = new int[middle];
        int[] right = new int[arr.Length - middle];

        for (int i = 0; i < middle; i++)
            left[i] = arr[i];

        for (int i = middle; i < arr.Length; i++)
            right[i - middle] = arr[i];

        MergeSort(left);
        MergeSort(right);

        Merge(arr, left, right);
    }

    static void Merge(int[] arr, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
            {
                arr[k] = left[i];
                i++;
            }
            else
            {
                arr[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < left.Length)
        {
            arr[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            arr[k] = right[j];
            j++;
            k++;
        }
    }


    static void PrintArray(int[] arr)
    {
        foreach (var element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }


    static void ReadMyFile()
    {
        string filePath = "/Users/deepdesai/Downloads/TestDataText/RandomOrder_100.txt";

        try
        {
            // Open the file with StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Create a list to store the lines
                var lines = new List<string>();

                // Read lines from the file and add them to the list
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lines.Add(line);
                }

                // Convert the list to an array if needed
                string[] linesArray = lines.ToArray();

                // Now 'linesArray' contains the lines from the file
                foreach (string line in linesArray)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while reading the file: {e.Message}");
        }
    }

    static void Main(string[] args)
    {
        ReadMyFile();
    }


}


