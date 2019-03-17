using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsedCars.Core;
using UsedCars.Data;

namespace UsedCars.Pages.CarsPage
{
    public class DetailModel : PageModel
    {
        private readonly ICarsData carsData;

        [TempData]
        public string SaveMessage { get; set; }
        public Car Car{ get; set; }

        public DetailModel(ICarsData carsData)
        {
            this.carsData = carsData;
        }

        public IActionResult OnGet(int carIdent)
        {
            Car = carsData.GetById(carIdent);
            if (Car==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}