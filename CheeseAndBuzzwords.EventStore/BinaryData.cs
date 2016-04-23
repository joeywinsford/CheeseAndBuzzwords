using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CheeseAndBuzzwords.EventStore
{
	internal class BinaryData : IEnumerable<byte>
	{
		private readonly object _data;

		public BinaryData(object data)
		{
			_data = data;
		}

		public IEnumerator<byte> GetEnumerator()
		{
			return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_data))
				.Cast<byte>()
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}