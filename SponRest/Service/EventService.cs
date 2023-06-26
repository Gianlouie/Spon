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
        #region dependencies
        private readonly IEventRepository _eventRepo;
		private readonly GeocodingClient _geocodingClient;
		private readonly MatrixClient _matrixClient;
        #endregion

        #region constants
        private const double METER_TO_MILE_RATIO = 1609.344;
        #endregion

        #region constructor
        public EventService(IEventRepository eventRepo, GeocodingClient geocodingClient, MatrixClient matrixClient)
		{
			_eventRepo = eventRepo;
			_geocodingClient = geocodingClient;
			_matrixClient = matrixClient;
		}
        #endregion

        #region public methods
        public async Task<IEnumerable<Event>> GetEvents(Coordinates currentLocation)
		{
			GeocodeResponse geocodeResponse = await _geocodingClient.GetReverseGeocode(currentLocation);

			var state = geocodeResponse.Features[0].Text;

			var events = await _eventRepo.GetEvents(state);

			events = await SortEventsByDistance(events, currentLocation);

			return events;
		}
        #endregion

        #region private methods
        private async Task<IEnumerable<Event>> SortEventsByDistance(IEnumerable<Event> events, Coordinates currentLocation)
		{
			List<Event> unsortedEvents = new List<Event>();

			var chunkedEvents = events.Chunk(25);

			foreach(var eventChunk in chunkedEvents)
			{
                var evs = eventChunk;

                List<Coordinates> coordinates = new List<Coordinates>
				{
					currentLocation
				};

                foreach (var ev in eventChunk)
				{
					coordinates.Add(ev.Coordinates);
				}

                MatrixResponse matrixReponse = await _matrixClient.GetMatrix(coordinates);

				for (int i = 1; i < matrixReponse.Distances[0].Count; i++)
				{
                    evs[i - 1].Distance = ConvertToMilesFromMeters(matrixReponse.Distances[0][i]);
                }

				unsortedEvents.AddRange(evs);

				coordinates.Clear();
            }

			var sortedEvents = unsortedEvents.OrderBy(o => o.Distance);

			return sortedEvents;
		}

		private float ConvertToMilesFromMeters(float distanceByMeters)
		{
			return (float)(distanceByMeters / METER_TO_MILE_RATIO);
		}
        #endregion
    }
}

