using System;
using System.Collections;

namespace CovidApp.Models
{
	public class fatigueTracker
	{
        public string date { get; set; }
    
		public ArrayList activities { get; set; }

		public double fatigueLevel { get; set; }

        public fatigueTracker(string entryDate,double level)
		{

			date = entryDate;
			//activities = Activity;
			fatigueLevel = level;

		}
	}
}

