using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookush.DAL;
using Bookush.DAL.DBO;
using Bookush.DAL.Repositories;
using Bookush.Models;

namespace Bookush.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Publisher> _publisherRepo;

        public BooksController(IRepository<Book> bookRepo, IRepository<Publisher> publisherRepo)
        {
            _bookRepo = bookRepo;
            _publisherRepo = publisherRepo;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepo.GetAllAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task <IActionResult> Create()
        {
            var bookViewModel = new BookViewModel();
            bookViewModel.Publishers = new SelectList(await _publisherRepo.GetAllAsync(), "Id", "Name");
            return View(bookViewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Authors,Edition,DateOfPublished,Genres,Barcode,PublisherId")] BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepo.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            book.Publishers = new SelectList(await _publisherRepo.GetAllAsync(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
                        
            var bookViewModel = new BookViewModel ();
            bookViewModel.Id = book.Id;
            bookViewModel.Publishers = new SelectList(await _publisherRepo.GetAllAsync(), "Id", "Name", book.PublisherId);
            return View(bookViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Authors,Edition,DateOfPublished,Genres,Barcode,PublisherId")] BookViewModel book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { 
                    await _bookRepo.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_bookRepo.Exists(book.Id))
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
            book.Publishers = new SelectList(await _publisherRepo.GetAllAsync(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
