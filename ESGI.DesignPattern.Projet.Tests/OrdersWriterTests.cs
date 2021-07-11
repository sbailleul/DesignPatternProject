using System;
using System.Collections.Generic;
using ESGI.DesignPattern.Projet.XmlWriters;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class OrdersWriterTests
    {
        [Fact]
        public void GetContents_produces_all_orders()
        {
            var orders = new List<Order>();
            var order = new Order(1234);
            order.Add(new Product(4321, "T-Shirt", ProductSize.Medium, new Price(21, "USD"), "red"));
            order.Add(new Product(6789, "Socks", ProductSize.Medium, new Price(8, "USD"), "red"));
            orders.Add(order);

            var ordersWriter = new OrdersWriter(orders);

            var expectedOrder =
                "<orders>" +
                "<order id='1234'>" +
                "<product id='4321' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "21.00" +
                "</price>" +
                "T-Shirt" +
                "</product>" +
                "<product id='6789' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "8.00" +
                "</price>" +
                "Socks" +
                "</product>" +
                "</order>" +
                "</orders>";
            Assert.Equal(expectedOrder, ordersWriter.GetContent());
        }
        
        [Fact]
        public void GetContents_produces_all_multiplr_orders()
        {
            var orders = new List<Order>();
            var tshirtProduct = new Product(4321, "T-Shirt", ProductSize.Medium, new Price(21, "USD"), "red");
            var socksProduct = new Product(6789, "Socks", ProductSize.Medium, new Price(8, "USD"), "red");
            
            var order1 = new Order(1234);
            order1.Add(tshirtProduct);
            order1.Add(socksProduct);
            orders.Add(order1);
            
            var order2 = new Order(2222);
            order2.Add(tshirtProduct);
            orders.Add(order2);

            var ordersWriter = new OrdersWriter(orders);

            var expectedOrder =
                "<orders>" +
                "<order id='1234'>" +
                "<product id='4321' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "21.00" +
                "</price>" +
                "T-Shirt" +
                "</product>" +
                "<product id='6789' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "8.00" +
                "</price>" +
                "Socks" +
                "</product>" +
                "</order>" +
                "<order id='2222'>" +
                "<product id='4321' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "21.00" +
                "</price>" +
                "T-Shirt" +
                "</product>" +
                "</order>" +
                "</orders>";
            Assert.Equal(expectedOrder, ordersWriter.GetContent());
        }
        
        [Fact]
        public void GetContent_should_handle_empty_order()
        {
            var orders = new List<Order>();
            var tshirtProduct = new Product(4321, "T-Shirt", ProductSize.Medium, new Price(21, "USD"), "red");
            var socksProduct = new Product(6789, "Socks", ProductSize.Medium, new Price(8, "USD"), "red");
            
            var order1 = new Order(1234);
            order1.Add(tshirtProduct);
            order1.Add(socksProduct);
            orders.Add(order1);
            
            var order2 = new Order(2222);
            orders.Add(order2);

            var ordersWriter = new OrdersWriter(orders);

            var expectedOrder =
                "<orders>" +
                "<order id='1234'>" +
                "<product id='4321' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "21.00" +
                "</price>" +
                "T-Shirt" +
                "</product>" +
                "<product id='6789' color='red' size='medium'>" +
                "<price currency='USD'>" +
                "8.00" +
                "</price>" +
                "Socks" +
                "</product>" +
                "</order>" +
                "<order id='2222'>" +
                "</order>" +
                "</orders>";
            Assert.Equal(expectedOrder, ordersWriter.GetContent());
        }

        [Fact]
        public void GetContents_produces_no_orders()
        {
            var orders = new List<Order>();
            var ordersWriter = new OrdersWriter(orders);

            var expectedOrder =
                "<orders>" +
                "</orders>";

            Assert.Equal(expectedOrder, ordersWriter.GetContent());
        }
    }
}