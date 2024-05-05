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
}