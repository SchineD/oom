using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task6;

namespace Unittests
{
    [TestFixture]

    public class Tests
    {

        [Test]
        public void CanCreateGuitar()
        {
            var x = new Guitar("Gibson", "SG Standard", 1399.99m);

            Assert.IsTrue(x.Brand == "Gibson");
            Assert.IsTrue(x.Model == "SG Standard");
            Assert.IsTrue(x.GetPrice() == 1399.99m);    
        }

        [Test]
        public void CannotCreateDrumkitWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Drumkit("SuperSonic", "blala", -20m);
            });
        }

        [Test]
        public void CannotCreateGuitartWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Guitar("Epiphone", "blala", -80m);
            });
        }

        [Test]
        public void CannotCreateGuitarWithoutStatingBrand()
        {
            Assert.Catch(() =>
            {
                var x = new Guitar("", "Mustang", 2000m);
            });
        }

        [Test]
        public void CannotCreateDrumkitWithoutStatingBrand()
        {
            Assert.Catch(() =>
            {
                var x = new Drumkit("", "BassMaster", 2000m);
            });
        }

        [Test]
        public void CannotCreateGuitarWithoutStatingModel()
        {
            Assert.Catch(() =>
            {
                var x = new Guitar("Ibanez", "", 2000m);
            });
        }

        [Test]
        public void CannotCreateGuitarWithoutStatingModel2()
        {
            Assert.Catch(() =>
            {
                var x = new Guitar("Ibanez", null, 2000m);
            });
        }

        [Test]
        public void CannotUpdateGuitarWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Guitar("Fender", "Mustang", 2000m);
                x.UpdatePrice(-999m);
            });
        }
    }
}
