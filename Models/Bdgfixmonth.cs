using BudgetStatus.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetStatus.Models
{
    public partial class Bdgfixmonth
    {

        [Key]
        public int Counter { get; set; }
        [Required]
        public int Byear { get; set; }
        [Required]
        public string Bbudget { get; set; }
        [Required]
        public int Bmonth { get; set; }
        [Required]
        public string Blongmonth { get; set; }
        [Required]
        public int Closed { get; set; }
        [Required]
        public string Current { get; set; }

    }
}
