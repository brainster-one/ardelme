using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ardelme.Core {
	public class InputState {
		public InputState(IDictionary<string, object> state) {
			_state = new Dictionary<string, object>(state);
		}

		public T Get<T>(string key) {
			object value;
			_state.TryGetValue(key, out value);
			if (value == null) throw new KeyNotFoundException(key);
			return (T)value;
		}

		readonly Dictionary<string, object> _state;
	}
}
