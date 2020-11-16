using System;
using VentaReal.API.Entities;

namespace VentaReal.API.Orm
{
    public class Response {

        public Response()
        {
            data   = null;
            exito  = 0;
        }
        public string message { get; set; }
        public double exito { get; set; }
        public Object data { get; set; }
    }
}