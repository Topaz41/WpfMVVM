using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp3
{
    enum Position
    {
        JuniorEmployee,
        MiddleEmployee,
        SeniorEmployee,
        Manager,
        ProjectManager
    }

    public class positionEnumValueConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Position.JuniorEmployee: return "Junior";
                case Position.MiddleEmployee: return "Middle";
                case Position.SeniorEmployee: return "Senior";
                case Position.Manager: return "Manager";
                case Position.ProjectManager: return "PM";
                default: return "Unknown Value";
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Junior": return Position.JuniorEmployee;
                case "Middle": return Position.MiddleEmployee;
                case "Senior": return Position.SeniorEmployee;
                case "Manager": return Position.Manager;
                case "PM": return Position.ProjectManager;
                default: return "Unknown Value";
            }
        }
    }
}
