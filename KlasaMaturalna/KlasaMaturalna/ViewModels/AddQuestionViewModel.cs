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
    class AddQuestionViewModel : INotifyPropertyChanged
    {
        private List<string> _numerQuestionsList;

        public List<string> NumberQuestionsList
        {
            get { return _numerQuestionsList; }
            set
            {
                _numerQuestionsList = value;
                OnPropetyChanged();
            }
        }

        private int _indexNumerQuestion;

        public int IndexNumberQuestion
        {
            get { return _indexNumerQuestion; }
            set
            {
                _indexNumerQuestion = value;
                OnPropetyChanged();
            }
        }

        private string _questionContent;

        public string QuestionContent
        {
            get { return _questionContent; }
            set
            {
                _questionContent = value;
                OnPropetyChanged();
            }
        }


        public AddQuestionViewModel()
        {
            var addQuestionServices = new AddQuestionServices();
            NumberQuestionsList = addQuestionServices.GetNumbersQuestions();
        }


        public Command SendQuestionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                    if (QuestionContent.Length > 5)
                    {
                        TodayQuestion question = new TodayQuestion()
                        {
                            question_content = QuestionContent,
                            question_number = (IndexNumberQuestion + 1).ToString()
                        };
                        string response = APIServices.addQustionPOST(question);
                        if (response == "\ntrue")
                        {
                            await App.Current.MainPage.DisplayAlert("", "Twoje pytanie zostało przesłane.", "", "Ok");
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("", response, "", "Ok");
                        }
                        QuestionContent = "";
                        IndexNumberQuestion = 0;

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("", "Twoje pytanie jest niepoprawne", "", "Ok");
                    }
                    }
                    catch (Exception)
                    {

                        await App.Current.MainPage.DisplayAlert("", "Twoje pytanie jest niepoprawne", "", "Ok");
                    }
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
