﻿using MusicCatalog.Controller;
using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class StartWindow : Window
    {
        public List<User> users;
        public List<Admin> admins;
        public static HomePageRegisteredWindow homePageRegisteredWindow;
        public static HomePageAdminWindow homePageAdminWindow;
        public static HomePageMusicEditorWindow homePageMusicEditorWindow;
        public UserService userService;
        private UserController userController = new UserController();
        private AdminController adminController = new AdminController();
        private MusicEditorController musicEditorController = new MusicEditorController();
       
        public StartWindow()
        {
            InitializeComponent();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            {
                HomePageUnregisteredWindow homePageUnregisteredWindow = new HomePageUnregisteredWindow();
                homePageUnregisteredWindow.Show();
                this.Hide();
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            {
                SignUpWindow signUpWindow = new SignUpWindow();
                signUpWindow.Show();
                this.Hide();
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            Admin admin = null;
            MusicEditor musicEditor = null;

            string email = tbEmail.Text;
            string password = tbPassword.Password;

            if (email != "" && password != "")
            {
                (object person, string role) = userController.IsLoggedIn(email, password);
                if (person != null)
                {
                    switch (role)
                    {
                        case "User":

                            user = person as User;
                            if (user != null)
                            {
                                homePageRegisteredWindow = new HomePageRegisteredWindow(user);
                                lblLogIn.Content = "";
                                homePageRegisteredWindow.Show();
                                this.Hide();
                                tbClear();
                            }
                            break;

                        case "Admin":
                            user = person as User;
                            if (user != null)
                            {
                                admin = adminController.GetAdminById(user.Id);
                                homePageAdminWindow = new HomePageAdminWindow(admin);
                                lblLogIn.Content = "";
                                homePageAdminWindow.Show();
                                this.Hide();
                                tbClear();
                            }
                            break;

                        case "MusicEditor":
                            user = person as User;
                            if (user != null)
                            {
                                musicEditor = musicEditorController.GetMusicEditorById(user.Id);
                                homePageMusicEditorWindow = new HomePageMusicEditorWindow(musicEditor); 
                                lblLogIn.Content = "";
                                homePageMusicEditorWindow.Show();
                                this.Hide();
                                tbClear();
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    lblLogIn.Content = "Non-existent user. Please try again.";
                    tbClear();
                }
            }
            else
            {
                lblLogIn.Content = "Please enter email and password!";
            }

        }
        private void tbClear()
        {
            tbEmail.Text = "";
            tbPassword.Password = "";
        }
    }
}
