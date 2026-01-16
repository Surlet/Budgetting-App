using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BudgetingApp.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BeneficiaryName { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string Title { get; set; }
        [Ignore]
        private Category Category { get; set; }

        public void EnsureTitle()
        {
            if (!string.IsNullOrWhiteSpace(Title))
                return;
            Title = $"{BeneficiaryName} {CreatedTime.Day}/{CreatedTime.Month}";
        }

        
    }
}
