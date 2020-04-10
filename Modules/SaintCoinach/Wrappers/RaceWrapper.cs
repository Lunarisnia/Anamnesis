﻿// Concept Matrix 3.
// Licensed under the MIT license.

namespace ConceptMatrix.SaintCoinachModule
{
	using System.Collections.Generic;
	using ConceptMatrix;
	using ConceptMatrix.Services;
	using SaintCoinach.Xiv;

	internal class RaceWrapper : ObjectWrapper<Race>, IRace
	{
		private Appearance.Races race;

		public RaceWrapper(Race row)
			: base(row)
		{
			this.race = (Appearance.Races)row.Key;
		}

		public Appearance.Races Race
		{
			get
			{
				return this.race;
			}
		}

		public string Feminine
		{
			get
			{
				return this.Value.Feminine;
			}
		}

		public string Masculine
		{
			get
			{
				return this.Value.Masculine;
			}
		}

		public string DisplayName
		{
			get
			{
				if (this.Feminine == this.Masculine)
				{
					return this.Feminine;
				}
				else
				{
					return this.Feminine + " / " + this.Masculine;
				}
			}
		}

		public IEnumerable<ITribe> Tribes
		{
			get
			{
				GameDataService service = Module.Services.Get<GameDataService>();

				List<ITribe> tribes = new List<ITribe>();
				foreach (Appearance.Tribes tribe in this.Race.GetTribes())
				{
					tribes.Add(service.Tribes.Get((byte)tribe));
				}

				return tribes;
			}
		}

		public override string ToString()
		{
			return this.DisplayName;
		}
	}
}
