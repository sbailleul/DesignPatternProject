namespace ESGI.DesignPattern.Projet
{
    public class Price
    {
        public double Amount { get; }
        public string Currency { get; }

        public Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}