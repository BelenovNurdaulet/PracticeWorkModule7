using System;

class CustomArray
{
    private int[] array;

    public CustomArray(int[] arr)
    {
        array = arr;
    }

    public static bool operator <(CustomArray arr1, CustomArray arr2)
    {
        return arr1.GetSum() < arr2.GetSum();
    }

    public static bool operator >(CustomArray arr1, CustomArray arr2)
    {
        return arr1.GetSum() > arr2.GetSum();
    }

    public int GetSum()
    {
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };

        CustomArray customArray1 = new CustomArray(array1);
        CustomArray customArray2 = new CustomArray(array2);

        Console.WriteLine("Сумма элементов первого массива: " + customArray1.GetSum());
        Console.WriteLine("Сумма элементов второго массива: " + customArray2.GetSum());

        if (customArray1 > customArray2)
        {
            Console.WriteLine("Сумма элементов первого массива больше.");
        }
        else if (customArray1 < customArray2)
        {
            Console.WriteLine("Сумма элементов второго массива больше.");
        }
        else
        {
            Console.WriteLine("Суммы элементов массивов равны.");
        }
    }
}
