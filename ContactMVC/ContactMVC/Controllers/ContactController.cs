using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        //Display List of Contacts
     
        public IActionResult Index()
        {
            ViewBag.contacts = ContactData.GetAll();//****
            ViewBag.title = "List Of Contacts";
            return View();
        }
        //Just to Display form to add Data
        [HttpGet]
        public IActionResult AddContact()
        {        
            ViewBag.title = "Add Contacts";
            return View();
        }
        [HttpPost]
        [Route("/Contact/AddContact")]
        public IActionResult AddContact(Contact newContact)
        {
            ContactData.Add(newContact);

            return Redirect("/Contact");
        }
        //Just to Display form to remove Data
        [HttpGet]
        public IActionResult RemoveContact()
        {
            ViewBag.contacts = ContactData.GetAll();//****
            ViewBag.title = "Remove Contacts";
            return View();
        }
        [HttpPost]
        public IActionResult RemoveContact(int [] contactIds)
        {
            foreach(int contactId in contactIds)
            {
                ContactData.Remove(contactId);//*****
            }
            
            return Redirect("/");
        }
    }


}
