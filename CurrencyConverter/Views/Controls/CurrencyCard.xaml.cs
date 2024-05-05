namespace CurrencyConverter.Views.Controls;

public partial class CurrencyCard : ContentView
{

    #region Bindable Properties

    //Symbol Property 
    public static readonly BindableProperty SymbolProperty =
        BindableProperty.Create(
            nameof(Symbol),
            typeof(string),
            typeof(CurrencyCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyCard)bindable;
                control.lblSymbol.Text = newValue as string;
            });


    //Name Property 
    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(CurrencyCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyCard)bindable;
                control.lblName.Text = newValue as string;
            });


    //FlagSource Property 
    public static readonly BindableProperty FlagSourceProperty =
        BindableProperty.Create(
            nameof(FlagSource),
            typeof(string),
            typeof(CurrencyCard),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyCard)bindable;
                control.imgFlag.Source = newValue as string;
            });

    #endregion


    public event EventHandler<EventArgs> OnTap;


    #region Properties

    public string Symbol
    {
        get => (string)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    public string FlagSource
    {
        get => (string)GetValue(FlagSourceProperty);
        set => SetValue(FlagSourceProperty, value);
    }

    #endregion

    public CurrencyCard()
	{
		InitializeComponent();
    }

    private void OnTapped(object sender, EventArgs e)
    {
        OnTap?.Invoke(sender, e);
    }
}