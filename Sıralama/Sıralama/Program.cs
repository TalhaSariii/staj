
int numb1;
int numb2 = 1;
while (numb2!= 0)    
    {
   
    Console.Write("enter the number of rows to list :");
    numb1 = Convert.ToInt32(Console.ReadLine());
    int[] numbers = new int[numb1];
    Random random = new Random();
    int temporary;
    int rnd;
    List<int> generatedNumber = new List<int>();
    for (var i = 0; i < numb1; i++)
    {
        rnd = random.Next(0, 100);

        numbers[i] = rnd;
        generatedNumber.Add(rnd);



    }
    for (var i = 0; i <= numb1; i++)
    {
        for (var j = i + 1; j < numb1; j++)
        {
            if (numbers[i] > numbers[j])
            {

                temporary = numbers[j];
                numbers[j] = numbers[i];
                numbers[i] = temporary;

            }
        }

    }
    Console.WriteLine("Random numbers small to large ");
    for (var i = 0; i < numb1; i++)
    {

        Console.WriteLine(numbers[i]);
    }

    Console.WriteLine(" Random numbers big to small");



    QuickSort(numbers, 0, numbers.Length - 1);

    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);

            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivotValue = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] >= pivotValue)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);

        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.WriteLine(number + " ");
        }
    }
    PrintArray(numbers);

    Console.WriteLine("Type 0 to exit or type any number to continue");
     numb2 = Convert.ToInt32(Console.ReadLine());

 
   
}
Environment.Exit(0);

