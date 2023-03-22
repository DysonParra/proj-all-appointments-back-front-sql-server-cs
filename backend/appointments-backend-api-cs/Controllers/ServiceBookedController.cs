/*
 * @fileoverview    {ServiceBookedController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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
    public class ServiceBookedController : Controller
    {
        private readonly AppointmentsContext _context;

        public ServiceBookedController(AppointmentsContext context)
        {
            _context = context;
        }

        // GET: ServiceBooked
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceBooked.ToListAsync());
        }

        // GET: ServiceBooked/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ServiceBooked == null)
            {
                return NotFound();
            }

            var serviceBooked = await _context.ServiceBooked
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (serviceBooked == null)
            {
                return NotFound();
            }

            return View(serviceBooked);
        }

        // GET: ServiceBooked/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceBooked/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,DecPrice,IntAppointmentI,IntServiceId")] ServiceBooked serviceBooked)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceBooked);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceBooked);
        }

        // GET: ServiceBooked/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ServiceBooked == null)
            {
                return NotFound();
            }

            var serviceBooked = await _context.ServiceBooked.FindAsync(id);
            if (serviceBooked == null)
            {
                return NotFound();
            }
            return View(serviceBooked);
        }

        // POST: ServiceBooked/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,DecPrice,IntAppointmentI,IntServiceId")] ServiceBooked serviceBooked)
        {
            if (id != serviceBooked.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBooked);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookedExists(serviceBooked.IntId))
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
            return View(serviceBooked);
        }

        // GET: ServiceBooked/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ServiceBooked == null)
            {
                return NotFound();
            }

            var serviceBooked = await _context.ServiceBooked
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (serviceBooked == null)
            {
                return NotFound();
            }

            return View(serviceBooked);
        }

        // POST: ServiceBooked/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.ServiceBooked == null)
            {
                return Problem("Entity set 'AppointmentsContext.ServiceBooked'  is null.");
            }
            var serviceBooked = await _context.ServiceBooked.FindAsync(id);
            if (serviceBooked != null)
            {
                _context.ServiceBooked.Remove(serviceBooked);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookedExists(long? id)
        {
            return _context.ServiceBooked.Any(e => e.IntId == id);
        }
    }
}
