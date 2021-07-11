using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESGI.DesignPattern.Projet.XmlWriters
{
    public class OrdersWriter : IWriter
    {
        private readonly List<Order> _orders;

        public OrdersWriter(IEnumerable<Order> orders)
        {
            this._orders = orders.ToList();
        }

        public string GetContent()
        {
            var xml = new StringBuilder();
            xml.Append("<orders>");
            foreach (var orderWriter in _orders.Select(order => new OrderWriter(order)))
            {
                xml.Append(orderWriter.GetContent());
            }

            xml.Append("</orders>");
            return xml.ToString();
        }
    }
}