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
    /// <summary>
    /// Interaction logic for HomePageMusicEditorWindow.xaml
    /// </summary>
    public partial class HomePageMusicEditorWindow : Window
    {
        public List<MusicWork> musicWorks;
        private MusicWorkController musicWorkController = new MusicWorkController();
        private GenreController genreController = new GenreController();
        public Genre genre;
        public User user; 
        private MusicEditor musicEditor;
        public HomePageMusicEditorWindow(MusicEditor musicEditor)
        {
            InitializeComponent();
            this.musicWorks = musicWorkController.GetAll();
            this.musicEditor = musicEditor;

            LoadDataFromCSV(musicWorks);
        }

        private void LoadDataFromCSV(List<MusicWork> musicWorks)
        {
            spMusicWorks.Children.Clear();

            if (musicWorks == null || musicWorks.Count == 0)
            {
                lblMessage.Content = "No music works available to display.";
                lblMessage.Visibility = Visibility.Visible;
                return;
            }

            lblMessage.Visibility = Visibility.Collapsed;

            foreach (var musicWork in musicWorks)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(0, 5, 0, 5),
                    Padding = new Thickness(10),
                    Background = Brushes.LightGray
                };

                Grid grid = new Grid();
                border.Child = grid;

                RowDefinition textRow = new RowDefinition();
                RowDefinition buttonRow = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };

                grid.RowDefinitions.Add(textRow);
                grid.RowDefinitions.Add(buttonRow);

                ColumnDefinition textColumn = new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) };
                ColumnDefinition imageColumn = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };

                grid.ColumnDefinitions.Add(textColumn);
                grid.ColumnDefinitions.Add(imageColumn);

                StackPanel textPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(10)
                };
                Grid.SetColumn(textPanel, 0);
                Grid.SetRow(textPanel, 0);

                Label lblTitle = new Label
                {
                    Content = "Title: " + musicWork.Title,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblTitle);

                Label lblArtist = new Label
                {
                    Content = "Artist: " + musicWork.Artist,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblArtist);

                genre = genreController.GetGenreById(musicWork.GenreId);
                Label lblGenre = new Label
                {
                    Content = "Genre: " + genre.Type,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblGenre);

                Label lblFormat = new Label
                {
                    Content = "Format: " + musicWork.Format,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblFormat);

                Label lblPublished = new Label
                {
                    Content = "Published: " + musicWork.PublicationDate.ToString("dd-MM-yyyy"),
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblPublished);

                grid.Children.Add(textPanel);

                string projectDirectory = musicWorkController.GetProjectDirectory();
                string photoDirectory = System.IO.Path.Combine(projectDirectory, "Photos");
                string imagePath = System.IO.Path.Combine(photoDirectory, musicWork.Picture);

                Image imgCover = new Image
                {
                    Height = 110,
                    Width = 110,
                    Margin = new Thickness(10)
                };

                try
                {
                    imgCover.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }

                Grid.SetColumn(imgCover, 1);
                Grid.SetRow(imgCover, 0);
                grid.Children.Add(imgCover);


                Button btnViewMore = new Button
                {
                    Content = "View More",
                    Margin = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                btnViewMore.Click += (s, e) => ViewMore_Click(musicWork);
                Grid.SetColumn(btnViewMore, 0);
                Grid.SetRow(btnViewMore, 1);
                grid.Children.Add(btnViewMore);

                spMusicWorks.Children.Add(border);
            }
        }

        private void ViewMore_Click(MusicWork musicWork)
        {
            DisplayMusicWorkRegisteredWindow displayMusicWorkWindow = new DisplayMusicWorkRegisteredWindow(musicWork, user);
            displayMusicWorkWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Logged out successfully!");
            this.Hide();
            StartWindow start = new StartWindow();
            start.Show();
        }

        private void CreateMusicWork_Click(object sender, RoutedEventArgs e)
        {
         
            CreateMusicWorkWindow createMusicWorkWindow = new CreateMusicWorkWindow();
            createMusicWorkWindow.MusicWorkCreated += OnMusicWorkCreated;
            createMusicWorkWindow.Show();
            
        }

        private void OnMusicWorkCreated(MusicWork newMusicWork)
        {
            this.musicWorks = musicWorkController.GetAll();
            LoadDataFromCSV(musicWorks);
        }

    }
}
