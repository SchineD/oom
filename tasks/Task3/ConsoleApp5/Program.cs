using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IInstrument
    {
        void UpdatePrice(decimal newPrice);
        decimal GetPrice();
        string Description { get; }
    }

    class Drumkit : IInstrument
    {
        private string Model, Brand;
        private decimal m_price;
       

        public Drumkit(string newBrand, string newModel, decimal newPrice)
        {
            if (string.IsNullOrWhiteSpace(newBrand)) throw new ArgumentException("Brand must not be empty.");
            if (string.IsNullOrWhiteSpace(newModel)) throw new ArgumentException("Model must not be empty.");

            Brand = newBrand;
            Model = newModel;
            UpdatePrice(newPrice);
        }

        public decimal GetPrice() => m_price;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.");
            m_price = newPrice;
        }

        public string Description => "Model: " + Model + "Brand: " + Brand + "Price: " + GetPrice();
    }

    class Guitar : IInstrument
    {
        private string Model, Brand;
        private decimal m_price;

        public Guitar(string newBrand, string newModel, decimal newPrice)
        {
            if (string.IsNullOrWhiteSpace(newBrand)) throw new ArgumentException("Brand must not be empty.");
            if (string.IsNullOrWhiteSpace(newModel)) throw new ArgumentException("Model must not be empty.");

            Brand = newBrand;
            Model = newModel;
            UpdatePrice(newPrice);
        }

        public decimal GetPrice() => m_price;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.");
            m_price = newPrice;
        }

        public string Description => "Model: " + Model + "Brand: " + Brand + "Price: " + GetPrice();
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var items = new IInstrument[]
           {
                new Guitar("Gibson ", "Les Paul Standard ", 2499.99m),
                new Guitar("Fender ", "Stratocaster HSS ", 1999.99m),
                new Guitar("Epiphone ", "ES 559 ", 949.99m),
                new Drumkit("SuperLoud ", "Deluxe 22 Plus ", 599.99m),
                new Drumkit("SoundWave ", "ProTune 24 ", 1299.99m),
           };

            foreach (var x in items)
            {
                Console.WriteLine(x.Description);
            }
        }
    }
}
