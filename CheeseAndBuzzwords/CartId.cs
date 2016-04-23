using System;

namespace CheeseAndBuzzwords
{
	public class CartId : IEquatable<CartId>
	{
		public CartId(Guid id)
		{
			Value = id;
		}

		public Guid Value { get; }

		public bool Equals(CartId other)
		{
			return Value.Equals(other.Value);
		}
	}
}