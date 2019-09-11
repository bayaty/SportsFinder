using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinder.Data.Models
{
    //Testing purposes
    public class WeatherForecast
    {
        [Display(Name ="Date")]
        public string DateFormatted { get; set; }
        public int TemperatureC { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Summary { get; set; }

        public int TemperatureF
        {
            get
            {
                return 32 + (int)(TemperatureC / 0.5556);
            }
        }
    }
}
