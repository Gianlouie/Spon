namespace SponUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreateEventPage), typeof(CreateEventPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}

