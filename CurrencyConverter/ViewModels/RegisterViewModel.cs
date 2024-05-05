using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurrencyConverter.Services;
using CurrencyConverter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public partial class RegisterViewModel: ObservableObject
    {
        private readonly LocalDbConnection _connection;

        public RegisterViewModel()
        {
            _connection = new LocalDbConnection();
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private string profilePictureSource = "camera.png";

        [RelayCommand]
        public async void CaptureImage()
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

                    ProfilePictureSource = localFilePath;

                    //this.imgProfilePicture.Source = CapturedImageResource;

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

        [RelayCommand]
        public async void Register()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await Shell.Current.DisplayAlert("Error", "Name cannot be empty", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Email))
            { 
                await Shell.Current.DisplayAlert("Error", "Email cannot be empty", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            { 
                await Shell.Current.DisplayAlert("Error", "Password cannot be empty", "Ok");
                return;
            }

            await _connection.AddUserAsync(new Models.User()
            {
                Name = Name,
                Email = Email,
                Password = Password,
                PhoneNumber = PhoneNumber,
                ProfilePictureSource = ProfilePictureSource
            });

            await Shell.Current.DisplayAlert("Success", "User created successfully", "Ok");
            await Shell.Current.GoToAsync("///" + nameof(LoginPage));

        }

        [RelayCommand]
        public async void Login()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
