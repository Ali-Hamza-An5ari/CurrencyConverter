namespace CurrencyConverter.Views.Controls;

public partial class CurrencyInputCard : ContentView
{

    #region Bindable Properties

    //Symbol Property 
    public static readonly BindableProperty SymbolProperty =
        BindableProperty.Create(
            nameof(Symbol),
            typeof(string),
            typeof(CurrencyInputCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyInputCard)bindable;
                control.lblSymbol.Text = newValue as string;
            });


    //Name Property 
    public static readonly BindableProperty CurrencyNameProperty =
        BindableProperty.Create(
            nameof(CurrencyName),
            typeof(string),
            typeof(CurrencyInputCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyInputCard)bindable;
                control.lblName.Text = newValue as string;
            });


    //FlagSource Property 
    public static readonly BindableProperty FlagSourceProperty =
        BindableProperty.Create(
            nameof(FlagSource),
            typeof(string),
            typeof(CurrencyInputCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyInputCard)bindable;
                control.imgFlag.Source = newValue as string;
            });


    //InputValue Property 
    public static readonly BindableProperty InputValueProperty =
        BindableProperty.Create(
            nameof(InputValue),
            typeof(string),
            typeof(CurrencyInputCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyInputCard)bindable;
                control.txtValue.Text = newValue as string;
            });


    #endregion



    public event EventHandler<EventArgs> OnTap;
    public event EventHandler<EventArgs> OnChange;


    #region Properties

    public string Symbol
    {
        get => (string)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    public string CurrencyName
    {
        get => (string)GetValue(CurrencyNameProperty);
        set => SetValue(CurrencyNameProperty, value);
    }
    public string FlagSource
    {
        get => (string)GetValue(FlagSourceProperty);
        set => SetValue(FlagSourceProperty, value);
    }

    public string InputValue
    {
        get => (string)GetValue(InputValueProperty);
        set => SetValue(InputValueProperty, value);
    }


    #endregion

    public CurrencyInputCard()
    {
        InitializeComponent();
    }

    private void OnTapped(object sender, EventArgs e)
    {
        OnTap?.Invoke(sender, e);
    }

    private void OnChanged(object sender, EventArgs e)
    {
        OnChange?.Invoke(sender, e);
    }
}