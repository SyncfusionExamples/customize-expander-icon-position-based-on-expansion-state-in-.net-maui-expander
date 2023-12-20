using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderMaui.Helper
{
    #region ExpanderIconConverter

    public class Converter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            {
                if ((bool)value!)
                {
                    if ((string)parameter! == "Android")
                        return "\ue704";
                    else if ((string)parameter! == "iOS")
                        return "\ue700";
                    else
                        return "\ue702";
                }
                else
                {
                    if ((string)parameter! == "Android")
                        return "\ue705";
                    else if ((string)parameter! == "iOS")
                        return "\ue701";
                    else
                        return "\ue703";
                }
            }

            public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region ExpanderVisibilityConverter
        public class ExpanderVisibilityConverter : IValueConverter
        {
            public object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            {
                if ((string)parameter! == "Header")
                    return (bool)value! ? false : true;
                else
                    return (bool)value! ? true : false;
            }

            public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
 }

