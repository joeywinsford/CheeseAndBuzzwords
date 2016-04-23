namespace CheeseAndBuzzwords
{
	public class Cart
	{
		private readonly Aggregate _aggregate;

		public Cart(CartId id)
		{
			_aggregate = id.BuildAggregate();
			_aggregate.Apply(new NewCartStarted(id, new PurchaseTotal(0.0m)));
		}

		public void Publish(IEventStream eventStream)
		{
			_aggregate.Publish(eventStream);
		}
	}
}