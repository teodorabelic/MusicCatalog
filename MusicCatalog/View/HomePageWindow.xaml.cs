using MusicCatalog.Controller;
using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MusicCatalog.View
{
    public partial class HomePageWindow : Window
    {
        public List<MusicWork> musicWorks;
        private MusicWorkController musicWorkController = new MusicWorkController();

        public HomePageWindow()
        {
            InitializeComponent();
            this.musicWorks = musicWorkController.GetAll();
            LoadDataFromCSV(musicWorks);
        }
private void LoadDataFromCSV(List<MusicWork> musicWorks)
{
    if (musicWorks == null || musicWorks.Count == 0)
    {
        lblMessage.Content = "No music works available to display.";
        lblMessage.Visibility = Visibility.Visible;
        return;
    }

    lblMessage.Visibility = Visibility.Collapsed;

    MusicWork musicWork = musicWorks[0];
    lblTitle.Content = musicWork.Title;
    lblArtist.Content = musicWork.Artist;
    lblGenre.Content = musicWork.GenreId.ToString(); // Display genre ID
    lblFormat.Content = musicWork.Format;
    lblPublished.Content = musicWork.PublicationDate.ToString("dd-MM-yyyy");

    try
    {
        // Construct the absolute path to the image
        string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, musicWork.Picture);
        BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        imgCover.Source = bitmap;
    }
    catch (Exception ex)
    {
        lblMessage.Content = $"Error loading image: {ex.Message}";
        lblMessage.Visibility = Visibility.Visible;
    }
}




        private string GetGenreNameById(int genreId)
        {
            // Example mapping - replace with real data logic
            switch (genreId)
            {
                case 1: return "Pop";
                case 2: return "Rock";
                case 3: return "Jazz";
                default: return "Unknown";
            }
        }
    }
}
