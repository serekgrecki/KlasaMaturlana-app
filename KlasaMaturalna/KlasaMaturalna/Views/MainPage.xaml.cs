using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Views;
using Xamarin.Forms;

namespace KlasaMaturalna
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new DefaultPage());
            App.MasterDetail = this;
          //  BackgroundColor = Color.FromHex("D7393D");
            
        }
    }
}
