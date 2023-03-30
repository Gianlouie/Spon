using SponUI.ViewModel;
using SponUI.Models;

namespace SponUI;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();

		for (int i = 0; i < 3; i++)
		{
			vm.Events.Add(new Event());
		}

        BindingContext = vm;
	}

    

}


