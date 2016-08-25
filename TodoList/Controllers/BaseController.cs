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
    }
}