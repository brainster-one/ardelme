
namespace Ardelme.Core {
	/// <summary>Abstract logic behavior.</summary>
	public abstract class RealmBehavior : IRealmBehavior {
		/// <summary>Calls then realm updateing.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="delta">Time passed since last update.</param>
		public virtual void Update(IRealm realm, double delta) { }

		/// <summary>Calls then realm finished.</summary>
		/// <param name="realm">Realm.</param>
		public virtual void Finish(IRealm realm) { }

		/// <summary>New user joined to the game as observer.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		public virtual bool Enter(IRealm realm, User user) { return true; }

		/// <summary>User outs from the game.</summary>
		/// <param name="user">User.</param>
		public virtual void Leave(IRealm realm, User user) { }

		/// <summary>New user joined to the game as player.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		public virtual bool Join(IRealm realm, User user, Team team) { return true; }

		/// <summary>Chat message received.</summary>
		/// <param name="user">User who sends the message.</param>
		/// <param name="message">Message.</param>
		/// <param name="channel">Channel.</param>
		public virtual void Chat(IRealm realm, User user, string message, string channel) { }

		/// <summary>User's input data received.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="user">User.</param>
		/// <param name="keys">Keys and mouse events.</param>
		public virtual void Input(IRealm realm, User user, int[] keys) { }

		/// <summary>New antity added.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		public virtual void AddEntity(IRealm realm, object entity) { }

		/// <summary>Entity modified.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		public virtual void ModifyEntity(IRealm realm, object entity) { }

		/// <summary>Entity removed.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		public virtual void RemoveEntity(IRealm realm, object entity) { }
	}
}
