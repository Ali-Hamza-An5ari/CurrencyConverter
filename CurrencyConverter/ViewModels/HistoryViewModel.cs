using CommunityToolkit.Mvvm.ComponentModel;
using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public partial class HistoryViewModel: ObservableObject
    {
        private ObservableCollection<History> histories;

        [ObservableProperty]
        private ObservableCollection<string> conversions;

        private readonly LocalDbConnection _connection;

        public HistoryViewModel()
        {
            _connection = new LocalDbConnection();
            
            Task.Run(async () => 
                await GetHistoriesAsync()
            );
        }

        public async Task<List<History>> GetHistories()
            => await _connection.GetHistoriesAsync();
    

        public async Task RemoveHistoryAsync(string conversion)
        {
            var history = histories.FirstOrDefault(x => x.Conversion == conversion);
            await _connection.RemoveHistoryAsync(history);
        }

        public async Task GetHistoriesAsync()
        {
            histories =
                new ObservableCollection<History>(
                    await _connection.GetHistoriesAsync()
                    );

            conversions = new ObservableCollection<string>
                (
                    histories.Select(x => x.Conversion).ToList()
                );

        }
    }
}
