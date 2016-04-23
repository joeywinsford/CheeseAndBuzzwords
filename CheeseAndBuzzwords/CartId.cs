using System;

namespace CheeseAndBuzzwords
{
	public class CartId : IEquatable<CartId>
	{
		private Guid _id;

		public CartId(Guid id)
		{
			_id = id;
		}

		public bool Equals(CartId other)
		{
			return _id.Equals(other._id);
		}
	}
}