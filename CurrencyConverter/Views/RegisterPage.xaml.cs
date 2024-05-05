using CurrencyConverter.Services;
using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class RegisterPage : ContentPage
{
	private readonly RegisterViewModel vm;
	private readonly LocalDbConnection _connection;
    public string CapturedImageResource = "";

    public RegisterPage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });

        BindingContext = vm = new RegisterViewModel();
	}

    private async void frmProfile_Tap(object sender, TappedEventArgs e)
    {

        if (MediaPicker.Default.IsCaptureSupported)
        {
            //TAKE PHOTO OR CAPTURE PHOTO
            // FileResult myPhoto = await MediaPicker.Default.CapturePhotoAsync();

            //LOAD PHOTO
            FileResult myPhoto = await MediaPicker.Default.CapturePhotoAsync();
            if (myPhoto != null)
            {
                //save the image captured in the application.
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, myPhoto.FileName);
                using Stream sourceStream = await myPhoto.OpenReadAsync();

                CapturedImageResource = localFilePath;

                this.imgProfilePicture.Source = CapturedImageResource;

                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
                //await Shell.Current.DisplayAlert("Success", "Image uploaded successfully", "Ok");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("OOPS", "You device isn't supported", "Ok");
        }
    }
}