using BudgetingApp.ViewModels;

namespace BudgetingApp.Views;

public partial class TablePage : ContentPage
{
	public TablePage(TableViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		if (BindingContext is TableViewModel viewModel)
		{
			viewModel.LoadExpensesCommand.Execute(this);
		}
    }
}