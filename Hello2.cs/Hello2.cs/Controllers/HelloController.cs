using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hello2.cs.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(string name = "World")
        {
            string html = "<form method = 'post'>" +
                           "<input type = 'text' name = 'name'>" +
                           "<input type = 'submit' value = 'Greet Me'>" +
                           "</form>";

            return Content(html, "text/html");

            //Redirect /Hello (when typed in URL) to /Hello/GoodBye
            //return Redirect("/Hello/GoodBye");
        }

        [HttpPost]
        [Route("/Hello")]
        public IActionResult Display(string name = "World")
        {
            return Content($"<h1>Hello {name}</h1>", "text/html");
        }

        #region URL Segment to handle Request

        //Handle request to /Hello/Davis(URL segment)
        //route match to name variable when typed in URL
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content($"<h1>Hello {name}</h1>", "text/html");
        }

        #endregion URL Segment to handle Request

        public IActionResult GoodBye()
        {
            return Content("<h1>GoodBye</h1>", "text/html");
        }
    }
}