using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}