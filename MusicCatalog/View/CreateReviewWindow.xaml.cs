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
    /// Interaction logic for CreateReviewWindow.xaml
    /// </summary>
    public partial class CreateReviewWindow : Window
    {
        private ReviewAndRatingController reviewAndRatingController = new ReviewAndRatingController();
        private MusicWork musicWork;
        private MusicEditor musicEditor;
        private User user;

        public CreateReviewWindow(MusicWork musicWork, User user)
        {
            InitializeComponent();
            this.musicWork = musicWork;
            this.user = user;
        }

        private void btnSubmitReview_Click(object sender, RoutedEventArgs e)
        {
            if (cbGrade.SelectedItem == null)
            {
                MessageBox.Show("Please select a grade between 1 and 5.");
                return;
            }

            int grade = int.Parse((cbGrade.SelectedItem as ComboBoxItem).Content.ToString());

            string reviewText = tbReviewText.Text;
            if (string.IsNullOrWhiteSpace(reviewText))
            {
                MessageBox.Show("Please enter some text for the review.");
                return;
            }

            ReviewAndRating newReview = new ReviewAndRating(
                id: -1,
                reviewerId: user.Id,
                text: reviewText,
                grade: grade,
                musicWorkId: musicWork.Id,
                approved: true
            );

            reviewAndRatingController.Create(newReview);

            MessageBox.Show("Review has been submitted successfully!");

            this.Close();
        }

    }
}