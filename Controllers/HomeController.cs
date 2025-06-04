using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {

        private readonly connection db;

        public HomeController(connection db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> create(student std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.students.AddAsync(std);
                    await db.SaveChangesAsync();
                    return RedirectToAction("show");
                }catch (Exception ex)
                {
                    return RedirectToAction("show");
                }
            }
            return View(std);
        }

        public async Task<IActionResult> show()
        {
            var data = await db.students.ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> edit(int id)
        {
            var data = await db.students.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> edit(int id,student std)
        {
            var data = await db.students.FindAsync(id);
            if (data == null) return NotFound();
            if (ModelState.IsValid)
            {
                data.name = std.name;
                data.email = std.email;
                data.password = std.password;
                data.department = std.department;
                data.date = std.date;


                await db.SaveChangesAsync();
                return RedirectToAction("show");
            }
            return View(data);
        }
        public async Task<IActionResult> delete(int id)
        {
            var data = await db.students.FindAsync(id);
            if(data == null) return NotFound();
            db.students.Remove(data);
           await db.SaveChangesAsync();
            return RedirectToAction("show");

        }
    }
}
