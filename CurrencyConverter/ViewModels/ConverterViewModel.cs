using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurrencyConverter.Models;
using CurrencyConverter.Services;
using CurrencyConverter.Views.Controls;

namespace CurrencyConverter.ViewModels
{
    public partial class ConverterViewModel:ObservableObject
    {
        private readonly LocalDbConnection _connection;

        public ConverterViewModel(LocalDbConnection connection)
        {
            _connection = connection; 
            Task.Run(async () => CurrencyListPopup.currencies = await _connection.GetCurrenciesAsync());

        }

        [ObservableProperty]
        private Currency from;

        [ObservableProperty]
        private string fromInput;

        [ObservableProperty]
        private string toInput;

        [RelayCommand]
        public async void changeFromText(string input)
        {
            ToInput = input;
        }

        [RelayCommand]
        public void changeToText(string input)
        {
            FromInput = input;
        }

        public async Task AddHistoryAsync(string conversion)
        {
            await _connection.AddHistoryAsync(new History()
            {
                Conversion = conversion
            });
        }

    }
}
