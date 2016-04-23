using System;
using System.Collections.Generic;

namespace CheeseAndBuzzwords
{
	public class Aggregate
	{
		private readonly AggregateName _aggregateName;
		private readonly List<IEvent> _unpublishedEvents = new List<IEvent>();

		public Aggregate(Guid id, AggregateName aggregateName)
		{
			_aggregateName = aggregateName;
			Id = id;
		}

		public Guid Id { get; }
		public string StreamName => $"{_aggregateName}-{Id}";
		public int Version => 0;

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