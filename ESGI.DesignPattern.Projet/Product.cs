using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Product
    {
        public Product(int id, string name, ProductSize? size, Price price, string color)
        {
            this.ID = id;
            this.Name = name;
            this.Size = size;
            this.Price = price;
            this.Color = color;
        }

        public int ID { get; }

        public string Name { get; }
        
        public string Color { get; }

        public ProductSize? Size { get; }

        public Price Price { get; }
    }
}