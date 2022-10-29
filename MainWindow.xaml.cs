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

        public void UpdateContent()
        {
            //bookingBox.ItemsSource = null;
            //bookingBox.ItemsSource = bookingList;
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
                TableNumCB.Items.Add(t.number);
            }


        }

        public void TimeListContent()
        {
            for (int i = 11; i < 23; i++)
            {
                timepicker.Items.Add(i.ToString() + ".00"); ;

            }
        }

        public void changeToString()
        {
            bookingBox.SelectedItem.ToString();
        }
        

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                // add also a regex for name , so user doesn't write number
                if (customerName.Text == null)
                {
                    MessageBox.Show("Please enter your name");
                    return;
                }
                if (myCalendar.SelectedDate == null)
                {
                    MessageBox.Show("Please choose a date");
                    return;
                }
                if (TableNumCB.SelectedItem == null)
                {
                    MessageBox.Show("Please choose your table");
                    return;
                }
                if (timepicker.SelectedItem == null)
                {
                    MessageBox.Show("Please choose a time");
                    return;
                }

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
                customerName.Text=null;
                myCalendar.SelectedDate=null;
                timepicker.SelectedItem = null;
                TableNumCB.SelectedItem =null;
                
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please insert all the required data.");
            }



        }
       
        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by ex
                                                        // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
           // bookingBox.ItemsSource = null;
            // bookingBox.ItemsSource = File.ReadAllText(dlg.FileName);
        }

        private void CancelingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bookingBox.SelectedItem == null)
                return;
            bookingList.RemoveAt(bookingBox.Items.IndexOf(bookingBox.SelectedItem));
           
            UpdateContent();

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
    } }

