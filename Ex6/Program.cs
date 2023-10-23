using System;

public class Decimal
{
    private char[] digits; // Массив из 100 десятичных цифр

    // Конструктор для инициализации десятичного числа
    public Decimal(string number)
    {
        if (number.Length != 100)
        {
            throw new ArgumentException("Число должно содержать 100 цифр.");
        }

        digits = number.ToCharArray();
        Array.Reverse(digits); // Переворачиваем массив для удобства работы с ним
    }

    // Метод для выполнения сложения
    public Decimal Add(Decimal other)
    {
        char[] result = new char[100];
        int carry = 0;

        for (int i = 0; i < 100; i++)
        {
            int sum = (digits[i] - '0') + (other.digits[i] - '0') + carry;
            result[i] = (char)((sum % 10) + '0');
            carry = sum / 10;
        }

        return new Decimal(new string(result));
    }

    // Метод для выполнения вычитания
    public Decimal Subtract(Decimal other)
    {
        char[] result = new char[100];
        int borrow = 0;

        for (int i = 0; i < 100; i++)
        {
            int diff = (digits[i] - '0') - (other.digits[i] - '0') - borrow;
            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }

            result[i] = (char)(diff + '0');
        }

        return new Decimal(new string(result));
    }

    // Метод для выполнения умножения
    public Decimal Multiply(Decimal other)
    {
        throw new NotImplementedException("Умножение пока не реализовано.");
    }

    // Метод для выполнения деления
    public Decimal Divide(Decimal other)
    {
        throw new NotImplementedException("Деление пока не реализовано.");
    }

    // Метод для вывода числа на экран
    public void Print()
    {
        char[] reversedDigits = (char[])digits.Clone();
        Array.Reverse(reversedDigits);
        Console.WriteLine(new string(reversedDigits));
    }
}

class Program
{
    static void Main()
    {
        // Пример использования класса Decimal
        Decimal number1 = new Decimal("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        Decimal number2 = new Decimal("9876543210987654321098765432109876543210987654321098765432109876543210987654321098765432109876543210");

        Decimal sum = number1.Add(number2);
        Console.WriteLine("Сумма:");
        sum.Print();

        Decimal difference = number1.Subtract(number2);
        Console.WriteLine("Разность:");
        difference.Print();
    }
}
