using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JAMK.IT
{
    public class TrainsVM
    {
        public static List<JAMK.IT.Train> GetTrainsAt(string station)
        {
            try
            {
                List<Train> trains = new List<Train>();
                if (station == "testi" || station == "")
                {
                    //vaihe1:Placebo palauttaa oikean muotoista dataa
                    //keksitään muutama juna
                    Train tr = new IT.Train();
                    tr.TrainNumber = "666";
                    tr.DepartureDate = new DateTime(2017, 3, 21);
                    tr.TargetStation = "Highway to hell";
                    trains.Add(tr);
                }
                else
                {
                    //Vaihe 2: haetaan Liikenneviraston API:sta
                    //muutetaan haettu json olio-kokoelmaksi
                    string tmp = API.GetJsonFromLiikenneVirasto(station);
                    trains = JsonConvert.DeserializeObject<List<Train>>(tmp);
                }
                //palautus
                return trains;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
