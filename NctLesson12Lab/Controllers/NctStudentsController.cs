
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NctK65Lesson10Lab1.Models;

public class NctStudentsController : Controller
{
    private readonly SchoolContext _context;

    public NctStudentsController(SchoolContext context)
    {
        _context = context;
    }

    // GET: STUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Students.ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName");
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Email,Password,Branch,Gender,IsRegular,Address,DateOfBirth,Diem,MajorID")] Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", student.MajorID);
        return View(student);
    }

    // GET: Students/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", student.MajorID);
        return View(student);
    }

    // POST: Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,Password,Branch,Gender,IsRegular,Address,DateOfBirth,Diem,MajorID")] Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
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
        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", student.MajorID);
        return View(student);
    }

    // GET: Students/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .Include(s => s.Major)
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        if (student.Enrollments.Count > 0)
        {
            return Content("This student has some enrollments, can't delete!");
        }

        return View(student);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student != null)
        {
            if (student.Enrollments.Count > 0)
            {
                return Content("This student has some enrollments, can't delete!");
            }
            _context.Students.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
