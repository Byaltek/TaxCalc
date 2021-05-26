using System.ComponentModel.DataAnnotations;

namespace TaxCalc.Entities
{
    public class RateResponse
    {
        public Rate Rate { get; set; }
    }

    public class Rate
    {
        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "City Rate")]
        public double city_rate { get; set; }

        [Display(Name = "Combined District Rate")]
        public double combined_district_rate { get; set; }

        [Display(Name = "Combined Rate")]
        public double combined_rate { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Country Rate")]
        public double country_rate { get; set; }

        [Display(Name = "County")]
        public string county { get; set; }

        [Display(Name = "County Rate")]
        public double county_rate { get; set; }

        [Display(Name = "FreightTaxable")]
        public bool freight_taxable { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "State Rate")]
        public double state_rate { get; set; }

        [Display(Name = "Zip")]
        public string zip { get; set; }
    }

}