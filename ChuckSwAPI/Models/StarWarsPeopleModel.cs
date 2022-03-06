using System;
using System.Collections.Generic;

namespace ChuckSwAPI.Models
{
	public class results
    {
		
		public string name { get; set; }

		public string height { get; set; }
		
		public string hairColour { get; set; }
		
		public string SkinColor { get; set; }
		
		public string eyeColor { get; set; }
		
		public string BirthYear { get; set; }
		
		public string Gender { get; set; }
		
		public string HomeWorld { get; set; }
		
		public List<string> Films { get; set; }
		
		public List<string> Species { get; set; }
		
		public List<string> Vehicles { get; set; }
		
		public List<string> Starships { get; set; }
		
		public DateTime created { get; set; }
		
		public DateTime Edited { get; set; }
		
		public string url { get; set; }

	}
}
