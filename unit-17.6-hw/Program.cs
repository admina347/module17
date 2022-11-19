namespace Unit_17_6;
public abstract class Account
{
    protected Account(string type, double balance, double interest)
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
    // Подсчет количества пассажиров
    public void CountPassengers()
    {
        Console.WriteLine($"Аккаунт {Type} Баланс {Balance} ставка {Interest}");
    }
}

/// <summary>
/// Интерфейс с общим функционалом
/// </summary>
public interface ICalculator
{
    void CalculateInterest(Account account);
}




public class BaseAccount : Account
{
    public BaseAccount(string type, double balance, double interest) : base(type, balance, interest)
    {
    }

    public void CalculateInterest(Account account)
    {
        Console.WriteLine("Aккаунт:" + account.Type);
    }
}

public class SalaryAccount : Account
{
    public SalaryAccount(string type, double balance, double interest) : base(type, balance, interest)
    {
    }

    public void CalculateInterest(Account account)
    {
        Console.WriteLine("Аккаунт:" + account.Type);
    }
}




/* public class Calculator : ICalculator
{
    // Метод для расчета процентной ставки
    public void CalculateInterest(Account account)
    {
        if (account.Type == "Обычный")
        {
            // расчет процентной ставки обычного аккаунта по правилам банка
            account.Interest = account.Balance * 0.4;

            if (account.Balance < 1000)
                account.Interest -= account.Balance * 0.2;

            if (account.Balance < 50000)
                account.Interest -= account.Balance * 0.4;
        }
        else if (account.Type == "Зарплатный")
        {
            // расчет процентной ставк зарплатного аккаунта по правилам банка
            account.Interest = account.Balance * 0.5;
        }
        Console.WriteLine("Расчет: " + account.Interest);
    }
} */

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
        // Считаем ставки
        FlightPassengerCount(accountList);

        //ICalculator calculator = new Calcultor();
        //Account ac = new Account();
        //ac.Type = "необычный";
        //ac.CalculateInterest(calculator);
        //
        //calculator.CalculateInterest();
        //  Document doc = new Document();
        //  doc.Text = "Hello World";
        //  doc.Export(exporter);


        //account.CalculateInterest(account);

        /*         var flightsList = new List<Flight>()
           {
               new DomesticFlight("Mow-32", new List<string>() {"Вася", "Петя"}),
               new DomesticFlight("SPB-14", new List<string>() {"Андрей"})
           }; */

        // Считаем пассажиров
        //FlightPassengerCount(flightsList);
    }
    /// <summary>
        /// Метод для подсчёта количества пассажиров
        /// </summary>
        public static void FlightPassengerCount(List<Account> accountList)
        {
            foreach (var account in accountList)
               account.CountPassengers();
        }
}