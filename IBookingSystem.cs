using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab3
{
    internal interface IBookingSystem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

    }
}
