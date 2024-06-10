using System;
using System.Windows;
using System.Windows.Controls;
using AppGestionRH.ViewModels;


namespace AppGestionRH.Views
{
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            bool isAuthenticated = AuthViewModel.Authenticate(username, password);

            if (isAuthenticated)
            {
                // Assurez-vous que MainWindow est référencé correctement
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this)?.Close();
            }
            else
            {
                if (AuthViewModel.IsLockedOut())
                {
                    MessageBox.Show("Votre compte est temporairement verrouillé. Veuillez réessayer après 30 minutes.", "Compte Verrouillé", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect.");
                }
            }
        }
    }
}

