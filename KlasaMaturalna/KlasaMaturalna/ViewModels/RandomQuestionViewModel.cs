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
         public Command RandomQustionCommand
          {
            get
            {
                return new Command(async () =>
                {
                  await App.NavigateMasterDetails(new RandomQuestionTextPage());
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
