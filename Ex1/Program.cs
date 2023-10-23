using System;

class MyClass
{
    public int Property1 { get; set; }
    public string Property2 { get; set; }

    // Конструктор класса
    public MyClass(int property1, string property2)
    {
        Property1 = property1;
        Property2 = property2;
    }

    // Перегрузка оператора ==
    public static bool operator ==(MyClass obj1, MyClass obj2)
    {
        if (ReferenceEquals(obj1, null) && ReferenceEquals(obj2, null))
        {
            return true;
        }
        if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
        {
            return false;
        }
        return obj1.Property1 == obj2.Property1 && obj1.Property2 == obj2.Property2;
    }

    // Перегрузка оператора !=
    public static bool operator !=(MyClass obj1, MyClass obj2)
    {
        return !(obj1 == obj2);
    }

    // Перегрузка метода Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        MyClass other = (MyClass)obj;
        return Property1 == other.Property1 && Property2 == other.Property2;
    }

    // Перегрузка метода GetHashCode (рекомендуется при перегрузке Equals)
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Property1.GetHashCode();
            hash = hash * 23 + (Property2 != null ? Property2.GetHashCode() : 0);
            return hash;
        }
    }
}

class Program1
{
    static void Main()
    {
        MyClass obj1 = new MyClass(1, "Hello");
        MyClass obj2 = new MyClass(1, "Hello");

        // Использование перегруженных операторов и метода Equals
        Console.WriteLine("Используя оператор ==: " + (obj1 == obj2));
        Console.WriteLine("Используя оператор !=: " + (obj1 != obj2));
        Console.WriteLine("Используя метод Equals: " + obj1.Equals(obj2));
    }
}