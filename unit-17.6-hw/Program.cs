namespace Unit_17_6;

/* 
Напишите свой вариант рефакторинга кода из задания 4 в соответствии с Принципом открытости-закрытости.

Иначе говоря, вы должны проектировать классы так, чтобы при необходимости их можно было легко дополнить 
(то есть оставлять задел на будущее, возможности для масштабирования и роста функционала).


Если код из задания 4 действительно нужно рефакторить, то с чего бы вы начали?
1 Реализовать общий интерфейс для всех аккаунтов с методом CalculateInterest()
2 через этот интерфейс потом будут передаваться конкретные реализации аккаунтов в класс Calculator */

public class Account
{
    // тип учетной записи
    public string Type { get; set; }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }
}

public interface ICalculator
{
    public void CalculateInterest(Account account);
}

public class Calculator
{
    public void CalculateInterest(ICalculator calculator, Account account)
    {
        calculator.CalculateInterest(account);
    }
}

public class BaseCalculator : ICalculator
{
    // Метод для расчета процентной ставки
    public void CalculateInterest(Account account)
    {
        Console.WriteLine(">> Загружен профиль: Базовый <<");
        // расчет процентной ставки обычного аккаунта по правилам банка
        account.Interest = account.Balance * 0.4;

        if (account.Balance < 1000)
            account.Interest -= account.Balance * 0.2;

        if (account.Balance < 50000)
            account.Interest -= account.Balance * 0.4;
    }
}

public class SalaryCalculator : ICalculator
{
    // Метод для расчета процентной ставки
    public void CalculateInterest(Account account)
    {
        Console.WriteLine(">> Загружен профиль: Зарплатный <<");
        // расчет процентной ставк зарплатного аккаунта по правилам банка
        account.Interest = account.Balance * 0.5;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account account = new Account();
        account.Balance = 10000;
        account.Type = "Обычный";
        account.Interest = 0;

        var calculator = new Calculator();

        calculator.CalculateInterest(new BaseCalculator(), account);

        Console.WriteLine();

        calculator.CalculateInterest(new SalaryCalculator(), account);
    }
}

/* // Новый список аккаунтов
        var accountList = new List<Account>()
        {
            new BaseAccount("Обычный", 5000, 0),
            new BaseAccount("Обычный", 10000, 0),
            new BaseAccount("Обычный", 15000, 0),
            new SalaryAccount("Зарплатный", 15000, 0),
            new SalaryAccount("Зарплатный", 20000, 0),
            new SalaryAccount("Зарплатный", 25000, 0)
        }; */