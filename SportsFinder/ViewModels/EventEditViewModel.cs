using SportsFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsFinder.ViewModels
{
    public class EventEditViewModel :Event
    {
        public List<Sport> Sports { get; set; }
        public List<PreferredGender> PreferredGenders { get; set; }
        public List<SkillLevel> SkillLevels { get; set; }
        public Event Event { get; set; }
    }
}
