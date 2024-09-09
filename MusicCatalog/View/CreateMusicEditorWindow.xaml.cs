using MusicCatalog.Controller;
using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicCatalog.View
{
    /// <summary>
    /// Interaction logic for CreateMusicEditorWindow.xaml
    /// </summary>
    public partial class CreateMusicEditorWindow : Window
    {
        private GenreController genreController;
        private UserController userController = new UserController();
        private MusicEditorController musicEditorController = new MusicEditorController();
        public CreateMusicEditorWindow()
        {
            InitializeComponent();
            genreController = new GenreController();
            LoadGenres();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbSurname.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text) ||
                genreComboBox.SelectedItem == null)
            {
                MessageBox.Show("All fields must be filled and a genre must be selected.");
                return;
            }

            try
            {
                List<Genre> genreHistory = new List<Genre>();
                List<ReviewAndRating> toDoList = new List<ReviewAndRating>();
                RoleEnum.Role role = RoleEnum.Role.MusicEditor;

                // Kreirajte korisnika
                User user = userController.CreateUser(tbName.Text, tbSurname.Text, tbEmail.Text, tbPassword.Text, genreHistory, role);
              

                // Dohvatite odabrani žanr iz ComboBox-a
                Genre selectedGenre = genreComboBox.SelectedItem as Genre;
                if (selectedGenre == null)
                {
                    MessageBox.Show("Please select a valid genre.");
                    return;
                }

                // Kreirajte MusicEditor objekat
                MusicEditor editor = new MusicEditor(
                    id: user.Id,
                    name: tbName.Text,
                    surname: tbSurname.Text,
                    email: tbEmail.Text,
                    password: tbPassword.Text,
                    blocked: false,
                    genreHistory: genreHistory,
                    role: role,
                    rank: 0,
                    genre: selectedGenre,
                    toDoList: toDoList
                );

                // Sačuvajte MusicEditor objekat
                musicEditorController.CreateMusicEditor(editor);
                MessageBox.Show("Account is created successfully!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void LoadGenres()
        {
            try
            {
                List<Genre> genres = genreController.GetAllGenres();
                if (genres != null && genres.Count > 0)
                {
                    genreComboBox.ItemsSource = genres;
                    genreComboBox.DisplayMemberPath = "Type"; 
                    genreComboBox.SelectedValuePath = "Id"; 
                }
                else
                {
                    MessageBox.Show("No genres found. Please add some genres first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading genres: {ex.Message}");
            }
        }
    }
}
