using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team5.DAL;
using MIS4200Team5.Models;



namespace MIS4200Team5.Controllers
{
    public class ProfilesController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: Profiles
        [Authorize]
        public ActionResult Index(int? page, string searchString)
        {
            int pgSize = 10;
                int pageNumber = (page ?? 1);
            var Profile = from r in db.Profile select r;
            Profile = db.Profile.OrderBy(r => r.ProfileFirst);
            if(!String.IsNullOrEmpty(searchString))
            {
                Profile = Profile.Where(r => r.ProfileFirst.Contains(searchString));
            }
            /* there's a line of code that needs to go here that I can't figure out how to write. it's the one that uses toPagedList. */
            return View(db.Profile.ToList());
        }

        // GET: Profiles/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ProfileID,ProfileFirst,ProfileLast,ProfileBday,ProfileEmail,ProfileJobTitle")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Create", "EmployeeQuestions");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,ProfileFirst,ProfileLast,ProfileBday,ProfileEmail,ProfileJobTitle")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profile.Find(id);
            db.Profile.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
