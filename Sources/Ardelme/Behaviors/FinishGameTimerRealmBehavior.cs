
namespace Ardelme.Behaviors {
	using System;
	using Core;

	/// <summary>Finsih game timer.</summary>
	public sealed class FinishGameTimerRealmBehavior : RealmBehavior {
		/// <summary>Gets or sets finish time.</summary>
		public DateTime FinishTime { get; set; }
	}
}
