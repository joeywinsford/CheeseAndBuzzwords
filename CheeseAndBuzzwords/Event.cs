using System;

namespace CheeseAndBuzzwords
{
	public abstract class Event : IEvent
	{
		protected Event()
		{
			EventId = Guid.NewGuid();
			EventName = GetType().Name;
		}

		public Guid EventId { get; }
		public string EventName { get; }
	}
}