using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Animation;

namespace MusicCatalog.Repository
{
    public class SoloRepository : ArtistRepository
    {
        private static SoloRepository instance = null;
        private List<Solo> solos;
        private readonly string filePath = "../../../Data/SoloFile.csv";

        public SoloRepository(string filePath) : base(filePath)
        {
            this.filePath = filePath;
            solos = LoadFromFile();
        }

        public static SoloRepository GetInstance(string filePath)
        {
            if (instance == null)
            {
                instance = new SoloRepository(filePath);
            }
            return instance;
        }

        public new List<Solo> GetAll()
        {
            return solos;
        }

        public new Solo GetById(int id)
        {
            foreach (Solo solo in solos)
            {
                if (solo.Id == id)
                {
                    return solo;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Solo solo in solos)
            {
                if (solo.Id > maxId)
                {
                    maxId = solo.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter(filePath, false);

                foreach (Solo solo in solos)
                {
                    file.WriteLine(solo.StringToCsv());
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

        public void Update(Solo solo)
        {
            base.Update(solo);
        }

        public List<Solo> Create(Solo solo)
        {
            solo.Id = GenerateId();
            solos.Add(solo);
            Save();
            return solos;
        }

        public List<Solo> LoadFromFile()
        {
            List<Solo> solos = new List<Solo>();

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
                    Solo solo = new Solo(
                        id: Int32.Parse(tokens[0]),
                        name: tokens[1],
                        startDate: DateTime.Parse(tokens[3]),
                        profession: (ProfessionEnum.Profession)Enum.Parse(typeof(ProfessionEnum.Profession), tokens[4]),
                        biography: tokens[5],
                        picture: tokens[6]
                    );
                    solos.Add(solo);
                }
                return solos;
            }
        }
    }
}
