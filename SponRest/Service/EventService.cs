using System;
using SponRest.Contracts;
using SponRest.MapBox.Geocoding;
using SponRest.MapBox.Geocoding.Response;
using SponRest.MapBox.Matrix;
using SponRest.Models;

namespace SponRest.Service
{
	public class EventService : IEventService
	{
        private readonly IEventRepository _eventRepo;
		private readonly GeocodingClient _geocodingClient;
		private readonly MatrixClient _matrixClient;

        public EventService(IEventRepository eventRepo, GeocodingClient geocodingClient, MatrixClient matrixClient)
		{
			_eventRepo = eventRepo;
			_geocodingClient = geocodingClient;
			_matrixClient = matrixClient;
		}

		public async Task<IEnumerable<Event>> GetEvents(Coordinates currentLocation)
		{
			GeocodeResponse geocodeResponse = await _geocodingClient.GetReverseGeocode(currentLocation);

			var state = geocodeResponse.Features[0].Text;

			var events = await _eventRepo.GetEvents(state);

			events = await SortEventsByDistance(events, currentLocation);

			return events;
		}

		private async Task<IEnumerable<Event>> SortEventsByDistance(IEnumerable<Event> events, Coordinates currentLocation)
		{
            List<Coordinates> coordinates = new List<Coordinates>
            {
                currentLocation
            };

            foreach (var ev in events)
			{
				coordinates.Add(ev.Coordinates);
			}

			MatrixResponse matrixReponse = await _matrixClient.GetMatrix(coordinates);

			var evs = events.ToList();

			for (int i = 1; i < matrixReponse.Distances[0].Count; i++)
			{
				evs[i-1].Distance = ConvertToMilesFromMeters(matrixReponse.Distances[0][i]);
			}

			var sortedEvents = evs.OrderBy(o => o.Distance).ToList();

			return sortedEvents;
		}

		private float ConvertToMilesFromMeters(float distanceByMeters)
		{
			return (float)(distanceByMeters / 1609.344);
		}
	}
}

