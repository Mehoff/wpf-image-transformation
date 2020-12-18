using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageTransformation
{
    public class TransformableImage
    {
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
    }
    public static class ImagesLoader 
    {
        public static ObservableCollection<TransformableImage> LoadImages() 
        {
            var collection = new ObservableCollection<TransformableImage>();

            string[] imagePaths = Directory.GetFiles("../../../Images", "*.jpg");

            foreach (var path in imagePaths) 
            {
                // Trim Name
                int pFrom = path.IndexOf("\\") + "\\".Length;
                int pTo = path.LastIndexOf(".jpg");
                string name = path.Substring(pFrom, pTo - pFrom);

                // Load Image
                var bitmap = new BitmapImage(new Uri(path, UriKind.Relative));

                collection.Add(new TransformableImage { Name = name, Image = bitmap });
            }

            return collection;
        }
        
    }
}
