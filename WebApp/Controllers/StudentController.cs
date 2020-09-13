using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository Repository { get; set; }

        public StudentController()
        {
            this.Repository = new StudentRepository();
        }

        public ActionResult Index()
        {
            return View(this.Repository.GetStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(Guid id)
        {
            var student = this.Repository.GetStudentById(id);
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                if (this.Repository.GetStudentByEmail(student.Email) != null)
                {
                    ModelState.AddModelError("EMAIL ALREADY EXISTS", "Please enter a VALID e-mail address");
                    return View();
                }

                student.Status = Status.EMAIL_EM_CONFIRMACAO;

                this.Repository.Save(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var student = this.Repository.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Student student)
        {
            try
            {
                this.Repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
