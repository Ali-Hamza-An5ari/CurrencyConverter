namespace CurrencyConverter.Views.Controls;

public partial class ConverterTabBar : ContentView
{
    //CurrentPage Property 
    public static readonly BindableProperty CurrentPageProperty =
        BindableProperty.Create(
            nameof(CurrentPage),
            typeof(string),
            typeof(ConverterTabBar),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (CurrencyInputCard)bindable;
                //control.lblCurrentPage.Text = newValue as string;
            });


    public string CurrentPage
    {
        get => (string)GetValue(CurrentPageProperty);
        set => SetValue(CurrentPageProperty, value);
    }

    public ConverterTabBar()
	{
		InitializeComponent();
        /*switch (Convert.ToInt32(CurrentPage))
        {
            case 0:
                this.ConverterButton.Source = "sconverteric.png";
                break;
            case 1:
                this.LocationButton.Source = "slocationic.png";
                break;
            case 2:
                this.HistoryButton.Source = "shistoryic.png";
                break;
            default:
                break;
        }*/
	}

    private void tabConverter_Clicked(object sender, EventArgs e)
    {
        NavigateToTab(0);

    }

    private void tabLocation_Clicked(object sender, EventArgs e)
    {
        NavigateToTab(1);

    }

    private void tabHistory_Clicked(object sender, EventArgs e)
    {
        NavigateToTab(2);
    }
    private void NavigateToTab(int tabIndex)
    {

        ConverterButton.Source = "converteric.png";
        LocationButton.Source = "locationic.png";
        HistoryButton.Source = "historyic.png";
        switch(tabIndex)
        {
            case 0:
                //ConverterButton.Source = "sconverteric.png";
                Shell.Current.GoToAsync(nameof(ConverterPage));
                break;
            case 1:
                //LocationButton.Source = "slocationic.png";
                Shell.Current.GoToAsync(nameof(LocationPage));
                break;
            case 2:
                Shell.Current.GoToAsync(nameof(HistoriesPage));
                break;
            case 3:
                Shell.Current.GoToAsync(nameof(ProfilePage));
                break;
            default:
                break;
        }
    }

    private void tabProfile_Clicked(object sender, EventArgs e)
    {
        NavigateToTab(3);
    }
}