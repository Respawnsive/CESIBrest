using KaamelotSampler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace KaamelotSampler.Services
{
    public class DataService
    {
        /// <summary>
        /// Résupère la liste des saamples depuis les ressources json
        /// </summary>
        /// <returns>La liste des saamples</returns>
        public List<Saample> GetSaamplesFromLocalJson()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataService)).Assembly;
            var stream = assembly.GetManifestResourceStream("KaamelotSampler.Ressources.sounds.json");
            StreamReader SR = new StreamReader(stream);
            var content = SR.ReadToEnd();
            var listsamples = JsonConvert.DeserializeObject<List<Saample>>(content);
            return listsamples;
        }

        //public List<Saample> GetSaamplesFromAPI()
        //{

        //}
    }
}
