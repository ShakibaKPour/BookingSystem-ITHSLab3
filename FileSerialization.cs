using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace CSLab3
{
    public class FileSerialization
    {
        public static async Task SerialFileAsync(List<Bookings> list)
        {
            string fileName = "Bookinglist.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, list);
            await createStream.DisposeAsync(); 
        }
    }
}
