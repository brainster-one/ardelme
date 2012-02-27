
namespace Ardelme.Behaviors {
	using System.Collections.Generic;
	using System.Linq;
	using Core;

	/// <summary>Modified entity state.</summary>
	public enum ModifiedEntityState {
		/// <summary>Entity added to realm.</summary>
		Added,

		/// <summary>Entity state changed.</summary>
		Modified,

		/// <summary>Entity removed.</summary>
		Removed
	}

	/// <summary>Modified entity and state.</summary>
	public sealed class ModifiedEntityStatePair {
		/// <summary>Initializes a new instance of the ModifiedEntityStatePair class.</summary>
		/// <param name="entity">Entity.</param>
		/// <param name="state">State.</param>
		public ModifiedEntityStatePair(IEntity entity, ModifiedEntityState state) {
			Entity = entity;
			State = state;
		}

		/// <summary>Gets entity.</summary>
		public IEntity Entity { get; private set; }

		/// <summary>Gets modification state.</summary>
		public ModifiedEntityState State { get; private set; }
	}

	/// <summary>Modified entities logic behavior.</summary>
	public sealed class ModifiedEntitiesRealmBehavior : RealmBehavior {
		/// <summary>New antity added.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		public override void AddEntity(IRealm realm, IEntity entity) {
			lock (_modified) {
				_modified[entity] = ModifiedEntityState.Added;
			} 
		}

		/// <summary>Entity modified.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		public override void ModifyEntity(IRealm realm, IEntity entity) {
			lock (_modified) {
				if (!_modified.Any(x => x.Key == entity && x.Value == ModifiedEntityState.Added))
					_modified[entity] = ModifiedEntityState.Modified;
			}
		}

		/// <summary>Entity removed.</summary>
		/// <param name="realm">Realm.</param>
		/// <param name="entity">Entity.</param>
		// TODO Не синхронизировать объекты которые прошли стадии Added/Changed/Removed за один игровой такт.
		// Ибо объект уже удалён, а на клиентах он ещё не был создан.
		public override void RemoveEntity(IRealm realm, IEntity entity) {
			lock(_modified) { _modified[entity] = ModifiedEntityState.Removed; }
		}

		/// <summary>Return modified entities since last call.</summary>
		/// <returns>List of modified entities.</returns>
		public IEnumerable<ModifiedEntityStatePair> GetModifiedEntities() {
			lock (_modified) {
				var listToReturn = _modified.Select(x => new ModifiedEntityStatePair(x.Key, x.Value)).ToList();
				_modified.Clear();
				return listToReturn;
			}
		}

		/// <summary>Events.</summary>
		readonly Dictionary<IEntity, ModifiedEntityState> _modified = new Dictionary<IEntity, ModifiedEntityState>();
	}
}
