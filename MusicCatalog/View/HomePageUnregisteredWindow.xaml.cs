using MusicCatalog.Controller;
using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            spMusicWorks.Children.Clear(); // Clear existing items

            if (musicWorks == null || musicWorks.Count == 0)
            {
                lblMessage.Content = "No music works available to display.";
                lblMessage.Visibility = Visibility.Visible;
                return;
            }

            lblMessage.Visibility = Visibility.Collapsed;

            foreach (var musicWork in musicWorks)
            {
                // Create a container for each music work
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(0, 5, 0, 5),
                    Padding = new Thickness(10),
                    Background = Brushes.LightGray
                };

                // Create a Grid to organize text and image
                Grid grid = new Grid();
                border.Child = grid;

                // Define rows for text content and button
                RowDefinition textRow = new RowDefinition();
                RowDefinition buttonRow = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };

                grid.RowDefinitions.Add(textRow);
                grid.RowDefinitions.Add(buttonRow);

                // Define columns for text and image
                ColumnDefinition textColumn = new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) };
                ColumnDefinition imageColumn = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };

                grid.ColumnDefinitions.Add(textColumn);
                grid.ColumnDefinitions.Add(imageColumn);

                // Create a StackPanel to hold the text content
                StackPanel textPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(10)
                };
                Grid.SetColumn(textPanel, 0);
                Grid.SetRow(textPanel, 0);

                // Create and add the Title Label
                Label lblTitle = new Label
                {
                    Content = "Title: " + musicWork.Title,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblTitle);

                // Create and add the Artist Label
                Label lblArtist = new Label
                {
                    Content = "Artist: " + musicWork.Artist,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblArtist);

                // Create and add the Genre Label
                Label lblGenre = new Label
                {
                    Content = "Genre: " + musicWork.GenreId.ToString(),
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblGenre);

                // Create and add the Format Label
                Label lblFormat = new Label
                {
                    Content = "Format: " + musicWork.Format,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblFormat);

                // Create and add the Published Date Label
                Label lblPublished = new Label
                {
                    Content = "Published: " + musicWork.PublicationDate.ToString("dd-MM-yyyy"),
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblPublished);

                // Create and add the Text Label
                Label lblText = new Label
                {
                    Content = "Text: " + musicWork.Text,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                textPanel.Children.Add(lblText);

                // Add the StackPanel to the Grid
                grid.Children.Add(textPanel);

                // Create and add the Image
                Image imgCover = new Image
                {
                    Height = 110,
                    Width = 110,
                    Margin = new Thickness(10),
                    Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, musicWork.Picture), UriKind.Absolute))
                };
                Grid.SetColumn(imgCover, 1);
                Grid.SetRow(imgCover, 0);
                grid.Children.Add(imgCover);

                // Create and configure the View More button
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

                // Add the Border (containing the Grid) to the ScrollViewer
                spMusicWorks.Children.Add(border);
            }
        }



        private void ViewMore_Click(MusicWork musicWork)
        {
            // Handle the "View More" button click event
            MessageBox.Show($"View more details for: {musicWork.Title}");
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = tbSearch.Text.ToLower();

            var filteredMusicWorks = musicWorks.Where(mw =>
            mw.Title.ToLower().Contains(searchText) ||
            mw.Artist.ToLower().Contains(searchText)).ToList();

            LoadDataFromCSV(filteredMusicWorks);
        }

    }
}
