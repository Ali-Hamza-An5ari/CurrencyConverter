using CommunityToolkit.Maui.Views;
using CurrencyConverter.Views.Controls;
using CurrencyConverter.Models;
using CurrencyConverter.ViewModels;
using CurrencyConverter.Services;


namespace CurrencyConverter.Views;

public partial class ConverterPage : ContentPage
{
    private ConverterViewModel vm;
    private readonly LocalDbConnection _connection;

    public static Currency FromCurrency {get;set;}
	public static Currency ToCurrency {get;set;}
    public static double ConvertedAmount { get; set; }

    public ConverterPage(LocalDbConnection connection)
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        _connection = connection;
        BindingContext = vm = new ConverterViewModel(_connection);

        FromCurrency = new Currency() { CurrencyName = "Dollars", FlagImageSource = "usa.png", Symbol = "$", ExchangeRateToUSD = 1 };
        ToCurrency = new Currency() { CurrencyName = "Euro", FlagImageSource = "eu.png", Symbol = "€", ExchangeRateToUSD = 0.93 };

        frmFrom.FlagSource = FromCurrency.FlagImageSource;
        frmFrom.Symbol = FromCurrency.Symbol;
        frmFrom.CurrencyName = FromCurrency.CurrencyName;
        frmFrom.InputValue = FromCurrency.ExchangeRateToUSD.ToString();

        frmTo.FlagSource = ToCurrency.FlagImageSource;
        frmTo.Symbol = ToCurrency.Symbol;
        frmTo.CurrencyName = ToCurrency.CurrencyName;
        frmTo.InputValue = ToCurrency.ExchangeRateToUSD.ToString();

        SetResultLabel(
            FromCurrency.ExchangeRateToUSD,
            ToCurrency.ExchangeRateToUSD,
            FromCurrency.CurrencyName,
            ToCurrency.CurrencyName);
    }


    #region From
    private async void frmFrom_Change(object sender, EventArgs e)
    {
        double amountToConvert = Convert.ToDouble(
            ((Entry)sender).Text
            );
        ConvertedAmount = amountToConvert * (ToCurrency.ExchangeRateToUSD / FromCurrency.ExchangeRateToUSD);
        frmTo.InputValue = ConvertedAmount.ToString("0.00");

        await vm.AddHistoryAsync(
        SetResultLabel(
            amountToConvert,
            ConvertedAmount,
            FromCurrency.CurrencyName,
            ToCurrency.CurrencyName)
            ); 
;
    }

    private void frmFrom_Tap(object sender, EventArgs e)
    {
        CurrencyListPopup.CurrencyType = 1;

        var popup = new CurrencyListPopup();
        // Subscribe to the Dismissed event of the popup
        popup.Closed += (s, args) =>
        {
            // Code here will execute after the popup is dismissed
            frmFrom.FlagSource = FromCurrency.FlagImageSource;
            frmFrom.Symbol = FromCurrency.Symbol;
            frmFrom.CurrencyName = FromCurrency.CurrencyName;
        };

        // Show the popup
        this.ShowPopup(popup);
    }

    #endregion

    #region To
    private async void frmTo_Change(object sender, EventArgs e)
    {

        double amountToConvert = Convert.ToDouble(
            ((Entry) sender).Text
            );
        ConvertedAmount = amountToConvert * (FromCurrency.ExchangeRateToUSD / ToCurrency.ExchangeRateToUSD);
        frmFrom.InputValue = ConvertedAmount.ToString("0.00");


        await vm.AddHistoryAsync(
        SetResultLabel(
            amountToConvert,
            ConvertedAmount,
            ToCurrency.CurrencyName,
            FromCurrency.CurrencyName)
        );
    }

    private  void frmTo_Tap(object sender, EventArgs e)
    {

        CurrencyListPopup.CurrencyType = 2;

        var popup = new CurrencyListPopup();
        // Subscribe to the Dismissed event of the popup
        popup.Closed += (s, args) =>
        {
            // Code here will execute after the popup is dismissed
            frmTo.FlagSource = ToCurrency.FlagImageSource;
            frmTo.Symbol = ToCurrency.Symbol;
            frmTo.CurrencyName = ToCurrency.CurrencyName;
        };

        // Show the popup
        this.ShowPopup(popup);
    }

    #endregion

    private string SetResultLabel(double from, double to, string fromCurrency, string toCurrency)
    {
        var text = $"{from.ToString("0.00")} {fromCurrency} = {to.ToString("0.00")} {toCurrency}";
        this.lblResult.Text = text;
        return text;
    }
}