using System;
using System.Collections;

namespace ElarosProject.Models
{
	public class fatigueTracker
	{
        public string date { get; set; }
    
		public ArrayList activities { get; set; }

		public double fatigueLevel { get; set; }

        public fatigueTracker(string entryDate)
		{

			date = entryDate;
			//activities = Activity;
			//fatigueLevel = level;

		}
	}
}

