namespace Unit_17_6;

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
