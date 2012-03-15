
namespace Ardelme.Core {
	using System;

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

		/// <summary>Gets session.</summary>
		public Guid Session { get; private set; }
	}
}
