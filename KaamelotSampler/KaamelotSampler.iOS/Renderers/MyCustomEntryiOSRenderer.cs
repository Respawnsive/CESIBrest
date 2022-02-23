using Foundation;
using KaamelotSampler.CustomCtrl;
using KaamelotSampler.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(MyCustomEntry), typeof(MyCustomEntryiOSRenderer))]
namespace KaamelotSampler.iOS.Renderers
{
    public class MyCustomEntryiOSRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}