using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class LoginPage : ContentPage
{
	private readonly LoginViewModel vm;
	public LoginPage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        BindingContext = vm = new LoginViewModel();
	}
}