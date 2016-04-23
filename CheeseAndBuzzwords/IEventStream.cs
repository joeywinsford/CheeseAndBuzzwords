using System.Collections.Generic;

namespace CheeseAndBuzzwords
{
	public interface IEventStream
	{
		void Publish(Aggregate aggregate, IEnumerable<IEvent> events);
	}
}