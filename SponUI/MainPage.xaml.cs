using SponUI.ViewModel;
using SponUI.Models;
using SponUI.Enums;

namespace SponUI;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        vm.GetEvents();
    }
}


