/*
 * @overview        {HomeController}
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
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Appointments.Models;

namespace Appointments.Controllers {

    /**
     * TODO: Description of {@code HomeController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        /**
         * TODO: Description of method {@code HomeController}.
         *
         */
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        /**
         * TODO: Description of method {@code Index}.
         *
         */
        public IActionResult Index() {
            return View();
        }

        /**
         * TODO: Description of method {@code Privacy}.
         *
         */
        public IActionResult Privacy() {
            return View();
        }

        /**
         * TODO: Description of method {@code Error}.
         *
         */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}