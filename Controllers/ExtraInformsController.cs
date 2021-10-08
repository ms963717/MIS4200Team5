using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS4200Team5.Controllers
{
    public class ExtraInformsController : Controller
    {
        // GET: ExtraInforms
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExtraInforms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExtraInforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraInforms/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtraInforms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExtraInforms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtraInforms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExtraInforms/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
