using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class HistoriesPage : ContentPage
{
	private readonly HistoryViewModel vm;
	public HistoriesPage()
	{
		InitializeComponent();
		BindingContext = vm = new HistoryViewModel();
	}

    private async void listConversionItem_Selected(object sender, SelectedItemChangedEventArgs e)
    {
		/*var item = (string)sender;

		await vm.RemoveHistoryAsync(item);*/
		await Shell.Current.DisplayAlert("Success", "Item deleted", "Ok");
    }
}