using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace MI9.Models.errorhandler
{
    public class ErrorHandlerAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
                //force to HTTP 400
            filterContext.HttpContext.Response.StatusCode = 400;
               
            filterContext.Result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { error = "Could not decode request: JSON parsing failed" },
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8

            };

            filterContext.ExceptionHandled = true;
               
           

        }
       
    }
}