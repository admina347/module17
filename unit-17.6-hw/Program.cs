namespace Unit_17_6;
public class Account
{
    // тип учетной записи
    public string Type { get; set; }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }
}

public class BaseAccount : Account
{

}

public class SalaryAccount : Account
{

}

public static class Calculator
{
    // Метод для расчета процентной ставки
    public static void CalculateInterest(Account account)
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
        Console.WriteLine("Расчет: "+account.Interest);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Новый список полётов
        var account = new Account();
        account.Type = "Зарплатный";
        account.Balance = 25000;
        account.Interest = 0.2;

        Calculator.CalculateInterest(account);
/*         var flightsList = new List<Flight>()
   {
       new DomesticFlight("Mow-32", new List<string>() {"Вася", "Петя"}),
       new DomesticFlight("SPB-14", new List<string>() {"Андрей"})
   }; */

        // Считаем пассажиров
        //FlightPassengerCount(flightsList);
    }
}