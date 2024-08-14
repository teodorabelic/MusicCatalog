using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class MusicEditorRepository
    {
        private static MusicEditorRepository instance = null;
        private List<MusicEditor> musicEditors;

        private MusicEditorRepository()
        {
            musicEditors = LoadFromFile();
        }

        public static MusicEditorRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicEditorRepository();
            }
            return instance;
        }

        public List<MusicEditor> GetAll()
        {
            return musicEditors;
        }

        public MusicEditor GetById(int id)
        {
            return musicEditors.FirstOrDefault(editor => editor.Id == id);
        }

        private int GenerateId()
        {
            return musicEditors.Any() ? musicEditors.Max(editor => editor.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/MusicEditorFile.csv", false))
                {
                    foreach (MusicEditor editor in musicEditors)
                    {
                        file.WriteLine(editor.StringToCsv());
                    }
                    file.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Delete(int id)
        {
            MusicEditor editor = GetById(id);
            if (editor == null)
            {
                return;
            }
            musicEditors.Remove(editor);
            Save();
        }

        public void Update(MusicEditor editor)
        {
            MusicEditor oldEditor = GetById(editor.Id);

            if (oldEditor != null)
            {
                oldEditor.Name = editor.Name;
                oldEditor.Surname = editor.Surname;
                oldEditor.Email = editor.Email;
                oldEditor.Password = editor.Password;
                oldEditor.Blocked = editor.Blocked;
                oldEditor.GenreHistory = editor.GenreHistory;
                oldEditor.Rank = editor.Rank;
                oldEditor.Genre = editor.Genre;
                oldEditor.ToDoList = editor.ToDoList;
                Save();
            }
        }

        public List<MusicEditor> Create(MusicEditor editor)
        {
            editor.Id = GenerateId();
            musicEditors.Add(editor);
            Save();
            return musicEditors;
        }

        private List<MusicEditor> LoadFromFile()
        {
            List<MusicEditor> editors = new List<MusicEditor>();

            string filename = "../../../Data/MusicEditorFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');

                        if (tokens.Length < 9)
                        {
                            continue;
                        }

                        List<Genre> genreHistory = tokens[6].Split(',').Select(genreToken =>
                        {
                            var genreData = genreToken.Split('-');
                            return new Genre(int.Parse(genreData[0]), genreData[1]);
                        }).ToList();

                        List<ReviewAndRating> toDoList = tokens[8].Split(',').Select(reviewToken =>
                        {
                            var reviewData = reviewToken.Split('-');
                            return new ReviewAndRating(
                                int.Parse(reviewData[0]),
                                reviewData[1],
                                int.Parse(reviewData[2]),
                                int.Parse(reviewData[3]),
                                bool.Parse(reviewData[4])
                            );
                        }).ToList();

                        MusicEditor editor = new MusicEditor(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            surname: tokens[2],
                            email: tokens[3],
                            password: tokens[4],
                            blocked: bool.Parse(tokens[5]),
                            genreHistory: genreHistory,
                            rank: int.Parse(tokens[7]),
                            genre: new Genre(int.Parse(tokens[6].Split('-')[0]), tokens[6].Split('-')[1]),
                            toDoList: toDoList
                        );

                        editors.Add(editor);
                    }
                }
            }
            return editors;
        }
    }
}
