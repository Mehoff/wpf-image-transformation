using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;

// For MessageBox Only
using System.Windows;

namespace ImageTransformation
{
    public class TransformableImage
    {
        public string Name { get; set; }
        public Image Image { get; set; }
    }
    public static class ImagesLoader 
    {
        public static ObservableCollection<TransformableImage> LoadImages() 
        {
            var collection = new ObservableCollection<TransformableImage>();

            string[] imagePaths = Directory.GetFiles("../../../Images", "*.jpg");

            foreach (var path in imagePaths) 
            {
                int pFrom = path.IndexOf("\\") + "\\".Length;
                int pTo = path.LastIndexOf(".jpg");
                string name = path.Substring(pFrom, pTo - pFrom);

                collection.Add(new TransformableImage { Name = name, Image = null });
            }

            return collection;
        }
        
    }
}
