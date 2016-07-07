using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using MI9.Models.appdomain;
using MI9.Models.utilities;

using MI9.Controllers;

using System.Linq;
using System.Web.Mvc;


namespace MI9.Tests
{
    [TestClass]
    public class TestJsonObj
    {

        Request request;
        string json;
        

       public TestJsonObj()
        {
            

            using (StreamReader r = new StreamReader("jsonobj.json"))
            {
                json = r.ReadToEnd();
                request = JsonConvert.DeserializeObject<Request>(json);
            }
        }

      
       

      


       [TestMethod]
       public void test_response()
       {

           ActionResult result = new SubmitRequestController().getResult(this.json);

           Assert.IsNotNull(result);
           Assert.AreNotEqual(result, typeof(JsonResult));


           Console.WriteLine(JsonConvert.SerializeObject(result));
               
       }

     


    }
}
