using SponUI.ViewModel;
using SponUI.Models;

namespace SponUI;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
        vm.Events.Add(new Event());
		vm.Events.Add(new Event());
        BindingContext = vm;
	}

    

}


