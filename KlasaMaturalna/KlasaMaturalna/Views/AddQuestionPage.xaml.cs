﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KlasaMaturalna.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();

        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}