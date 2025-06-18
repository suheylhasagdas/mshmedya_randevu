using Core.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIWeb.Controllers
{
    [ServiceFilter(typeof(ActionFiltersAttribute))]
    public class MshController : Controller
    {

    }
}
