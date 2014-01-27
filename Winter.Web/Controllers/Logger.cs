using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winter.Web.Controllers
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            var x = 1;
        }
    }
}