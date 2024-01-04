using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KTStoreSite.Data;
using KTStoreSite.Models;
using KTStoreSite.Areas.Admin.Services.Models;
using KTStoreSite.Areas.Admin.Services.Interfaces;

namespace KTStoreSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment he;

        public CategoryController(ICategoryService categoryService)
        {
            categoryService = categoryService;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            var list = await categoryService.GetAllCategoryAsync();
            return View(list);
        }



        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = await categoryService.AddCategoryAsync(category) ? 
                    "Category Added Succesfull" : "";
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id=0)
        {

            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //        // POST: Admin/Category/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id,  Category category)
        //        {
        //            if (id != category.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(category);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!CategoryExists(category.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(category);
        //        }

        //        // GET: Admin/Category/Delete/5
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null || _context.Category == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(category);
        //        }

        //        // POST: Admin/Category/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            if (_context.Category == null)
        //            {
        //                return Problem("Entity set 'ApplicationDbContext.Category'  is null.");
        //            }
        //            var category = await _context.Category.FindAsync(id);
        //            if (category != null)
        //            {
        //                _context.Category.Remove(category);
        //            }

        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool CategoryExists(int id)
        //        {
        //          return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        //        }
    }
}
