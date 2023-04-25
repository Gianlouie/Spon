using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestSharp;
using SponUI.Enums;
using SponUI.Models;
using Newtonsoft.Json;

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

        [RelayCommand]
        public async void GetEvents()
        {
            try
            {
                Events.Clear();

                string baseUrl = "https://sponrest.azurewebsites.net/";

                var options = new RestClientOptions(baseUrl);

                var client = new RestClient(options);

                var request = new RestRequest("api/events");

                var response = await client.GetAsync(request);

                Events = JsonConvert.DeserializeObject<ObservableCollection<Event>>(response.Content);

                IsRefreshing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

