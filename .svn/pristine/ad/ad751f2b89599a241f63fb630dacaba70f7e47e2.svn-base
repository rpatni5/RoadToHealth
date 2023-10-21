using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    class CategoryCountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Question> questions = (ObservableCollection<Question>)values[0];
            if (questions == null) return "";

            var CategoryCount = (from Q in questions where Q.Category.name.Equals(values[1].ToString()) select Q).Count();
            var CategoryList = (from q in questions select q.Category.name).Distinct().ToList();
            if ((Question)values[2] != null)
            {
                if(((Question)values[2]).Category.name == values[1].ToString())
                {
                    CategoryCount = ((Question)values[2]).QuestionPosition;
                }
                var CurrentCategoryIndex= CategoryList.IndexOf(((Question)values[2]).Category.name);
                foreach (var item in CategoryList)
                {
                    if (CategoryList.IndexOf((string)values[1]) < CurrentCategoryIndex) { return 0;}
                }

            }
            return CategoryCount;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
