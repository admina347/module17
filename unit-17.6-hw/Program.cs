namespace Unit_17_6;

/* 
Напишите свой вариант рефакторинга кода из задания 4 в соответствии с Принципом открытости-закрытости.

Иначе говоря, вы должны проектировать классы так, чтобы при необходимости их можно было легко дополнить 
(то есть оставлять задел на будущее, возможности для масштабирования и роста функционала).


Если код из задания 4 действительно нужно рефакторить, то с чего бы вы начали?
1 Реализовать общий интерфейс для всех аккаунтов с методом CalculateInterest()
2 через этот интерфейс потом будут передаваться конкретные реализации аккаунтов в класс Calculator */

public interface IAccount
{
    public void CalculateInterest();
    public void Print();
}

public static class Calculator
{
    public static void CalculateInterest(IAccount account)
    {
        account.CalculateInterest();
    }
}
public abstract class Account
{
    protected Account(double balance, double interest)
    {
        Balance = balance;
        Interest = interest;
    }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }
    public void Print()
    {
        Console.WriteLine("Процентная ставка: " + Interest);
    }
}
public class Ordinary : Account, IAccount
{
    public Ordinary(double balance, double interest) : base(balance, interest)
    {
    }

    public void CalculateInterest()
    {
        // расчет процентной ставки обычного аккаунта по правилам банка
        Interest = Balance * 0.4;
        if (Balance < 1000)
            Interest -= Balance * 0.2;

        if (Balance < 50000)
            Interest -= Balance * 0.4;
    }
}

public class Salary : Account, IAccount
{
    public Salary(double balance, double interest) : base(balance, interest)
    {
    }

    public void CalculateInterest()
    {
        // расчет процентной ставк зарплатного аккаунта по правилам банка
        Interest = Balance * 0.5;
    }
}

class Program
{
    static void Main(string[] args)
    {
        /* var account = new Ordinary();
        account.Balance = 60000;
        account.Interest = 0;
        account.CalculateInterest();
        account.Print(); */

        // Новый список аккаунтов
        var accountList = new List<IAccount>()
        {
            new Ordinary(5000, 0),
            new Ordinary(10000, 0),
            new Ordinary(15000, 0),
            new Salary(15000, 0),
            new Salary(20000, 0),
            new Salary(25000, 0)
        };

        foreach (var a in accountList)
        {
            a.CalculateInterest();
            a.Print();
        }
    }
}

