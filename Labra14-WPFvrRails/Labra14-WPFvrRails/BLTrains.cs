using System;
using Newtonsoft.Json;

namespace JAMK.IT
{
    public class Train
    {
        public string TrainNumber { get; set; }
        [JsonProperty("cancelled")]
        public bool IsCancelled { get; set; }
        [JsonProperty("departureDate")]
        public DateTime DepartureDate { get; set; }
        public string TargetStation { get; set; }
    }
    public class Station
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Station (string koodi, string asemapaikka)
        {
            this.Code = koodi; //asemapaikan tunniste, JY = Jyväskylä
            this.Name = asemapaikka; //asemapaikan nimi
        }
    }
}
