using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C.Data;
using Library_Management_System_C.Models;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace Library_Management_System_C.Controllers
{
    public class DetailsController : Controller
    {
        private readonly Library_Management_System_CContext _context;

        public DetailsController(Library_Management_System_CContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
       
                var library_Management_System_CContext = _context.Details.Include(d => d.FK_books_id).Include(d => d.FK_record_id).Include(d => d.FK_record_id.FK_borrower);




            return View(await library_Management_System_CContext.ToListAsync());
    
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            var details = await _context.Details
                .Include(d => d.FK_books_id)
                .Include(d => d.FK_record_id)
                .FirstOrDefaultAsync(m => m.details_id == id);
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["books_id"] = new SelectList(_context.Books, "bookId", "bookName");



            // Fetching data from your database context with condition
            var data = _context.Records.Include(r => r.FK_borrower).Select(x => new {
                CombinedValue = x.record_id + " " + x.FK_borrower.borrower_fname + " " + x.FK_borrower.borrower_lname,
                Id = x.record_id // Assuming you have an Id property or some unique identifier
            }).ToList();

            // Creating a SelectList
            ViewData["RecordsList"] = new SelectList(data, "Id", "CombinedValue");


           /* ViewData["record_id"] = new SelectList(_context.Records, "record_id", "record_id");*/
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("details_id,books_id,record_id,return_date")] Details details)
        {
            //check boooks
            bool checkDetails = _context.Details.Any(b => b.books_id == details.books_id);

            if (checkDetails == true)
            {
                //error not returned yet
                ModelState.AddModelError("", "Book in not available. It is not returned yet.");
                ViewData["books_id"] = new SelectList(_context.Books, "bookId", "bookName");


                // Fetching data from your database context with condition
                var data = _context.Records.Include(r => r.FK_borrower).Select(x => new {
                    CombinedValue = x.record_id + " " + x.FK_borrower.borrower_fname + " " + x.FK_borrower.borrower_lname,
                    Id = x.record_id // Assuming you have an Id property or some unique identifier
                }).ToList();

                // Creating a SelectList
                ViewData["RecordsList"] = new SelectList(data, "Id", "CombinedValue");


            /*    ViewData["record_id"] = new SelectList(_context.Records, "record_id", "record_id");*/
                return View();
            }

            else
            {
                //book is returned
                    if (ModelState.IsValid)
                    {
                        _context.Add(details);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["books_id"] = new SelectList(_context.Books, "bookId", "books_id", details.books_id);
                    ViewData["record_id"] = new SelectList(_context.Records, "record_id", "record_id", details.record_id);
                    return View(details);
                
            }
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {



            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            var details = await _context.Details.FindAsync(id);
            if (details == null)
            {
                return NotFound();
            }



            // Fetching data from your database context with condition
            var data = _context.Records.Include(r=> r.FK_borrower).Where(r=>r.record_id == details.record_id).Select(x => new {
                CombinedValue = x.record_id + " " + x.FK_borrower.borrower_fname + " " + x.FK_borrower.borrower_lname,
                Id = x.record_id // Assuming you have an Id property or some unique identifier
            }).ToList();

            // Creating a SelectList
            ViewData["RecordsList"] = new SelectList(data, "Id", "CombinedValue");


            ViewData["books_id"] = new SelectList(_context.Books.Where(b=> b.bookId == details.books_id ), "bookId", "bookName", details.books_id);
/*
            ViewData["record_id"] = new SelectList(_context.Records.Where(r => r.record_id == details.record_id), "record_id", "record_id", details.record_id);*/
            return View(details);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("details_id,books_id,record_id,return_date")] Details details)
        {
            if(details.return_date == null)
            {
                ModelState.AddModelError("", "Please input returned date");
                ViewData["books_id"] = new SelectList(_context.Books.Where(b => b.bookId == details.books_id), "bookId", "bookName", details.books_id);


                // Fetching data from your database context with condition
                var data = _context.Records.Include(r => r.FK_borrower).Where(r => r.record_id == details.record_id).Select(x => new {
                    CombinedValue = x.record_id + " " + x.FK_borrower.borrower_fname + " " + x.FK_borrower.borrower_lname,
                    Id = x.record_id // Assuming you have an Id property or some unique identifier
                }).ToList();

                // Creating a SelectList
                ViewData["RecordsList"] = new SelectList(data, "Id", "CombinedValue");




                /*  ViewData["record_id"] = new SelectList(_context.Records.Where(r => r.record_id == details.record_id), "record_id", "record_id", details.record_id);*/
                return View();
            }
            else
            {
                if (id != details.details_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(details);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DetailsExists(details.details_id))
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
         
            }
            ViewData["books_id"] = new SelectList(_context.Books, "bookId", "books_id", details.books_id);
            ViewData["record_id"] = new SelectList(_context.Records, "record_id", "record_id", details.record_id);
            return View(details);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
                if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            var details = await _context.Details
                .Include(d => d.FK_books_id)
                .Include(d => d.FK_record_id)
                .FirstOrDefaultAsync(m => m.details_id == id);
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            //check null returned
            var returneDate = _context.Details.Any(b => string.IsNullOrEmpty(b.return_date.ToString()));

            if (returneDate == false)
            {
                if (_context.Details == null)
                {
                    return Problem("Entity set 'Library_Management_System_CContext.Details'  is null.");
                }


                var details = await _context.Details.FindAsync(id);
                if (details != null)
                {
                    _context.Details.Remove(details);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {

                ModelState.AddModelError("", "Book is not returned yet");
                //customize for er
                var error_details = await _context.Details
                 .Include(d => d.FK_books_id)
                 .Include(d => d.FK_record_id)
                 .FirstOrDefaultAsync(m => m.details_id == id);
                return View(error_details);
               
            }

        }
        

        private bool DetailsExists(int id)
        {
          return (_context.Details?.Any(e => e.details_id == id)).GetValueOrDefault();
        }
    }
}
