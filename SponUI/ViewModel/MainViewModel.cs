using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
    }
}

