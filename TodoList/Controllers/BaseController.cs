using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace TodoList.Controllers
{
    public class BaseController:Controller
    {
        protected string UserId
        {
            get
            {
                if (Session["UserId"] != null)
                    return Session["UserId"].ToString();
                var uId = GetUserId();
                Session["UserId"] = uId;

                return uId;
            }
        }
        protected JsonResult GetJsonResult(object data, JsonRequestBehavior requestBehavior)
        {
            return new JsonResult()
            {
                ContentEncoding = Encoding.Default,
                ContentType = "application/json",
                Data = data,
                JsonRequestBehavior = requestBehavior,
                MaxJsonLength = int.MaxValue
            };


        }
        protected string GetUserId()
        {


            using (var ctx = new Models.ApplicationDbContext())
            {
                var q = from u in ctx.Users
                        where User.Identity.Name == u.Email
                        select u;

                var rs = q.FirstOrDefault();

                return rs == null ? string.Empty : rs.Id;
            }
        }
    }
}