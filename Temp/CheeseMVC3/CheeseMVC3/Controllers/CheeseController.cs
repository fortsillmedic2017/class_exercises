using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC3.Models;         //Pulled in the Cheese class Model
using CheeseMVC3.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC3.Controllers
{
    public class CheeseController : Controller
    {
        //Display the list of cheeses on index page by using ViewBag and Views
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "My Cheese";
            //ViewBag.cheeses = CheeseData.GetAll();  //Get from CheeseData Class*******
            //ViewBag["cheese"] = CheeseData.GetAll();//Same as above to get Data
            //Can pass data into the View() directly
            List<Cheese> cheeses = CheeseData.GetAll();//better way to get list of all cheeses
            return View(cheeses);  //Pass in object to View
        }

        //(FORM) to input Cheeses (Just Display form)
        [HttpGet]
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid) //Check to see if properties in ViewModel is valid[Required]
            {
                //Get new cheese from ????
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Taste = addCheeseViewModel.Taste,
                    Type = addCheeseViewModel.Type   //******
                };
                CheeseData.Add(newCheese);

                //will see data on /Cheese page
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            //Display form
            //needs to pass in the whole List of form(via ViewBag same one as before)
            ViewBag.cheeses = CheeseData.GetAll();//*****
            ViewBag.title = "Remove Cheese";
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        { //cheeseIds entered from form with name = cheeseIds and put in a list
            // Remove cheeses from list//
            //Loop over each cheesIds entered from form

            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);//*******
            }

            return Redirect("/");
        }
    }
}