using AppTCC.Interfaces;
using AppTCC.Models;
using AppTCC.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    public class AnalysisService
    {
        private AnalysisRepository _analysisRepository = new AnalysisRepository();

        public Task<List<DateEvent>> GetDateEventsAsync()
        {
            return _analysisRepository.GetDateEvents();
        }
    }
}
