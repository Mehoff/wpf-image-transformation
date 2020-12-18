using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ImageTransformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class SomeData 
    {
        public string myString { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<SomeData> myCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Initialize();

        }
        private void Initialize() 
        {
            myCollection = new ObservableCollection<SomeData>
            {
                new SomeData
                {
                    myString = "Data 1"
                },
                new SomeData
                {
                    myString = "Data 2"
                },
                new SomeData
                {
                    myString = "Data 3"
                },
                new SomeData
                {
                    myString = "Data 4"
                },
                new SomeData
                {
                    myString = "Data 5"
                }
            };
            RadioButtonList.ItemsSource = myCollection;

        }
    }
}
