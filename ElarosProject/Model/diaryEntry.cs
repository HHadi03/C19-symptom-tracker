using System;
namespace ElarosProject.Models
{
	public class diaryEntry
	{
		public string date { get; set; }
        public string activities { get; set; }
        public int fatigueLevel{ get; set; }
  
        public diaryEntry(string Date,string Activities,int fatigue)
		{
			date = Date;
			activities = Activities;
			fatigueLevel = fatigue;
		}
	}
}

