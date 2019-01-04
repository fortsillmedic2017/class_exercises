using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC3.Models;         //Pulled in the Cheese class Model
using CheeseMVC3.ViewModels;
using CheeseMVC3.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC3.Controllers
{
    public class CheeseController : Controller
    {
        /*1) needed to creates a object for CheeseDbContext class to reference it*/
        private CheeseDbContext context;

        /*2) Need to create a controller and set parmeters to what you
             want object(context) to Equal to (dbContext)*/
        public CheeseController(CheeseDbContext dbContextt)
        {
            context = dbContextt;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "My Cheese";
        /* 3) Want to Use the context (it exstens CheeseDbContext class)
              so can use its feilds and properties as base list
              note need to add .ToList() at end to convert DbSet to List Type */
            List<Cheese> cheeses = context.Cheeses.ToList();
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
                /* 4) Switch the Cheese.Data.Add to context.Cheese.Add()
                 *    this will post cheeses usinfg cheeseDbContext actions instead
                 *    of CheeseData.cs note: must save each change with[ context.SaveChanges();]*/
                context.Cheeses.Add(newCheese);
                context.SaveChanges();
                // CheeseData.Add(newCheese);  ****old way****

                //will see data on /Cheese page
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            //Display form
            //needs to pass in the whole List of form(via ViewBag same one as before)
            ViewBag.title = "Remove Cheese";

            /*5) Display list of cheeses you want to remove**************/
            List<Cheese> cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        { //cheeseIds entered from form with name = IDs and put in a list
          // Remove cheeses from list//
          //Loop over each cheesIds entered from form
          /*6) Need to go to Remove View and change the (id="",value="" and name=="")
           * from cheese.CheeseId to ID(new feild added to Cheese.cs)*/

            foreach (int cheeseId in cheeseIds )
            {
                /*7) Now Have a List of int cheeseIds want to search through them and 
                 * select which one you want to remove
                 * Do this by using the LINQ query, so first have to create an instant of list*/

                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);      
            //CheeseData.Remove(cheeseId);//*******
            }
            context.SaveChanges();
            return Redirect("/");
        }
    }
}





/*===============================================================
 * OLD Controller When using CheesesData.cs
 * ==============================================================
 * [HttpPost]
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
        */