using Microsoft.AspNetCore.Mvc;
using JMSmedical.Models;
using JMSmedical.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore; // ??? ??????

namespace JMSWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/About
        public IActionResult About()
        {
            // ?? ??? ?? ??? ??? ??? ???? ???? ??, ?? ?? ???? ??????
            return View();
        }

        // GET: /Home/Services
        public async Task<IActionResult> Services()
        {
            // ??????? ?? Services ???? ????
            var services = await _context.Services.ToListAsync();
            // Services ????? ?? ???? ??? ??? ????
            return View(services);
        }

        // GET: /Home/Contact
        public IActionResult Contact()
        {
            // ?? ???? ContactMessage ???? ?? ??? ???? ?????? (??? ?????? ??)
            return View(new ContactMessage());
        }

        // POST: /Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("Name,Email,Subject,Message")] ContactMessage contactMessage) // Bind attribute ??????? ?????? ??
        {
            // ???? ????? ?? ???? ???? (???? ??? ?????? ?????? ??? ?? ??? ?? ????? ????)
            if (ModelState.IsValid)
            {
                try
                {
                    contactMessage.SubmittedDate = DateTime.UtcNow;
                    _context.Add(contactMessage); // Add ?? ?????
                    await _context.SaveChangesAsync(); // ??????? ??? ??? ????

                    // ????? ?? ????? ?????? ?? ??? ??? ?? ?????????? ???? (????? ?????? ???? ?? ???)
                    TempData["SuccessMessage"] = "Your message has been sent successfully! We will get back to you soon.";
                    return RedirectToAction(nameof(Contact));
                }
                catch (DbUpdateException /* ex */)
                {
                    // ??? ??? ???? (?????? ?? ???, logger ?? ????? ????)
                    _logger.LogError("Could not save contact message to database.");
                    // ???? ?? ?? ??????? ??? ????? ??????
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, see your system administrator.");
                }
            }

            // ??? ModelState ????? ???? ??, ?? ????? ?? ??? ?? ???? ?????? ??? ?? ???? ?? ??? ???? ??????
            return View(contactMessage);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // --- Seed Data (Optional - For Testing) ---
        // ?? ????? ?? Services ???? ??? ??? ??????? ???? ????? ?? ???
        // ?? ??? ?????? ???? ??? ???? ??? ?? ???????? ??? ?? SQL Server ??? ??? ???? ????
        // ?? ???? ??? ???? ?? ??? ???? ??? ???? ??? (Program.cs ???)
    }
}