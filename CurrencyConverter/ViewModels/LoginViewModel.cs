using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurrencyConverter.Services;
using CurrencyConverter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        private readonly LocalDbConnection _connection;
        public LoginViewModel()
        {
            _connection = new LocalDbConnection();
        }
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        public async void Register()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));

        }

        [RelayCommand]
        public async void Login()
        {

            if(!await _connection.LoginAsync(Email, Password))
            {
                await Shell.Current.DisplayAlert("Error", "Invalid credentials", "Ok");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(ConverterPage));
            }

        }
    }
}
