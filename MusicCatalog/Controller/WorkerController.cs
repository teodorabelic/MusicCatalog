using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class WorkerController
    {
        private WorkerService workerService;

        public WorkerController(string workerFilePath)
        {
            workerService = WorkerService.GetInstance(workerFilePath);
        }

        public List<Worker> GetAll()
        {
            return workerService.GetAll();
        }

        public Worker GetById(int id)
        {
            return workerService.GetById(id);
        }

        public List<Worker> Create(Worker worker)
        {
            return workerService.Create(worker);
        }

        public void Update(Worker worker)
        {
            workerService.Update(worker);
        }

        public void Delete(int id)
        {
            workerService.Delete(id);
        }

        public List<Worker> LoadFromFile()
        {
            return workerService.LoadFromFile();
        }
    }
}
