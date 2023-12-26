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
    public class KediÜrünController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: KediÜrün
        public ActionResult Index()
        {
            var kediÜrün = db.KediÜrün.Include(k => k.TEDARİKÇİ);
            return View(kediÜrün.ToList());
        }

        // GET: KediÜrün/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KediÜrün kediÜrün = db.KediÜrün.Find(id);
            if (kediÜrün == null)
            {
                return HttpNotFound();
            }
            return View(kediÜrün);
        }

        // GET: KediÜrün/Create
        public ActionResult Create()
        {
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı");
            return View();
        }

        // POST: KediÜrün/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kediÜrünID,tedarikçiNo,ürünAd,stokMiktarı")] KediÜrün kediÜrün)
        {
            if (ModelState.IsValid)
            {
                db.KediÜrün.Add(kediÜrün);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kediÜrün.tedarikçiNo);
            return View(kediÜrün);
        }

        // GET: KediÜrün/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KediÜrün kediÜrün = db.KediÜrün.Find(id);
            if (kediÜrün == null)
            {
                return HttpNotFound();
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kediÜrün.tedarikçiNo);
            return View(kediÜrün);
        }

        // POST: KediÜrün/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kediÜrünID,tedarikçiNo,ürünAd,stokMiktarı")] KediÜrün kediÜrün)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kediÜrün).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", kediÜrün.tedarikçiNo);
            return View(kediÜrün);
        }

        // GET: KediÜrün/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KediÜrün kediÜrün = db.KediÜrün.Find(id);
            if (kediÜrün == null)
            {
                return HttpNotFound();
            }
            return View(kediÜrün);
        }

        // POST: KediÜrün/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KediÜrün kediÜrün = db.KediÜrün.Find(id);
            db.KediÜrün.Remove(kediÜrün);
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
