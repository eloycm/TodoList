using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class OnOffController : Controller
    {
        // GET: OnOff
        public ActionResult Index()
        {
            return View();
        }

        

        // GET: OnOff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OnOff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, bool newvalue)
        {
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var r=ctx.TodoItems.SingleOrDefault(t => t.ID == id);
                    r.IsCompleted = newvalue;
                    ctx.SaveChanges();

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

       
    }
}
