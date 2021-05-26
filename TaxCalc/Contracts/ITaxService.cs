using System.Threading.Tasks;
using TaxCalc.Entities;

namespace TaxCalc.Contracts
{
    public interface ITaxService
    {
        Task<TaxResponse> CalculateTaxesAsync(string zip, string state, double orderAmt);

        Task<RateResponse> GetTaxRateByLocationAsync(string zip);
    }
}
