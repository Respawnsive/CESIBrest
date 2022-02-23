using KaamelotSampler.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace KaamelotSampler
{
    public partial class KaamelotApp : Application
    {
        public KaamelotApp()
        {
            InitializeComponent();
            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                MainPage = new NavigationPage(new ListeSaamplesPage());
            }
            else
            {
                MainPage = new NavigationPage(new ListeSaamplesPage());
            }
            
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=7778396b-176a-4a2a-97fa-489a39eeb582;ios=3eda4bd5-142c-4701-91e3-dbc42202eb72;",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
