﻿using System;
using System.Linq;
using CheeseAndBuzzwords.Carts;
using Xunit;

namespace CheeseAndBuzzwords.UnitTests.Carts
{
	public class StartingANewCart
	{
		private readonly NewCartStarted _newCartEvent;
		private readonly Guid _newCartId;

		public StartingANewCart()
		{
			_newCartId = Guid.NewGuid();
			var cart = new Cart(new CartId(_newCartId));

			var eventStream = new FakeEventStream();
			cart.Publish(eventStream);

			_newCartEvent = (NewCartStarted)eventStream.PublishedEvents(_newCartId).Single();
		}

		[Fact]
		public void NewCartHasTheCorrectId()
		{
			Assert.Equal(new CartId(_newCartId), _newCartEvent.CartId);
		}

		[Fact]
		public void OpeningTotalIsZero()
		{
			Assert.Equal(new PurchaseTotal(0.0m), _newCartEvent.OpeningTotal);
		}
	}
}
