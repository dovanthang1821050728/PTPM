using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btl.Models;

namespace btl.Controllers
{
    public class ChiNhanhCuaHangsController : Controller
    {
        private KhachhangDbContext db = new KhachhangDbContext();

        // GET: ChiNhanhCuaHangs
        public ActionResult Index()
        {
            return View(db.ChiNhanhCuaHangs.ToList());
        }

        // GET: ChiNhanhCuaHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanhCuaHang chiNhanhCuaHang = db.ChiNhanhCuaHangs.Find(id);
            if (chiNhanhCuaHang == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanhCuaHang);
        }

        // GET: ChiNhanhCuaHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiNhanhCuaHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCuaHang,TenCuaHang,Tonghangtrongkho,SoLuongDaBan,SoLuongConLai")] ChiNhanhCuaHang chiNhanhCuaHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiNhanhCuaHangs.Add(chiNhanhCuaHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiNhanhCuaHang);
        }

        // GET: ChiNhanhCuaHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanhCuaHang chiNhanhCuaHang = db.ChiNhanhCuaHangs.Find(id);
            if (chiNhanhCuaHang == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanhCuaHang);
        }

        // POST: ChiNhanhCuaHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCuaHang,TenCuaHang,Tonghangtrongkho,SoLuongDaBan,SoLuongConLai")] ChiNhanhCuaHang chiNhanhCuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiNhanhCuaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiNhanhCuaHang);
        }

        // GET: ChiNhanhCuaHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanhCuaHang chiNhanhCuaHang = db.ChiNhanhCuaHangs.Find(id);
            if (chiNhanhCuaHang == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanhCuaHang);
        }

        // POST: ChiNhanhCuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiNhanhCuaHang chiNhanhCuaHang = db.ChiNhanhCuaHangs.Find(id);
            db.ChiNhanhCuaHangs.Remove(chiNhanhCuaHang);
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
