﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace EmployeeStorageApi.Controllers
{
    [Route("skill")]
    public class SkillsController : Controller
    {
        private readonly EmploeeContext _context;

        public SkillsController(EmploeeContext context)
        {
            _context = context;
        }

        // GET: Skills
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var json = await _context.Skills.ToListAsync();
            var ob = Results.Json(new Skill() { Name = "ASP" });
            return View(json);
            //return Newtonsoft.Json.JsonConvert.SerializeObject(json);
            //return View(await _context.Skills.ToListAsync());
        }

        //// GET: Skills/Details/5
        //[HttpGet]
        //public async Task<IActionResult> Details([FromQuery] Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var skill = await _context.Skills
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (skill == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(skill);
        //}

        //// GET: Skills/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Skills/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Skill skill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        skill.Id = Guid.NewGuid();
        //        _context.Add(skill);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(skill);
        //}

        //// GET: Skills/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var skill = await _context.Skills.FindAsync(id);
        //    if (skill == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(skill);
        //}

        //// POST: Skills/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Skill skill)
        //{
        //    if (id != skill.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(skill);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SkillExists(skill.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(skill);
        //}

        //// GET: Skills/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var skill = await _context.Skills
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (skill == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(skill);
        //}

        //// POST: Skills/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var skill = await _context.Skills.FindAsync(id);
        //    _context.Skills.Remove(skill);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SkillExists(Guid id)
        //{
        //    return _context.Skills.Any(e => e.Id == id);
        //}
    }
}
