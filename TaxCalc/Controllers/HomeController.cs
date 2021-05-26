using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaxCalc.Contracts;
using TaxCalc.Models;

namespace TaxCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITaxService taxService;

        public HomeController(ILogger<HomeController> log, ITaxService service)
        {
            logger = log;
            taxService = service;
        }

        public async Task<IActionResult> GetTaxRate(string zip)
        {
            var rateInfo = await taxService.GetTaxRateByLocationAsync(zip);
            return PartialView("_RateInfo", rateInfo.Rate);
        }

        public async Task<IActionResult> CalculateRate(string zip, string state, double orderAmt)
        {
            var taxInfo = await taxService.CalculateTaxesAsync(zip, state.Trim(), orderAmt);
            return PartialView("_TaxInfo", taxInfo.Tax);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
