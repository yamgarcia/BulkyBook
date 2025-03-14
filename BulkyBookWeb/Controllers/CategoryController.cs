﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
public class CategoryController : Controller
{

    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
        }

        //Can I modify "The value '' is invalid." before it's sent to view?
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDbFind = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);

        if (categoryFromDbFind == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFind);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
        }

        //Can I modify "The value '' is invalid." before it's sent to view?
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    /*
     * GET
     * 
     * Method used to show the object from the database on the screen.
     * By clicking the Delete button line 52 on C:\Users\Marcos\Documents\GitHub\C#\BulkyBook\BulkyBookWeb\Views\Category\Index.cshtml
     * 
     */
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDbFind = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);

        if (categoryFromDbFind == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFind);
    }

    /*
     * POST
     *
     * Method used to DELETE the object from the database.
     * By confirming the Deletion line 23 on C:\Users\Marcos\Documents\GitHub\C#\BulkyBook\BulkyBookWeb\Views\Category\Delete.cshtml
     *
     */
    // POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}

