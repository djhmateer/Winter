using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winter.Web.Tests.Controllers
{
    public class FakeLogger : Winter.Web.Controllers.ILogger
    {
        void Web.Controllers.ILogger.Log(string message)
        {
            
        }
    }
}
