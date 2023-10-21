﻿using RTH.Business.Objects;
using RTH.Windows.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DatePickerControl.xaml
    /// </summary>
    public partial class DatePickerControl : AnswerBase
    {
        public DatePickerControl()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Question q = (Question)e.NewValue;

            //if (q.SelectedAnswers == null)
            //{
            //    DateTime dtDefault = DateTime.Now.AddYears(-20);
            //    q.SelectedAnswers = new ObservableCollection<Answer>();
            //    Answer a = new Answer();
            //    a.date = a.date = Convert.ToString(DateTime.Now.Ticks);;
            //    a.key_string = q.key_string;
            //    a.element_type = q.element_type;
            //    a.answer = dtDefault;
            //    a.question = q._id;
            //    q.SelectedAnswers.Add(a);
            //}
            Question q = null;
            if (e.OldValue == null)
            {
                q = (Question)e.NewValue;
                if (q.SelectedAnswers == null)
                {
                    Answer a = new Answer();
                    if (UIHelper.FindParent<QuestionNavigatorView>(this) != null)
                    {
                        DateTime dt = DateTime.Today.AddYears(-20);
                        a.answer = dt;
                    }
                    q.SelectedAnswers = new ObservableCollection<Answer>();
                    a.date = a.date = Convert.ToString(DateTime.Now.Ticks); ;
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;

                    q.SelectedAnswers.Add(a);
                }
            }

        }

        private void DateAnswer_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Globalization.DateTimeFormatInfo df = new System.Globalization.DateTimeFormatInfo();
            df.ShortDatePattern = "YYYY-MM-DD";
            Question q = (DataContext as Question);
            if (q != null)
            {
                if (q.SelectedAnswers == null)
                { q.SelectedAnswers = new ObservableCollection<Answer>(); }
                if (DateAnswer.SelectedDate != null)
                {
                    String DOB = Convert.ToString(Convert.ToDateTime(DateAnswer.SelectedDate).ToString("yyyy-MM-dd"));
                    q.SelectedAnswers[0].response = q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].answer = DOB;
                }
            }
        }
        public void OpenQuestionHelper()
        {
            // transition.LoadControl(QuestionHelperContainer.FindResource("QuestionHelper"));
        }
    }
}
