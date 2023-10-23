using System;

class OneDimensionalArray
{
    private int[] array;

    public OneDimensionalArray(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона массива");
            }
        }
        set
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона массива");
            }
        }
    }

    public static bool operator ==(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.array.Length != arr2.array.Length)
        {
            return false;
        }

        for (int i = 0; i < arr1.array.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator !=(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        return !(arr1 == arr2);
    }

    public static OneDimensionalArray operator +(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.array.Length != arr2.array.Length)
        {
            throw new InvalidOperationException("Длины массивов должны быть одинаковыми для выполнения операции объединения");
        }

        OneDimensionalArray result = new OneDimensionalArray(arr1.array.Length);
        for (int i = 0; i < arr1.array.Length; i++)
        {
            result[i] = arr1[i] + arr2[i];
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        OneDimensionalArray array1 = new OneDimensionalArray(3);
        array1[0] = 1;
        array1[1] = 2;
        array1[2] = 3;

        OneDimensionalArray array2 = new OneDimensionalArray(3);
        array2[0] = 4;
        array2[1] = 5;
        array2[2] = 6;

        Console.WriteLine("Первый массив:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(array1[i] + " ");
        }

        Console.WriteLine("\nВторой массив:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(array2[i] + " ");
        }

        if (array1 == array2)
        {
            Console.WriteLine("\nМассивы равны.");
        }
        else
        {
            Console.WriteLine("\nМассивы не равны.");
        }

        OneDimensionalArray sumArray = array1 + array2;
        Console.WriteLine("\nРезультат объединения массивов:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(sumArray[i] + " ");
        }
    }
}
