using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Data.Entity;
using AsyncCRUD.Models;

namespace AsyncCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private MyDB db = new MyDB();

#region Index
        public async Task<ActionResult> Index()
        {
            return View(await db.Departments.ToListAsync());
        }


#endregion
#region Create

        public ActionResult Create()
        {
            return View(new Department());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dept);
        }
#endregion
#region Details
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = await db.Departments.FindAsync(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }
#endregion
#region Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = await db.Departments.FindAsync(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dept).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dept);
        }
#endregion
#region Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = await db.Departments.FindAsync(id);
            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Department dept = await db.Departments.FindAsync(id);
            db.Departments.Remove(dept);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
#endregion
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}