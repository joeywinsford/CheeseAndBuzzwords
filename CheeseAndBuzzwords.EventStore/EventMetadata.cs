using System.Collections;
using System.Collections.Generic;

namespace CheeseAndBuzzwords.EventStore
{
	internal class EventMetadata : IEnumerable<KeyValuePair<string, object>>
	{
		private const string EventTypeNameKey = "EventClrTypeName";
		private readonly IEvent _event;

		public EventMetadata(IEvent @event)
		{
			_event = @event;
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return new Dictionary<string, object> {{EventTypeNameKey, _event.GetType().AssemblyQualifiedName}}
				.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}