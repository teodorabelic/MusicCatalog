using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using System.Collections.Generic;
using System.IO;

namespace MusicCatalog.Repository
{
    public class BandRepository : ArtistRepository
    {
        private static BandRepository instance = null;
        private List<Band> bands;
        private readonly string filePath = "../../../Data/BandFile.csv";

        public BandRepository(string filePath) : base(filePath)
        {
            this.filePath = filePath;
            bands = LoadFromFile();
        }

        public static BandRepository GetInstance(string filePath)
        {
            if (instance == null)
            {
                instance = new BandRepository(filePath);
            }
            return instance;
        }

        public new List<Band> GetAll()
        {
            return bands;
        }

        public new Band GetById(int id)
        {
            foreach (Band band in bands)
            {
                if (band.Id == id)
                {
                    return band;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Band band in bands)
            {
                if (band.Id > maxId)
                {
                    maxId = band.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter(filePath, false);

                foreach (Band band in bands)
                {
                    file.WriteLine(band.StringToCsv());
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

        public void Update(Band band)
        {
            base.Update(band);
        }

        public List<Band> Create(Band band)
        {
            band.Id = GenerateId();
            bands.Add(band);
            Save();
            return bands;
        }

        public List<Band> LoadFromFile()
        {
            List<Band> bands = new List<Band>();

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
                    Band band = new Band(
                        id: Int32.Parse(tokens[0]),
                        name: tokens[1],
                        participants: StringToList(tokens[2]),
                        startDate: DateTime.Parse(tokens[3]),
                        profession: (ProfessionEnum.Profession)Enum.Parse(typeof(ProfessionEnum.Profession), tokens[4]),
                        biography: tokens[5],
                        picture: tokens[6]
                    );
                    bands.Add(band);
                }
                return bands;
            }
        }

        private List<int> StringToList(string data)
        {
            List<int> dataList = new List<int>();
            string[] tokens = data.Split(',');

            foreach (string token in tokens)
            {
                string trimmedToken = token.Trim();

                if (int.TryParse(trimmedToken, out int value))
                {
                    dataList.Add(value);
                }
                else
                {
                    Console.WriteLine($"Failed to parse: {trimmedToken}");
                }
            }

            return dataList;
        }
    }
}
