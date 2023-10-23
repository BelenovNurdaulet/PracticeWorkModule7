using System;

class OneDimensionalArray
{
    private int[] array;

    public OneDimensionalArray(int size)
    {
        array = new int[size];
    }

    public int Length
    {
        get { return array.Length; }
    }

    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public static OneDimensionalArray operator *(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            throw new InvalidOperationException("Arrays must have the same length for multiplication.");
        }

        OneDimensionalArray result = new OneDimensionalArray(arr1.Length);
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] * arr2[i];
        }
        return result;
    }

    public static bool operator ==(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            return false;
        }

        for (int i = 0; i < arr1.Length; i++)
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

    public static bool operator <=(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            throw new InvalidOperationException("Arrays must have the same length for comparison.");
        }

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] > arr2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            throw new InvalidOperationException("Arrays must have the same length for comparison.");
        }

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] < arr2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static implicit operator int(OneDimensionalArray arr)
    {
        return arr.Length;
    }
}

class Program
{
    static void Main()
    {
        OneDimensionalArray arr1 = new OneDimensionalArray(3);
        arr1[0] = 1;
        arr1[1] = 2;
        arr1[2] = 3;

        OneDimensionalArray arr2 = new OneDimensionalArray(3);
        arr2[0] = 4;
        arr2[1] = 5;
        arr2[2] = 6;

        OneDimensionalArray result = arr1 * arr2;

        Console.WriteLine("Результат умножения:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }

        Console.WriteLine("Размер arr1: " + (int)arr1);

        if (arr1 == arr2)
        {
            Console.WriteLine("arr1 равен arr2.");
        }
        else
        {
            Console.WriteLine("arr1 не равен arr2.");
        }

        if (arr1 <= arr2)
        {
            Console.WriteLine("arr1 меньше или равен arr2.");
        }
        else
        {
            Console.WriteLine("arr1 больше arr2.");
        }
    }
}