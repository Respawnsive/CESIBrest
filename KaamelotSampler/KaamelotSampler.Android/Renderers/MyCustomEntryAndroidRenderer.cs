using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KaamelotSampler.CustomCtrl;
using KaamelotSampler.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomEntry), typeof(MyCustomEntryAndroidRenderer))]
namespace KaamelotSampler.Droid.Renderers
{
    public class MyCustomEntryAndroidRenderer : EntryRenderer
    {
        public MyCustomEntryAndroidRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}