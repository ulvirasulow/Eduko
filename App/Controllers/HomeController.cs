using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Faq()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult PrivacyPolicy()
    {
        return View();
    }
    public IActionResult Terms()
    {
        return View();
    }
    public IActionResult Testimonial()
    {
        return View();
    }
}