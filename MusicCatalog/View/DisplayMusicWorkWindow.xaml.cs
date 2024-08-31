using MusicCatalog.Controller;
using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicCatalog.View
{
    public partial class DisplayMusicWorkWindow : Window
    {
        private MusicWork musicWork;
        private MusicWorkController musicWorkController = new MusicWorkController();

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
            lblGenre.Content = "Genre: " + musicWork.GenreId.ToString();
            lblPublished.Content = "Published: " + musicWork.PublicationDate.ToString("dd-MM-yyyy");
            lblLyrics.Content = musicWork.Lyrics;

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
    }
}
