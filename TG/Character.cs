using System.Collections.Generic;
using System.Runtime.Serialization;
using TG.Enums;

namespace TG
{
	public class Character
	{
		public CharacterName CharacterName;
		public CharacterArchetype Archetype;

		public int Bear { get; set; }
		public int Pig { get; set; }
		public int Snake { get; set; }

		public int Dove { get; set; }
		public int Mouse { get; set; }
		public int Owl { get; set; }

		public int MaxHealth { get; set; }
		public int CurrentHealth { get; set; }
		public int MaxEnergy { get; set; }
		public int CurrentEnergy { get; set; }
		public int MaxTerror { get; set; }
		public int CurrentTerror { get; set; }

		public object Skills;





		public Character()
		{

		}
	}

}
