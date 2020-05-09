using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_to_webapps.Models
{
    public class ReminderItem
    {
        public long Id { get; set; }
        public string Contents { get; set; }
        public bool IsComplete { get; set; }
    }
}
