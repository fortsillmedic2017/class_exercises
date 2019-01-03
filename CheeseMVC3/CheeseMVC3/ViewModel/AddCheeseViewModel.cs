using CheeseMVC3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC3.ViewModel
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name="Name Of Cheese")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description Of Cheese")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Taste Of Cheese")]
        public string Taste { get; set; }



        //List item selected (need to have options to choose list items)
        public CheeseType Type { get; set; }

        //This List<> represent choices in dropdown list(list items)
        public List<SelectListItem> CheeseTypes { get; set; }

        //We popuplate this list above with a Constructor
        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();//empty list

            //option value = "0">Hard</option>
            //Value should corspond to the enum integer
            //Text should corspond to the enum text that is there
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = (CheeseType.Hard).ToString()
            });

            CheeseTypes.Add(new SelectListItem
            
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = (CheeseType.Soft).ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = (CheeseType.Fake).ToString()
            });

        }



    }
}
