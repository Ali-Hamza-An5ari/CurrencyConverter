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
        [ObservableProperty]
        private ObservableCollection<History> histories;

        private readonly LocalDbConnection _connection;

        public HistoryViewModel()
        {
            _connection = new LocalDbConnection();
            /*Task.Run(async () => 
            histories =
            new ObservableCollection<History>(
                await _connection.GetHistoriesAsync()
                )
            );*/
        }

        public async Task<List<History>> GetHistories()
            => await _connection.GetHistoriesAsync();
    

        public async Task RemoveHistoryAsync(History history)
        {
            await _connection.RemoveHistoryAsync(history);
        }
    }
}
