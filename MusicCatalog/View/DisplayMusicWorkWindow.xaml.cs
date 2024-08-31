using MusicCatalog.Controller;
using MusicCatalog.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicCatalog.View
{
    public partial class DisplayMusicWorkWindow : Window
    {
        private MusicWork musicWork;
        private MusicWorkController musicWorkController = new MusicWorkController();
        private GenreController genreController = new GenreController();
        private Genre genre;
        private bool isExpanded = false;
        private string fullLyrics;
        private string initialLyrics;

        public DisplayMusicWorkWindow(MusicWork musicWork)
        {
            InitializeComponent();
            this.musicWork = musicWork;
            DisplayMusicWork();
        }

        private void DisplayMusicWork()
        {
            lblTitle.Content = musicWork.Title;
            lblArtist.Content = musicWork.Artist;
            lblFormat.Content = "Format: " + musicWork.Format;
            genre = genreController.GetGenreById(musicWork.GenreId);
            lblGenre.Content = "Genre: " + genre.Type;
            lblPublished.Content = "Published: " + musicWork.PublicationDate.ToString("dd-MM-yyyy");

            fullLyrics = musicWork.Lyrics.Replace("\\n", Environment.NewLine);

            // Show only the first 4 lines initially
            string[] lines = fullLyrics.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            initialLyrics = string.Join(Environment.NewLine, lines, 0, Math.Min(4, lines.Length));

            tbLyrics.Text = initialLyrics;

            string projectDirectory = musicWorkController.GetProjectDirectory();
            string photoDirectory = System.IO.Path.Combine(projectDirectory, "Photos");
            string imagePath = System.IO.Path.Combine(photoDirectory, musicWork.Picture);

            if (System.IO.File.Exists(imagePath))
            {
                imgPhoto.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            }
            else
            {
                imgPhoto.Source = null;
            }
        }

        private void btnShowMore_Click(object sender, RoutedEventArgs e)
        {
            tbLyrics.Text = fullLyrics;
            btnShowMore.Visibility = Visibility.Collapsed;
            btnShowLess.Visibility = Visibility.Visible;
        }

        private void btnShowLess_Click(object sender, RoutedEventArgs e)
        {
            tbLyrics.Text = initialLyrics;
            btnShowMore.Visibility = Visibility.Visible;
            btnShowLess.Visibility = Visibility.Collapsed;
        }
    }
}
