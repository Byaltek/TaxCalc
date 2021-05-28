using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using TaxCalc.Services;

namespace TaxCalc_Test
{
    public class Tests
    {
        [Test]
        public async Task TestRate()
        {
            var tax = new TaxJarService(new RestClient());
            var result = await tax.GetTaxRateByLocationAsync("60611");
            if (result.Rate != null)
                Assert.Pass();
            Assert.Fail();
        }

        [Test]
        public async Task TestTaxCalc()
        {
            var tax = new TaxJarService(new RestClient());
            var result = await tax.CalculateTaxesAsync("60611", "IL", 199.00);
            if (result.Tax != null)
                Assert.Pass();
            Assert.Fail();
        }
    }
}