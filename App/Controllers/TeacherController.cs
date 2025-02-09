using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class TeacherController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TeacherSingle()
    {
        return View();
    }
    public IActionResult BecomeTeacher()
    {
        return View();
    }
}