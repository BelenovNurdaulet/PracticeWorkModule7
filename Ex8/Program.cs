using System;

class Frac
{
    private int numerator;
    private int denominator;

    public Frac(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
        Simplify();
    }

    // Методы вычисления полинома в точке и перегрузка операторов остаются без изменений

    // Перегрузка операторов +, -, *, / для класса Frac
    public static Frac operator +(Frac a, Frac b)
    {
        return new Frac(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
    }

    public static Frac operator -(Frac a, Frac b)
    {
        return new Frac(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
    }

    public static Frac operator *(Frac a, Frac b)
    {
        return new Frac(a.numerator * b.numerator, a.denominator * b.denominator);
    }

    public static Frac operator /(Frac a, Frac b)
    {
        if (b.numerator == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return new Frac(a.numerator * b.denominator, a.denominator * b.numerator);
    }

    // Перегрузка операторов == и !=
    public static bool operator ==(Frac a, Frac b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Frac a, Frac b)
    {
        return !a.Equals(b);
    }

    // Приведение типа Frac -> double
    public static implicit operator double(Frac frac)
    {
        return (double)frac.numerator / frac.denominator;
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Frac other)
        {
            return numerator == other.numerator && denominator == other.denominator;
        }
        return false;
    }

    private void Simplify()
    {
        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

class Program
{
    static void Main()
    {
        Frac a = new Frac(1, 2);
        Frac b = new Frac(3, 4);

        Frac sum = a + b;
        Frac difference = a - b;
        Frac product = a * b;
        Frac quotient = a / b;

        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Разность: {difference}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Частное: {quotient}");

        // Приведение Frac к double
        double doubleValue = a;
        Console.WriteLine($"Приведение типа: {doubleValue}");

        // Вычисление значения полинома в точке
        Frac[] coefficients = { new Frac(1, 1), new Frac(2, 1), new Frac(3, 1) }; // Пример коэффициентов x^2 + 2x + 3
        Frac x = new Frac(2, 1); // Точка, в которой нужно вычислить полином
        Frac result = CalculatePolynomial(coefficients, x);
        Console.WriteLine($"Значение полинома в точке {x}: {result}");
    }

    static Frac CalculatePolynomial(Frac[] coefficients, Frac x)
    {
        Frac result = new Frac(0, 1);
        Frac xPower = new Frac(1, 1);

        foreach (Frac coef in coefficients)
        {
            result += coef * xPower;
            xPower *= x;
        }

        return result;
    }
}
