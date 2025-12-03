using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.Models
{
    class Expense
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
    }
}
