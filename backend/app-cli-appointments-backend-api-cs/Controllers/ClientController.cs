/*
 * @fileoverview    {ClientController}
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
     * TODO: Description of {@code ClientController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ClientController : Controller {
        private readonly AppointmentsContext _context;

        /**
         * TODO: Description of method {@code ClientController}.
         *
         */
        public ClientController(AppointmentsContext context) {
            _context = context;
        }

        /**
         * GET: Client
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Client.ToListAsync());
        }

        /**
         * GET: Client/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Client == null) {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (client == null) {
                return NotFound();
            }

            return View(client);
        }

        /**
         * GET: Client/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Client/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,StrClientName,StrContactMobile,StrContactMail")] Client client) {
            if (ModelState.IsValid) {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        /**
         * GET: Client/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Client == null) {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null) {
                return NotFound();
            }
            return View(client);
        }

        /**
         * POST: Client/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,StrClientName,StrContactMobile,StrContactMail")] Client client) {
            if (id != client.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ClientExists(client.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        /**
         * GET: Client/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Client == null) {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (client == null) {
                return NotFound();
            }

            return View(client);
        }

        /**
         * POST: Client/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Client == null) {
                return Problem("Entity set 'AppointmentsContext.Client'  is null.");
            }
            var client = await _context.Client.FindAsync(id);
            if (client != null) {
                _context.Client.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ClientExists}.
         *
         */
        private bool ClientExists(long? id) {
            return _context.Client.Any(e => e.IntId == id);
        }
    }
}
