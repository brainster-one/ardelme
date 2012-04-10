
namespace Ardelme.Core {
	using System;
	using System.Collections.Generic;

	/// <summary>User.</summary>
	public sealed class User {
		/// <summary>Initializes a new instance of the User class.</summary>
		public User() {
			Session = Guid.Empty;
		}

		/// <summary>Initializes a new instance of the User class.</summary>
		/// <param name="sessionId">Session Id.</param>
		public User(Guid sessionId) {
			Session = sessionId;
		}

		/// <summary>Gets or sets related to user objects.</summary>
		/// <param name="index">Index.</param>
		/// <returns>Object.</returns>
		public object this[string index] {
			get { return _objects[index]; }
			set { _objects[index] = value; }
		}

		/// <summary>Gets session.</summary>
		public Guid Session { get; private set; }

		/// <summary>Related to user objects.</summary>
		readonly Dictionary<string, object> _objects = new Dictionary<string, object>();
	}
}
