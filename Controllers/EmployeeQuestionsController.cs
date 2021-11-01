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
    public class EmployeeQuestionsController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: EmployeeQuestions
        public ActionResult Index()
        {
            return View(db.EmployeeQuestions.ToList());
        }

        // GET: EmployeeQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQuestions employeeQuestions = db.EmployeeQuestions.Find(id);
            if (employeeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(employeeQuestions);
        }

        // GET: EmployeeQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeQuestionsID,Q1,Q2,Q3,Q4,Q5")] EmployeeQuestions employeeQuestions)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                employeeQuestions.EmployeeQuestionsID = memberId;
                db.EmployeeQuestions.Add(employeeQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeQuestions);
        }

        // GET: EmployeeQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQuestions employeeQuestions = db.EmployeeQuestions.Find(id);
            if (employeeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(employeeQuestions);
        }

        // POST: EmployeeQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeQuestionsID,Q1,Q2,Q3,Q4,Q5")] EmployeeQuestions employeeQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeQuestions);
        }

        // GET: EmployeeQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQuestions employeeQuestions = db.EmployeeQuestions.Find(id);
            if (employeeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(employeeQuestions);
        }

        // POST: EmployeeQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeQuestions employeeQuestions = db.EmployeeQuestions.Find(id);
            db.EmployeeQuestions.Remove(employeeQuestions);
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
