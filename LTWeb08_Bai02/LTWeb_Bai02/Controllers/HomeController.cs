using LTWeb_Bai02.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_Bai02.Controllers
{
    public class HomeController : Controller
    {
        QLSachContext data = new QLSachContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DMSach()
        {
            var dsSach = data.SACH.Include("ChuDe").Include("NhaXuatBan").ToList();
            return View(dsSach);
        }

        //Thêm sách
        [HttpGet]
        public ActionResult ThemSach()
        {
            ViewBag.MaCD = new SelectList(data.CHUDE, "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN, "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSach(SACH emp, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(Image.FileName);
                    string folderPath = Server.MapPath("~/Content/images/");
                    string fullPath = System.IO.Path.Combine(folderPath, fileName);
                    Image.SaveAs(fullPath);

                    emp.AnhBia = "/Content/images/" + fileName;
                }

                data.SACH.Add(emp);
                data.SaveChanges();
                return RedirectToAction("DMSach");
            }

            ViewBag.MaCD = new SelectList(data.CHUDE, "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN, "MaNXB", "TenNXB");
            return View(emp);
        }

        //Sửa sách
        [HttpGet]
        public ActionResult SuaSach(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var sach = data.SACH.Find(id.Trim());
            if (sach == null)
                return HttpNotFound();

            ViewBag.MaCD = new SelectList(data.CHUDE, "MaCD", "TenChuDe", sach.MaCD);
            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSach(SACH emp, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var existingEmp = data.SACH.Find(emp.MaSach);
                if (existingEmp == null)
                {
                    return HttpNotFound();
                }

                existingEmp.TenSach = emp.TenSach;
                existingEmp.GiaBan = emp.GiaBan;
                existingEmp.MoTa = emp.MoTa;

                if (Image != null && Image.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Image.FileName);
                    string folderPath = Server.MapPath("~/Content/images/");
                    string fullPath = Path.Combine(folderPath, fileName);
                    Image.SaveAs(fullPath);

                    existingEmp.AnhBia = "/Content/images/" + fileName;
                }

                existingEmp.NgayCapNhat = emp.NgayCapNhat;
                existingEmp.SoLuongTon = emp.SoLuongTon;
                data.SaveChanges();
                return RedirectToAction("DMSach");
            }

            ViewBag.MaCD = new SelectList(data.CHUDE, "MaCD", "TenChuDe", emp.MaCD);
            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN, "MaNXB", "TenNXB", emp.MaNXB);
            return View(emp);
        }

        //Chi tiết sách
        public ActionResult ChiTiet(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var sach = data.SACH
                           .Include("ChuDe")
                           .Include("NhaXuatBan")
                           .FirstOrDefault(s => s.MaSach == id);

            if (sach == null)
                return HttpNotFound();

            return View(sach);
        }

        //Delete
        [HttpGet]
        public ActionResult XoaSach(string id)
        {
            var emp = data.SACH.Find(id);
            if (emp != null)
            {
                data.SACH.Remove(emp);
                data.SaveChanges();
            }

            return RedirectToAction("DMSach");
        }

    }
}