namespace CheeseAndBuzzwords
{
	public class AggregateName
	{
		private readonly string _name;

		public AggregateName(string name)
		{
			_name = name;
		}

		public override string ToString()
		{
			return char.ToLower(_name[0]) + _name.Substring(1);
		}
	}
}