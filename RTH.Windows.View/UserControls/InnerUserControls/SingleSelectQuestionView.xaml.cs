﻿using RTH.Business.Objects;
using RTH.Windows.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SingleSelectQuestionView.xaml
    /// </summary>
    public partial class SingleSelectQuestionView : AnswerBase
    {
        public SingleSelectQuestionView() : base()
        {
            InitializeComponent();
            this.element_type = 0;
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            Question q = (Question)e.NewValue;
            if (this.element_type == q.element_type)
            {
                if (q.SelectedAnswers == null || q.SelectedAnswers.Count == 0)
                {
                    q.SelectedAnswers = new ObservableCollection<Answer>();
                    Answer a = new Answer();
                    a.date = Convert.ToString(DateTime.Now.Ticks);
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;
                    q.SelectedAnswers.Add(a);
                }
            }
            else if(q.element_type==1) {
                if (q.SelectedAnswers == null || q.SelectedAnswers.Count == 0)
                {
                    q.SelectedAnswers = new ObservableCollection<Answer>();
                    Answer a = new Answer();
                    a.date = Convert.ToString(DateTime.Now.Ticks);
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;
                    q.SelectedAnswers.Add(a);
                }
            }
        }

        private async void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsEnabled = false;
            string ans = (sender as RadioButton).Tag.ToString();
            Question q = (DataContext as Question);
            await Task.Run(() =>
            {

                q.SelectedAnswers[0].answer = ans;
                //Following function is a hack only for the purpose of navigation to the next question.
                Thread.Sleep(50);
                NavigateToNextQuestion();
            });
        }



        /// <summary>
        /// Navigates to the next question in the row using QuestionNavigatorView's ExecuteContinueCommand
        /// </summary>
        private void NavigateToNextQuestion()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (UIHelper.FindParent<QuestionNavigatorView>(this) != null)
                {
                    QuestionNavigatorView questionNavigator = UIHelper.FindParent<QuestionNavigatorView>(this);
                    questionNavigator.ExecuteContinueCommand(questionNavigator.DataContext);
                }
                else if (UIHelper.FindParent<HealthPlanQuestionnaireView>(this) != null)
                {
                    HealthPlanQuestionnaireView questionNavigator = UIHelper.FindParent<HealthPlanQuestionnaireView>(this);
                    questionNavigator.ExecuteContinueCommand(questionNavigator.DataContext);
                }
            }));

        }

        private void RadioButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext == null) return;
            Question q = (DataContext as Question);
            if (q.SelectedAnswers == null || !q.SelectedAnswers.Any() || q.SelectedAnswers[0].answer == null || string.IsNullOrEmpty(q.SelectedAnswers[0].answer.ToString())) return;
            RadioButton rdb = sender as RadioButton;
            rdb.IsChecked = q.SelectedAnswers[0].answer.ToString() == rdb.Tag.ToString();
        }
    }
}
