using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class LocationPage : ContentPage
{
	private readonly LocationViewModel vm;
	public LocationPage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        BindingContext = vm = new LocationViewModel();

        Task.Run(async () => await vm.GetPermissionAndLocactionAsync()); 
        //Task.Run(async () => await vm.GetCurrentLocation());
    }
}