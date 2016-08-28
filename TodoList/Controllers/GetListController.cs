using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using PagingUtil;
using PagingUtil.Extensions;
using X.PagedList;

namespace TodoList.Controllers
{
    public class GetListController : BaseController
    {
        // GET: GetList
        public JsonResult Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var q = from r in ctx.TodoItems
                        orderby r.DueDate descending
                        select r;

                var rs = q.ToList();
                return GetJsonResult(rs, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult Paged(jqGridViewModel vm)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var nRecords = ctx.TodoItems.Count();

                var q = (from r in ctx.TodoItems
                        orderby r.DueDate descending
                        select r).ToPagedList(vm.page,vm.rows);

                PagedResults<TodoItem> rs = q.ToList().ToPagedObject(vm.page, vm.rows, nRecords);
                
                return GetJsonResult(rs, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult PagedNonCompleted(jqGridViewModel vm)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var nRecords = ctx.TodoItems.Count();

                var q = (from r in ctx.TodoItems
                         where !r.IsCompleted
                         orderby r.DueDate descending
                         select r).ToPagedList(vm.page, vm.rows);

                PagedResults<TodoItem> rs = q.ToList().ToPagedObject(vm.page, vm.rows, nRecords);

                return GetJsonResult(rs, JsonRequestBehavior.AllowGet);

            }
        }
    }
}