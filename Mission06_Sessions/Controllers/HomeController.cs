using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Sessions.Models;

namespace Mission06_Sessions.Controllers;

public class HomeController : Controller
{
   private MovieFormContext _context;

   public HomeController(MovieFormContext temp)
   {
       _context = temp;
   }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }
    
    
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MovieForm(Form response)
    {
        _context.Forms.Add(response);
        _context.SaveChanges();
        
        // take back to home page
        return View("Index", response);
    }

    
}