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
		private string beneficiaryEntry;

		[ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddExpenseCommand))]
        private Category categoryEntry;

		[ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddExpenseCommand))]
        private string amountEntry;

        [ObservableProperty]
        private string titleEntry;

        private readonly DatabaseService _databaseService;


        // Collections
        public ObservableCollection<Expense> ExpensesCollection { get; set; }

        public ObservableCollection<Category> CategoriesCollection { get; set; }

		// ----- Commands -----

		// Submit Command
		[RelayCommand(CanExecute = nameof(CanAddExpense))]
        private void AddExpense()
        {
            var newExpense = new Expense()
            {
                BeneficiaryName = beneficiaryEntry,
                CategoryName = categoryEntry.Name,
                Amount = DecimalParser.ParseFlexible(amountEntry),
                CreatedTime = DateTime.Now,
                Title = titleEntry,
            };
            newExpense.EnsureTitle();
            _databaseService.AddAsync(newExpense);
            ExpensesCollection.Add(newExpense);
            ClearEntries();
        }

		private bool CanAddExpense()
		{
            if (string.IsNullOrWhiteSpace(beneficiaryEntry)) return false;
            if (!DecimalParser.TryParseFlexible(amountEntry, out var amount)) return false;
            if (amount < 0) return false;

            return true;
		}

        // ----- Methods -----

        private void ClearEntries()
        {
            TitleEntry = string.Empty;
            BeneficiaryEntry = string.Empty;
            CategoryEntry = null;
            AmountEntry = string.Empty;
        }

        // ----- Constructor -----

        public FormViewModel(DatabaseService databaseService)
		{
			// Initialise Collection
			ExpensesCollection = new ObservableCollection<Expense>();
            CategoriesCollection = new ObservableCollection<Category>
            {
                new Category{Id = 1, Name = "Rent", LabelColor = Colors.DarkCyan },
                new Category{Id = 2, Name = "Groceries", LabelColor = Colors.Coral },
                new Category{Id = 3, Name = "Leisure", LabelColor = Colors.Gold },
                new Category{Id = 4, Name = "Going out", LabelColor = Colors.DeepPink },
                new Category{Id = 5, Name = "Car & Insurances", LabelColor = Colors.SpringGreen },
                new Category{Id = 6, Name = "Miscellaneous", LabelColor = Colors.PowderBlue }
            };
            _databaseService = databaseService;

		}

    }
}
