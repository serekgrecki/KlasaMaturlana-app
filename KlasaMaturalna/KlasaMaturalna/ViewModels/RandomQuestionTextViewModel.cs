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
    public class RandomQuestionTextViewModel : INotifyPropertyChanged
    {

        public UriImageSource img { get; set; }
     
        private int count = 1;

        public RandomQuestionTextViewModel()
        {
            this.count = APIServices.countRandomQuesitonsGET();
            Random rnd = new Random();
            int id = rnd.Next(1, count + 1);
            zapytanie = APIServices.qeustionRandomGET(id);
            zapytanie.img = zapytanie.img.Replace("\\", "");
            zapytanie.img = zapytanie.img.Replace("\"", "");
            try
            {
                img = new UriImageSource()
                {
                    Uri = new Uri(zapytanie.img)
                };
            }
            catch (Exception ex)
            {
            }
           
        }

        private Question _question;
        public Question zapytanie
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropetyChanged();
            }
        }

        private bool _anwerVisible;
        public bool answerVisible
        {
            get { return _anwerVisible; }
            set
            {
                _anwerVisible = value;
                OnPropetyChanged();
            }
        }

        public Command AnswerCommand
        {
            get
            {
                return new Command(() =>
                {
                    answerVisible = answerVisible == true ? false : true;
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
