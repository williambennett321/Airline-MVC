using Airline_MVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Airline_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Airline_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AirlineTicket = await _context.AirlineTicket.ToListAsync();
            return View(AirlineTicket);
        }

        public async Task<IActionResult> AddorEdit(int? TicketNum)
        {
            ViewBag.PageName = TicketNum == null ? "Create Ticket" : "Edit Ticket";
            ViewBag.isEdit = TicketNum == null ? false : true;
            if (TicketNum == null)
            {
                return View();
            }
            else
            {
                var AirlineTicket = await _context.AirlineTicket.FindAsync(TicketNum);

                if (AirlineTicket == null)
                {
                    return NotFound();
                }
                return View(AirlineTicket);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int TicketNum, [Bind("TicketNum,Class,FullName,InitialAirport,LandingAirport")]
        AirlineTicket ticketData)
        {
            bool IsTicketExist = false;

            AirlineTicket ticket = await _context.AirlineTicket.FindAsync(TicketNum);

            if (ticket != null)
            {
                IsTicketExist = true;
            }
            else
            {
                ticket = new AirlineTicket();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.TicketNum = ticketData.TicketNum;
                    ticket.Class = ticketData.Class;
                    ticket.FullName = ticketData.FullName;
                    ticket.InitialAirport = ticketData.InitialAirport;
                    ticket.LandingAirport = ticketData.LandingAirport;

                    if (IsTicketExist)
                    {
                        _context.Update(ticket);
                    }
                    else
                    {
                        _context.Add(ticket);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticketData);
        }

        public async Task<IActionResult> Details(int? TicketNum)
        {
            if (TicketNum == null)
            {
                return NotFound();
            }
            var AirlineTicket = await _context.AirlineTicket.FirstOrDefaultAsync(ticket => ticket.TicketNum == TicketNum);
            if (AirlineTicket == null)
            {
                return NotFound();
            }
            return View(AirlineTicket);
        }

        public async Task<IActionResult> Delete(int? TicketNum)
        {
            if (TicketNum == null)
            {
                return NotFound();
            }
            var travelTicket = await _context.AirlineTicket.FirstOrDefaultAsync(ticket => ticket.TicketNum == TicketNum);

            return View(travelTicket);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int TicketNum)
        {
            var AirlineTicket = await _context.AirlineTicket.FindAsync(TicketNum);
            _context.AirlineTicket.Remove(AirlineTicket);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
