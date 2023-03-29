using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class DataVisualizationModel
    {
        public string Label { get; set; }
        public string SKColor { get; set; }

        public DataVisualizationModel(string label, string color) 
        {
            Label = label;
            SKColor = color;
        }
    }
}
