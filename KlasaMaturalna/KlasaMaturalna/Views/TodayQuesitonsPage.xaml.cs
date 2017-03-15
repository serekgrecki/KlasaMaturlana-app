using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KlasaMaturalna.Views
{
    public partial class TodayQuesitonsPage : ContentPage
    {
        public TodayQuesitonsPage()
        {
            InitializeComponent();
        }
        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView elo = (ListView)sender;
            elo.SelectedItem = -1;
        }
    }
}
