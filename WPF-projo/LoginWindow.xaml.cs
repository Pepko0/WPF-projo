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
using WPF_projo.Models;

namespace WPF_projo
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Pobieramy wpisane dane
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Magia LINQ: Szukamy na naszej statycznej liście pierwszego użytkownika, 
            // który ma taki sam login ORAZ takie samo hasło, jakie wpisano w okienku.
            var user = MockDatabase.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            // Jeśli zmienna 'user' nie jest pusta (czyli znaleźliśmy kogoś), to logujemy
            if (user != null)
            {
                MessageBox.Show($"Zalogowano pomyślnie! Witaj.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
