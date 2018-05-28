using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        private decimal m_price;


        public Drumkit(string Brand, string Model, decimal Price)
        {
            if (string.IsNullOrWhiteSpace(Brand)) throw new ArgumentException("Brand must not be empty.");
            if (string.IsNullOrWhiteSpace(Model)) throw new ArgumentException("Model must not be empty.");

            this.Brand = Brand;
            this.Model = Model;
            this.UpdatePrice(Price);
        }

        public string Model { get; }
        public string Brand { get; }

        public decimal GetPrice() => m_price;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.");
            m_price = newPrice;
        }

        public string Description => "Model: " + Model + " Brand: " + Brand + " Price: " + GetPrice();
    }

    class Guitar : IInstrument
    {
        private decimal m_price;

        public Guitar(string Brand, string Model, decimal Price)
        {
            if (string.IsNullOrWhiteSpace(Brand)) throw new ArgumentException("Brand must not be empty.");
            if (string.IsNullOrWhiteSpace(Model)) throw new ArgumentException("Model must not be empty.");

            this.Brand = Brand;
            this.Model = Model;
            this.UpdatePrice(Price);
        }

        public string Model { get; }
        public string Brand { get; }

        public decimal GetPrice() => m_price;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.");
            m_price = newPrice;
        }

        public string Description => "Model: " + Model + " Brand: " + Brand + " Price: " + GetPrice();
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
       

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IInstrument[]>(textFromFile, settings);

            foreach (var x in itemsFromFile) Console.WriteLine(x.Description);
            
         }
    }
}
