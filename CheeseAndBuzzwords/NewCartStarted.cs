﻿namespace CheeseAndBuzzwords
{
	public class NewCartStarted : IEvent
	{
		public NewCartStarted(CartId cartId, PurchaseTotal openingTotal)
		{
			CartId = cartId;
			OpeningTotal = openingTotal;
		}

		public CartId CartId { get; }
		public PurchaseTotal OpeningTotal { get; }
	}
}