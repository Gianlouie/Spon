using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestSharp;
using SponUI.Models;
using Newtonsoft.Json;
using SponUI.Util;

namespace SponUI.ViewModel
{
    public partial class MainViewModel : ObservableObject 
    {
        public MainViewModel()
        {
            Events = new ObservableCollection<Event>();
        }

        [ObservableProperty]
        ObservableCollection<Event> events;

        [ObservableProperty]
        Event ev;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        public Event selectedEvent;

        [RelayCommand]
        public async void GetEvents()
        {
            try
            {
                Events?.Clear();

                IsRefreshing = false;
                IsBusy = true;

                LocationServices location = new LocationServices();

                var coordinates = await location.GetCurrentLocation();

                string baseUrl = "https://sponrest.azurewebsites.net/";

                var options = new RestClientOptions(baseUrl);

                RestClient client = new RestClient(options);

                var request = new RestRequest("api/events?Longitude=" + coordinates.Longitude + "&Latitude=" + coordinates.Latitude);

                RestResponse response = new RestResponse();

                response = await client.GetAsync(request);

                Events = JsonConvert.DeserializeObject<ObservableCollection<Event>>(response?.Content);

                LoadImages(Events);

                IsBusy = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [RelayCommand]
        public async void CreateEvent()
        {
            await Shell.Current.GoToAsync(nameof(CreateEventPage));
        }

        [RelayCommand]
        public async void EditEvent()
        {
            if (SelectedEvent != null)
            {
                await Shell.Current.GoToAsync(nameof(CreateEventPage));
                SelectedEvent = null;
            }
        }

        private void LoadImages(ObservableCollection<Event> events)
        {
            foreach (var ev in events)
            {
                if (ev.Photo64 != null)
                {
                    var stream = new MemoryStream(ev.Photo64);

                    var image = ImageSource.FromStream(() => stream);

                    ev.Photo = new Image() { Source = image };
                }
                else
                {
                    ev.Photo = new Image();
                }
            }
        }
    }
}

