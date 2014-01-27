using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winter.Web.Controllers
{
    public interface ILogger
    {
        void Log(string message);
    }
}
