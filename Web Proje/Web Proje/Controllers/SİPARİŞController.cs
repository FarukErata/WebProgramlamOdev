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
    public class SİPARİŞController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: SİPARİŞ
        public ActionResult Index()
        {
            var sİPARİŞ = db.SİPARİŞ.Include(s => s.FATURA).Include(s => s.HamsterÜrün).Include(s => s.KARGO).Include(s => s.KediÜrün).Include(s => s.KöpekÜrün).Include(s => s.KuşÜrün).Include(s => s.MÜŞTERİ);
            return View(sİPARİŞ.ToList());
        }

        // GET: SİPARİŞ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SİPARİŞ sİPARİŞ = db.SİPARİŞ.Find(id);
            if (sİPARİŞ == null)
            {
                return HttpNotFound();
            }
            return View(sİPARİŞ);
        }

        // GET: SİPARİŞ/Create
        public ActionResult Create()
        {
            ViewBag.faturaNo = new SelectList(db.FATURA, "faturaNo", "faturaNo");
            ViewBag.ürünID = new SelectList(db.HamsterÜrün, "hamsterÜrünID", "ürünAd");
            ViewBag.kargocuKodu = new SelectList(db.KARGO, "kargocuKodu", "Adı");
            ViewBag.ürünID = new SelectList(db.KediÜrün, "kediÜrünID", "ürünAd");
            ViewBag.ürünID = new SelectList(db.KöpekÜrün, "köpekÜrünId", "ürünAd");
            ViewBag.ürünID = new SelectList(db.KuşÜrün, "kuşÜrünId", "ürünAd");
            ViewBag.müşteriNo = new SelectList(db.MÜŞTERİ, "müşteriNo", "müşteriAdı");
            return View();
        }

        // POST: SİPARİŞ/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "siparişNo,ürünID,müşteriNo,faturaNo,kargocuKodu,toplamFiyat")] SİPARİŞ sİPARİŞ)
        {
            if (ModelState.IsValid)
            {
                db.SİPARİŞ.Add(sİPARİŞ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.faturaNo = new SelectList(db.FATURA, "faturaNo", "faturaNo", sİPARİŞ.faturaNo);
            ViewBag.ürünID = new SelectList(db.HamsterÜrün, "hamsterÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.kargocuKodu = new SelectList(db.KARGO, "kargocuKodu", "Adı", sİPARİŞ.kargocuKodu);
            ViewBag.ürünID = new SelectList(db.KediÜrün, "kediÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KöpekÜrün, "köpekÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KuşÜrün, "kuşÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.müşteriNo = new SelectList(db.MÜŞTERİ, "müşteriNo", "müşteriAdı", sİPARİŞ.müşteriNo);
            return View(sİPARİŞ);
        }

        // GET: SİPARİŞ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SİPARİŞ sİPARİŞ = db.SİPARİŞ.Find(id);
            if (sİPARİŞ == null)
            {
                return HttpNotFound();
            }
            ViewBag.faturaNo = new SelectList(db.FATURA, "faturaNo", "faturaNo", sİPARİŞ.faturaNo);
            ViewBag.ürünID = new SelectList(db.HamsterÜrün, "hamsterÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.kargocuKodu = new SelectList(db.KARGO, "kargocuKodu", "Adı", sİPARİŞ.kargocuKodu);
            ViewBag.ürünID = new SelectList(db.KediÜrün, "kediÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KöpekÜrün, "köpekÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KuşÜrün, "kuşÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.müşteriNo = new SelectList(db.MÜŞTERİ, "müşteriNo", "müşteriAdı", sİPARİŞ.müşteriNo);
            return View(sİPARİŞ);
        }

        // POST: SİPARİŞ/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "siparişNo,ürünID,müşteriNo,faturaNo,kargocuKodu,toplamFiyat")] SİPARİŞ sİPARİŞ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sİPARİŞ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.faturaNo = new SelectList(db.FATURA, "faturaNo", "faturaNo", sİPARİŞ.faturaNo);
            ViewBag.ürünID = new SelectList(db.HamsterÜrün, "hamsterÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.kargocuKodu = new SelectList(db.KARGO, "kargocuKodu", "Adı", sİPARİŞ.kargocuKodu);
            ViewBag.ürünID = new SelectList(db.KediÜrün, "kediÜrünID", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KöpekÜrün, "köpekÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.ürünID = new SelectList(db.KuşÜrün, "kuşÜrünId", "ürünAd", sİPARİŞ.ürünID);
            ViewBag.müşteriNo = new SelectList(db.MÜŞTERİ, "müşteriNo", "müşteriAdı", sİPARİŞ.müşteriNo);
            return View(sİPARİŞ);
        }

        // GET: SİPARİŞ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SİPARİŞ sİPARİŞ = db.SİPARİŞ.Find(id);
            if (sİPARİŞ == null)
            {
                return HttpNotFound();
            }
            return View(sİPARİŞ);
        }

        // POST: SİPARİŞ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SİPARİŞ sİPARİŞ = db.SİPARİŞ.Find(id);
            db.SİPARİŞ.Remove(sİPARİŞ);
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
