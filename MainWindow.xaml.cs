using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace CSLab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bookings> bookingList = new List<Bookings>();
        List<Tables> table = new List<Tables>();
        //List<TimeOnly> timeOnlyList = new List<TimeOnly>();

        public MainWindow()
        {
            InitializeComponent();
            bookingList.Add(new Bookings("Shakiba Pour", new DateTime(2022,11,10), "1", new DateTime(2022,11,10, 19, 00, 00)));
            bookingList.Add(new Bookings("Sara Nilsson", new DateTime(2022, 11, 14), "4", new DateTime(2022, 11, 14, 19, 00, 00)));
            bookingList.Add(new Bookings("Viktor George", new DateTime(2022, 11, 10), "2", new DateTime(2022, 11, 10, 19, 00, 00)));
            BookingWindowContent();
            table.Add(new Tables("1"));
            table.Add(new Tables("2"));
            table.Add(new Tables("3"));
            table.Add(new Tables("4"));
            table.Add(new Tables("5"));
            table.Add(new Tables("6"));
            table.Add(new Tables("7"));
            TableListCBContent();
            TimeListContent();
            
        }

        public string BookingWindowContent()
        {
            foreach(var booking in bookingList)
            {
                servingWindow.Text += booking.Name + booking.DateTime.ToString()
                    + booking.TableNumber  + "\n";
            }
            return servingWindow.Text;
        }

        public void TableListCBContent()
        {
            foreach (var table in table)
            {
                TableNumCB.ItemsSource += table.number;
            }
        }

        public void TimeListContent()
        {
            for (int i = 11; i < 22; i++)
            {
                timepicker.Items.Add(i + ".00");
                // or
                //comboBox1.Items.Add(i.ToString("00")); // to get 00, 01, 02 
            }
        }
        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //BookingList.date property- add to the list of bookings and blockout the date
        }

        void AddToBookingList()
        {
            string name=customerName.Text;
            DateTime date=datepicker.DisplayDate;
            //int tableNum=ComboBox

            //bookingList.Add(new Bookings(name, date, Table number, time));
        }

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {
            string Name= customerName.Text;
            var date=datepicker.DisplayDate;
            var tableNumber = TableNumCB.Items;

           // bookingList.Add(new Bookings(Name, date, tableNumber));
        }
    }
}
