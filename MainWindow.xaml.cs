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
        DateTime date;

        List<Bookings> bookingList = new List<Bookings>();

        List<Tables> table = new List<Tables>();
        List<Table> availableTableList = new List<Table>();
        List<Table> bookedTableList = new List<Table>();

        List <DateTime> availablDates = new List<DateTime>();
        List <DateTime> bookedDates = new List<DateTime>();

        List<string> availableHours = new List<string>();
        List<string> bookedHours = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            bookingList.Add(new Bookings("Shakiba Pour", new DateTime(2022,11,10), "1", "19"));
            bookingList.Add(new Bookings("Sara Nilsson", new DateTime(2022, 11, 14), "4", "20"));
            bookingList.Add(new Bookings("Viktor George", new DateTime(2022, 11, 10), "2", "18"));
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

        public void BookingWindowContent()
        {  

        foreach(Bookings booking in bookingList)
            {
                bookingBox.Items.Add(booking.Name + " " + booking.Date.ToShortDateString() +
                     " kl. "+booking.Time + " Bord N. " + booking.TableNumber);
            }
            
        //here I can add it to a fil and then return the file content?
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
                timepicker.Items.Add(i.ToString() + ".00"); ;
                
            }
        }

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {

                string name = customerName.Text;
                DateTime date = (DateTime)myCalendar.SelectedDate;
                string tableNumber = TableNumCB.SelectedItem.ToString();
                var time = timepicker.SelectedItem.ToString();

            foreach (var booking in bookingList)
            {
                if (booking.TableNumber == tableNumber &&
                    booking.Date == date &&
                    booking.Time == time)
                {
                    MessageBox.Show("The table is already booked on that date and time." +
                        "Please try again!");
                    break;
                }

            }

            bookingList.Add(new Bookings(name, date, tableNumber, time));
            MessageBox.Show("Bokningen är klar!");    
        }

        private void ShowBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            bookingBox.Items.Clear();
            BookingWindowContent();
            
        }

        private void CancelingBtn_Click(object sender, RoutedEventArgs e)
        {
            var avbokning= bookingBox.SelectedItem;
            bookingList.Remove((Bookings)avbokning);

            //or access the file, delete the avbokning object
        }

        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = (DateTime)myCalendar.SelectedDate;
        }
    }
}
