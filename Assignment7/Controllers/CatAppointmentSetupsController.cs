using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment7.Data;
using Assignment7.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment7.Controllers
{
    public class CatAppointmentSetupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatAppointmentSetupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CatAppointmentSetups.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catAppointmentSetup = await _context.CatAppointmentSetups
                .SingleOrDefaultAsync(m => m.MeetingID == id);
            if (catAppointmentSetup == null)
            {
                return NotFound();
            }

            return View(catAppointmentSetup);
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingID,FirstName,LastName,PetName,MeetingDay,MeetingTime")] CatAppointmentSetup catAppointmentSetup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catAppointmentSetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catAppointmentSetup);
        }
        //[Authorize(Roles = "Admin")]
        // GET: UserStories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catAppointmentSetup = await _context.CatAppointmentSetups.SingleOrDefaultAsync(m => m.MeetingID == id);
            if (catAppointmentSetup == null)
            {
                return NotFound();
            }
            return View(catAppointmentSetup);
        }

        // POST: UserStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingID,FirstName,LastName,PetName,MeetingDay,MeetingTime")] CatAppointmentSetup catAppointmentSetup)
        {
            if (id != catAppointmentSetup.MeetingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catAppointmentSetup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatAppointmentSetupExists(catAppointmentSetup.MeetingID))
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
            return View(catAppointmentSetup);
        }
        //[Authorize(Roles = "Admin")]
        // GET: UserStories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catAppointmentSetup = await _context.CatAppointmentSetups
                .SingleOrDefaultAsync(m => m.MeetingID == id);
            if (catAppointmentSetup == null)
            {
                return NotFound();
            }

            return View(catAppointmentSetup);
        }

        // POST: UserStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userStory = await _context.CatAppointmentSetups.SingleOrDefaultAsync(m => m.MeetingID == id);
            _context.CatAppointmentSetups.Remove(userStory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatAppointmentSetupExists(int id)
        {
            return _context.CatAppointmentSetups.Any(e => e.MeetingID == id);
        }
    }
}
