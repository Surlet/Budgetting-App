using BudgetingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BudgetingApp.Services;


namespace BudgetingApp.ViewModels
{
    public partial class FormViewModel : ObservableObject
    {
		//----- 2. Propriétés -----//

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(AddExpenseCommand))]
		private string storeNameEntry;

		[ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddExpenseCommand))]
        private string categoryEntry;

		[ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddExpenseCommand))]
        private string amountEntry;

        private readonly DatabaseService _databaseService;


        // Collection with all expenses
        public ObservableCollection<Expense> ExpensesCollection { get; set; }

		// ----- Commands -----

		// Submit Command
		[RelayCommand(CanExecute = nameof(CanAddExpense))]
        private void AddExpense()
        {
            var newExpense = new Expense()
            {
                StoreName = storeNameEntry,
                Category = categoryEntry,
                Amount = double.Parse(amountEntry)
            };
            _databaseService.AddExpenseAsync(newExpense);
            ExpensesCollection.Add(newExpense);
        }

		private bool CanAddExpense()
		{
            if (string.IsNullOrWhiteSpace(storeNameEntry)) return false;

            if(string.IsNullOrWhiteSpace(categoryEntry)) return false;

            if (!double.TryParse(amountEntry, out var amount)) return false;
            if (amount < 0) return false;

            return true;
		}

        // ----- Constructor -----

        public FormViewModel(DatabaseService databaseService)
		{
			// Initialise Collection
			ExpensesCollection = new ObservableCollection<Expense>();
            _databaseService = databaseService;

		}

    }
}
