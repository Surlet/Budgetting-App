using BudgetingApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.ViewModels
{
    partial class SettingsViewModel: ObservableObject
    {
        //----- Properties -----
        private const string MonthlyBudgetKey = "Monthly Budget";

        [ObservableProperty]
        private string monthlyBudget;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfirmMonthlyBudgetCommand))]
        private string monthlyBudgetEntry;

        //----- Commands -----

        [RelayCommand(CanExecute = nameof(CanConfirmMonthlyBudget))]
        private void ConfirmMonthlyBudget()
        {
            var newBudget = double.Parse(monthlyBudgetEntry);
            Preferences.Set(MonthlyBudgetKey, newBudget);
            MonthlyBudget = $"Budget mensuel: {newBudget} EUR";
        }
        private bool CanConfirmMonthlyBudget()
        {
            if (string.IsNullOrEmpty(MonthlyBudgetEntry)) return false;
            if (!double.TryParse(MonthlyBudgetEntry, out var amount)) return false;
            if (amount < 0) return false;

            return true;
        }

        public SettingsViewModel()
        {
            var monthlyBudgetDouble = Preferences.Get(MonthlyBudgetKey, 2000d);
            MonthlyBudget = $"Budget mensuel: {monthlyBudgetDouble} EUR";
        }
    }
}
