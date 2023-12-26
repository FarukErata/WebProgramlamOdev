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
    public class KöpekÜrünController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: KöpekÜrün
        public ActionResult Index()
        {
            var köpekÜrün = db.KöpekÜrün.Include(k => k.TEDARİKÇİ);
            return View(köpekÜrün.ToList());
        }

        // GET: KöpekÜrün/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KöpekÜrün köpekÜrün = db.KöpekÜrün.Find(id);
            if (köpekÜrün == null)
            {
                return HttpNotFound();
            }
            return View(köpekÜrün);
        }

        // GET: KöpekÜrün/Create
        public ActionResult Create()
        {
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı");
            return View();
        }

        // POST: KöpekÜrün/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "köpekÜrünId,tedarikçiNo,ürünAd,stokMiktarı")] KöpekÜrün köpekÜrün)
        {
            if (ModelState.IsValid)
            {
                db.KöpekÜrün.Add(köpekÜrün);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", köpekÜrün.tedarikçiNo);
            return View(köpekÜrün);
        }

        // GET: KöpekÜrün/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KöpekÜrün köpekÜrün = db.KöpekÜrün.Find(id);
            if (köpekÜrün == null)
            {
                return HttpNotFound();
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", köpekÜrün.tedarikçiNo);
            return View(köpekÜrün);
        }

        // POST: KöpekÜrün/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "köpekÜrünId,tedarikçiNo,ürünAd,stokMiktarı")] KöpekÜrün köpekÜrün)
        {
            if (ModelState.IsValid)
            {
                db.Entry(köpekÜrün).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", köpekÜrün.tedarikçiNo);
            return View(köpekÜrün);
        }

        // GET: KöpekÜrün/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KöpekÜrün köpekÜrün = db.KöpekÜrün.Find(id);
            if (köpekÜrün == null)
            {
                return HttpNotFound();
            }
            return View(köpekÜrün);
        }

        // POST: KöpekÜrün/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KöpekÜrün köpekÜrün = db.KöpekÜrün.Find(id);
            db.KöpekÜrün.Remove(köpekÜrün);
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
