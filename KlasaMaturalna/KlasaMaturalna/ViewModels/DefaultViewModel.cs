using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Services;

namespace KlasaMaturalna.ViewModels
{
    class DefaultViewModel : INotifyPropertyChanged
    {
        private List<string> _timetable;

        public List<string> Timetable
        {
            get { return _timetable; }
            set
            {
                _timetable = value;
                OnPropetyChanged();
            }
        }

        public DefaultViewModel()
        {
            var defaultServices = new DefaultServices();
            Timetable = defaultServices.GetTimeTable();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
