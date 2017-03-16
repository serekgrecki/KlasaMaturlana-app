using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using KlasaMaturalna.Services;

namespace KlasaMaturalna.ViewModels
{
    class TodayQuestionViewModel : INotifyPropertyChanged
    {
        private string _todayDate;

        public string TodayDate
        {
            get { return _todayDate; }
            set
            {
                _todayDate = value;
                OnPropetyChanged();
            }
        }

        private List<TodayQuestion> _todayQuestionsList;

        public List<TodayQuestion> TodayQuestionList
        {
            get { return _todayQuestionsList; }
            set
            {
                _todayQuestionsList = value;
                OnPropetyChanged();
            }
        }

        private bool _labelVisable;

        public bool LabelVisable
        {
            get { return _labelVisable; }
            set
            {
                _labelVisable = value;
                OnPropetyChanged();
            }
        }
        public TodayQuestionViewModel()
        {
            TodayDate = DateTime.Today.ToString("yyyy-MM-dd");
            TodayQuestionList = APIServices.quesitonTodayGET();
            LabelVisable = TodayQuestionList.Count == 0 ? true : false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
