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
    public class KuşÜrünController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: KuşÜrün
        public ActionResult Index()
        {
            var kuşÜrün = db.KuşÜrün.Include(k => k.TEDARİKÇİ);
            return View(kuşÜrün.ToList());
        }

        // GET: KuşÜrün/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuşÜrün kuşÜrün = db.KuşÜrün.Find(id);
            if (kuşÜrün == null)
            {
                return HttpNotFound();
            }
            return View(kuşÜrün);
        }

        // GET: KuşÜrün/Create
        public ActionResult Create()
        {
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı");
            return View();
        }

        // POST: KuşÜrün/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kuşÜrünId,tedarikçiNo,ürünAd,stokMiktarı")] KuşÜrün kuşÜrün)
        {
            if (ModelState.IsValid)
            {
                db.KuşÜrün.Add(kuşÜrün);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kuşÜrün.tedarikçiNo);
            return View(kuşÜrün);
        }

        // GET: KuşÜrün/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuşÜrün kuşÜrün = db.KuşÜrün.Find(id);
            if (kuşÜrün == null)
            {
                return HttpNotFound();
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kuşÜrün.tedarikçiNo);
            return View(kuşÜrün);
        }

        // POST: KuşÜrün/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kuşÜrünId,tedarikçiNo,ürünAd,stokMiktarı")] KuşÜrün kuşÜrün)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuşÜrün).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kuşÜrün.tedarikçiNo);
            return View(kuşÜrün);
        }

        // GET: KuşÜrün/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuşÜrün kuşÜrün = db.KuşÜrün.Find(id);
            if (kuşÜrün == null)
            {
                return HttpNotFound();
            }
            return View(kuşÜrün);
        }

        // POST: KuşÜrün/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KuşÜrün kuşÜrün = db.KuşÜrün.Find(id);
            db.KuşÜrün.Remove(kuşÜrün);
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
