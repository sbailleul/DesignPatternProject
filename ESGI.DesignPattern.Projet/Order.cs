using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Order
    {
        private readonly int id;
        private List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Order(int id)
        {
            this._products = new List<Product>();
            this.id = id;
        }

        public int OrderId()
        {
            return this.id;
        }

        public void Add(Product product)
        {
            this._products.Add(product);
        }
    }
}
