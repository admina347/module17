namespace Unit_17_6;

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
    //печать
    public void Print()
    {
        Console.WriteLine("Процентная ставка: " + Interest);
    }
}
