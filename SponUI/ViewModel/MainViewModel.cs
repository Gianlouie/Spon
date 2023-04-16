using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SponUI.Enums;
using SponUI.Models;

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
        public void GetEvents()
        {
            //Events.Clear();

            Random r = new Random();
           
            List<Attendant> attendants = new List<Attendant>() { new Attendant(), new Attendant(), new Attendant() };

            Events.Add(new Event() { Photo = new Image() { Source = "bowling.png" }, Activity = "Bowling", Place = "Boardwalk Bowl", Price = r.Next(1, 20), Attendants = attendants });
            //Events.Add(new Event() { Activity = "Hiking", Place = "Nature Trail", Attendants = attendants });
            

            IsRefreshing = false;
        }
    }
}

