using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int restart = 1;
        while (restart != 0)
        {
            Thread.Sleep(1000);
            Console.Clear();

            string? sortchoice;
            bool checkInput;

            Console.WriteLine("Enter order Type.\n 1: Ascending and manually \n" +
                " 2: Ascending and random\n 3: Descending and manually \n" +
                " 4: Descending and random\n 5: Manually list \n 6: Random list ");

            sortchoice = Console.ReadLine();
            checkInput = Validate(sortchoice);
            if (checkInput == true)
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
                continue;
            }
        }
    }

    static void RandomNumberSorting(string? sortOrder)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string? temp;
        int numb1 = 0;
        int numb2 = 1;
        string rndtemp;
        string rndtemp2;
        int rnd1;
        int rnd2;

        while (numb2 != 0)
        {
            Console.Write("Enter the number of rows to list: ");
            temp = Console.ReadLine();
            if (Validate(temp))
            {
                numb1 = Convert.ToInt32(temp);
                if (numb1 < int.MaxValue)
                {
                    Console.Write("Enter the lower limit of the random number: ");
                    rndtemp = Console.ReadLine();
                    if (Validate(rndtemp))
                    {
                        rnd1 = Convert.ToInt32(rndtemp);

                        Console.Write("Enter the upper limit of the random number: ");
                        rndtemp2 = Console.ReadLine();
                        if (Validate(rndtemp2))
                        {
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
                                Main();
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                       
                    }
                }
                else
                {
                   
                }
            }
            else
            {
                continue;
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
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        var checkRange = int.TryParse(input, out var value);
        if (!checkRange)
        {
            Console.WriteLine("Wrong Enter.");
            return false;
        }

        if (value < 0)
        {
            Console.WriteLine("Wrong Enter..");
            return false;
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
                if (numb1 < int.MaxValue)
                {
                    int[] numbers = new int[numb1];
                    Console.WriteLine("Enter the numbers you want to list:");

                    for (var i = 0; i < numb1; i++)
                    {
                        Console.Write($"Enter the {i + 1}st value: ");
                        temp = Console.ReadLine();
                        if (Validate(temp))
                        {
                            numbers[i] = Convert.ToInt32(temp);
                        }
                        else
                        {
                          
                            i--;
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
                        Main();
                    }
                }
                else
                {
                    Console.WriteLine("The number of rows exceeds the limit.");
                }
            }
            else
            {
                continue;
            }
        }
        Environment.Exit(0);
    }
}
