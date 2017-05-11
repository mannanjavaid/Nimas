using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HolidayViewModel
    {
        IEnumerable<DateTime> Dates { get; set; }
    }
}