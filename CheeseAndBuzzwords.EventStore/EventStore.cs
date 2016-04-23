using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EventStore.ClientAPI;

namespace CheeseAndBuzzwords.EventStore
{
	/*
	 *  With thanks to http://belczyk.com/2013/11/eventstore-getting-started/
	 *  and https://github.com/EventStore/getting-started-with-event-store
	 */
	public class EventStore : IEventStream, IDisposable
	{
		private readonly IEventStoreConnection _connection;

		public EventStore(IPEndPoint tcpEndPoint)
		{
			_connection = EventStoreConnection.Create(tcpEndPoint);
			_connection.ConnectAsync().Wait();
		}

		public void Publish(Aggregate aggregate, IEnumerable<IEvent> events)
		{
			_connection
				.AppendToStreamAsync(aggregate.StreamName, ExpectedVersion.NoStream, events.Select(ToEventData))
				.Wait();
		}

		private static EventData ToEventData(IEvent @event)
		{
			const bool isJson = true;
			return 
				new EventData(
					@event.EventId, 
					@event.EventName, 
					isJson, 
					new BinaryData(@event).ToArray(), 
					new BinaryData(new EventMetadata(@event)).ToArray());
		}


		public void Dispose()
		{
			_connection.Close();
		}
	}
}
