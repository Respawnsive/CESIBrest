using KaamelotSampler.Models;
using KaamelotSampler.ViewModels;
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
    public partial class DetailSaamplePage : ContentPage
    {
        public DetailSaamplePage(Saample saample)
        {
            InitializeComponent();
            BindingContext = new DetailSaamplePageViewModel(Navigation, saample);
        }
    }
}