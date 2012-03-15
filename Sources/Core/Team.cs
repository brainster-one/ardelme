
namespace Ardelme.Core {
	/// <summary>Team.</summary>
	public sealed class Team {
		/// <summary>Initializes a new instance of the Team class.</summary>
		public Team() {
		}

		/// <summary>Initializes a new instance of the Team class.</summary>
		/// <param name="id">Id.</param>
		/// <param name="name">Name.</param>
		public Team(int id, string name) {
			Id = id;
			Name = name;
		}

		/// <summary>Gets or sets Id.</summary>
		public int Id { get; set; }

		/// <summary>Gets or sets name.</summary>
		public string Name { get; set; }
	}
}
