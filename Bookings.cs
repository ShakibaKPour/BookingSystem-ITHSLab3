using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab3
{
    public class Bookings
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string TableNumber { get; set; }
        public string Time { get; set; }

        public Bookings(string name, string date, string tableNum, string time)
        {
            this.Name = name;
            this.Date = date;
            this.TableNumber = tableNum;
            this.Time = time;
        }
        public override string ToString()
        {

            string allInfo = $"{Name} {Date} kl. {Time} bord n. {TableNumber}";
            return allInfo;
        }
    }
}
