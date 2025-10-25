using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb08_Bai03.Models;

namespace LTWeb08_Bai03.Controllers
{
    public class HomeController : Controller
    {
        Model1 data=new Model1();
        public ActionResult Index()
        {
            List<Employee> employees = data.Employees.ToList();
            return View(employees);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string folderPath = Server.MapPath("~/Content/images/"); 
                    string filePath = Path.Combine(folderPath, fileName);
                    ImageFile.SaveAs(filePath);
                    employee.ImagePath = "~/Content/images/" + fileName;
                }
                else
                {
                    employee.ImagePath = null;
                }
                data.Employees.Add(employee);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult ThemMoi()
        {
            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem{Text="Nam",Value="Nam"},
                new SelectListItem{Text="Nữ",Value="Nữ"},
            };
            var department=data.Departments.ToList();
            ViewBag.DeptId = new SelectList(department, "DeptId","Name");
            return View();
        }
        public ActionResult Edit(int id)
        {
            var em_edit=data.Employees.First(e=> e.Id == id);
            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem{Text="Nam",Value="Nam"},
                new SelectListItem{Text="Nữ",Value="Nữ"},
            };
            var department = data.Departments.ToList();
            ViewBag.DeptId = new SelectList(department, "DeptId", "Name", em_edit.DeptId);
           
            return View(em_edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase ImageFile)
        {
            var em_edit = data.Employees.First(e => e.Id == id);
            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem{Text="Nam",Value="Nam"},
                new SelectListItem{Text="Nữ",Value="Nữ"},
            };
            var department = data.Departments.ToList();
            ViewBag.DeptId = new SelectList(department, "DeptId", "Name", em_edit.DeptId);
            
            em_edit.Name = collection["Name"];
            em_edit.Gender = collection["Gender"];
            em_edit.City = collection["City"];
            if (int.TryParse(collection["DeptId"], out int deptId))
            {
                em_edit.DeptId = deptId;
            }
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string folderPath = Server.MapPath("~/Content/images/");
                    string filePath = Path.Combine(folderPath, fileName);
                    ImageFile.SaveAs(filePath);
                    em_edit.ImagePath = "~/Content/images/" + fileName;
                }
            }
            data.UpdateOnSubmit(em_edit);
            data.SubmitSaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var employee=data.Employees.Where(e=>e.Id == id).First();
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var em_delete = data.Employees.First(e=>e.Id==id);
            data.DeleteOnSubmit(em_delete);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentList()
        {
            List<Department> ds = data.Departments.ToList();
            return View(ds);
        }
        public ActionResult DanhSachNhanVienTheoPhongBan(int id)
        {
            var employees=data.Employees.Where(e=>e.DeptId == id).ToList();
            return View(employees);
        }
        public ActionResult TongHop()
        {
            return View();
        }
    }
}