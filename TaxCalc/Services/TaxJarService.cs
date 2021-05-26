using RestSharp;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TaxCalc.Contracts;
using TaxCalc.Entities;

namespace TaxCalc.Services
{
    public class TaxJarService : ITaxService
    {
        private IRestClient client;

        public TaxJarService(IRestClient restClient)
        {
            client = restClient; 
        }       

        public async Task<TaxResponse> CalculateTaxesAsync(string zip, string state, double orderAmt)
        {
            var client = new RestClient("https://api.taxjar.com/v2/taxes");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n  \"from_country\": \"US\",\n  \"from_zip\": \"" + zip + "\",\n  \"from_state\": \"" + state + "\",\n  \"to_country\": \"US\",\n  \"to_zip\": \"" + zip + "\",\n  \"to_state\": \"" + state + "\",\n  \"amount\": " + orderAmt + ",\n  \"shipping\": 0,\n  \"line_items\": [\n    {\n      \"quantity\": 1,\n      \"unit_price\": " + orderAmt + ",\n      \"product_tax_code\": \"\"\n    }\n  ]\n}", ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            var tax = JsonConvert.DeserializeObject<TaxResponse>(response.Content);
            return tax;
        }

        public async Task<RateResponse> GetTaxRateByLocationAsync(string zip)
        {
            var baseUrl = "https://api.taxjar.com/v2/rates/";
            if (!string.IsNullOrEmpty(zip))
                baseUrl += $"{zip}?country=US";
            client.BaseUrl = new Uri(baseUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            var rate = JsonConvert.DeserializeObject<RateResponse>(response.Content);
            return rate;
        }
    }
}
