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
    public class CVRecognitionsController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: CVRecognitions
        public ActionResult Index()
        {
            return View(db.CVRecognitions.ToList());
        }

        // GET: CVRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVRecognition cVRecognition = db.CVRecognitions.Find(id);
            if (cVRecognition == null)
            {
                return HttpNotFound();
            }
            return View(cVRecognition);
        }

        // GET: CVRecognitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVRecognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVRecognitionID,CV1,CV2,CV3,CV4,CV5,CV6,CV7")] CVRecognition cVRecognition)
        {
            if (ModelState.IsValid)
            {
                db.CVRecognitions.Add(cVRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cVRecognition);
        }

        // GET: CVRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVRecognition cVRecognition = db.CVRecognitions.Find(id);
            if (cVRecognition == null)
            {
                return HttpNotFound();
            }
            return View(cVRecognition);
        }

        // POST: CVRecognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVRecognitionID,CV1,CV2,CV3,CV4,CV5,CV6,CV7")] CVRecognition cVRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cVRecognition);
        }

        // GET: CVRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVRecognition cVRecognition = db.CVRecognitions.Find(id);
            if (cVRecognition == null)
            {
                return HttpNotFound();
            }
            return View(cVRecognition);
        }

        // POST: CVRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVRecognition cVRecognition = db.CVRecognitions.Find(id);
            db.CVRecognitions.Remove(cVRecognition);
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
