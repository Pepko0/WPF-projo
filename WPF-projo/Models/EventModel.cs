using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projo.Models
{
    public class EventModel : INotifyPropertyChanged
    {
        private string _title = string.Empty;
        private string _date = string.Empty;
        private string _shortDescription = string.Empty;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public string ShortDescription
        {
            get => _shortDescription;
            set { _shortDescription = value; OnPropertyChanged(); }
        }

        // Ta sekcja to "magia" powiadamiająca interfejs o zmianach
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
