namespace Unit_17_6;

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
