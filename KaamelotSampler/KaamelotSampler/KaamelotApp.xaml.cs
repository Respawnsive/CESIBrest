using KaamelotSampler.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KaamelotSampler
{
    public partial class KaamelotApp : Application
    {
        public KaamelotApp()
        {
            InitializeComponent();

            MainPage = new ListeSaamplesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
