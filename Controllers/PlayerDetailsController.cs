﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD3202_Lab5Communication_RyanClayson.Data;
using NETD3202_Lab5Communication_RyanClayson.Models;

namespace NETD3202_Lab5Communication_RyanClayson.Controllers
{
    public class PlayerDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerDetails.ToListAsync());
        }

        // GET: PlayerDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerDetails = await _context.PlayerDetails
                .FirstOrDefaultAsync(m => m.playerID == id);
            if (playerDetails == null)
            {
                return NotFound();
            }

            return View(playerDetails);
        }

        // GET: PlayerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("playerID,playerAge,playerHeight,playerWeight")] PlayerDetails playerDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerDetails);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return RedirectToAction(nameof(IdUnknown));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playerDetails);
        }

        // GET: PlayerDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerDetails = await _context.PlayerDetails.FindAsync(id);
            if (playerDetails == null)
            {
                return NotFound();
            }
            return View(playerDetails);
        }

        // POST: PlayerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("playerID,playerAge,playerHeight,playerWeight")] PlayerDetails playerDetails)
        {
            if (id != playerDetails.playerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(playerDetails);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerDetailsExists(playerDetails.playerID))
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
            return View(playerDetails);
        }

        // GET: PlayerDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerDetails = await _context.PlayerDetails
                .FirstOrDefaultAsync(m => m.playerID == id);
            if (playerDetails == null)
            {
                return NotFound();
            }

            return View(playerDetails);
        }

        // POST: PlayerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerDetails = await _context.PlayerDetails.FindAsync(id);
            _context.PlayerDetails.Remove(playerDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IdUnknown()
        {
            return View();
        }

        private bool PlayerDetailsExists(int id)
        {
            return _context.PlayerDetails.Any(e => e.playerID == id);
        }
    }
}
