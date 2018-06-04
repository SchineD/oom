using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Guitar
    {
        private string Brand, Model;

        private decimal m_price;
        public decimal Price
        {
            get 
            {
                return m_price;
            }
            set 
            {
                
                if (value < 0) throw new Exception("Price must not be negative.");
                m_price = value;
            }
        }

        public Guitar(string newBrand, string newModel, decimal newPrice)
        {
            if (string.IsNullOrWhiteSpace(newBrand)) throw new ArgumentException("Brand must not be empty.");
            if (string.IsNullOrWhiteSpace(newModel)) throw new ArgumentException("Model must not be empty.");

            Brand = newBrand;
            Model = newModel;
            Price = newPrice;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.");
            m_price = newPrice;
        }

        static void Main(string[] args)
        {
            var a = new Guitar("Gibson", "Les Paul", 2499.99m);
            var b = new Guitar("Fender", "Statocaster", 1999.99m);
           
            Console.WriteLine("brand: {0}, model: {1}, price: {2}", a.Brand, a.Model, a.Price);
            Console.WriteLine("brand: {0}, model: {1}, price: {2}", b.Brand, b.Model, b.Price);

            a.UpdatePrice(-2299.99m);

            Console.WriteLine("brand: {0}, model: {1}, price: {2}", a.Brand, a.Model, a.Price);
        }
    }
}
