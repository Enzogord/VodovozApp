﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace VodovozWPF.Infrastructure.Converters
{
    public class ImageToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            Image image = value as Image;
            if(image != null) {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bi = new BitmapImage();
                bi.CacheOption = BitmapCacheOption.None;
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                return bi;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
