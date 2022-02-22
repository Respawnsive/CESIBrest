using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaamelotSampler.Models
{
    public class Saample
    {
        [JsonProperty("title")]
        public string Tirade { get; set; }

        [JsonProperty("character")]
        public string Personnage { get; set; }

        [JsonProperty("episode")]
        public string Episode { get; set; }

        [JsonProperty("file")]
        public string Mp3File { get; set; }

        [JsonProperty("imagefile")]
        public string Imagefile { get; set; }
    }
}
