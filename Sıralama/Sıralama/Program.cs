using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
       
        
        string? sortchoice;
        bool checkInput;


        Console.WriteLine("Enter order Type.\n 1: Ascending and manually \n" +
            " 2: Ascending and random\n 3: Descending and manually \n" +
            " 4: Descending and random\n 5: Manually list \n 6: Random list ");

        sortchoice = Console.ReadLine();
        checkInput=Validate(sortchoice);
        if(checkInput==true)
        {
            if (sortchoice == "1" || sortchoice == "3" || sortchoice == "5")
            {
                manualNumberSorting(sortchoice);
            }
            else if (sortchoice == "2" || sortchoice == "4" || sortchoice == "6")
            {


                RandomNumberSorting(sortchoice);
            }
        }
        else
        {
            Console.WriteLine("Wrong enery!!!");
            
        }
    
      
    }

    

    static void RandomNumberSorting(string? sortOrder)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string ? temp;
        int numb1=0;
        int numb2 = 1;
        string rndtemp;
        string rndtemp2;
        int rnd1;
        int rnd2;

        while (numb2 != 0)
        {
            Console.Write("Enter the number of rows to list: ");
            temp = Console.ReadLine();
            if(Validate(temp))
            {
                numb1 = Convert.ToInt32(temp);
            }
            else
            {
                Console.WriteLine("Wrong enery!!!");
                continue;
            }

            Console.Write("Enter the lower limit of the random number: ");
            rndtemp = Console.ReadLine();
            if (Validate(rndtemp))
            {
                rnd1 = Convert.ToInt32(rndtemp);
            }
            else
            {
                Environment.Exit(0);
            }

            rnd1 = Convert.ToInt32(rndtemp);

            Console.Write("Enter the upper limit of the random number: ");
            rndtemp2 = Console.ReadLine();
            if (Validate(rndtemp2))
            {
                rnd2 = Convert.ToInt32(rndtemp2);
            }
            else
            {
                Console.WriteLine("wrong entry please enter a number");
                continue;

            }


            rnd2 = Convert.ToInt32(rndtemp2);

            int[] numbers = new int[numb1];
            Random random = new Random();

            for (var i = 0; i < numb1; i++)
            {
                int rnd = random.Next(rnd1, rnd2);
                numbers[i] = rnd;
            }

            if (sortOrder == "2")
            {
                Ascending(numbers);
            }
            else if (sortOrder == "4")
            {
                Descending(numbers);
            }
            else if (sortOrder == "6")
            {
                Ascending(numbers);
                Descending(numbers);
            }
            else
            {
                return;
            }
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed (For): {stopwatch.Elapsed}");


            Console.WriteLine("Type 0 to exit or type any number to continue");
            temp = Console.ReadLine();
            if (Validate(temp))
            {
                numb2 = Convert.ToInt32(temp);
            }
            else
            {
                Environment.Exit(0);

            }

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



    static bool Validate(string input)
    {
        var checkRange = int.TryParse(input, out var value);
        if(checkRange == false)
        {
            Console.WriteLine("wrong entery!!!");
        }
        if (input == "")
        { return false; }
        foreach (char character in input)
        {
            if (character < '0' || character > '9')
            {
                return false;
            }
        }
        
        return true;
    }

    static void manualNumberSorting(string? sortOrder)
    {
        string? temp;
        int numb1;
        int numb2 = 1;
        while (numb2 != 0)
        {
            Console.Write("Enter the number of rows to list: ");
            temp = Console.ReadLine();
            if (Validate(temp))
            {
                numb1 = Convert.ToInt32(temp);
            }
            else
            {
                Console.WriteLine("wrong entry please enter a number");
                continue;
            }

            numb1 = Convert.ToInt32(temp);

            int[] numbers = new int[numb1];

            Console.WriteLine("Enter the numbers you want to list:");
            for (var i = 0; i < numb1; i++)
            {
                Console.Write("Enter the " + (i + 1) + "st value: ");
                temp = Console.ReadLine();
                if (Validate(temp))
                {
                    numbers[i] = Convert.ToInt32(temp);
                }
                else
                {
                    Console.WriteLine("wrong entry please enter a number");
                    continue;
                }
                
            }
            if (sortOrder == "1")
            {
                Ascending(numbers);
            }
            else if (sortOrder == "3")
            {
                Descending(numbers);
            }
            else if (sortOrder == "5")
            {
                Ascending(numbers);
                Descending(numbers);
            }
            else
            {
                return;
            }

            Console.WriteLine("Type 0 to exit or type any number to continue");
            temp = Console.ReadLine();
            if (Validate(temp))
            {
                numb2 = Convert.ToInt32(temp);
            }
            else
            {
                Environment.Exit(0);
            
            }

           
        }

        Environment.Exit(0);
    }
}
   
