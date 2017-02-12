using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tehtava4;

namespace Tehtava4
{
    class Kiuas
    {
        private double temperature = 0;
        private double humidity = 0;
        public double maxTemperature = 120d;
        public double maxHumidity = 100d;


        public string ChangeTemperature(string str)
        {
            if (double.TryParse(str, out temperature))
            {
                if (temperature <= maxTemperature && temperature >= 0)
                {
                    return temperature.ToString("F");
                }
                else { return "0"; }
            }
            else { return "0"; }

        }

        public string ChangeHumidity(string str)
        {
            if (double.TryParse(str, out humidity))
            {
                if (humidity <= maxHumidity && humidity >= 0)
                {
                    return humidity.ToString("F");
                }
                else { return "0"; }
            }
            else { return "0"; }
        }


    }
}

