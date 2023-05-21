using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notepad.Models.FileTypes;
using Notepad.Models;

namespace Notepad.ViewModels.Converters
{
    public class FileTypeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (value is FileTypes @f_t)
            {
                string icon = @f_t switch
                {
                    SysDrive => "sys_drive",
                    Drive => "drive",
                    BackFolder => "back_folder",
                    Folder => "folder",
                    FILE => "file",
                    _ => ""
                };
                var app = Application.Current;
                if (app == null) return null;
                var ress = app.Resources;
                var img = (Image?)ress[icon];
                if (img == null) return null;
                return (Bitmap?)img.Source;
            }
            throw new NotSupportedException();
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
