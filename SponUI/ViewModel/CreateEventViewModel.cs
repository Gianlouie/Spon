using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SponUI.ViewModel
{
	public partial class CreateEventViewModel : ObservableObject
	{
		[ObservableProperty]
		DateTime selectedDate;

		[ObservableProperty]
		DateTime minimumDate;

		[ObservableProperty]
		DateTime maximumDate;

		[ObservableProperty]
		TimeSpan selectedTime;

		public CreateEventViewModel()
		{
			selectedDate = DateTime.Today;
			minimumDate = DateTime.Today;
			maximumDate = DateTime.Today.AddDays(7);
			selectedTime = DateTime.Now.TimeOfDay;
		}

		[RelayCommand]
		public async void GoBack()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}

