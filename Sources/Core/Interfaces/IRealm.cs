
namespace Ardelme.Core {
	using System.Collections.Generic;

	/// <summary>Interface of realm.</summary>
	public interface IRealm {
		/// <summary>Gets or sets name of realm</summary>
		string Name { get; set; }

		/// <summary>Gets list of behaviors.</summary>
		IEnumerable<IRealmBehavior> Behaviors { get; }

		/// <summary>Adds behavior to realm.</summary>
		/// <param name="behavior">Behavior to add.</param>
		void AddBehavior(IRealmBehavior behavior);

		/// <summary>Removes behavior from realm.</summary>
		/// <param name="behavior">Behavior to remove.</param>
		void RemoveBehavior(IRealmBehavior behavior);

		/// <summary>Updates realm.</summary>
		/// <param name="delta">Time passed since last update.</param>
		void Update(double delta);

		/// <summary>On game finished.</summary>
		void Finish();

		/// <summary>New user joined to the game as observer.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		bool Enter(User user);

		/// <summary>User outs from the game.</summary>
		/// <param name="user">User.</param>
		void Leave(User user);

		/// <summary>New user joined to the game as player.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		bool Join(User user, Team team);

		/// <summary>Chat message received.</summary>
		/// <param name="user">User who sends the message.</param>
		/// <param name="message">Message.</param>
		/// <param name="channel">Channel.</param>
		void Chat(User user, string message, string channel);

		/// <summary>Users input data.</summary>
		/// <param name="user">User.</param>
		/// <param name="state">Input data.</param>
		void Input(User user, InputState state);

		/// <summary>New entity added to realm.</summary>
		/// <param name="entity">Entity.</param>
		void AddEntity(object entity);

		/// <summary>Entity's state modified.</summary>
		/// <param name="entity">Entity.</param>
		void ModifyEntity(object entity);

		/// <summary>Entity removed from realm.</summary>
		/// <param name="entity">Entity.</param>
		void RemoveEntity(object entity);

		/// <summary>Gets list of entities.</summary>
		IEnumerable<object> Entities { get; }
	}
}
