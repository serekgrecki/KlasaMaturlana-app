﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KlasaMaturalna.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultPage : ContentPage
    {
        public DefaultPage()
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