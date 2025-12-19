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

        [ObservableProperty]
        private string titleEntry;

        private readonly DatabaseService _databaseService;


        // Collections
        public ObservableCollection<Expense> ExpensesCollection { get; set; }

        public ObservableCollection<string> CategoriesCollection { get; set; }

		// ----- Commands -----

		// Submit Command
		[RelayCommand(CanExecute = nameof(CanAddExpense))]
        private void AddExpense()
        {
            var newExpense = new Expense()
            {
                StoreName = storeNameEntry,
                Category = categoryEntry,
                Amount = DecimalParser.ParseFlexible(amountEntry),
                CreatedTime = DateTime.Now,
                Title = titleEntry
            };
            newExpense.EnsureTitle();
            _databaseService.AddAsync(newExpense);
            ExpensesCollection.Add(newExpense);
            ClearEntries();
        }

		private bool CanAddExpense()
		{
            if (string.IsNullOrWhiteSpace(storeNameEntry)) return false;

            if(string.IsNullOrWhiteSpace(categoryEntry)) return false;

            if (!DecimalParser.TryParseFlexible(amountEntry, out var amount)) return false;
            if (amount < 0) return false;

            return true;
		}

        // ----- Methods -----

        private void ClearEntries()
        {
            TitleEntry = string.Empty;
            StoreNameEntry = string.Empty;
            CategoryEntry = string.Empty;
            AmountEntry = string.Empty;
        }

        // ----- Constructor -----

        public FormViewModel(DatabaseService databaseService)
		{
			// Initialise Collection
			ExpensesCollection = new ObservableCollection<Expense>();
            CategoriesCollection = new ObservableCollection<string>
            {
                "Rent",
                "Groceries",
                "Leisure",
                "Going out",
                "Car & Insurances",
                "Miscellaneous"
            };
            _databaseService = databaseService;

		}

    }
}
