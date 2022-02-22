using Android.Media;
using KaamelotSampler.Droid.Implementations;
using KaamelotSampler.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidAudioService))]
namespace KaamelotSampler.Droid.Implementations
{
    public class AndroidAudioService : IAudioService
    {
        public void PlayMp3(string filename)
        {
            //Récupérer le stream du fichier MP3
            var filepath = Path.Combine("mp3", filename);
            var filedescriptor = Android.App.Application.Context.Assets.OpenFd(filepath);
            //Jouer le son avec android
            MediaPlayer player = new MediaPlayer();
            player.SetDataSource(filedescriptor);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.Completion += (s, e) =>
            {
                player.Dispose();
            };
            player.Prepare();
        }
    }
}