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
using MusicCatalog.Controller;
using MusicCatalog.Model;
using MusicCatalog.ModelEnum;

namespace MusicCatalog.View
{
    public partial class SignUpWindow : Window
    {
        private UserController userController = new UserController();
        StartWindow startWindow = new StartWindow();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            List<Genre> genreHistory = new List<Genre>();
            RoleEnum.Role role = RoleEnum.Role.User;
            userController.CreateUser(tbName.Text, tbSurname.Text, tbEmail.Text,
                    tbPassword.Text, genreHistory, role);
            MessageBox.Show("Account is created successfully! Turn back on login");

            startWindow.Show();
            this.Hide();

        }
    }
}

