using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            return View();
        }

        // GET: ToDo/Details/5
        public PartialViewResult Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var q = from r in ctx.TodoItems
                        where r.ID==id
                        select r;

                var rs = q.FirstOrDefault();
                return PartialView("/views/todo/details.cshtml", rs);

            }
            
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        public string Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return "thank you!";
            }
            catch
            {
                return "Error";
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return Json("[]");
            }
            catch
            {
                return  Json("[]"); ;
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
