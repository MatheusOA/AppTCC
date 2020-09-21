using AppTCC.Interfaces;
using AppTCC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    public class MockDataAnalysis: IDataAnalysis<EventData>
    {
        readonly List<EventData> Events;

        public MockDataAnalysis()
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

        public async Task<IEnumerable<EventData>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Events);
        }
    }
}
