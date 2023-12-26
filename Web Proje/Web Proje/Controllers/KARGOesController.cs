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
    public class KARGOesController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: KARGOes
        public ActionResult Index()
        {
            return View(db.KARGO.ToList());
        }

        // GET: KARGOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARGO kARGO = db.KARGO.Find(id);
            if (kARGO == null)
            {
                return HttpNotFound();
            }
            return View(kARGO);
        }

        // GET: KARGOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KARGOes/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kargocuKodu,Adı,vergiNo")] KARGO kARGO)
        {
            if (ModelState.IsValid)
            {
                db.KARGO.Add(kARGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kARGO);
        }

        // GET: KARGOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARGO kARGO = db.KARGO.Find(id);
            if (kARGO == null)
            {
                return HttpNotFound();
            }
            return View(kARGO);
        }

        // POST: KARGOes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kargocuKodu,Adı,vergiNo")] KARGO kARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kARGO);
        }

        // GET: KARGOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARGO kARGO = db.KARGO.Find(id);
            if (kARGO == null)
            {
                return HttpNotFound();
            }
            return View(kARGO);
        }

        // POST: KARGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KARGO kARGO = db.KARGO.Find(id);
            db.KARGO.Remove(kARGO);
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
