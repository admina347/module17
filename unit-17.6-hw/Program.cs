namespace Unit_17_6;

class Program
{
    static void Main(string[] args)
    {
        // Новый список аккаунтов
        var accountList = new List<IAccount>()
        {
            new Ordinary(5000, 0),
            new Ordinary(10000, 0),
            new Ordinary(60000, 0),
            new Salary(15000, 0),
            new Salary(20000, 0),
            new Salary(25000, 0)
        };

        foreach (var account in accountList)
        {
            account.CalculateInterest();
            account.Print();
        }
    }
}