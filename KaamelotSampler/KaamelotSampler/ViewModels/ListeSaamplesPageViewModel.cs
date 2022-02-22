using KaamelotSampler.Interfaces;
using KaamelotSampler.Models;
using KaamelotSampler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace KaamelotSampler.ViewModels
{
    public class ListeSaamplesPageViewModel : BaseViewModel
    {
        public ListeSaamplesPageViewModel()
        {
            LoadDatas();
            SelectSaampleCommand = new Command(SelectSaample);
            ClearPersoCommand = new Command(ClearSelectedPerso);
        }

        #region Bindable Properties

        private List<Saample> AllSamples;

        private List<Saample> listSaamples;
        public List<Saample> ListSaamples
        {
            get 
            { 
                return listSaamples; 
            }
            set 
            { 
                listSaamples = value;
                OnPropertyChanged();
            }
        }

        private Saample selectedSaample;
        public Saample SelectedSaample
        {
            get { return selectedSaample; }
            set 
            { 
                selectedSaample = value;
                OnPropertyChanged();
            }
        }

        private string searchedText;
        public string SearchedText
        {
            get { return searchedText; }
            set 
            { 
                searchedText = value;
                OnPropertyChanged();
                FilterSaamples(value, SelectedPerso);
            }
        }

        private List<string> listPersos;
        public List<string> ListPersos
        {
            get { return listPersos; }
            set 
            { 
                listPersos = value;
                OnPropertyChanged();
            }
        }

        private string selectedPerso;
        public string SelectedPerso
        {
            get { return selectedPerso; }
            set 
            { 
                selectedPerso = value;
                OnPropertyChanged();
                FilterSaamples(SearchedText, value);
            }
        }

        #endregion

        #region Bindable Commands

        public Command SelectSaampleCommand { get; set; }

        public Command ClearPersoCommand { get; set; }
        #endregion

        #region Private methods

        private void LoadDatas()
        {
            DataService datas = new DataService();
            AllSamples = ListSaamples = datas.GetSaamplesFromLocalJson();
            ListPersos = AllSamples
                .Select(x => x.Personnage)
                .Distinct()
                .OrderBy(x => x)
                .ToList(); 
        }

        private void SelectSaample(object obj)
        {
            var audioService = DependencyService.Get<IAudioService>();
            audioService.PlayMp3(SelectedSaample.Mp3File);
        }

        private void FilterSaamples(string searchedText, string personnage)
        {
            if (String.IsNullOrWhiteSpace(searchedText) && String.IsNullOrWhiteSpace(personnage))
            {
                //RAZ
                ListSaamples = AllSamples;
            }
            else if (!String.IsNullOrWhiteSpace(searchedText) && String.IsNullOrWhiteSpace(personnage))
            {
                //uniquement searchtext
                ListSaamples = AllSamples.Where(x => x.Tirade.ToLower().Contains(searchedText.ToLower())).ToList();
            }
            else if (String.IsNullOrWhiteSpace(searchedText) && !String.IsNullOrWhiteSpace(personnage))
            {
                //uniquement personnage
                ListSaamples = AllSamples.Where(x => x.Personnage == personnage).ToList();
            }
            else
            {
                //Searchtext ET personnage
                ListSaamples = AllSamples
                    .Where(x => x.Personnage == personnage 
                            && x.Tirade.ToLower().Contains(searchedText.ToLower())).ToList();
            }
        }

        private void ClearSelectedPerso(object obj)
        {
            SelectedPerso = null;
        }

        #endregion

    }
}
