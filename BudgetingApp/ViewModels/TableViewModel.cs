using BudgetingApp.Models;
using BudgetingApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.ViewModels
{
    public partial class TableViewModel: ObservableObject
    {
        public ObservableCollection<Expense> ExpensesCollection { get; set; }

        private readonly DatabaseService _databaseService;

        

        public TableViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            ExpensesCollection = new ObservableCollection<Expense>();
            LoadExpensesAsync();
        }

        [RelayCommand]
        private async Task LoadExpensesAsync()
        {
            var data = await _databaseService.GetAllAsync<Expense>();
            ExpensesCollection.Clear();
            foreach (Expense expense in data)
            {
                ExpensesCollection.Add(expense);
            }

        }

    }
}
