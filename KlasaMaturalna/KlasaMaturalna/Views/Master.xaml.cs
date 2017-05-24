using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Views;
using Xamarin.Forms;

namespace KlasaMaturalna
{
    public partial class Master : ContentPage
    {
        public ImageSource imagesource=ImageSource.FromFile("logo.png");
        public Master()
        {
            InitializeComponent();

            btnCalculatorPage.Clicked +=async (sender, e) =>
            {
                await App.NavigateMasterDetails(new CalculatorPage());
            };

            btnRandomQuestionPage.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetails(new RandomQuestionPage());
            };

            btnTodayQuestionsPage.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetails(new TodayQuesitonsPage());
            };
            btnAddQuestionsPage.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetails(new AddQuestionPage());
            };
            btnStatisticPage.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetails(new StatisticPage());
            };
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.klasamaturalna.pl/"));
        }
    }
}
