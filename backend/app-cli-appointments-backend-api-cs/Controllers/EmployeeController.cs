﻿/*
 * @fileoverview    {EmployeeController}
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
     * TODO: Description of {@code EmployeeController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class EmployeeController : Controller {
        private readonly AppointmentsContext _context;

        /**
         * TODO: Description of method {@code EmployeeController}.
         *
         */
        public EmployeeController(AppointmentsContext context) {
            _context = context;
        }

        /**
         * GET: Employee
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Employee.ToListAsync());
        }

        /**
         * GET: Employee/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Employee == null) {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (employee == null) {
                return NotFound();
            }

            return View(employee);
        }

        /**
         * GET: Employee/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Employee/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,StrFirstName,StrLastName")] Employee employee) {
            if (ModelState.IsValid) {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        /**
         * GET: Employee/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Employee == null) {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null) {
                return NotFound();
            }
            return View(employee);
        }

        /**
         * POST: Employee/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,StrFirstName,StrLastName")] Employee employee) {
            if (id != employee.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!EmployeeExists(employee.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        /**
         * GET: Employee/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Employee == null) {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (employee == null) {
                return NotFound();
            }

            return View(employee);
        }

        /**
         * POST: Employee/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Employee == null) {
                return Problem("Entity set 'AppointmentsContext.Employee'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null) {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code EmployeeExists}.
         *
         */
        private bool EmployeeExists(long? id) {
            return _context.Employee.Any(e => e.IntId == id);
        }
    }
}
