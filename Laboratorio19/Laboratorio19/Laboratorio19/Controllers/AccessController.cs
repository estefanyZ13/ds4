using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Laboratorio19.Models.WS;

namespace Laboratorio19.Controllers
{
    public class AccessController : ApiController
    {
        public class Reply
        {
            public int result { get; set; }
            public string message { get; set; }
        }
        [HttpGet]
        public Reply HelloworldId()
        {
            Reply oR = new Reply();
            oR.result = 1;
            oR.message = "Microsoft Hello World en API";
            return oR;
        }
    }
  
}
