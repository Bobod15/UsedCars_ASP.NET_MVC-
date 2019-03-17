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
    public class EditModel : PageModel
    {
        private readonly ICarsData carsData;

        [BindProperty]
        public Car Car{ get; set; }

        public EditModel(ICarsData carsData)
        {
            this.carsData = carsData;
        }
        public IActionResult OnGet(int? carIdent)
        {
            if (carIdent.HasValue)
            {
            Car = carsData.GetById(carIdent.Value);
            }
            else
            {
                Car = new Car();
            }

            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Car.ID > 0)
            {
                Car = carsData.Update(Car);
            }
            else
            {
                carsData.AddNew(Car);
            }
            carsData.Commit();
            TempData["SaveMessage"] = "Information has been updated!";
            return RedirectToPage("./Detail", new { carIdent = Car.ID });
            
        }
    }
}