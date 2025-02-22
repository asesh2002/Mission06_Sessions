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
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View(new Movie()); // Ensures a new movie object is passed
    }
    
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //add record to the database 
            _context.SaveChanges(); //commit changes to database 
                    
            return View("Index", response);
        }
        else //invalid data
        {
            ViewBag.Majors = _context.Categories
                .OrderBy(x=> x.CategoryName)
                .ToList();
            return View(response);
        }
    }
    
    public IActionResult MovieList()
    {
        //linq
        var movies = _context.Movies
            .OrderBy(x => x.Title).ToList();
        
        return View(movies);
    }
    
    //to FIX: get and post for delete and cancel 
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .SingleOrDefault(x=>x.MovieId == id);
        
        if (recordToEdit == null)
        {
            return NotFound(); // Handles the case where the movie doesn't exist
        }
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x=> x.CategoryName)
            .ToList();
        
        return View("MovieForm", recordToEdit); //send them back to the dating application form 
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x=>x.MovieId == id);
       
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
         
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
}