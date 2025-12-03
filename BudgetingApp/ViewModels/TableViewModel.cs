using BudgetingApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.ViewModels
{
    partial class TableViewModel: ObservableObject
    {
        ObservableCollection<Expense> ExpensesCollection { get; set; }

        public TableViewModel()
        {
            ExpensesCollection = new ObservableCollection<Expense>();
        }
    }
}
