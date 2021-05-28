using System.ComponentModel.DataAnnotations;

namespace TaxCalc.Entities
{
    public class TaxResponse
    {
        public Tax Tax { get; set; }
    }

    public class Tax
    {
        [Display(Name = "Tax to Collect")]
        public float amount_to_collect { get; set; }

        [Display(Name = "Breakdown")]
        public Breakdown breakdown { get; set; }

        [Display(Name = "Freight Taxable")]
        public bool freight_taxable { get; set; }

        [Display(Name = "Has Nexus")]
        public bool has_nexus { get; set; }

        [Display(Name = "Jurisdictions")]
        public Jurisdictions jurisdictions { get; set; }

        [Display(Name = "Order Total Amount")]
        public float order_total_amount { get; set; }

        [Display(Name = "Rate")]
        public float rate { get; set; }

        [Display(Name = "Shipping")]
        public float shipping { get; set; }

        [Display(Name = "Tax Source")]
        public string tax_source { get; set; }

        [Display(Name = "Taxable Amount")]
        public float taxable_amount { get; set; }
    }

    public class Breakdown
    {
        public float city_tax_collectable { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_tax_collectable { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public Line_Items[] line_items { get; set; }
        public Shipping shipping { get; set; }
        public float special_district_tax_collectable { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_tax_collectable { get; set; }
        public float state_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Shipping
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public float special_district_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float special_taxable_amount { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Line_Items
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public string id { get; set; }
        public float special_district_amount { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Jurisdictions
    {
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string state { get; set; }
    }

}
