using System.Collections.ObjectModel;

namespace BudgetingApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> _categories;
        private const string ADD_CATEGORY = "Add a new category";

        public MainPage()
        {
            InitializeComponent();

            _categories = new ObservableCollection<string>
            {
            "Rent",
            "Groceries",
            "Leisure",
            };

            CategoryPicker.ItemsSource = _categories;
        }



        //private async void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    string selection = picker.SelectedItem as string;

        //    if (selection == ADD_CATEGORY) {
        //        string newCategory = await DisplayPromptAsync(
        //            "New Category", 
        //            "Enter a new category", 
        //            "Submit"
        //            );

        //        if (!string.IsNullOrWhiteSpace(newCategory))
        //        {
        //            if (_categories.Contains(newCategory))
        //            {
        //                await DisplayAlert("Warning", "This category already exists!", "OK");
        //                picker.SelectedIndex = _categories.IndexOf(newCategory);
        //                return;
        //            }

        //            int addIndex = _categories.IndexOf(ADD_CATEGORY);
        //            _categories.Insert(addIndex, newCategory);

        //            picker.SelectedItem = newCategory;
        //        }
        //        else
        //        {
        //            picker.SelectedIndex = -1; 
        //        }
        //    }
        //}
    }

}
