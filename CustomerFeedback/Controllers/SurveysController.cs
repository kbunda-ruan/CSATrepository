#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerFeedback.Data;
using CustomerFeedback.Models;
using CustomerFeedback.Models.ViewModels;

namespace CustomerFeedback.Controllers
{
  public class SurveysController : Controller
  {
    private readonly CSATContext _context;

    public SurveysController(CSATContext context)
    {
      _context = context;
    }

    // GET: Surveys
    //public async Task<IActionResult> Index()
    //{
    //    return View(await _context.Survey.ToListAsync());
    //}

    // GET: Surveys
    public async Task<IActionResult> Index(string surveyAudience, string searchString)
    {
      // Use LINQ to get list of audiences.
      IQueryable<string> audienceQuery = from m in _context.Survey
                                         orderby m.Audience
                                         select m.Audience;
      var surveys = from m in _context.Survey
                    select m;

      if (!string.IsNullOrEmpty(searchString))
      {
        surveys = surveys.Where(s => s.Title!.Contains(searchString));
      }

      if (!string.IsNullOrEmpty(surveyAudience))
      {
        surveys = surveys.Where(x => x.Audience == surveyAudience);
      }

      var surveyAudienceVM = new SurveyAudienceVM
      {
        Audiences = new SelectList(await audienceQuery.Distinct().ToListAsync()),
        Surveys = await surveys.ToListAsync()
      };

      return View(surveyAudienceVM);
    }

    // GET: Surveys/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var survey = await _context.Survey
          .FirstOrDefaultAsync(m => m.Id == id);
      if (survey == null)
      {
        return NotFound();
      }

      return View(survey);
    }

    // GET: Surveys/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Surveys/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,ExpireDate,AdministratorId,Audience")] Survey survey)
    {
      if (ModelState.IsValid)
      {
        _context.Add(survey);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(survey);
    }

    // GET: Surveys/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var survey = await _context.Survey.FindAsync(id);
      if (survey == null)
      {
        return NotFound();
      }
      return View(survey);
    }

    // POST: Surveys/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate,ExpireDate,AdministratorId,Audience")] Survey survey)
    {
      if (id != survey.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(survey);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!SurveyExists(survey.Id))
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
      return View(survey);
    }

    // GET: Surveys/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var survey = await _context.Survey
          .FirstOrDefaultAsync(m => m.Id == id);
      if (survey == null)
      {
        return NotFound();
      }

      return View(survey);
    }

    // POST: Surveys/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var survey = await _context.Survey.FindAsync(id);
      _context.Survey.Remove(survey);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool SurveyExists(int id)
    {
      return _context.Survey.Any(e => e.Id == id);
    }
  }
}