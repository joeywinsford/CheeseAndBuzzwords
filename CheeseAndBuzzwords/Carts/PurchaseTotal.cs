﻿using System;

namespace CheeseAndBuzzwords.Carts
{
	public class PurchaseTotal : IEquatable<PurchaseTotal>
	{
		public PurchaseTotal(decimal total)
		{
			Total = total;
		}

		public decimal Total { get; }

		public bool Equals(PurchaseTotal other)
		{
			return Total.Equals(other.Total);
		}
	}
}