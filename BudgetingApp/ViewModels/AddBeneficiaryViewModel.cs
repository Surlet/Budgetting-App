using BudgetingApp.Models;
using BudgetingApp.Services;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.ViewModels
{
    public partial class AddBeneficiaryViewModel: ObservableObject
    {
        //----- Properties -----//

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBeneficiaryCommand))]
        private string beneficiaryName;

        private readonly Popup _popup;

        private readonly DatabaseService _databaseService;

        //----- Commands -----//

        [RelayCommand(CanExecute = nameof(CanAddBeneficiary))]
        private async Task AddBeneficiary()
        {
            var newBeneficiary = new Beneficiary()
            {
                Name = beneficiaryName,
            };
            await _databaseService.AddAsync(newBeneficiary);
            _popup.Close(newBeneficiary);
        }

        public bool CanAddBeneficiary()
        {
            if(beneficiaryName == string.Empty) return false;
            return true;
        }

        [RelayCommand]
        private void Cancel()
        {
            _popup.Close();
        }

        //----- Constructor -----//

        public AddBeneficiaryViewModel(Popup popup, DatabaseService databaseService)
        {
            _popup = popup;
            _databaseService = databaseService;
        }
    }
}
