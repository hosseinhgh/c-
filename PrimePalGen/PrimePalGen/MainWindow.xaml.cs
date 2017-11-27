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

namespace PrimePalGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<long> getPrimeNumbersList(long from, long to, bool onlyPalindromes)
        {
            List<long> result = new List<long>();
            for (long i = from; i <= to; i++)
            {
                int counter = 0;
                for (long num = i; num >= 1; num--)
                {
                    if (i % num == 0)
                    {
                        counter = counter + 1;
                    }
                }
                if (counter == 2)
                {
                    // TODO: check if i is a palindrome as well
                    result.Add(i);
                }
            }
            return result;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
