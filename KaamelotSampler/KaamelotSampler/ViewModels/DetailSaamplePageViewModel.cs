using KaamelotSampler.Interfaces;
using KaamelotSampler.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace KaamelotSampler.ViewModels
{
    public class DetailSaamplePageViewModel : BaseViewModel
    {
        private INavigation NavigationService;

        public DetailSaamplePageViewModel(INavigation navigationService, Saample saample)
        {
            PlayMP3Command = new Command(PlayMP3);
            PlayTTSCommand = new Command(PlayTTS);
            ShareCommand = new Command(Share);
            CurrentSaample = saample;
            NavigationService = navigationService;
        }

        #region Bindable properties

        private Saample currentSaample;
        public Saample CurrentSaample
        {
            get { return currentSaample; }
            set 
            { 
                currentSaample = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Bindable Commands

        public Command PlayMP3Command { get; set; }
        public Command PlayTTSCommand { get; set; }
        public Command ShareCommand { get; set; }


        #endregion

        #region Private methods

        private void PlayMP3()
        {
            var audioService = DependencyService.Get<IAudioService>();
            audioService.PlayMp3(CurrentSaample.Mp3File);
        }

        private async void PlayTTS()
        {
            var installedLanguages = await TextToSpeech.GetLocalesAsync();
            Locale currentLanguage = installedLanguages.Where(x => x.Country == "FR").FirstOrDefault();
            SpeechOptions options = new SpeechOptions();
            options.Volume = 1.0f;
            options.Pitch = 1.0f;
            options.Locale = currentLanguage;
            await TextToSpeech.SpeakAsync(CurrentSaample.Tirade, options);
        }

        private async void Share()
        {
            ShareTextRequest request = new ShareTextRequest();
            request.Title = "Partage d'un son de kaamelot";
            request.Text = CurrentSaample.Tirade;
            request.Uri = $"https://github.com/2ec0b4/kaamelott-soundboard/blob/master/sounds/{CurrentSaample.Mp3File}";
            await Xamarin.Essentials.Share.RequestAsync(request);
        }

        #endregion
    }
}
