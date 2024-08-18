using MusicCatalog.Model;
using MusicCatalog.Service;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class PerformanceController
    {
        private PerformanceService performanceService;

        public PerformanceController()
        {
            performanceService = new PerformanceService();
        }

        public List<Performance> GetAllPerformances()
        {
            return performanceService.GetAllPerformances();
        }

        public Performance GetPerformanceById(int id)
        {
            return performanceService.GetPerformanceById(id);
        }

        public void CreatePerformance(Performance performance)
        {
            performanceService.CreatePerformance(performance);
        }

        public void UpdatePerformance(Performance performance)
        {
            performanceService.UpdatePerformance(performance);
        }

        public void DeletePerformance(int id)
        {
            performanceService.DeletePerformance(id);
        }
    }
}
