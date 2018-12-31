using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller             // the controler is the 1st part after the port number /Hello (Controler).
    {
        // GET: /<controller>/
        public IActionResult Index(string name = "World")
        { // This is a form 
            string html = "<form method ='post action = '/Hello/Display'>" +                                      
                        "<input type = 'text' name = 'name'  />" +
                        "<input type ='submit' name = 'Greet Me!'/>" +
                        "</form>";
                                                                   
            return Content(string.Format(html,"text/html"));                       // has 2 perameters - 1st is what you want viewed with it tags
        }                                                                         // 2nd is what type of view (text/html)                                                                                               - (string.Format("text {0}", name), "text/html")
        public IActionResult Display(string name = "World!")
        {
            return Content(string.Format("<h1> Hello {0}</h1>", name), "text/html");

        }                                                                       // by /Hello?name=Davis  ==> will print Hello Davis
                                                                                  //  if no name typed in Url  /Hello  ==> will get Hello World
        //Hello/GoodBye 
        //alter to /Hello/Aloha
        [Route("Hello/Aloha")]
        public IActionResult GoodBye()                         // Hello /GoodBye follows the controler it is known as the action method
        {
            
            return Content("GoodBye all");
        }
    }
}
