using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class HistoriesPage : ContentPage
{
	private readonly HistoryViewModel vm;
	public HistoriesPage()
	{
		InitializeComponent();
		BindingContext = vm = new HistoryViewModel();

        Task.Run(async () =>
            await vm.GetHistoriesAsync()
        );

    }

    private async void listConversionItem_Selected(object sender, SelectedItemChangedEventArgs e)
    {
        /*var item = (string)sender;

		await vm.RemoveHistoryAsync(item);*/

        if (e.SelectedItem == null)
            return;

        var selectedItem = (string)e.SelectedItem;
        await vm.RemoveHistoryAsync(selectedItem);

        await Shell.Current.DisplayAlert("Success", "Item deleted", "Ok");
    }
}