using XamFormsAwaitablePopup.ViewModel;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamFormsAwaitablePopup.Converter
{
    public class DisplayAlertTypeToIsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (parameter is null || !(parameter is string))
                return false;

            string[] pars = ((string)parameter).Split('|');

            if (value is DisplayAlertViewModel.EnumInputType && pars != null)
            {
                switch((DisplayAlertViewModel.EnumInputType)value)
                {
                    case DisplayAlertViewModel.EnumInputType.Ok:
                        if (Array.IndexOf(pars,  "OK") >= 0)
                            return true;

                        break;
                    case DisplayAlertViewModel.EnumInputType.YesNo:
                        if (Array.IndexOf(pars, "YESNO") >= 0)
                            return true;

                        break;
                    case DisplayAlertViewModel.EnumInputType.OkCancel:
                        if (Array.IndexOf(pars, "OKCANCEL") >= 0)
                            return true;

                        break;
                    case DisplayAlertViewModel.EnumInputType.OkCancelWithInput:
                        if (Array.IndexOf(pars, "OKCANCELWITHINPUT") >= 0)
                            return true;

                        break;
                    default:
                        return false;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
