using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Habaripay.ShopsRUs.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public string TraceId
        {
            get
            {
                return Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            }
        }
    }
}
