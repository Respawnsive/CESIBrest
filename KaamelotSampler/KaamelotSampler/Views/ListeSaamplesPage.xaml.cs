using KaamelotSampler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            BindingContext = new ListeSaamplesPageViewModel(Navigation);
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                //Tablette
                MyList.ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                {
                    HorizontalItemSpacing = 10,
                    VerticalItemSpacing = 10,
                    Span = 3
                };
            }
            else
            {
                //Phone
                MyList.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical) { ItemSpacing = 10 };
            }
            
        }
    }
}