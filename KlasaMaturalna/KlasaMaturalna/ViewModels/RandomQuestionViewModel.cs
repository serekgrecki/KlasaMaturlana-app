using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using KlasaMaturalna.Services;
using KlasaMaturalna.Views;
using Xamarin.Forms;

namespace KlasaMaturalna.ViewModels
{
    public class RandomQuestionViewModel : INotifyPropertyChanged
    {

        public RandomQuestionViewModel()
        {
            Visible = false;
            Enable = true;
        }

         public Command RandomQustionCommand
          {
            get
            {
                return new Command(async () =>
                {
                    Visible = true;
                    Enable = false;
                  await App.NavigateMasterDetails(new RandomQuestionTextPage());
                });
            }
        }

        private bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropetyChanged();
            }
        }

        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                OnPropetyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
