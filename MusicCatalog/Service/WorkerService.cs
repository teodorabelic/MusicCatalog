using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class WorkerService
    {
        private static WorkerService instance = null;
        private WorkerRepository workerRepository;

        // Private constructor to initialize the WorkerRepository with a file path
        private WorkerService(string workerFilePath)
        {
            workerRepository = new WorkerRepository();
        }

        public static WorkerService GetInstance(string workerFilePath)
        {
            if (instance == null)
            {
                instance = new WorkerService(workerFilePath);
            }
            return instance;
        }

        public Worker GetById(int id)
        {
            return workerRepository.GetById(id);
        }

        public List<Worker> GetAll()
        {
            return workerRepository.GetAll();
        }

        public List<Worker> Create(Worker worker)
        {
            return workerRepository.Create(worker);
        }

        public void Update(Worker worker)
        {
            workerRepository.Update(worker);
        }

        public void Delete(int id)
        {
            workerRepository.Delete(id);
        }

        public List<Worker> LoadFromFile()
        {
            return workerRepository.LoadFromFile();
        }
    }
}
