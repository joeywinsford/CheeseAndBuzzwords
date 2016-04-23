using System.Collections.Generic;

namespace CheeseAndBuzzwords
{
	public class Cart
	{
		private readonly List<IEvent> _events = new List<IEvent>();

		public Cart(CartId id)
		{
			Apply(new NewCartStarted(id, new PurchaseTotal(0.0m)));
		}

		private void Apply(IEvent @event)
		{
			_events.Add(@event);
		}

		public void Publish(IEventStream eventStream)
		{
			eventStream.Publish(_events);
		}
	}
}