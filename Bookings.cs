using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab3
{
    public class Bookings : IBookingSystem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TableNumber { get; set; }
        public string Time { get; set; }

        public Bookings(string name, DateTime date, string tableNum, string time)
        {
            this.Name = name;
            this.Date = date;
            this.TableNumber = tableNum;
            this.Time = time;
        }

        public Bookings()
        {

        }

        public override string ToString()
        {
            string dateOnly = Date.ToShortDateString();
            string allInfo = $"{Name} {dateOnly} kl. {Time} bord n. {TableNumber}";
            return allInfo;
        }
    }
}
