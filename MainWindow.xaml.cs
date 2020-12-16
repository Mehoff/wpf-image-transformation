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
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> myCollection { get; set; }
        public MainWindow()
        {
            Initialize();
            InitializeComponent();
            
        }
        private void Initialize() 
        {
            myCollection = new ObservableCollection<string>();
            myCollection.Add("Asd");
            myCollection.Add("Asd");
            myCollection.Add("Asd");


            //RadioButtonList is NULL
            //RadioButtonList.ItemsSource = myCollection;

        }
    }
}
