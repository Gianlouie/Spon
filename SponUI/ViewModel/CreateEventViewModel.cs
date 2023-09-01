using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using RestSharp;
using SponUI.Models;
using SponUI.Dto;

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

		[ObservableProperty]
		Guid guid;

		[ObservableProperty]
		ObservableCollection<Suggestion> suggestions;

		[ObservableProperty]
		Suggestion selectedSuggestion;

		[ObservableProperty]
		ImageSource uploadedImage;

		[ObservableProperty]
		string selectedActivity;

		[ObservableProperty]
		string selectedDetails;

		[ObservableProperty]
		string selectedCapacity;

		[ObservableProperty]
		string selectedPrice;

		[ObservableProperty]
		bool isSponsorToggled;

		public CreateEventViewModel()
		{
			selectedDate = DateTime.Today;
			minimumDate = DateTime.Today;
			maximumDate = DateTime.Today.AddDays(7);
			selectedTime = DateTime.Now.TimeOfDay;

			uploadedImage = ImageSource.FromFile("upload_image.png");

			guid = Guid.NewGuid();
		}

		[RelayCommand]
		public async void GoBack()
		{
			await Shell.Current.GoToAsync("..", true);
			MainViewModel vm = new MainViewModel();
			vm.GetEvents();
		}

		[RelayCommand]
		public async void UploadImage()
		{
			var result = await FilePicker.PickAsync(new PickOptions
			{
				PickerTitle = "Pick Image Please",
				FileTypes = FilePickerFileType.Images
			});

			if (result != null)
			{
				var stream = await result.OpenReadAsync();

				UploadedImage = ImageSource.FromStream(() => stream);
			}
        }

		public List<Suggestion> GetSuggestions(string searchText)
		{
            string baseUrl = "https://sponrest.azurewebsites.net/";

            var options = new RestClientOptions(baseUrl);

            RestClient client = new RestClient(options);

            var request = new RestRequest("api/Searchbox?searchText=" + searchText + "&guid=" + Guid);

            var response = client.Get(request);

            SearchboxResponse searchBoxResponse = JsonConvert.DeserializeObject<SearchboxResponse>(response.Content);

			Suggestions = new ObservableCollection<Suggestion>();

			foreach(var suggestion in searchBoxResponse.Suggestions)
			{
				Suggestions.Add(suggestion);
			}

			return Suggestions.ToList();
        }

		[RelayCommand]
		public async void SubmitEvent()
		{
			// maybe some validations here TODO
			try
			{
				EventForCreationDto ev = new EventForCreationDto();

				ev.Activity = SelectedActivity;
				ev.StartTime = DateTime.Now + SelectedTime;
				ev.Price = decimal.Parse(SelectedPrice);

				// testing
				var suggestion = SelectedSuggestion;

				ev.Address = new Address()
				{
					Address1 = "345 Conch Shell Ln",
					Address2 = "",
					City = "Casselberry",
                    ZipCode = "32707",
                    State = "Florida"
                };
				ev.Place = SelectedSuggestion.Name;
				ev.Coordinates = new Coordinates()
				{
					Longitude = -81.33732447476923,
					Latitude = 28.663773693717104
				};

				ev.UserId = 4;
				var image = new Image();

				string baseUrl = "https://sponrest.azurewebsites.net/";

				var options = new RestClientOptions(baseUrl);

				RestClient client = new RestClient(options);

				var request = new RestRequest("api/events", Method.Post);

				var evJson = JsonConvert.SerializeObject(ev);

				request.AddBody(evJson, ContentType.Json);

				var response = await client.PostAsync(request);
				
				GoBack();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}

