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
        public string Time { get; set; }

        public Bookings(string name, DateTime date, string tableNum, string time)
        {
            this.Name = name;
            this.DateTime = date.Date;
            this.TableNumber = tableNum;
            this.Time = time;
        }
    }
}
