using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HagitageWoodsMVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HagitageWoodsMVC.Controllers
{
    public class FurnituresController : Controller
    {
        private readonly HeritageWoodsContext _context;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public FurnituresController(HeritageWoodsContext context)
        {
            _context = context;
            //_webHostEnvironment = webHostEnvironment;
        }

        // GET: Furnitures
        public async Task<IActionResult> Index()
        {
            var heritageWoodsContext = _context.Products.Include(p => p.C);
            return View(await heritageWoodsContext.ToListAsync());
        }

        // GET: Furnitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.C)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Furnitures/Create
        public IActionResult Create()
        {
            ViewData["Catname"] = new SelectList(_context.ProductCategory, "Catname", "Catname");
            return View();
        }

        // POST: Furnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Cid,Name,Description,Price,Stock,ProductImage")] Products products)
        {
            if (ModelState.IsValid)
            {
                //string rootPath = _webHostEnvironment.WebRootPath;
                //string fileName = Path.GetFileName(products.ProductPic.FileName);
                //string pPath = Path.Combine(rootPath + "/Images/" + fileName);
                //products.ProductImage = fileName;
                //var filStream = new FileStream(pPath, FileMode.Create);
                //await products.ProductPic.CopyToAsync(filStream);

                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Catname"] = new SelectList(_context.ProductCategory, "Catname", "Catname", products.Cid);
            return View(products);
        }

        // GET: Furnitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.ProductCategory, "Cid", "Cid", products.Cid);
            return View(products);
        }

        // POST: Furnitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,Cid,Name,Description,Price,Stock,ProductImage")] Products products)
        {
            if (id != products.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Pid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.ProductCategory, "Cid", "Cid", products.Cid);
            return View(products);
        }

        // GET: Furnitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.C)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Pid == id);
        }
    }
}
