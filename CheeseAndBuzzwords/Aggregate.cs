using System;
using System.Collections.Generic;

namespace CheeseAndBuzzwords
{
	public class Aggregate
	{
		private readonly List<IEvent> _unpublishedEvents = new List<IEvent>();

		public Aggregate(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }

		public void Apply(IEvent @event)
		{
			_unpublishedEvents.Add(@event);
		}

		public void Publish(IEventStream eventStream)
		{
			eventStream.Publish(this, _unpublishedEvents);
			_unpublishedEvents.Clear();
		}
	}
}