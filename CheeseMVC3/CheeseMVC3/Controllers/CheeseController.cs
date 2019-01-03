using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC3.Models;         //Pulled in the Cheese class
using CheeseMVC3.ViewModel;

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
            List<Cheese> cheeses = CheeseData.GetAll();                     
            return View(cheeses);
        }

        //(FORM) to input Cheeses (Just Display form)
        
        public IActionResult Add()
        {
            ViewBag.title = "Add Cheese";
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

       
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add the new cheese to my exsiting list
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Taste = addCheeseViewModel.Taste,
                    Type = addCheeseViewModel.Type
                };
                CheeseData.Add(newCheese);
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