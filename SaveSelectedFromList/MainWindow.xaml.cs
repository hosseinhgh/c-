using System;
using System.Collections.Generic;
using System.IO;
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

namespace SaveSelectedFromList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isModified;

        public MainWindow()
        {
            InitializeComponent();
            //
            string s1 = "abc";
            object o1 = s1;
            string s2 = o1.ToString();
            string s3 = (string)o1;

            //
        }

        private void btSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            List<string> nameList = new List<string>();

            foreach (ListViewItem item in lvNames.SelectedItems)
            {
//                item.Content.ToString

                nameList.Add((string)(item.Content));
                /*
                string name = (string) item.Content;
                nameList.Add(name); */
            }

            File.WriteAllLines("selected.txt", nameList);

        }
    }
}
