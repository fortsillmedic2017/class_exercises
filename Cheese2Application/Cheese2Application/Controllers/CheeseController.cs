using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cheese2Application.Controllers
{
    public class CheeseController : Controller
    {
        //static means that it is available to any code in entire class
        //so don't need to make a list just for Index() action (blocked out below)
        // just use the ViewBag to access the list
        //Cheese is uppercase bc it is and instant of a class(if was local variable ie..
        //Index() then would use lowercase)

        //static private List<string> Cheeses = new List<string>();
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            /* List<string> cheeses = new List<string>();

             cheeses.Add("Cheddar");
             cheeses.Add("Swiss");
             cheeses.Add("Munster");
             cheeses.Add("Gouda");*/

            ViewBag.cheeses = Cheeses;
            return View();
        }

        //How can have a  cont. input of cheeses?
        //Need a new action method to display a form
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Need a action method to handle form submission

        [HttpPost]
        [Route("/Cheese/Add")] //This will not change the action of this, just lets you post
                               //result to that url when submitted
        public IActionResult NewCheese(string name, string description)
        {
            //Add new cheese to my existing cheeses
            // can not use cheese to list in the Index() action method b/c if works
            // for only that method so have to go above that method and
            // create a List variable for the controller(don't need the local List in Index())

            // now we can just use Cheese.Add() to add to the controller list
            Cheeses.Add(name, description);

            //Use redirect instead of views bc once cheese add to list want to refresh page
            //to show new add cheese
            return Redirect("/Cheese");
        }
    }
}