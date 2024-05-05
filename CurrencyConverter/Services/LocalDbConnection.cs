using CurrencyConverter.Models;
using CurrencyConverter.ViewModels;
using CurrencyConverter.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class LocalDbConnection //: ILocalDbConnection
    {
        private readonly string DB_NAME = "converter_db.db3";
        private readonly SQLiteAsyncConnection _connection;
        public static User CurrentUser { get; private set; }
        public LocalDbConnection()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));

            _connection.DeleteAllAsync<Currency>();

            _connection.CreateTableAsync<Currency>();
            _connection.CreateTableAsync<User>();
            _connection.CreateTableAsync<History>();

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Dollars", FlagImageSource = "usa.png", Symbol = "$", ExchangeRateToUSD = 1 }
                );
            _connection.InsertAsync(
                new Currency() { CurrencyName = "Euro", FlagImageSource = "eu.png", Symbol = "€", ExchangeRateToUSD = 0.93 }
                );
            _connection.InsertAsync(
                new Currency() { CurrencyName = "Pounds Sterling", FlagImageSource = "uk.png", Symbol = "£", ExchangeRateToUSD = 0.80 }
                );
            _connection.InsertAsync(
                new Currency() { CurrencyName = "Australian Dollars", FlagImageSource = "australia.png", Symbol = "AU$", ExchangeRateToUSD = 1.53 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Pakistani Rupees", FlagImageSource = "pakistan.png", Symbol = "PKR", ExchangeRateToUSD = 277.29 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Canadian Dollars", FlagImageSource = "canada.png", Symbol = "CA$", ExchangeRateToUSD = 1.37 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Yuan", FlagImageSource = "china.png", Symbol = "¥", ExchangeRateToUSD = 7.24 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Indian Rupees", FlagImageSource = "india.png", Symbol = "INR", ExchangeRateToUSD = 83.45 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "Japanese Yen", FlagImageSource = "japan.png", Symbol = "¥", ExchangeRateToUSD = 155.50 }
                );

            _connection.InsertAsync(
                new Currency() { CurrencyName = "AED", FlagImageSource = "uae.png", Symbol = "AED", ExchangeRateToUSD = 3.67 }
                );
        }

        #region Currency

        public async Task<Currency> AddCurrencyAsync(Currency currency)
        {
            await _connection.InsertAsync(currency);
            return currency;
        }
        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            var result = await _connection.Table<Currency>().ToListAsync();
            return result;
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return await _connection.Table<Currency>().FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region User

        public async Task<User> AddUserAsync(User user)
        {
            await _connection.InsertAsync(user);
            return user;
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _connection.Table<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _connection.Table<User>().ToListAsync();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _connection.Table<User>().FirstOrDefaultAsync(x=>x.Email==email && x.Password == password);
            CurrentUser = user;

            return user != null;
        }

        #endregion

        #region History

        public async Task<History> AddHistoryAsync(History history)
        {
            await _connection.InsertAsync(history);
            return history;
        }

        public async Task<List<History>> GetHistoriesAsync()
        {
           var result = await _connection.Table<History>().ToListAsync();
            return result;
        }

        public async Task<bool> RemoveHistoryAsync(History history)
        {
            await _connection.DeleteAsync(history);
            return true;
        }

        #endregion
    }
}
