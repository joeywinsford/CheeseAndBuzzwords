using System;

namespace CheeseAndBuzzwords
{
	public class PurchaseTotal : IEquatable<PurchaseTotal>
	{
		private readonly decimal _total;

		public PurchaseTotal(decimal total)
		{
			_total = total;
		}

		public bool Equals(PurchaseTotal other)
		{
			return _total.Equals(other._total);
		}
	}
}