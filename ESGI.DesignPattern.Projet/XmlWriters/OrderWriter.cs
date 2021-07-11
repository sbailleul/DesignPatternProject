using System.Text;

namespace ESGI.DesignPattern.Projet.XmlWriters
{
    public class OrderWriter : IWriter
    {
        private readonly Order _order;

        public OrderWriter(Order order)
        {
            _order = order;
        }

        public string GetContent()
        {
            var xml = new StringBuilder();
            xml.Append($"<order id='{_order.OrderId()}'>");
            foreach (var orderProduct in _order.Products)
            {
                var productWriter = new ProductWriter(orderProduct);
                xml.Append(productWriter.GetContent());
            }

            xml.Append("</order>");
            return xml.ToString();
        }
    }
}