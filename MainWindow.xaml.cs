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
    

    public partial class MainWindow : Window
    {
        private ObservableCollection<TransformableImage> images;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();

        }
        private void Initialize() 
        {
            UpdateImagesList();
        }
        private void UpdateImagesList() 
        {
            images = ImagesLoader.LoadImages();
           // ListView
            RadioButtonList.ItemsSource = images;
        }

        // RadioButtonList.Items - Коллекция TransformableImages 
        // Задача, найти коллекцию контролов RadioButton, или индекс нажатого радиобаттона
        // Пытался найти способ связать коллекцию радиобаттонов и коллекцию моих объектов , но не смог

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            var resourceName = button.Tag.ToString();
            
            foreach (var item in RadioButtonList.Items)
            {
                var t_img = (TransformableImage)item;

                if (string.Equals(resourceName, t_img.Name))
                {
                    ImageSpace.Source = t_img.Image;
                    break;
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            MakeSliderAction(slider);
        }

        private void MakeSliderAction(Slider slider) 
        {
            switch (slider.Name) 
            {
                case "sWidth": ChangeWidth(slider);
                    break;
                case "sHeight": 
                    break;
                case "sMoveX":
                    break;
                case "sMoveY":
                    break;
                case "sTiltX":
                    break;
                case "sTiltY":
                    break;
                case "sClockwise":
                    break;
            }
        }

        private void ChangeWidth(Slider slider) 
        {

        }
    }
}
