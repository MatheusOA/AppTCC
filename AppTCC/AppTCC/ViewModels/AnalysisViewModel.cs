using AppTCC.Interfaces;
using AppTCC.Models;
using AppTCC.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTCC.ViewModels
{
    public class AnalysisViewModel
    {
        public ObservableCollection<DateEvent> Events { get; set; }
        public AnalysisService _analysisService = new AnalysisService();
        private object chart;

        public AnalysisViewModel()
        {

            LoadEvents();
            //Events = new List<DateEvent>
            //{
            //    new DateEvent() { Date = "2020-09-09", Fatigue = 3, Distraction = 7 },
            //};
        }

        public async Task LoadEvents()
        {
            Events = new ObservableCollection<DateEvent>();

            List<DateEvent> events = await _analysisService.GetDateEventsAsync();

            foreach (var item in events)
            {
                Events.Add(item);
            }
            

            //MethodInfo methodInfo = chart.Series[0].GetType().GetMethod("OnBindingPathChanged",
            //                        BindingFlags.NonPublic | BindingFlags.Instance);
            //methodInfo?.Invoke(chart.Series[0], new object[] { null });
        }
    }
}
