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
using Microsoft.AspNet.Identity;

namespace MIS4200Team5.Controllers
{
    public class ProfileCreationController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: ProfileCreation
        [Authorize]
        public ActionResult Index(int? page, string searchString)
        {
            int pgSize = 10;
            int pageNumber = (page ?? 1);
            var Profile = from r in db.Profile select r;
            Profile = db.Profile.OrderBy(r => r.ProfileFirst);
            if (!String.IsNullOrEmpty(searchString))
            {
                Profile = Profile.Where(r => r.ProfileFirst.Contains(searchString));
            }
            /* there's a line of code that needs to go here that I can't figure out how to write. it's the one that uses toPagedList. */


            return View(db.Profile.ToList());
        }
       
        

        // GET: ProfileCreation/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
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

        // GET: ProfileCreation/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileCreation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ProfileID,ProfileFirst,ProfileLast,ProfileBday,ProfileEmail,ProfileJobTitle,role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);             
                profile.ProfileID = memberId;
                profile.ProfileEmail = User.Identity.Name;
                return RedirectToAction( "Create", "EmployeeQuestions");
            }

            return View(profile);
        }

        // GET: ProfileCreation/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
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

        // POST: ProfileCreation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ProfileID,ProfileFirst,ProfileLast,ProfileBday,ProfileEmail,ProfileJobTitle,role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: ProfileCreation/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
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

        // POST: ProfileCreation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(Guid id)
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
