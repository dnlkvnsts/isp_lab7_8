using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.UI.ValueConverters
{
    public class IdToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "dotnet_bot.png";

            string id = value.ToString();
            
            string path = Path.Combine(FileSystem.AppDataDirectory, "Images", $"{id}.jpg");

            if (File.Exists(path))
            {
                
                var bytes = File.ReadAllBytes(path);
               
                return ImageSource.FromStream(() => new MemoryStream(bytes));
            }

            return ImageSource.FromFile("dotnet_bot.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
