using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
