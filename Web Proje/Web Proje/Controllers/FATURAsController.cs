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
    public class FATURAsController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: FATURAs
        public ActionResult Index()
        {
            return View(db.FATURA.ToList());
        }

        // GET: FATURAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FATURA fATURA = db.FATURA.Find(id);
            if (fATURA == null)
            {
                return HttpNotFound();
            }
            return View(fATURA);
        }

        // GET: FATURAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FATURAs/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "faturaNo,faturaTarihi")] FATURA fATURA)
        {
            if (ModelState.IsValid)
            {
                db.FATURA.Add(fATURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fATURA);
        }

        // GET: FATURAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FATURA fATURA = db.FATURA.Find(id);
            if (fATURA == null)
            {
                return HttpNotFound();
            }
            return View(fATURA);
        }

        // POST: FATURAs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "faturaNo,faturaTarihi")] FATURA fATURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fATURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fATURA);
        }

        // GET: FATURAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FATURA fATURA = db.FATURA.Find(id);
            if (fATURA == null)
            {
                return HttpNotFound();
            }
            return View(fATURA);
        }

        // POST: FATURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FATURA fATURA = db.FATURA.Find(id);
            db.FATURA.Remove(fATURA);
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
