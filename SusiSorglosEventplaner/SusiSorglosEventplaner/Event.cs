using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusiSorglosEventplaner
{
    class Event
    {
        public int eventID { get; set; }
        public string strEventname { get; set; }
        public string strEventLocation { get; set; }
        public DateTime dateEventStart { get; set; }
        public DateTime dateEventEnd { get; set; }
    }
}
