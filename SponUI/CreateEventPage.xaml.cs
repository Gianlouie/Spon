using DevExpress.Maui.Editors;
using RestSharp;
using SponUI.ViewModel;
using SponUI.Models;
using Newtonsoft.Json;

namespace SponUI;

public partial class CreateEventPage : ContentPage
{
	private Guid guid;
	private CreateEventViewModel _vm;
	
	public CreateEventPage(CreateEventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		guid = vm.Guid;
		_vm = vm;
	}

	public void OnDelegateRequested(object sender, ItemsRequestEventArgs e)
	{
		if (e.Text.Length > 3)
		{
			var suggestions = _vm.GetSuggestions(e.Text);

			e.Request = () =>
			{
				return suggestions;
			};
		}
    }
}
