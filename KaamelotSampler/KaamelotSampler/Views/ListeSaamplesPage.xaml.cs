﻿using KaamelotSampler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KaamelotSampler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeSaamplesPage : ContentPage
    {
        public ListeSaamplesPage()
        {
            InitializeComponent();
            BindingContext = new ListeSaamplesPageViewModel();
        }
    }
}