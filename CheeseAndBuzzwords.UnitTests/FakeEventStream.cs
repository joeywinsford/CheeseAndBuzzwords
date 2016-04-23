using System.Collections.Generic;

namespace CheeseAndBuzzwords.UnitTests
{
	public class FakeEventStream : IEventStream
	{
		private readonly List<IEvent> _publishedEvents = new List<IEvent>();
		public IEnumerable<IEvent> PublishedEvents => _publishedEvents;
		public void Publish(IEnumerable<IEvent> events)
		{
			_publishedEvents.AddRange(events);
		}
	}
}