using MusicCatalog.Controller;
using MusicCatalog.Model;
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

    public partial class CreateMusicWorkWindow : Window
    {
        private MusicWorkController musicWorkController;
        private GenreController genreController;
        public CreateMusicWorkWindow()
        {
            InitializeComponent();
            musicWorkController = new MusicWorkController();
            genreController = new GenreController();
            LoadGenres();
        }

        private void LoadGenres()
        {
            try
            {
                List<Genre> genres = genreController.GetAllGenres();
                genreComboBox.ItemsSource = genres;
                genreComboBox.DisplayMemberPath = "Type";
                genreComboBox.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri učitavanju žanrova: {ex.Message}");
            }
        }

        private void CreateMusicWorkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = musicWorkTitleTextBox.Text;
                string artist = artistTextBox.Text;
                string text = textTextBox.Text;
                string picture = pictureTextBox.Text;
                int genreId = (int)genreComboBox.SelectedValue;
                string format = formatTextBox.Text;
                DateTime publicationDate = publicationDatePicker.SelectedDate ?? DateTime.Now;

                MusicWork newMusicWork = new MusicWork(
                    id: 0, 
                    title: title,
                    artist: artist,
                    lyrics: text,
                    picture: picture,
                    genreId: genreId,
                    format: format,
                    publicationDate: publicationDate
                );

                musicWorkController.CreateMusicWork(newMusicWork);

                MessageBox.Show("Muzičko delo je uspešno kreirano.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri kreiranju muzičkog dela: {ex.Message}");
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementirajte funkcionalnost za izbor slike, npr. otvorite dijalog za izbor datoteke
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                pictureTextBox.Text = openFileDialog.FileName;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}