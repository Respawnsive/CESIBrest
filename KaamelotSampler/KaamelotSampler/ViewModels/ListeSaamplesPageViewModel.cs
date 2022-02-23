using KaamelotSampler.Interfaces;
using KaamelotSampler.Models;
using KaamelotSampler.Services;
using KaamelotSampler.Views;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KaamelotSampler.ViewModels
{
    public class ListeSaamplesPageViewModel : BaseViewModel
    {
        private List<Saample> AllSamples;
        private INavigation NavigationService;

        public ListeSaamplesPageViewModel(INavigation navigationService)
        {
            SelectSaampleCommand = new Command(async() => await SelectSaample());
            ClearPersoCommand = new Command(ClearSelectedPerso);
            NavigationService = navigationService;
            Task.Run(async() => await LoadDatas());
        }

        #region Bindable Properties

        private List<Saample> filteredSaamples;
        public List<Saample> FilteredSaamples
        {
            get 
            { 
                return filteredSaamples; 
            }
            set 
            { 
                filteredSaamples = value;
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

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set 
            { 
                isBusy = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Bindable Commands

        public Command SelectSaampleCommand { get; set; }

        public Command ClearPersoCommand { get; set; }
        #endregion

        #region Private methods

        private async Task LoadDatas()
        {
            IsBusy = true;
            try
            {
                DataService datas = new DataService();
                FilteredSaamples = AllSamples = await datas.GetSaamplesFromLocalJsonAsync();
                ListPersos = AllSamples
                    .Select(x => x.Personnage)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task SelectSaample()
        {
            await NavigationService.PushAsync(new DetailSaamplePage(SelectedSaample));
        }

        private void FilterSaamples(string searchedText, string personnage)
        {
            try
            {
                if (searchedText == "toto")
                {
                    throw new ArgumentOutOfRangeException("searchvalue", "user search toto");
                }
                else if (String.IsNullOrWhiteSpace(searchedText) && String.IsNullOrWhiteSpace(personnage))
                {
                    //RAZ
                    FilteredSaamples = AllSamples.OrderBy(x => x.Episode).ToList();
                }
                else if (!String.IsNullOrWhiteSpace(searchedText) && String.IsNullOrWhiteSpace(personnage))
                {
                    //uniquement searchtext
                    FilteredSaamples = AllSamples.Where(x => x.Tirade.ToLower().Contains(searchedText.ToLower())).OrderBy(x => x.Episode).ToList();
                }
                else if (String.IsNullOrWhiteSpace(searchedText) && !String.IsNullOrWhiteSpace(personnage))
                {
                    //uniquement personnage
                    FilteredSaamples = AllSamples.Where(x => x.Personnage == personnage).OrderBy(x => x.Episode).ToList();
                }
                else
                {
                    //Searchtext ET personnage
                    FilteredSaamples = AllSamples
                        .Where(x => x.Personnage == personnage
                                && x.Tirade.ToLower().Contains(searchedText.ToLower())).OrderBy(x => x.Episode).ToList();
                }
            }
            catch(Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        private void ClearSelectedPerso(object obj)
        {
            SelectedPerso = null;
        }

        #endregion

    }
}
