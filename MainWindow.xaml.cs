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
using Microsoft.Win32;

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

        List<DateTime> availablDates = new List<DateTime>();
        List<DateTime> bookedDates = new List<DateTime>();

       

        public MainWindow()
        {
            InitializeComponent();

            bookingList.Add(new Bookings("Shakiba Pour", new DateTime(2022, 11, 10), "1", "19.00"));
            bookingList.Add(new Bookings("Sara Nilsson", new DateTime(2022, 11, 14), "4", "20.00"));
            bookingList.Add(new Bookings("Viktor George", new DateTime(2022, 11, 10), "2", "18.00"));
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
            bookingBox.Items.Clear();
            foreach (Bookings booking in bookingList)
            {
                bookingBox.Items.Add(booking.Name + " " + booking.Date.ToShortDateString() +
                     " kl. " + booking.Time + " Bord N. " + booking.TableNumber);
            }
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in bookingBox.Items)
            {
                sb.Append(item.ToString());
                sb.Append("\n");
            }
            
            File.WriteAllText(@"BookigListFile.txt", sb.ToString());

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
            try
            {
                // add also a regex for name , so user doesn't write number
                string name = customerName.Text;
                DateTime date = (DateTime)myCalendar.SelectedDate;
                string tableNumber = TableNumCB.SelectedItem.ToString();
                var time = timepicker.SelectedItem.ToString();



                foreach (var booking in bookingList)
                {
                    if (tableNumber == booking.TableNumber &&
                        date == booking.Date &&
                        time == booking.Time)
                    {
                        MessageBox.Show("This table is already booked on that date and time. " +
                            "Please try another combination!");
                        return;
                    }

                }

                bookingList.Add(new Bookings(name, date, tableNumber, time));
                UpdateContent();
                MessageBox.Show("Bokningen är klar!");
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please insert all the required data.");
            }



        }
       
        private void ShowBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            bookingBox.Items.Clear();
            UpdateContent();
            // it's not working atm : File.ReadAllText(@"BookigListFile.txt");
        }

        private void CancelingBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (bookingBox.SelectedItem == null)
            //    return;

            //bookingList.Items.Remove((Bookings)bookingBox.SelectedItem);
            //UpdateContent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            //bookingBox.ClearSelected();

            //int index = bookingBox.FindString(customerName.Text);

            //if (index < 0)
            //{
            //    MessageBox.Show("Item not found.");
            //    customerName.Text = String.Empty;
            //}
            //else
            //{
            //    customerName.SelectedIndex = index;
            //}
        }

    } }

