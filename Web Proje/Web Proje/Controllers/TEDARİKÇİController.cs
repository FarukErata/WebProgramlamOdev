using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Proje;

namespace Web_Proje.Controllers
{
    public class TEDARİKÇİController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: TEDARİKÇİ
        public ActionResult Index()
        {
            return View(db.TEDARİKÇİ.ToList());
        }

        // GET: TEDARİKÇİ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEDARİKÇİ tEDARİKÇİ = db.TEDARİKÇİ.Find(id);
            if (tEDARİKÇİ == null)
            {
                return HttpNotFound();
            }
            return View(tEDARİKÇİ);
        }

        // GET: TEDARİKÇİ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEDARİKÇİ/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tedarikçiNo,tedarikçiAdı")] TEDARİKÇİ tEDARİKÇİ)
        {
            if (ModelState.IsValid)
            {
                db.TEDARİKÇİ.Add(tEDARİKÇİ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEDARİKÇİ);
        }

        // GET: TEDARİKÇİ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEDARİKÇİ tEDARİKÇİ = db.TEDARİKÇİ.Find(id);
            if (tEDARİKÇİ == null)
            {
                return HttpNotFound();
            }
            return View(tEDARİKÇİ);
        }

        // POST: TEDARİKÇİ/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tedarikçiNo,tedarikçiAdı")] TEDARİKÇİ tEDARİKÇİ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEDARİKÇİ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEDARİKÇİ);
        }

        // GET: TEDARİKÇİ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEDARİKÇİ tEDARİKÇİ = db.TEDARİKÇİ.Find(id);
            if (tEDARİKÇİ == null)
            {
                return HttpNotFound();
            }
            return View(tEDARİKÇİ);
        }

        // POST: TEDARİKÇİ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEDARİKÇİ tEDARİKÇİ = db.TEDARİKÇİ.Find(id);
            db.TEDARİKÇİ.Remove(tEDARİKÇİ);
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
