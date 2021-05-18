using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btl.Models;

namespace btl.Controllers
{
    public class ThongTinKhachhangsController : Controller
    {
        private KhachhangDbContext db = new KhachhangDbContext();

        // GET: ThongTinKhachhangs
        public ActionResult Index()
        {
            return View(db.ThongTinKhachhangs.ToList());
        }

        // GET: ThongTinKhachhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachhang thongTinKhachhang = db.ThongTinKhachhangs.Find(id);
            if (thongTinKhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachhang);
        }

        // GET: ThongTinKhachhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongTinKhachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenKhachHang,DiaChi,SoDienThoai")] ThongTinKhachhang thongTinKhachhang)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinKhachhangs.Add(thongTinKhachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTinKhachhang);
        }

        // GET: ThongTinKhachhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachhang thongTinKhachhang = db.ThongTinKhachhangs.Find(id);
            if (thongTinKhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachhang);
        }

        // POST: ThongTinKhachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenKhachHang,DiaChi,SoDienThoai")] ThongTinKhachhang thongTinKhachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinKhachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTinKhachhang);
        }

        // GET: ThongTinKhachhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachhang thongTinKhachhang = db.ThongTinKhachhangs.Find(id);
            if (thongTinKhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachhang);
        }

        // POST: ThongTinKhachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinKhachhang thongTinKhachhang = db.ThongTinKhachhangs.Find(id);
            db.ThongTinKhachhangs.Remove(thongTinKhachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile()
        {
            //duong dan chua file muon download
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excels/"; // tu muc chua fiel excel
            //chuyen file sang dang byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "fielexcel.xlsx"); //doan nay de file excel
            //ten file khi download ve
            string fileName = "Sinhviencapnhat.xlsx";
            //tra ve file
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            string _FileName = "thonggtin.xls";

            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);

            file.SaveAs(_path);

            DataTable dt = ReadDataFromExcelFile(_path);
           /* CopyDataByBulk(dt);*/
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThongTinKhachhang kr = new ThongTinKhachhang();
                kr.TenKhachHang = dt.Rows[i][0].ToString();
                kr.DiaChi = dt.Rows[i][1].ToString();
                kr.SoDienThoai = dt.Rows[i][2].ToString();


                db.ThongTinKhachhangs.Add(kr);
                db.SaveChanges();
            }

           /* CopyDataByBulk(ReadDataFromExcelFile(_path));*/
            return RedirectToAction("Index");
        }

        private void CopyDataByBulk(object v)
        {
            throw new NotImplementedException();
        }
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf(".xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }


            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {

                oledbConn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                DataSet ds = new DataSet();

                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {

                oledbConn.Close();
            }
            return data;
        }

        private void CopyDataByBulk(DataTable dt)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RuouDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "KhoRuous";
            bulkcopy.ColumnMappings.Add(0, "TenKhachHang");
            bulkcopy.ColumnMappings.Add(1, "DiaChi");
            bulkcopy.ColumnMappings.Add(2, "SoDienThoai");
            
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
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
