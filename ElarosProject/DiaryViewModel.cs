using System;
using System.Collections.ObjectModel;
namespace CovidApp.ViewModels

{
	public class DiaryViewModel : BaseViewModel
	{
		public ObservableCollection<Models.diaryEntry> allEntries { get; set; }
		public DiaryViewModel()
		{
			Title = "My Diary";
			allEntries = new ObservableCollection<Models.diaryEntry>();

			allEntries.Add(new Models.diaryEntry("15/12/2022", "School Drop-off, Grocery Shopping", 5));
            allEntries.Add(new Models.diaryEntry("16/12/2022", "Morning walk, interview", 6));
        }
	}
}

