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
using System.ComponentModel;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Dynamic;

namespace CSLab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bookings> bookingList = new List<Bookings>();

        List<Tables> table = new List<Tables>();

        //List<Tables> availableTableList = new List<Tables>();
        //List<Tables> bookedTableList = new List<Tables>();

        public MainWindow()
        {
            InitializeComponent();
            bookingList.Add(new Bookings("Shakiba Pour", new DateTime(2022,11,10), "1", "19.00 - 21.00"));
            bookingList.Add(new Bookings("Sara Nilsson", new DateTime(2022,11,10), "4", "20.00 - 22.00"));
            bookingList.Add(new Bookings("Viktor George", new DateTime(2022,11,10), "2", "18.00 - 20.00"));
            UpdateContent();
            TableListCBContent();
            TimeListContent();
            EnableButton();
        }

        private void EnableButton()
        {
            if (customerName.Text == null || timepicker.SelectedItem == null || TableNumCB.SelectedItem == null || myCalendar.SelectedDate == null)
            {
                bookingBtn.IsEnabled = false;
            }
            else bookingBtn.IsEnabled = true;
        }

        private void UpdateContent()
        {
            bookingBox.ItemsSource = null;
            bookingBox.ItemsSource = bookingList;

            // Make a backup text file any time the listbox is updated
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in bookingBox.Items)
            {
                sb.Append(item.ToString());
                sb.Append("\n");
            }

            File.WriteAllText(@"BookigListFile.txt", sb.ToString());
        }

        private void ClearContent()
        {
            customerName.Text = null;
            myCalendar.SelectedDate = null;
            timepicker.SelectedItem = null;
            TableNumCB.SelectedItem = null;
        }

            private void TableListCBContent()
        {
            for (int i = 1; i < 11; i++)
            {
                table.Add(new Tables(i.ToString()));
            }

            foreach (Tables t in table)
            {
                TableNumCB.Items.Add(t.number);
            }
        }

        private void TimeListContent()
        {
            for (int i = 11; i < 23; i++)
            {
                timepicker.Items.Add(i.ToString() + ".00 - " + (i + 2).ToString() + ".00");

            }
        }

        private void ValidateName()   //Regex is not working
        {
            Regex r = new Regex(@"[a - z]|[A-Z]*");
            if (!r.IsMatch(customerName.Text))
            {
                MessageBox.Show("Please insert your name");
                customerName.Text = null;
                return;
            }
        }

        private void ValidateCalender()
        {
            if (myCalendar.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("You cannot choose passed days!");
                myCalendar.SelectedDate = null;
            }
        }

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = customerName.Text;
                ValidateName();

                ValidateCalender();
                DateTime date = (DateTime)myCalendar.SelectedDate;
                

                string tableNumber = TableNumCB.SelectedItem.ToString();

                var time = timepicker.SelectedItem.ToString();

                var endofbookedtime = timepicker.SelectedItem + 2.00.ToString();

                foreach (var booking in bookingList)
                {
                    if (tableNumber == booking.TableNumber &&
                        date == booking.Date &&
                        time == booking.Time)

                    {
                        MessageBox.Show("This table is already booked on that date and time. " +
                            "Please try another combination!");
                        ClearContent();
                        return;
                    }

                }

                

                bookingList.Add(new Bookings(name, date , tableNumber, time));

                UpdateContent();

                MessageBox.Show("Bokningen är klar!");

                ClearContent();

            }
            catch
            {
                MessageBox.Show("Something went wrong! Please try again.");
            }
        }
 
        private void CancelingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bookingBox.SelectedItem == null)
                return;
            bookingList.RemoveAt(bookingBox.Items.IndexOf(bookingBox.SelectedItem));
            UpdateContent();
            MessageBox.Show("Bokningen har borttagen!");
        }

        private async void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            using FileStream openStream = File.OpenRead("Bookinglist.json");
            List<Bookings> getBookinglist =
                 await JsonSerializer.DeserializeAsync<List<Bookings>>(openStream);
            bookingBox.ItemsSource = getBookinglist;

        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            FileSerialization.SerialFileAsync(bookingList);
            MessageBox.Show("Saved as Bookinglist.json");
        }

        private void customerName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            EnableButton();
        }

        private void TableNumCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }

        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }

        private void timepicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }
    }
}

