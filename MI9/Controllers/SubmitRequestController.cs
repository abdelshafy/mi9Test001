using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using System.Dynamic;
using MI9.Models;
using MI9.Models.appdomain;
using MI9.Models.utilities;
using Newtonsoft.Json;

using System.IO;

namespace MI9.Controllers
{

    public class SubmitRequestController : Controller
    {
        //
        // GET: /SubmitRequest/

       
       [CrossSiteJson]
        [HandleError]
        
        public ActionResult getResult(String request)
        {

           
               if (Request != null) { 

                    if (Request.ContentLength == 0 || Request.ContentType != "application/json")
                    { 
                        // no request recieved.  Throw error
                        Response.StatusCode = 400;
                        throw new HttpException();
                    }

                    Request.InputStream.Position = 0;
                    StreamReader str = new StreamReader(Request.InputStream);

                    request = str.ReadToEnd();
                }

               
            

                Request input = JsonConvert.DeserializeObject<Request>(request);

                if (input.totalRecords == 0)
                {

                    Response.StatusCode = 400;
                    throw new HttpException(400, "bad request");
                }

          

                return new JsonResult 
                { 
                    Data = new 
                    { 
                        response = Helper.FilterAndGenerateResponse(input) 
                    }, 
                    ContentEncoding = System.Text.Encoding.UTF8, 
                    ContentType = "application/json" 
                };

       
        }

    }
}
