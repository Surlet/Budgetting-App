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
        public string StoreName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string Title { get; set; }
    }
}
