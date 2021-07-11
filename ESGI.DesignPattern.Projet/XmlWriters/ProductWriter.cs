using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class ProductWriter : IWriter
    {
        private Product _product;

        private Dictionary<ProductSize, string> _sizeMatcher = new Dictionary<ProductSize, string>
        {
            {ProductSize.Medium, "medium"}
        };

        public ProductWriter(Product product)
        {
            _product = product;
        }

        public string GetContent()
        {
            var xml = new StringBuilder();
            xml.Append($"<product id='{_product.ID}' color='{_product.Color}'");
            if (_product.Size.HasValue)
            {
                xml.Append($" size='{GetSize()}'");
            }
            var priceWriter = new PriceWriter(_product.Price);
            xml.Append($">{priceWriter.GetContent()}{_product.Name}</product>");
            return xml.ToString();
        }


        private string GetSize()
        {
            if (_product.Size != null && _sizeMatcher.TryGetValue(_product.Size.Value, out var textSize))
            {
                return textSize;
            }

            return "NOT APPLICABLE";
        }
    }
}