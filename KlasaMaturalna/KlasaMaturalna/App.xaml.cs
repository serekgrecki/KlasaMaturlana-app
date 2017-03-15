using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using KlasaMaturalna.Services;
using Xamarin.Forms;

namespace KlasaMaturalna
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public static async Task NavigateMasterDetails(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }


        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
