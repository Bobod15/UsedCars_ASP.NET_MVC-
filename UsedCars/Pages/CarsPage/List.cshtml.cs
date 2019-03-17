using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using UsedCars.Data;
using UsedCars.Core;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UsedCars.Pages.Cars
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICarsData carsData;

        public string DisplayMessage { get; set; }
        public IEnumerable<Car> DisplayCars { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchVal { get; set; }
        public string ManifacVal { get; set; }
        public string ModelVal { get; set; }
        public string YearVal { get; set; }
        public string OwnerVal { get; set; }
        


        public ListModel(IConfiguration config, ICarsData carsData )
        {
            this.config = config;
            this.carsData = carsData;

        }

        public void OnGet(string SearchVal, string ManifacVal, string ModelVal, string YearVal, string OwnerVal)
        {
            if (String.IsNullOrEmpty(SearchVal) &&
                String.IsNullOrEmpty(ManifacVal) &&
                String.IsNullOrEmpty(ModelVal) &&
                String.IsNullOrEmpty(YearVal) &&
                String.IsNullOrEmpty(OwnerVal))
            {
                this.SearchVal = SearchVal;
                DisplayCars = carsData.GetCarsByManifacturer(SearchVal);
            }
            if (String.IsNullOrEmpty(SearchVal) &&
                !String.IsNullOrEmpty(ManifacVal) ||
                !String.IsNullOrEmpty(ModelVal) ||
                !String.IsNullOrEmpty(YearVal) ||
                !String.IsNullOrEmpty(OwnerVal))
            {
                this.ManifacVal = ManifacVal;
                this.ModelVal = ModelVal;
                this.YearVal = YearVal;
                this.OwnerVal = OwnerVal;
                DisplayCars = carsData.GetCarsByMultipleFields(ManifacVal, ModelVal, YearVal, OwnerVal);
            }
            else
            {              
                this.SearchVal = SearchVal;
                DisplayCars = carsData.GetCarsByManifacturer(SearchVal);
            }
        }
    }
}