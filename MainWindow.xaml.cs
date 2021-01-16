using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ImageTransformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public struct ImageInfo
    {
        public TransformGroup transformGroup;
        public SkewTransform skewTransform;
        public TranslateTransform translateTransform;
        public RotateTransform rotateTransform;

        public double Width { get; set; }
        public double Height { get; set; }

        public double SkewX { get; set; }
        public double SkewY { get; set; }

        public double cX { get; set; }
        public double cY { get; set; }

        public double clockwise { get; set; }
        public void SetValues(Image image) 
        {
            Width = image.Source.Width;
            Height = image.Source.Height;
        }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<TransformableImage> images;
        private ImageInfo currentImageInfo;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Initialize();
        }
        private void Initialize() 
        {
            UpdateImagesList();
        }
        private void UpdateImagesList() 
        {
            currentImageInfo = new ImageInfo();
            
            currentImageInfo.transformGroup = new TransformGroup();
            currentImageInfo.skewTransform = new SkewTransform();
            currentImageInfo.translateTransform = new TranslateTransform();
            currentImageInfo.rotateTransform = new RotateTransform();
            currentImageInfo.transformGroup.Children.Add(currentImageInfo.skewTransform);
            currentImageInfo.transformGroup.Children.Add(currentImageInfo.translateTransform);
            currentImageInfo.transformGroup.Children.Add(currentImageInfo.rotateTransform);

            images = ImagesLoader.LoadImages();
            RadioButtonList.ItemsSource = images; 
        }

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
                    currentImageInfo.SetValues(ImageSpace);
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
            if (ImageSpace == null)
                return;

            switch (slider.Name) 
            {
                case "sWidth":
                    ChangeWidth(slider);
                    break;
                case "sHeight":
                    ChangeHeight(slider);
                    break;
                case "sMoveX":
                    MoveX(slider);
                    break;
                case "sMoveY":
                    MoveY(slider);
                    break;
                case "sTiltX":
                    TiltX(slider);
                    break;
                case "sTiltY":
                    TiltY(slider);
                    break;
                case "sClockwise":
                    Clockwise(slider);
                    break;
            }
        }

        private void ChangeWidth(Slider slider) 
        {
            slider.Maximum = currentImageInfo.Width;
            ImageSpace.Width = slider.Value;
        }

        private void ChangeHeight(Slider slider)
        {
            slider.Maximum = currentImageInfo.Height;
            ImageSpace.Height = slider.Value;
        }

        private void MoveX(Slider slider) 
        {
            currentImageInfo.cX = slider.Value;
            currentImageInfo.translateTransform.X = currentImageInfo.cX;
            ImageSpace.RenderTransform = currentImageInfo.transformGroup;
            
        }
        private void MoveY(Slider slider)
        {
            currentImageInfo.cY = slider.Value;
            currentImageInfo.translateTransform.Y = currentImageInfo.cY;
            ImageSpace.RenderTransform = currentImageInfo.transformGroup;

        }
        private void TiltX(Slider slider) 
        {
            currentImageInfo.SkewX = slider.Value;
            currentImageInfo.skewTransform.AngleX = currentImageInfo.SkewX;
            ImageSpace.RenderTransform = currentImageInfo.transformGroup;
        }
        private void TiltY(Slider slider)
        {
            currentImageInfo.SkewY = slider.Value;
            currentImageInfo.skewTransform.AngleY = currentImageInfo.SkewY;
            ImageSpace.RenderTransform = currentImageInfo.transformGroup;
        }
        private void Clockwise(Slider slider) 
        {
            currentImageInfo.clockwise = slider.Value;

            currentImageInfo.rotateTransform.CenterX = ImageSpace.ActualWidth / 2;
            currentImageInfo.rotateTransform.CenterY = ImageSpace.ActualHeight / 2;

            currentImageInfo.rotateTransform.Angle = currentImageInfo.clockwise;
            ImageSpace.RenderTransform = currentImageInfo.transformGroup;
        }

    }
}
