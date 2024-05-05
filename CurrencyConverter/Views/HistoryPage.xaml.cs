using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class HistoryPage : ContentPage
{
	private readonly HistoryViewModel vm;
	public HistoryPage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        BindingContext = vm = new HistoryViewModel();
        Task.Run(async () =>
           this.listHistory.ItemsSource = (await vm.GetHistories())
                .Select(x=> x.Conversion).ToList()
                );
	}

    private void OnSwipeLeft(object sender, SwipedEventArgs e)
    {
        var o = sender;
    }

    private void OnSwipeRight(object sender, SwipedEventArgs e)
    {

    }
}