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
            var rs = new TodoItem();
            rs.DueDate = DateTime.Now;
            return PartialView("/views/todo/Create.cshtml",rs);
        }

        // POST: ToDo/Create
        [HttpPost]
        public JsonResult Create(TodoItem collection)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var newItem = new TodoItem();


                    UpdateModel(newItem);
                    ctx.TodoItems.Add(newItem);
                    ctx.SaveChanges();
                }
                return Json("[]");
            }
            catch
            {
                return Json("[]");
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        public JsonResult Edit(TodoItem collection)
        {
            try
            {
                

                using (var ctx = new ApplicationDbContext())
                {

                    var q = from r in ctx.TodoItems
                            where r.ID ==collection.ID
                            select r;

                    var rs = q.FirstOrDefault();
                    UpdateModel(rs);
                    ctx.SaveChanges();
                }
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
