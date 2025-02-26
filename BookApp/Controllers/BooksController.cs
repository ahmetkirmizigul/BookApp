using BookApp.DataAccess;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApp.Controllers;

public class BooksController : Controller 
{
    private readonly AppDbContext _context;
    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.GetAllBooks();
        ViewBag.Categories = _context.Categories
                                    .Select(c => new { c.CategoryID, c.CategoryName })
                                    .ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        // kategorileri Viewbag içine atarak Dropdownlist için tutuyorum
        ViewBag.Categories = _context.Categories
                                    .Select(c => new SelectListItem
                                    {
                                        Value = c.CategoryID.ToString(),
                                        Text = c.CategoryName
                                    })
                                    .ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      
        return View(book);
    }

    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);
        ViewBag.Categories = _context.Categories
                              .Select(c => new SelectListItem
                              {
                                  Value = c.CategoryID.ToString(),
                                  Text = c.CategoryName
                              })
                              .ToList();
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        try
        {
            _context.DeleteBook(id); 
            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = "Silme işlemi sırasında bir hata oluştu: " + ex.Message });
        }
    }
}