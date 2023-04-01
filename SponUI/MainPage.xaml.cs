﻿using SponUI.ViewModel;
using SponUI.Models;
using SponUI.Enums;

namespace SponUI;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        LoadEvents(ref vm);

        BindingContext = vm;
    }

    private static void LoadEvents(ref MainViewModel vm)
    {
        Random r = new Random();

        for (int i = 0; i < 3; i++)
        {
            List<Attendant> attendants = new List<Attendant>() { new Attendant(), new Attendant(), new Attendant() };

            vm.Events.Add(new Event() { Price = r.Next(1, 20), Attendants = attendants });
            vm.Events.Add(new Event() { Attendants = attendants});
        }
    }


}


