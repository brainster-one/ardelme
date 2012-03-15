
namespace Ardelme.Core {
	/// <summary>Realm's logic interface.</summary>
	public interface IRealmBehavior {
		/// <summary>Update realm.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="delta">Time passed since last update.</param>
		void Update(IRealm realm, double delta);

		/// <summary>On game finished.</summary>
		/// <param name="realm">Realm.</param>
		void Finish(IRealm realm);

		/// <summary>New user joined to the game as observer.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		bool Enter(IRealm realm, User user);

		/// <summary>User outs from the game.</summary>
		/// <param name="user">User.</param>
		void Leave(IRealm realm, User user);

		/// <summary>New user joined to the game as player.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		bool Join(IRealm realm, User user, Team team);

		/// <summary>Chat message received.</summary>
		/// <param name="user">User who sends the message.</param>
		/// <param name="message">Message.</param>
		/// <param name="channel">Channel.</param>
		void Chat(IRealm realm, User user, string message, string channel);

		/// <summary>Users input data.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="user">User.</param>
		/// <param name="keys">Input data.</param>
		void Input(IRealm realm, User user, int[] keys);

		/// <summary>New entity added to realm.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		void AddEntity(IRealm realm, object entity);

		/// <summary>Entity's state modified.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		void ModifyEntity(IRealm realm, object entity);

		/// <summary>Entity removed from realm.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		void RemoveEntity(IRealm realm, object entity);
	}
}
