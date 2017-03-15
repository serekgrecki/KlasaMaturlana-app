using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KlasaMaturalna.ViewModels;

namespace KlasaMaturalna.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomQuestionPage : ContentPage
    {
        public RandomQuestionPage()
        {
            InitializeComponent();
        }
    }
}
