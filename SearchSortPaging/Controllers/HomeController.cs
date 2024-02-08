using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchSortPaging.Models;
using PagedList;

namespace SearchSortPaging.Controllers
{
    public class HomeController : Controller
    {
        db_StudentsEntities1 db = new db_StudentsEntities1();

        public ActionResult _Index()
        {
            List<studentsTable> StudentList = db.studentsTables.ToList();
            
            return View(StudentList);
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Subjects")
            {
                return View(db.studentsTables.Where
                    (x => x.Subjects == search || search == null).ToList()
                    .ToPagedList(pageNumber ?? 1, 3));
            }
            else if (option == "Gender")
            { 
                return View(db.studentsTables.Where
                    (x => x.Gender == search || search == null).ToList()
                    .ToPagedList(pageNumber ?? 1, 3)); 
            }
            else
            {
                return View(db.studentsTables.Where
                    (x => x.stuName.StartsWith(search) || search == null).ToList()
                    .ToPagedList(pageNumber ?? 1, 3));
            }
        }
    }
}