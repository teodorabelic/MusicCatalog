using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicCatalog.ModelEnum.RoleEnum;

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

                        if (tokens.Length != 11)
                        {
                            continue;
                        }

                        // Parse genreHistory as a list of Genre objects
                        List<Genre> genreHistory = tokens[6].Split(',').Select(id =>
                        {
                            return new Genre(int.Parse(id), "Unknown"); // Assuming genre names are not provided; use a default name or adjust if necessary
                        }).ToList();

                        // Handle toDoList if it is in a different format or if it's not present, initialize as empty list
                        List<ReviewAndRating> toDoList = new List<ReviewAndRating>(); // Adjust if you have a specific format for this field

                        MusicEditor editor = new MusicEditor(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            surname: tokens[2],
                            email: tokens[3],
                            password: tokens[4],
                            blocked: bool.Parse(tokens[5]),
                            genreHistory: genreHistory,
                            role: (ModelEnum.RoleEnum.Role)Enum.Parse(typeof(ModelEnum.RoleEnum.Role), tokens[7]),
                            rank: int.Parse(tokens[8]),
                            genre: new Genre(int.Parse(tokens[9]), "Unknown"), // Assuming genre information; adjust if necessary
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
