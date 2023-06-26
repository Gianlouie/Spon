using DevExpress.Maui.Editors;
using SponUI.ViewModel;

namespace SponUI;

public partial class CreateEventPage : ContentPage
{
	public CreateEventPage(CreateEventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	public void OnDelegateRequested(object sender, ItemsRequestEventArgs e)
	{
		if (e.Text == "u")
		{
			e.Request = () =>
			{
				return new List<string>()
				{
				"ur mum"
				};
			};
		}
		else
		{
            e.Request = () =>
            {
                return new List<string>()
                {
                "not ur mum"
                };
            };
        }
	}
}
