/*
 * @fileoverview    {ServiceProvidedController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appointments.Data;
using Project.Models;

namespace Appointments.Controllers
{
    public class ServiceProvidedController : Controller
    {
        private readonly AppointmentsContext _context;

        public ServiceProvidedController(AppointmentsContext context)
        {
            _context = context;
        }

        // GET: ServiceProvided
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceProvided.ToListAsync());
        }

        // GET: ServiceProvided/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ServiceProvided == null)
            {
                return NotFound();
            }

            var serviceProvided = await _context.ServiceProvided
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (serviceProvided == null)
            {
                return NotFound();
            }

            return View(serviceProvided);
        }

        // GET: ServiceProvided/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceProvided/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,DecPrice,IntAppointmentI,IntServiceId")] ServiceProvided serviceProvided)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceProvided);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceProvided);
        }

        // GET: ServiceProvided/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ServiceProvided == null)
            {
                return NotFound();
            }

            var serviceProvided = await _context.ServiceProvided.FindAsync(id);
            if (serviceProvided == null)
            {
                return NotFound();
            }
            return View(serviceProvided);
        }

        // POST: ServiceProvided/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,DecPrice,IntAppointmentI,IntServiceId")] ServiceProvided serviceProvided)
        {
            if (id != serviceProvided.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceProvided);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceProvidedExists(serviceProvided.IntId))
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
            return View(serviceProvided);
        }

        // GET: ServiceProvided/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ServiceProvided == null)
            {
                return NotFound();
            }

            var serviceProvided = await _context.ServiceProvided
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (serviceProvided == null)
            {
                return NotFound();
            }

            return View(serviceProvided);
        }

        // POST: ServiceProvided/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.ServiceProvided == null)
            {
                return Problem("Entity set 'AppointmentsContext.ServiceProvided'  is null.");
            }
            var serviceProvided = await _context.ServiceProvided.FindAsync(id);
            if (serviceProvided != null)
            {
                _context.ServiceProvided.Remove(serviceProvided);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceProvidedExists(long? id)
        {
            return _context.ServiceProvided.Any(e => e.IntId == id);
        }
    }
}
