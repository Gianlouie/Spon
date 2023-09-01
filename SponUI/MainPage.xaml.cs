using SponUI.ViewModel;
using SponUI.Models;
using SponUI.Enums;

namespace SponUI;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        vm.GetEvents();

        BindingContext = vm;
    }
}


