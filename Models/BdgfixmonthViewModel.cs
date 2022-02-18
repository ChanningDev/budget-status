using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BudgetStatus.Models
{


    public class BdgfixmonthViewModel
    {
        public List<Bdgfixmonth> Bdgfixmonths { get; set; }
        public int Byear { get; set; }
    }
}


