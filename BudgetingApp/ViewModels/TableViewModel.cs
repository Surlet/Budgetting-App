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

        [ObservableProperty]
        public int countExpenses;

        [ObservableProperty]
        public decimal sumAmountOfExpenses;

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
            CountExpenses = data.Count;
            decimal sum = 0;
            ExpensesCollection.Clear();
            foreach (Expense expense in data)
            {
                ExpensesCollection.Add(expense);
                sum += expense.Amount;
            }
            SumAmountOfExpenses = sum;
        }

    }
}
