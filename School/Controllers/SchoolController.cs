using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.DAL;
using School.Models;
using PagedList;

namespace School.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: School
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Schedule(int? day, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            if (day == null) { return View(db.Lessons.Include("Course").Include("Day").OrderByDescending(x => x.Day.Id).ToPagedList(pageNumber, pageSize)); }
            else { return View(db.Lessons.Include("Course").Include("Day").Where(x => x.Day.Id.Equals(day)).OrderByDescending(x => x.Day.Id).ToPagedList(pageNumber, pageSize)); }
        }

        public ActionResult TeacherDetails(int id)
        {
            return View(db.Teachers.Find(id));
        }
          
        public ActionResult StudentDetails(int id)
        {
            return View(db.Students.Find(id));
        }

        public ActionResult StudentsInCourse(int id)
        {
            CourseModel course = db.Courses.Find(id);
            ViewBag.Title = "Students in " + course.Subject.SubjectName;
            return View(course.Students);
        }

        // GET: School/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModel courseModel = db.Courses.First(x => x.Id == id);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
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
