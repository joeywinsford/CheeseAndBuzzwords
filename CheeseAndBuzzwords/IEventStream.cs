using System.Collections.Generic;

namespace CheeseAndBuzzwords
{
	public interface IEventStream
	{
		void Publish(IEnumerable<IEvent> events);
	}
}