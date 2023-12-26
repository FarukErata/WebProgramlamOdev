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
    public class MÜŞTERİController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: MÜŞTERİ
        public ActionResult Index()
        {
            return View(db.MÜŞTERİ.ToList());
        }

        // GET: MÜŞTERİ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MÜŞTERİ mÜŞTERİ = db.MÜŞTERİ.Find(id);
            if (mÜŞTERİ == null)
            {
                return HttpNotFound();
            }
            return View(mÜŞTERİ);
        }

        // GET: MÜŞTERİ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MÜŞTERİ/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "müşteriNo,müşteriAdı,parola")] MÜŞTERİ mÜŞTERİ)
        {
            if (ModelState.IsValid)
            {
                db.MÜŞTERİ.Add(mÜŞTERİ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mÜŞTERİ);
        }

        // GET: MÜŞTERİ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MÜŞTERİ mÜŞTERİ = db.MÜŞTERİ.Find(id);
            if (mÜŞTERİ == null)
            {
                return HttpNotFound();
            }
            return View(mÜŞTERİ);
        }

        // POST: MÜŞTERİ/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "müşteriNo,müşteriAdı,parola")] MÜŞTERİ mÜŞTERİ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mÜŞTERİ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mÜŞTERİ);
        }

        // GET: MÜŞTERİ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MÜŞTERİ mÜŞTERİ = db.MÜŞTERİ.Find(id);
            if (mÜŞTERİ == null)
            {
                return HttpNotFound();
            }
            return View(mÜŞTERİ);
        }

        // POST: MÜŞTERİ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MÜŞTERİ mÜŞTERİ = db.MÜŞTERİ.Find(id);
            db.MÜŞTERİ.Remove(mÜŞTERİ);
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
