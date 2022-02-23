using KaamelotSampler.Models;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KaamelotSampler.Services
{
    public class DataService
    {
        /// <summary>
        /// Récupère la liste des saamples depuis les ressources json
        /// </summary>
        /// <returns>La liste des saamples</returns>
        public async Task<List<Saample>> GetSaamplesFromLocalJsonAsync()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataService)).Assembly;
                var stream = assembly.GetManifestResourceStream("KaamelotSampler.Ressources.sounds.json");
                StreamReader SR = new StreamReader(stream);
                var content = await SR.ReadToEndAsync();
                var listsamples = JsonConvert.DeserializeObject<List<Saample>>(content);
                return listsamples;
            }
            catch(Exception ex)
            {
                Crashes.TrackError(ex);
                return new List<Saample>();
            }
        }

        //public List<Saample> GetSaamplesFromAPI()
        //{

        //}
    }
}
