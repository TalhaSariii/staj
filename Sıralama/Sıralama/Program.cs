using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        int sortchoice;
        Validate(Convert.ToChar("8"));


        Console.WriteLine("Enter order Type.\n 1: Ascending and manually \n 2: Ascending and random\n 3: Descending and manually \n 4: Descending and random\n 5: Manually list \n 6: Random list ");

        sortchoice = Convert.ToInt32(Console.ReadLine());
        if (sortchoice == 1 || sortchoice == 3 || sortchoice == 5)
        {
            manualNumberSorting(sortchoice);
        }
        else if(sortchoice == 2 || sortchoice == 4 || sortchoice == 6)
        {


            RandomNumberSorting(sortchoice);
        }
    }

    

    static void RandomNumberSorting(int? sortOrder)
    {
        int numb1;
        int numb2 = 1;

        while (numb2 != 0)
        {
            Console.Write("Enter the number of rows to list: ");
            numb1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the lower limit of the random number: ");
            int rnd1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the upper limit of the random number: ");
            int rnd2 = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[numb1];
            Random random = new Random();

            for (var i = 0; i < numb1; i++)
            {
                int rnd = random.Next(rnd1, rnd2);
                numbers[i] = rnd;
            }

            if (sortOrder == 3)
            {
                Ascending(numbers);
            }
            else if (sortOrder == 4)
            {
                Descending(numbers);
            }
            else if (sortOrder == 6)
            {
                Ascending(numbers);
                Descending(numbers);
            }
            else
            {
                return;
            }


            Console.WriteLine("Type 0 to exit or type any number to continue");
            numb2 = Convert.ToInt32(Console.ReadLine());
        }

        Environment.Exit(0);
    }

    

    static void Ascending(int[] numbers)
    {

        Array.Sort(numbers);

        Console.WriteLine("Random numbers (small to large):");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    static void Descending(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int maxIndex = i;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] > numbers[maxIndex])
                {
                    maxIndex = j;
                }
            }

            int temp = numbers[i];
            numbers[i] = numbers[maxIndex];
            numbers[maxIndex] = temp;
        }

        Console.WriteLine("Random numbers (big to small):");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

    }



    static bool Validate(char input)
    {
        var tryInput = input;
        return true;
    }
    static void manualNumberSorting(int? sortOrder)
    {
        int numb1;
        int numb2 = 1;
        while (numb2 != 0)
        {
            Console.Write("Enter the number of rows to list: ");
            numb1 = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[numb1];

            Console.WriteLine("Enter the numbers you want to list:");
            for (var i = 0; i < numb1; i++)
            {
                Console.Write("Enter the " + (i + 1) + "st value: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            if (sortOrder == 1)
            {
                Ascending(numbers);
            }
            else if (sortOrder == 2)
            {
                Descending(numbers);
            }
            else if (sortOrder == 5)
            {
                Ascending(numbers);
                Descending(numbers);
            }
            else
            {
                return;
            }

            Console.WriteLine("Type 0 to exit or type any number to continue");
            numb2 = Convert.ToInt32(Console.ReadLine());
        }

        Environment.Exit(0);
    }
}
   
