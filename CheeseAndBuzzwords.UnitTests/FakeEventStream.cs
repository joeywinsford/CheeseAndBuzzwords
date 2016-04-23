using System;
using System.Collections.Generic;
using System.Linq;

namespace CheeseAndBuzzwords.UnitTests
{
	public class FakeEventStream : IEventStream
	{
		private readonly Dictionary<Guid, List<IEvent>> _aggregates = new Dictionary<Guid, List<IEvent>>();

		public IEnumerable<IEvent> PublishedEvents(Guid aggregateId)
		{
			return _aggregates[aggregateId];
		}

		public void Publish(Aggregate aggregate, IEnumerable<IEvent> events)
		{
			if (_aggregates.ContainsKey(aggregate.Id))
			{
				_aggregates[aggregate.Id].AddRange(events);
			}
			else
			{
				_aggregates[aggregate.Id] = events.ToList();
			}
		}
	}
}