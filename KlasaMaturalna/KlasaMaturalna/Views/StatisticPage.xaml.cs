using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.SQLite;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KlasaMaturalna.Views
{
    public partial class StatisticPage : ContentPage
    {
        public StatisticPage()
        {
            InitializeComponent();
            SQLiteConnection SQLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            var statisctList = new List<StatisticData>(SQLiteConnection.Table<StatisticData>());
            var countTrue = 0;
            var countFasle = 0;
            foreach (var itm in statisctList)
            {
                if (itm.Answer)
                    countTrue++;
                else
                    countFasle++;
            }

            var sum = countTrue + countFasle;
            var modell = new PlotModel { Title = "Jak dobrze odpowiadałeś : "};
            var barSeries = new BarSeries
            {
                ItemsSource = new List<BarItem>(new[]
                {
                    
                    new BarItem {Value = countTrue},
                    new BarItem {Value = countFasle,Color = OxyColor.FromRgb(217,83,79)}
                }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };
            modell.Series.Add(barSeries);

            modell.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "ScoreAxis",
                ItemsSource = new[] { "TAK", "NIE" }
            });
            this.Content = new PlotView()
            {
                Model = modell,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

        }
    }
}
