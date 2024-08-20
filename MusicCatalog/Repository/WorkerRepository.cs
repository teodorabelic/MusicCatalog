using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using System.Collections.Generic;
using System.IO;

namespace MusicCatalog.Repository
{
    public class WorkerRepository : ArtistRepository
    {
        private static WorkerRepository instance = null;
        private List<Worker> workers;
        private readonly string filePath = "../../../Data/WorkerFile.csv";

        public WorkerRepository(string filePath) : base(filePath)
        {
            this.filePath = filePath;
            workers = LoadFromFile();
        }

        public static WorkerRepository GetInstance(string filePath)
        {
            if (instance == null)
            {
                instance = new WorkerRepository(filePath);
            }
            return instance;
        }

        public new List<Worker> GetAll()
        {
            return workers;
        }

        public new Worker GetById(int id)
        {
            foreach (Worker worker in workers)
            {
                if (worker.Id == id)
                {
                    return worker;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Worker worker in workers)
            {
                if (worker.Id > maxId)
                {
                    maxId = worker.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter(filePath, false);

                foreach (Worker worker in workers)
                {
                    file.WriteLine(worker.StringToCsv());
                }
                file.Flush();
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Delete(int id)
        {
            base.Delete(id);
        }

        public void Update(Worker worker)
        {
            base.Update(worker);
        }

        public List<Worker> Create(Worker worker)
        {
            worker.Id = GenerateId();
            workers.Add(worker);
            Save();
            return workers;
        }

        public List<Worker> LoadFromFile()
        {
            List<Worker> workers = new List<Worker>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split('|');

                    if (tokens.Length < 7)
                    {
                        continue;
                    }
                    Worker worker = new Worker(
                        id: Int32.Parse(tokens[0]),
                        name: tokens[1],
                        startDate: DateTime.Parse(tokens[3]),
                        profession: (ProfessionEnum.Profession)Enum.Parse(typeof(ProfessionEnum.Profession), tokens[4]),
                        biography: tokens[5],
                        picture: tokens[6]
                    );
                    workers.Add(worker);
                }
                return workers;
            }
        }
    }
}
