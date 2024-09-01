﻿using MusicCatalog.Controller;
using MusicCatalog.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MusicCatalog.View
{
    public partial class DisplayMusicWorkRegisteredWindow : Window
    {
        private MusicWork musicWork;
        private MusicWorkController musicWorkController = new MusicWorkController();
        private GenreController genreController = new GenreController();
        private Genre genre;
        private bool isExpanded = false;
        private string fullLyrics;
        private string initialLyrics;
        private List<ReviewAndRating> reviews;
        private ReviewAndRatingController reviewAndRatingController = new ReviewAndRatingController();
        private List<MusicEditor> musicEditors;
        private MusicEditorController musicEditorController = new MusicEditorController();

        public DisplayMusicWorkRegisteredWindow(MusicWork musicWork)
        {
            InitializeComponent();
            this.musicWork = musicWork;
            this.reviews = reviewAndRatingController.GetAll();
            this.musicEditors = musicEditorController.GetAll();
            DisplayMusicWork();
            DisplayReviewsAndRaitings();
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

            string[] lines = fullLyrics.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            initialLyrics = string.Join(Environment.NewLine, lines, 0, Math.Min(6, lines.Length));

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

        private void DisplayReviewsAndRaitings()
        {
            spReviews.Children.Clear();

            foreach (ReviewAndRating review in reviews)
            {
                if (review.MusicWorkId == musicWork.Id && review.Approved)
                {
                    Border reviewBorder = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Margin = new Thickness(0, 5, 0, 5),
                        Padding = new Thickness(10),
                        Background = Brushes.LightGray
                    };

                    StackPanel reviewStackPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };
                    reviewBorder.Child = reviewStackPanel;

                    int grade = review.Grade;
                    char star = '★';
                    string starRating = new string(star, grade);

                    Label lblGrade = new Label
                    {
                        Content = starRating,
                        FontWeight = FontWeights.Bold,
                        FontSize = 18,
                        Foreground = Brushes.Yellow,
                    };
                    reviewStackPanel.Children.Add(lblGrade);

                    TextBlock txtReview = new TextBlock
                    {
                        Text = review.Text,
                        TextWrapping = TextWrapping.Wrap,
                        FontWeight = FontWeights.Bold,
                    };
                    reviewStackPanel.Children.Add(txtReview);

                    string reviewerString = "";
                    foreach (MusicEditor musicEditor in musicEditors)
                    {
                        if (musicEditor.Id == review.ReviewerId)
                        {
                            reviewerString = musicEditor.Name + " " + musicEditor.Surname;
                        }
                    }
                    Label lblReviewerId = new Label
                    {
                        Content = "Reviewer: " + reviewerString,
                        FontWeight = FontWeights.Bold,
                    };
                    reviewStackPanel.Children.Add(lblReviewerId);

                    spReviews.Children.Add(reviewBorder);
                    return;
                }
                else
                {
                    lblNoReviews.Content = "There are no Reviews and Raitings for this music work!";
                    lblNoReviews.Visibility = Visibility.Visible;
                }
            }
        }
    }
}