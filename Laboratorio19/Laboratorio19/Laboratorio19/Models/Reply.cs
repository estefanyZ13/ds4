using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio19.Models.WS;


namespace Laboratorio19.Models.WS
{
    public class Reply
    {
        
            public int result { get; set; }
            public string message { get; set; }
            public List<object> data { get; set; }  // ✅ LISTA
        

    }
}