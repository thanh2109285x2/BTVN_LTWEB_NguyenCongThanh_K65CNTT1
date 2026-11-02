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
    private int pageSize = 3;

    public IActionResult Index(int? mid)
    {
        var learners = (IQueryable<Student>)_context.Students
            .Include(m => m.Major);
        if (mid != null)
        {
            learners = (IQueryable<Student>)_context.Students
                .Where(l => l.MajorID == mid)
                .Include(m => m.Major);
        }

        int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
        ViewBag.pageNum = pageNum;

        var result = learners.Take(pageSize).ToList();
        return View(result);
    }

    public IActionResult LearnerFilter(int? mid, string? keyword, int pageIndex = 1)
    {
        int pageSize = 3;
        if (pageIndex < 1) pageIndex = 1;

        var query = _context.Students
            .Include(s => s.Major)
            .AsQueryable();

        if (mid != null)
            query = query.Where(s => s.MajorID == mid);
        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(s => s.Name!.Contains(keyword));

        int count = query.Count();
        ViewBag.pageNum = (int)Math.Ceiling(count / (double)pageSize);
        ViewBag.mid = mid;
        ViewBag.keyword = keyword;

        var result = query.OrderBy(s => s.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return PartialView("LearnerTable", result);
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

    public IActionResult LearnerByMajorID(int mid)
    {
        var learners = _context.Students
            .Where(l => l.MajorID == mid)
            .Include(m => m.Major).ToList();
        return PartialView("LearnerTable", learners);
    }


}
