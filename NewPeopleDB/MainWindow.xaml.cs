using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace NewPeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        public MainWindow()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                ReloadPersonList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void ReloadPersonList()
        {
            List<Person> list = db.GetAllPersons();
            lvPeople.Items.Clear();
            foreach (Person p in list)
            {
                lvPeople.Items.Add(p);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            double height = sliderHeight.Value;
            try
            {
                Person p = new Person { Name = name, AgeStr = ageStr, Height = height };
                db.AddPerson(p);
                ReloadPersonList();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Input error: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sliderHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double height = sliderHeight.Value;
            String strHeight = String.Format("{0:F2}m", height);
            lblHeight.Content = strHeight;

        }
    }
}
