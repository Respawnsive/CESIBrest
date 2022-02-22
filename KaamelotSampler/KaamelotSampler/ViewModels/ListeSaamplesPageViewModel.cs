using KaamelotSampler.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaamelotSampler.ViewModels
{
    public class ListeSaamplesPageViewModel : BaseViewModel
    {
        public ListeSaamplesPageViewModel()
        {
            DataService datas = new DataService();
            var listsaamples = datas.GetSaamplesFromLocalJson();
        }
    }
}
