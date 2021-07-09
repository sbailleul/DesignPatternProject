﻿using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class OrdersWriter
    {
        private Orders orders;

        public OrdersWriter(Orders orders)
        {
            this.orders = orders;
        }

        public string GetContents()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<orders>");
            for (int i = 0; i < this.orders.OrderCount(); i++)
            {
                Order order = this.orders.Order(i);
                xml.Append("<order");
                xml.Append(" id='");
                xml.Append(order.OrderId());
                xml.Append("'>");
                for (int j = 0; j < order.ProductCount(); j++)
                {
                    Product product = order.Product(j);
                    xml.Append("<product");
                    xml.Append(" id='");
                    xml.Append(product.ID);
                    xml.Append("'");
                    xml.Append(" color='");
                    xml.Append(this.ColorFor(product));
                    xml.Append("'");
                    if (product.Size != (int)ProductSize.NotApplicable)
                    {
                        xml.Append(" size='");
                        xml.Append(this.SizeFor(product));
                        xml.Append("'");
                    }

                    xml.Append(">");
                    xml.Append("<price");
                    xml.Append(" currency='");
                    xml.Append(this.CurrencyFor(product));
                    xml.Append("'>");
                    xml.Append(product.Price);
                    xml.Append("</price>");
                    xml.Append(product.Name);
                    xml.Append("</product>");
                }

                xml.Append("</order>");
            }

            xml.Append("</orders>");
            return xml.ToString();
        }

        private string CurrencyFor(Product product)
        {
            return "USD";
        }

        private string SizeFor(Product product)
        {
            switch (product.Size)
            {
                case ProductSize.Medium:
                    return "medium";
                default:
                    return "NOT APPLICABLE";
            }
        }

        private string ColorFor(Product product)
        {
            return "red";
        }
    }
}
