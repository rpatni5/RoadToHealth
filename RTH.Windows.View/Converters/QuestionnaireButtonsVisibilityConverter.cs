using RTH.Business.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class QuestionnaireButtonsVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2) return Visibility.Collapsed;
            if (parameter == null || string.IsNullOrEmpty(parameter.ToString())) return Visibility.Collapsed;
            if (values[0] == null) return Visibility.Collapsed;
            if (values[1] == null) return Visibility.Collapsed;
            ArrayList questions = (ArrayList)values[0];

            if (questions == null || questions.Count == 0) return Visibility.Collapsed;
            Question currentQuestion = (Question)values[1];
            switch (parameter.ToString().ToLower())
            {
                case "continue":
                    if (((Question)questions[0])._id == currentQuestion._id) return Visibility.Visible;
                    break;
                case "next":
                    if (((Question)questions[0])._id != currentQuestion._id && questions[questions.Count - 1] != currentQuestion) return Visibility.Visible;
                    break;
                case "prev":/// if currentQuestion is not the first one (ie, not at 0 index)
                    if (((Question)questions[0])._id != currentQuestion._id) return Visibility.Visible; ;
                    break;
                case "submit":/// if currentQuestion is the last one (ie, not at 0 index)
                    if ((((Question)questions[0])._id != currentQuestion._id) && (Question)questions[questions.Count - 1] == currentQuestion) return Visibility.Visible; ;
                    break;
                default:
                    return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
