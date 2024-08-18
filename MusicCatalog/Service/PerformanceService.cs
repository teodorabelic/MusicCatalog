using MusicCatalog.Model;
using MusicCatalog.Repository;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class PerformanceService
    {
        private PerformanceRepository performanceRepository;

        public PerformanceService()
        {
            performanceRepository = PerformanceRepository.GetInstance();
        }

        public List<Performance> GetAllPerformances()
        {
            return performanceRepository.GetAll();
        }

        public Performance GetPerformanceById(int id)
        {
            return performanceRepository.GetById(id);
        }

        public void CreatePerformance(Performance performance)
        {
            performanceRepository.Create(performance);
        }

        public void UpdatePerformance(Performance performance)
        {
            performanceRepository.Update(performance);
        }

        public void DeletePerformance(int id)
        {
            performanceRepository.Delete(id);
        }
    }
}
