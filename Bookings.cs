using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab3
{
    internal class Bookings
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string TableNumber { get; set; }
        public DateTime GetTime { get; set; }

        public Bookings(string name, DateTime date, string tableNum, DateTime time)
        {
            this.Name = name;
            this.DateTime = date;
            this.TableNumber = tableNum;
            this.GetTime = time;
        }
    }
}
