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
    /// Logika interakcji dla klasy EventDetailsWindow.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        private bool _isEditing = false; // Zapamiętuje, czy jesteśmy w trybie edycji

        // Zmieniliśmy konstruktor, aby przyjmował kliknięty EventModel
        public EventDetailsWindow(EventModel selectedEvent)
        {
            InitializeComponent();

            // MAGIA BINDOWANIA: Ustawiamy kliknięte wydarzenie jako dostarczyciela danych dla tego okna!
            DataContext = selectedEvent;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isEditing)
            {
                // WŁĄCZAMY TRYB EDYCJI
                _isEditing = true;
                TitleBox.IsReadOnly = false;
                DateBox.IsReadOnly = false;
                DescBox.IsReadOnly = false;

                EditBtn.Content = "Zakończ edycję";
                EditBtn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 174, 96)); // Zmiana na zielony
            }
            else
            {
                // WYŁĄCZAMY TRYB EDYCJI
                _isEditing = false;
                TitleBox.IsReadOnly = true;
                DateBox.IsReadOnly = true;
                DescBox.IsReadOnly = true;

                EditBtn.Content = "Edytuj";
                EditBtn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(243, 156, 18)); // Powrót na pomarańczowy
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Po prostu zamyka okno
        }
    }
}
