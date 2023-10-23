using System;

public class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money money1, Money money2)
    {
        if (money1.Currency != money2.Currency)
        {
            throw new InvalidOperationException("Cannot add money in different currencies without conversion.");
        }

        return new Money(money1.Amount + money2.Amount, money1.Currency);
    }

    public static bool operator ==(Money money1, Money money2)
    {
        if (ReferenceEquals(money1, money2))
        {
            return true;
        }

        if (money1 is null || money2 is null)
        {
            return false;
        }

        return money1.Amount == money2.Amount && money1.Currency == money2.Currency;
    }

    public static bool operator !=(Money money1, Money money2)
    {
        return !(money1 == money2);
    }
}

public class MoneyConverter
{
    private decimal exchangeRate;

    public MoneyConverter(decimal exchangeRate)
    {
        this.exchangeRate = exchangeRate;
    }

    public Money Convert(Money money, string targetCurrency)
    {
        if (money.Currency == targetCurrency)
        {
            return money;
        }

        decimal convertedAmount = money.Amount * exchangeRate;
        return new Money(convertedAmount, targetCurrency);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Money money1 = new Money(100, "USD");
        Money money2 = new Money(150, "USD");

        MoneyConverter converter = new MoneyConverter(0.8m); // Conversion rate from USD to EUR: 1 USD = 0.8 EUR

        Money convertedMoney = converter.Convert(money1, "EUR");
        Console.WriteLine($"Конвертация валют: {convertedMoney.Amount} {convertedMoney.Currency}");

        Money sum = money1 + money2;
        Console.WriteLine($"Сложение валют: {sum.Amount} {sum.Currency}");

        if (money1 == money2)
        {
            Console.WriteLine("money1  равно money2.");
        }
        else
        {
            Console.WriteLine("money1 не равно money2.");
        }
    }
}
