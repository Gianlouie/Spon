using System;
using SponUI.Models;
namespace SponUI.Util
{
	public class LocationServices
	{
        private async Task<Coordinates> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var coordinates = new Coordinates()
                    {
                        Longitude = location.Longitude,
                        Latitude = location.Latitude
                    };

                    return coordinates;
                }
            }
            catch (Exception ex)
            {
                // Unable to get location
                throw ex;
            }

            return null;
        }

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task<Coordinates> GetCurrentLocation()
        {
            try
            {
                Coordinates cachedCoordinates = await GetCachedLocation();

                if (cachedCoordinates != null)
                {
                    return cachedCoordinates;
                }

                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    var coordinates = new Coordinates()
                    {
                        Longitude = location.Longitude,
                        Latitude = location.Latitude
                    };

                    return coordinates;
                }
            }
            catch (Exception ex)
            {
                // Unable to get location
                throw ex;
            }
            finally
            {
                _isCheckingLocation = false;
            }

            return null;
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }
}

