using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using KlasaMaturalna.Services;
using KlasaMaturalna.SQLite;
using KlasaMaturalna.Views;
using Xamarin.Forms;
using SQLite;

namespace KlasaMaturalna.ViewModels
{
    public class RandomQuestionTextViewModel : INotifyPropertyChanged
    {

        public UriImageSource img { get { return _img; } set { _img = value; OnPropetyChanged(); } }
        private UriImageSource _img;

        private int count;
        public static int GetRandomInt(int start, int end)
        {
            Random rnd = new Random();
            int rnum = start + Convert.ToInt32(Math.Floor(rnd.NextDouble() * (end - start + 1)));
            return rnum;
        }

        public RandomQuestionTextViewModel()
        {
            visibleStatInfo = false;
            try
            {
                int id;
                Random rnd = new Random();
                this.count = APIServices.countRandomQuesitonsGET();
                if (GetRandomInt(1, 2000) % 2 == 0)
                    id = GetRandomInt(1, count);
                else
                    id = rnd.Next(1, count);


                zapytanie = APIServices.qeustionRandomGET(id);
                zapytanie.pytanie = zapytanie.pytanie.Replace("\\n", Environment.NewLine);
                zapytanie.pytanie = zapytanie.pytanie.Replace("\\r", "");
                zapytanie.odpowiedz = zapytanie.odpowiedz.Replace("\\n", Environment.NewLine);
                zapytanie.odpowiedz = zapytanie.odpowiedz.Replace("\\r", "");
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
                App.Current.MainPage.DisplayAlert("", "Kosmici potrzebują połączenia z internetem.", "", "Ok");
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
        public Command AnswerYESCommand
        {
            get
            {
                return new Command(() =>
                {
                    SQLiteConnection SQLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
                    try
                    {
                        SQLiteConnection.Insert(new StatisticData()
                        {
                            Answer = true,
                            IdQuestion = int.Parse(zapytanie.id)
                        });
                        statisctList = new List<StatisticData>(SQLiteConnection.Table<StatisticData>());

                        foreach (var itm in statisctList.Where(e => e.IdQuestion == int.Parse(zapytanie.id)))
                        {
                            if (itm.Answer)
                                countTrue++;
                            else
                                countFasle++;
                        }
                        statisticInfo =
                            $"Na to pytanie udało Ci się odpowiedzieć {countTrue} poprawnie oraz {countFasle} nie znałeś odpowiedzi.";
                        visibleStatInfo = true;
                    }
                    catch (Exception ex)
                    {
                        SQLiteConnection.CreateTable<StatisticData>();
                        SQLiteConnection.Insert(new StatisticData()
                        {
                            Answer = true,
                            IdQuestion = int.Parse(zapytanie.id)
                        });
                        statisctList = new List<StatisticData>(SQLiteConnection.Table<StatisticData>());

                        foreach (var itm in statisctList.Where(e => e.IdQuestion == int.Parse(zapytanie.id)))
                        {
                            if (itm.Answer)
                                countTrue++;
                            else
                                countFasle++;
                        }
                        statisticInfo =
                            $"Na to pytanie udało Ci się odpowiedzieć {countTrue} poprawnie oraz {countFasle} nie znałeś odpowiedzi.";
                        visibleStatInfo = true;
                    }

                });
            }
        }
        public Command AnswerNOCommand
        {
            get
            {
                return new Command(() =>
                {
                    SQLiteConnection SQLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
                    SQLiteConnection.Insert(new StatisticData() { Answer = false, IdQuestion = int.Parse(zapytanie.id) });
                    statisctList = new List<StatisticData>(SQLiteConnection.Table<StatisticData>());

                    foreach (var itm in statisctList.Where(e => e.IdQuestion == int.Parse(zapytanie.id)))
                    {
                        if (itm.Answer)
                            countTrue++;
                        else
                            countFasle++;
                    }
                    statisticInfo = $"Na to pytanie udało Ci się odpowiedzieć {countTrue} poprawnie oraz {countFasle} nie znałeś odpowiedzi.";
                    visibleStatInfo = true;
                });
            }
        }

        private bool _visibleStatInfo;

        public bool visibleStatInfo
        {
            get { return _visibleStatInfo; }
            set
            {
                _visibleStatInfo = value;
                OnPropetyChanged();
            }
        }

        private string _statisticInfo;

        public string statisticInfo
        {
            get { return _statisticInfo; }
            set
            {
                _statisticInfo = value;
                OnPropetyChanged();
            }
        }

        private int _countTrue;

        public int countTrue
        {
            get { return _countTrue; }
            set
            {
                _countTrue = value;
                OnPropetyChanged();
            }
        }
        private int _countFasle;

        public int countFasle
        {
            get { return _countFasle; }
            set
            {
                _countFasle = value;
                OnPropetyChanged();
            }
        }
        private List<StatisticData> _statisctList;

        public List<StatisticData> statisctList
        {
            get { return _statisctList; }
            set
            {
                _statisctList = value;
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
