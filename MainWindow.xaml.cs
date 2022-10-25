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
        List<Tables> availableTableList = new List<Tables>();
        List<Tables> bookedTableList = new List<Tables>();

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
            UpdateContent();


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

        public void UpdateContent()
        {
            bookingBox.ItemsSource = null;
            foreach (Bookings booking in bookingList)
            {
                bookingBox.ItemsSource += booking.Name + " " + booking.Date.ToShortDateString() +
                     " kl. " + booking.Time + " Bord N. " + booking.TableNumber;
            }

            //Save it to a file later
        }

    public void TableListCBContent()
        {
           foreach (Tables t in table)
            {
                TableNumCB.ItemsSource += t.number;
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
                    MessageBox.Show("This table is already booked on that date and time." +
                        "Please try another combination!");
                    return;
                }

            }
            
            bookingList.Add(new Bookings(name, date, tableNumber, time));
            UpdateContent();
            MessageBox.Show("Bokningen är klar!");    
        }

        private void ShowBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            bookingBox.Items.Clear();
            UpdateContent();
            
        }

        private void CancelingBtn_Click(object sender, RoutedEventArgs e)
        {
            var avbokning= bookingBox.SelectedItem;
            bookingList.Remove((Bookings)avbokning);

            if (bookingBox.SelectedItem == null)
                return;
            bookingList.Remove((Bookings)bookingBox.SelectedItem);
            UpdateContent();

            //or access the file, delete the avbokning object
        }

        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = (DateTime)myCalendar.SelectedDate;
        }
    }
}
