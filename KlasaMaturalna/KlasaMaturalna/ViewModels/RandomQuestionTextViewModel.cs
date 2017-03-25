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

        private int count;
        public static int GetRandomInt(int start, int end)
        {
            Random rnd = new Random();
            int rnum = start + Convert.ToInt32(Math.Floor(rnd.NextDouble() * (end - start + 1)));
            return rnum;
        }

        public RandomQuestionTextViewModel()
        {
            try
            {
                int id;
                Random rnd = new Random();
                this.count = APIServices.countRandomQuesitonsGET();
                if (GetRandomInt(1, 2000)%2 == 0)
                    id = GetRandomInt(1, count);
                else
                    id = rnd.Next(1, count);


                zapytanie = APIServices.qeustionRandomGET(id);
                zapytanie.pytanie = zapytanie.pytanie.Replace("\\n", Environment.NewLine);
                zapytanie.pytanie = zapytanie.pytanie.Replace("\\r", "");
                zapytanie.odpowiedz = zapytanie.odpowiedz.Replace("\\n", Environment.NewLine);
                zapytanie.odpowiedz = zapytanie.odpowiedz.Replace("\\r", "");
                zapytanie.img = zapytanie.img.Replace("\\", "");
                zapytanie.img = zapytanie.img.Replace("\"", "");
                try
                {
                    img = new UriImageSource()
                    {
                        Uri = new Uri(zapytanie.img)
                    };
                }
                catch (Exception)
                {
                }
            }
            catch
            {
               App.Current.MainPage.DisplayAlert("","Kosmici potrzebują połączenia z internetem.", "", "Ok");
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
