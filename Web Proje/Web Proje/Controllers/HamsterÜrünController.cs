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
    public class HamsterÜrünController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: HamsterÜrün
        public ActionResult Index()
        {
            var hamsterÜrün = db.HamsterÜrün.Include(h => h.TEDARİKÇİ);
            return View(hamsterÜrün.ToList());
        }

        // GET: HamsterÜrün/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamsterÜrün hamsterÜrün = db.HamsterÜrün.Find(id);
            if (hamsterÜrün == null)
            {
                return HttpNotFound();
            }
            return View(hamsterÜrün);
        }

        // GET: HamsterÜrün/Create
        public ActionResult Create()
        {
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı");
            return View();
        }

        // POST: HamsterÜrün/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hamsterÜrünID,tedarikçiNo,ürünAd,stokMiktarı")] HamsterÜrün hamsterÜrün)
        {
            if (ModelState.IsValid)
            {
                db.HamsterÜrün.Add(hamsterÜrün);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", hamsterÜrün.tedarikçiNo);
            return View(hamsterÜrün);
        }

        // GET: HamsterÜrün/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamsterÜrün hamsterÜrün = db.HamsterÜrün.Find(id);
            if (hamsterÜrün == null)
            {
                return HttpNotFound();
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", hamsterÜrün.tedarikçiNo);
            return View(hamsterÜrün);
        }

        // POST: HamsterÜrün/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hamsterÜrünID,tedarikçiNo,ürünAd,stokMiktarı")] HamsterÜrün hamsterÜrün)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hamsterÜrün).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tedarikçiNo = new SelectList(db.TEDARİKÇİ, "tedarikçiNo", "tedarikçiAdı", hamsterÜrün.tedarikçiNo);
            return View(hamsterÜrün);
        }

        // GET: HamsterÜrün/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamsterÜrün hamsterÜrün = db.HamsterÜrün.Find(id);
            if (hamsterÜrün == null)
            {
                return HttpNotFound();
            }
            return View(hamsterÜrün);
        }

        // POST: HamsterÜrün/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HamsterÜrün hamsterÜrün = db.HamsterÜrün.Find(id);
            db.HamsterÜrün.Remove(hamsterÜrün);
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
