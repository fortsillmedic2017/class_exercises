using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC3.Models;         //Pulled in the Cheese class

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC3.Controllers
{
    public class CheeseController : Controller
    {
        //Display the list of cheeses on index page by using ViewBag and Views
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();  //Get from CheeseData Class*******
            ViewBag.title = "My Cheese";
            return View();
        }

        //(FORM) to input Cheeses (Just Display form)
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.title = "Add Cheese";
            return View();
        }

        //This will take data entered from form and Add it to Dictionary

        [HttpPost]
        [Route("/Cheese/Add")]
        //get info from Cheese Model file Cheese class

        /*//METHOD BINDING:
          don't have to write: NewCheese(string name, string description)
          {
             Name = name;
             Description =description;

            Cheese.Add(newCheese);
          }

          Just creating a Instance of Cheese and placing it as a parameter of
          IActionResult(Cheese newCheese) it will look for data entered
           from form and compare it to the fields in the Cheese class
        */
        public IActionResult NewCheese(Cheese newCheese)
        {
            //Get new cheese from CheeseData class Add method*******
            CheeseData.Add(newCheese);

            //will see data on /Cheese page
            return Redirect("/Cheese");
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