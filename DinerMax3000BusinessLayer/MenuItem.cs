using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000.Business
{
    public class MenuItem
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price
        {
            get {
                CDyne.WeatherSoapClient client = new CDyne.WeatherSoapClient();
                var resultWeather = client.GetCityWeatherByZIP("78729");
                if(int.Parse(resultWeather.Temperature) > 80)
                {
                    return price * 2;
                }
                return _price;
            }
            set {
                if(value > 0)
                {
                    _price = value;
                }
            }
        }

        private double _price;
    }
}
