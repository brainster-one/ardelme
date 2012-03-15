
namespace Ardelme.Core {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>Realm.</summary>
	public sealed class Realm : IRealm {
		/// <summary>Initializes a new instance of the Realm class.</summary>
		public Realm() {
		}

		/// <summary>Initializes a new instance of the Realm class with specified behavior.</summary>
		/// <param name="behavior">Realm behavior.</param>
		public Realm(IRealmBehavior behavior) : this() {
			if (behavior == null) throw new ArgumentNullException("behavior");
			AddBehavior(behavior);
		}

		/// <summary>Initializes a new instance of the Realm class with specified behaviors.</summary>
		/// <param name="behaviors">List of realm behaviors.</param>
		public Realm(IEnumerable<IRealmBehavior> behaviors) : this() {
			foreach (var behavior in behaviors)
				AddBehavior(behavior);
		}

		/// <summary>Gets or sets name.</summary>
		public string Name { get; set; }

		/// <summary>Gets RealmBehavior.</summary>
		public IEnumerable<IRealmBehavior> Behaviors {
			get { return _behaviors.AsReadOnly(); }
		}

		/// <summary>Adds behavior to realm.</summary>
		/// <param name="behavior">Behavior to add.</param>
		public void AddBehavior(IRealmBehavior behavior) {
			_behaviors.Add(behavior);
		}

		/// <summary>Removes behavior from realm.</summary>
		/// <param name="behavior">Behaior to remove.</param>
		public void RemoveBehavior(IRealmBehavior behavior) {
			_behaviors.Remove(behavior);
		}

		/// <summary>Update realm.</summary>
		/// <param name="delta">Time passed since last update.</param>
		public void Update(double delta) {
			_behaviors.ForEach(x => x.Update(this, delta));
		}

		/// <summary>On game finished.</summary>
		public void Finish() {
			_behaviors.ForEach(x => x.Finish(this));
		}

		/// <summary>New user connected to the game.</summary>
		/// <param name="user">User.</param>
		/// <returns>Accept connection?</returns>
		public bool Enter(User user) {
			return _behaviors.Aggregate(true, (current, b) => current && b.Enter(this, user));
		}

		/// <summary>User disconnected from the game.</summary>
		/// <param name="user">User.</param>
		public void Leave(User user) {
			_behaviors.ForEach(x => x.Leave(this, user));
		}

		/// <summary>New user joined a game.</summary>
		/// <param name="user">User.</param>
		/// <returns>Aceept user to the game?</returns>
		public bool Join(User user, Team team) {
			return _behaviors.Aggregate(true, (current, b) => current && b.Join(this, user, team));
		}

		/// <summary>Chat message received.</summary>
		/// <param name="user">User who sends the message.</param>
		/// <param name="message">Message.</param>
		/// <param name="channel">Channel.</param>
		public void Chat(User user, string message, string channel) {
			_behaviors.ForEach(x => x.Chat(this, user, message, channel));
		}

		/// <summary>Users input data.</summary>
		/// <param name="user">User.</param>
		/// <param name="keys">Input data.</param>
		public void Input(User user, int[] keys) {
			_behaviors.ForEach(x => x.Input(this, user, keys));
		}

		/// <summary>New entity added to realm.</summary>
		/// <param name="entity">Entity.</param>
		public void AddEntity(object entity) {
			if (_entites.Contains(entity)) throw new InvalidOperationException("This entity already exist in realm: " + entity.GetType());

			_entites.Add(entity);
			_behaviors.ForEach(x => x.AddEntity(this, entity));
		}

		/// <summary>Entity's state modified.</summary>
		/// <param name="entity">Entity.</param>
		public void ModifyEntity(object entity) {
			if (!_entites.Contains(entity)) throw new InvalidOperationException("Entity does not exist in realm.");

			_behaviors.ForEach(x => x.ModifyEntity(this, entity));
		}

		/// <summary>Entity removed from realm.</summary>
		/// <param name="entity">Entity.</param>
		public void RemoveEntity(object entity) {
			if (!_entites.Contains(entity)) throw new InvalidOperationException("Entity does not exist in realm.");

			_entites.Remove(entity);
			_behaviors.ForEach(x => x.RemoveEntity(this, entity));
		}

		public IEnumerable<object> Entities {
			get { return _entites.AsReadOnly(); }
		}

		/// <summary>Behaviors.</summary>
		readonly List<IRealmBehavior> _behaviors = new List<IRealmBehavior>();

		/// <summary>Entities.</summary>
		readonly List<object> _entites = new List<object>();
	}
}
