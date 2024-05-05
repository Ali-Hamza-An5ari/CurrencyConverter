using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public partial class LocationViewModel: ObservableObject
    {
        [ObservableProperty]
        private string locationName;


        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        public LocationViewModel()
        {

            //Task.Run(async () => await GetCurrentLocation());
        }

        [RelayCommand]
        public async Task GetPermissionAndLocactionAsync()
        {
            await RequestPermissionsAsync();
            await GetCurrentLocation();
        }
        public async Task RequestPermissionsAsync()
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    // Handle the permission status accordingly
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            });
        }
        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    // Reverse Geocoding
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    if (placemarks != null && placemarks.Count() > 0)
                    {
                        var placemark = placemarks.FirstOrDefault();
                        if (placemark != null)
                        {
                            //Console.WriteLine($"City: {placemark.Locality}, Country: {placemark.CountryName}");
                            LocationName =$"City: {placemark.Locality}, Country: {placemark.CountryName}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        /*
                public async Task GetCurrentLocation()
                {
                    try
                    {
                        _isCheckingLocation = true;

                        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                        _cancelTokenSource = new CancellationTokenSource();

                        Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                        if (location != null)
                            LocationName = $"{location.Latitude} {location.Longitude}";
                            //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }
                    // Catch one of the following exceptions:
                    //   FeatureNotSupportedException
                    //   FeatureNotEnabledException
                    //   PermissionException
                    catch (Exception ex)
                    {
                        // Unable to get location
                    }
                    finally
                    {
                        _isCheckingLocation = false;
                    }
                }
        */
        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
        public async Task<string> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                    return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return "None";
        }
    }
}
