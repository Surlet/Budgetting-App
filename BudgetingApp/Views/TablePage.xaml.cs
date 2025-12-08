using BudgetingApp.ViewModels;

namespace BudgetingApp.Views;

public partial class TablePage : ContentPage
{
	public TablePage(TableViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}