using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_projo.Models;

namespace WPF_projo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EventModel> Events { get; set; }

        // ================= POLA FORMULARZA =================
        private string _newEventTitle = string.Empty;
        public string NewEventTitle
        {
            get => _newEventTitle;
            set { _newEventTitle = value; OnPropertyChanged(); }
        }

        private string _newEventDate = string.Empty;
        public string NewEventDate
        {
            get => _newEventDate;
            set { _newEventDate = value; OnPropertyChanged(); }
        }

        private string _newEventDescription = string.Empty;
        public string NewEventDescription
        {
            get => _newEventDescription;
            set { _newEventDescription = value; OnPropertyChanged(); }
        }

        // ================= KOMENDY =================
        public ICommand AddEventCommand { get; }
        public ICommand DeleteEventCommand { get; }
        public ICommand ShowDetailsCommand { get; }

        public MainViewModel()
        {
            // Ładowanie początkowych danych
            Events = new ObservableCollection<EventModel>
            {
                new EventModel { Title = "Koncert Rockowy", Date = "20.03.2026", ShortDescription = "Wstęp wolny." },
                new EventModel { Title = "Wystawa Sztuki", Date = "25.03.2026", ShortDescription = "Lokalni artyści." }
            };

            // Inicjalizacja komend
            AddEventCommand = new RelayCommand(AddEvent, CanAddEvent);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
            ShowDetailsCommand = new RelayCommand(ShowDetails);
        }

        // ================= LOGIKA CRUD =================

        // Sprawdza, czy przycisk "Dodaj" ma być klikalny (wymaga tytułu i daty)
        private bool CanAddEvent(object? obj)
        {
            return !string.IsNullOrWhiteSpace(NewEventTitle) && !string.IsNullOrWhiteSpace(NewEventDate);
        }

        // C - CREATE (Dodawanie)
        private void AddEvent(object? obj)
        {
            var newEvent = new EventModel
            {
                Title = NewEventTitle,
                Date = NewEventDate,
                ShortDescription = NewEventDescription
            };

            Events.Add(newEvent);

            // Czyszczenie formularza po dodaniu
            NewEventTitle = string.Empty;
            NewEventDate = string.Empty;
            NewEventDescription = string.Empty;
        }

        // D - DELETE (Usuwanie)
        private void DeleteEvent(object? obj)
        {
            // 'obj' to wydarzenie przekazane z przycisku w widoku
            if (obj is EventModel eventToDelete)
            {
                Events.Remove(eventToDelete);
            }
        }

        private void ShowDetails(object? obj)
        {
            if (obj is EventModel selectedEvent)
            {
                // Tworzymy nowe okno i przekazujemy mu kliknięte wydarzenie
                EventDetailsWindow detailsWindow = new EventDetailsWindow(selectedEvent);
                detailsWindow.ShowDialog();
            }
        }

        // ================= SYSTEM POWIADOMIEŃ =================
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
