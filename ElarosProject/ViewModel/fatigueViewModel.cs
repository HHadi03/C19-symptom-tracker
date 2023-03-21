using System;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Common;

namespace ElarosProject.ViewModel
{
    public class fatigueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        databaseConnection db = new databaseConnection();
        private Chart mychart;
        Random rand = new Random();

        public Chart Mychart
        {
            get => mychart;
            set => SetProperty(ref mychart, value);
        }

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static List<Model.fatigueModel> userEntries = new List<Model.fatigueModel>();

        private async void getInfo()
        {
            userEntries = await db.getEntriesByDate();
            var entries = new List<ChartEntry>();
            String[] backgroundCol = new String[] { "#2c3e50", "#77d065", "#34C2DB", "#3498db" };
            foreach (var log in userEntries)
            {
                var entry = new ChartEntry(float.Parse(log.fatigueLevel))
                {
                    Label = log.date,
                    ValueLabel = log.fatigueLevel,
                    TextColor = SKColor.Parse("#3498DB"),
                    Color = SKColor.Parse(backgroundCol[rand.Next(1, 4)])
                };
                entries.Add(entry);
            }

            Mychart = new LineChart
            {
                Entries = entries,
                Margin = 30,
                LineMode = LineMode.Straight,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelOrientation = Orientation.Vertical,
                BackgroundColor = SKColor.Parse("#FFFFFF"),
                LabelTextSize = 25,
                LabelColor = SKColor.Parse("#3498db")
            };
        }
        public fatigueViewModel()
        {
            getInfo();
        }
    }
}


