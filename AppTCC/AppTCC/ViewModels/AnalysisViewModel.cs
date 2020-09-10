using AppTCC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.ViewModels
{
    public class AnalysisViewModel
    {
        public List<EventData> Events { get; set; }

        public AnalysisViewModel()
        {
            Events = new List<EventData>
            {
                new EventData() { EventDate = "2020-09-09", Normal = 3, Disattention = 7 },
                new EventData() { EventDate = "2020-09-08", Normal = 5, Disattention = 4 },
                new EventData() { EventDate = "2020-09-07", Normal = 7, Disattention = 2 },
                new EventData() { EventDate = "2020-09-06", Normal = 3, Disattention = 8 },
                new EventData() { EventDate = "2020-09-05", Normal = 9, Disattention = 13 },
                new EventData() { EventDate = "2020-09-04", Normal = 1, Disattention = 2 },
            };
        }
    }
}
