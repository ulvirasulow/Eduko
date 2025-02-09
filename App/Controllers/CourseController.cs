using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult CourseSingle()
    {
        return View();
    }
}