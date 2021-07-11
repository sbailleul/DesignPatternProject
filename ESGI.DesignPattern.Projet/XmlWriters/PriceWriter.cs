using System.Globalization;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class PriceWriter : IWriter
    {
        private readonly Price _price;

        public PriceWriter(Price price)
        {
            _price = price;
        }

        public string GetContent()
        {
            var xml = new StringBuilder();
            var priceAmount = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", _price.Amount);
            xml.Append($"<price currency='{_price.Currency}'>{priceAmount}</price>");
            return xml.ToString();
        }
    }
}