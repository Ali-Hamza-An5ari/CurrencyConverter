using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ProfilePageViewModel vm;
	public ProfilePage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        BindingContext = vm = new ProfilePageViewModel();
    }
}