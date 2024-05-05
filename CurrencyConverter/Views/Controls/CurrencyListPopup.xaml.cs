using CommunityToolkit.Maui.Views;
using CurrencyConverter.Models;
using CurrencyConverter.Services;

namespace CurrencyConverter.Views.Controls;

public partial class CurrencyListPopup : Popup
{

    //Specifies if the call is coming from from-currency of to-currency
    //1 - From, 2 - To
    public static int CurrencyType { get; set; } = 1;

    public static List<Currency> currencies
		= new List<Currency>();


    public CurrencyListPopup()
    {
        InitializeComponent();
        this.listCurrencies.ItemsSource = currencies;
        /*
                currencies.Add(
                    new Currency() { CurrencyName = "Dollars", FlagImageSource = "usa.png", Symbol = "$", ExchangeRateToUSD = 1 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Euro", FlagImageSource = "eu.png", Symbol = "€", ExchangeRateToUSD = 0.93 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Pounds Sterling", FlagImageSource = "uk.png", Symbol = "£", ExchangeRateToUSD = 0.80 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Australian Dollars", FlagImageSource = "australia.png", Symbol = "AU$", ExchangeRateToUSD = 1.53 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Pakistani Rupees", FlagImageSource = "pakistan.png", Symbol = "PKR", ExchangeRateToUSD = 277.29 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Canadian Dollars", FlagImageSource = "canada.png", Symbol = "CA$", ExchangeRateToUSD = 1.37 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Yuan", FlagImageSource = "china.png", Symbol = "¥", ExchangeRateToUSD = 7.24 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "Japanese Yen", FlagImageSource = "japan.png", Symbol = "¥", ExchangeRateToUSD = 155.50 }
                    );


                currencies.Add(
                    new Currency() { CurrencyName = "Indian Rupees", FlagImageSource = "india.png", Symbol = "INR", ExchangeRateToUSD = 83.45 }
                    );

                currencies.Add(
                    new Currency() { CurrencyName = "AED", FlagImageSource = "uae.png", Symbol = "AED", ExchangeRateToUSD = 3.67 }
                    );*/

        //InitializeAsync();
    }


    private void currency_Tapped(object sender, EventArgs e)
    {
        var selectedCard = (Frame)sender;
        var data = (Currency) selectedCard.BindingContext;

        if (CurrencyType == 1)
            ConverterPage.FromCurrency = data;
        else
            ConverterPage.ToCurrency = data;

        this.Close();
    }
}