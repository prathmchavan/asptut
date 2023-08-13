using asp.Data;
using asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace asp.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db= db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList= _db.Categories;
        return View(objCategoryList);
    }
    


    // this is for get req 
    public IActionResult Create()
    {

        return View();
    }

    //this is for post request
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {   
        _db.Categories.Add(obj);
       
        _db.SaveChanges();

        TempData["success"] = "Created successfully";

        return RedirectToAction("Index");
    }



    // this is for get req 
    public IActionResult Edit(int? id)
    {   
        if(id == null || id== 0)
        {
            return NotFound();
        }
        var CategoryFromDb = _db.Categories.Find(id);    
        
        
        if(CategoryFromDb == null)
        {
            return NotFound();
        }
        
        
        return View(CategoryFromDb);
    }

    //this is for post request
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        _db.Categories.Update(obj);

        _db.SaveChanges();
        TempData["success"] = "Updated successfully";
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CategoryFromDb = _db.Categories.Find(id);


        if (CategoryFromDb == null)
        {
            return NotFound();
        }


        return View(CategoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      
        var obj = _db.Categories.Find(id);


        if (obj  == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Deleted  successfully";
        return RedirectToAction("Index");

    }
}
