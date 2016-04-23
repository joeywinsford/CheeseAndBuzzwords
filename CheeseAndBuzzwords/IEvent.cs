using System;

namespace CheeseAndBuzzwords
{
	public interface IEvent
	{
		Guid EventId { get; }
		string EventName { get; }
	}
}