using KaamelotSampler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KaamelotSampler.Datatemplates
{
    public class PersonnageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RoyalDataTemplate { get; set; }
        public DataTemplate NormalDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            
            var saample = (Saample)item;
            if (saample.Personnage == "Arthur" || saample.Personnage == "Arthur - Le Roi Burgonde" || saample.Personnage == "Léodagan")
            {
                return RoyalDataTemplate;
            }
            return NormalDataTemplate;
        }
    }
}
