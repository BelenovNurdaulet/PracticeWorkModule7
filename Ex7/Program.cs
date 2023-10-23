using System;

struct Complex
{
    public double Real { get; }
    public double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
    }

    public static Complex operator /(Complex a, Complex b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        return new Complex((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
                           (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
    }

    public static implicit operator Complex(double real)
    {
        return new Complex(real, 0);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }

    public override bool Equals(object obj)
    {
        if (obj is Complex other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
        }
        return false;
    }

    public override int GetHashCode()

    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Real.GetHashCode();
            hash = hash * 23 + Imaginary.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(Complex a, Complex b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Complex a, Complex b)
    {
        return !(a == b);
    }
}

class Program
{
    static void Main()
    {
        Complex complex1 = new Complex(1, 2);
        Complex complex2 = new Complex(3, 4);

        Complex sum = complex1 + complex2;
        Complex difference = complex1 - complex2;
        Complex product = complex1 * complex2;
        Complex quotient = complex1 / complex2;

        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Разность: {difference}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Частное: {quotient}");

        double realNumber = 2.5;
        Complex complexFromDouble = realNumber;
        Console.WriteLine($"Приведение типа: {complexFromDouble}");

        Console.WriteLine($"Сравнение: complex1 == complex2: {complex1 == complex2}");
        Console.WriteLine($"Сравнение: complex1 != complex2: {complex1 != complex2}");
    }
}