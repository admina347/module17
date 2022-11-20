namespace Unit_17_6;
public abstract class Account
{
    public Account(string type, double balance, double interest)
    {
        Type = type;
        Balance = balance;
        Interest = interest;
    }

    // тип учетной записи
    public string Type { get; set; }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }

    public void CalculateInterest(ICalculator calculator)
    {
        calculator.CalculateInterest(this);
    }
}

/// <summary>
/// Интерфейс с общим функционалом
/// </summary>
public interface ICalculator
{
    void CalculateInterest(Account account);
}

public class Calculator
{
    public void CalculateInterest(ICalculator calculator, Account account)
    {
        calculator.CalculateInterest(account);
    }
}

public class BaseAccount : Account, ICalculator
{
    public BaseAccount(string type, double balance, double interest) : base(type, balance, interest)
    {
    }

    public void CalculateInterest(Account account)
    {
        Console.WriteLine("Aккаунт:" + account.Type);
        // расчет процентной ставки обычного аккаунта по правилам банка
        account.Interest = account.Balance * 0.4;

        if (account.Balance < 1000)
            account.Interest -= account.Balance * 0.2;

        if (account.Balance < 50000)
            account.Interest -= account.Balance * 0.4;
        Console.WriteLine("Ставка: " + account.Interest);
    }
}

public class SalaryAccount : Account, ICalculator
{
    public SalaryAccount(string type, double balance, double interest) : base(type, balance, interest)
    {
    }

    public void CalculateInterest(Account account)
    {
        Console.WriteLine("Аккаунт:" + account.Type);
        account.Interest = account.Balance * 0.5;
        Console.WriteLine("Ставка: " + account.Interest);
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Новый список аккаунтов
        var accountList = new List<Account>()
        {
            new BaseAccount("Обычный", 5000, 0),
            new BaseAccount("Обычный", 10000, 0),
            new BaseAccount("Обычный", 15000, 0),
            new SalaryAccount("Зарплатный", 15000, 0),
            new SalaryAccount("Зарплатный", 20000, 0),
            new SalaryAccount("Зарплатный", 25000, 0)
        };
        //accountList[0].CalculateInterest(Account.)
        // Считаем ставки
        //ICalculator calculator = new Account();
        //FlightPassengerCount(accountList);
        //foreach (var a in accountList)
        //a.CalculateInterest(a.Balance);

        /* ICalculator calculator = new BaseAccount();
        var account = new Account("Обычный", 5000, 0);
        calculator.CalculateInterest(account);
        Console.WriteLine(); */

        /* var calculator = new Calculator();
        var account = new Account("Обычный", 5000, 0);  
        // посадка на землю
        calculator.CalculateInterest(new BaseAccount(), account);
        Console.WriteLine(); */

        //account.CalculateInterest(new SalaryAccount());
        //Account ac = new BaseAccount();
        //ac.Type = "необычный";
        //ac.CalculateInterest(calculator);
        //
        //calculator.CalculateInterest();
        //  Document doc = new Document();
        //  doc.Text = "Hello World";
        //  doc.Export(exporter);

        var calculator = new Calculator();
        foreach (var a in accountList)
            calculator.CalculateInterest(a);

    }
    //public static void FlightPassengerCount(List<Account> accounts)
    //{
    //    foreach (var a in accounts)
    //        a.CalculateInterest(a);
    //}
}