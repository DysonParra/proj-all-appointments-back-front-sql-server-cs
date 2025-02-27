/*
 * @fileoverview    {ServiceController}
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

namespace Appointments.Controllers {

    /**
     * TODO: Description of {@code ServiceController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ServiceController : Controller {
        private readonly AppointmentsContext _context;

        /**
         * TODO: Description of method {@code ServiceController}.
         *
         */
        public ServiceController(AppointmentsContext context) {
            _context = context;
        }

        /**
         * GET: Service
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Service.ToListAsync());
        }

        /**
         * GET: Service/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Service == null) {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (service == null) {
                return NotFound();
            }

            return View(service);
        }

        /**
         * GET: Service/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Service/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,StrServiceName,IntDuration,DecPrice")] Service service) {
            if (ModelState.IsValid) {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        /**
         * GET: Service/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Service == null) {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null) {
                return NotFound();
            }
            return View(service);
        }

        /**
         * POST: Service/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,StrServiceName,IntDuration,DecPrice")] Service service) {
            if (id != service.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ServiceExists(service.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        /**
         * GET: Service/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Service == null) {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (service == null) {
                return NotFound();
            }

            return View(service);
        }

        /**
         * POST: Service/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Service == null) {
                return Problem("Entity set 'AppointmentsContext.Service'  is null.");
            }
            var service = await _context.Service.FindAsync(id);
            if (service != null) {
                _context.Service.Remove(service);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ServiceExists}.
         *
         */
        private bool ServiceExists(long? id) {
            return _context.Service.Any(e => e.IntId == id);
        }
    }
}
