using AVFoundation;
using Foundation;
using KaamelotSampler.Interfaces;
using KaamelotSampler.iOS.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSAudioService))]
namespace KaamelotSampler.iOS.Implementations
{
    public class iOSAudioService : IAudioService
    {
        public void PlayMp3(string filename)
        {
            //Récupérer le chemin (NSURL) du fichier MP3
            NSUrl fileUrl = new NSUrl("Sounds/" + filename);
            NSError error;
            //Jouer le son avec iOS
            AVAudioPlayer player = new AVAudioPlayer(fileUrl, "mp3", out error);
            player.NumberOfLoops = 0;
            player.Volume = 1.0f;
            player.Play();
        }
    }
}