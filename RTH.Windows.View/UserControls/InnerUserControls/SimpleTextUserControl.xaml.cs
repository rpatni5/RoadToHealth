﻿using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SimpleTextUserControl.xaml
    /// </summary>
    public partial class SimpleTextUserControl : AnswerBase
    {
        public SimpleTextUserControl()
        {
            InitializeComponent();
            this.element_type = 4;
            DataContextChanged += OnDataContextChanged;
            // Unloaded += OnUnloaded;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Question q = null;
            if (e.OldValue == null)
            {
                q = (Question)e.NewValue;
                if (q.SelectedAnswers == null)
                {
                    q.SelectedAnswers = new ObservableCollection<Answer>();
                    Answer a = new Answer();
                    a.date = a.date = Convert.ToString(DateTime.Now.Ticks); ;
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;
                    q.SelectedAnswers.Add(a);
                }
            }
            else if (e.NewValue != null)
            {
                q = (Question)e.OldValue;
                q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].answer) == "none" || q.SelectedAnswers[0].answer == null ? q.SelectedAnswers[0].response : q.SelectedAnswers[0].answer;
                q.SelectedAnswers[0].answer = "none";
                q.SelectedAnswers[0].response1 = "none";
                q.SelectedAnswers[0].response2 = "none";
                if (((Question)e.OldValue).element_type == ((Question)e.NewValue).element_type)
                {
                    if (((Question)e.NewValue).SelectedAnswers == null)
                    {
                        Question newQuestion = (Question)e.NewValue;
                        newQuestion.SelectedAnswers = new ObservableCollection<Answer>();
                        Answer a = new Answer();
                        a.date = a.date = Convert.ToString(DateTime.Now.Ticks); ;
                        a.key_string = newQuestion.key_string;
                        a.element_type = newQuestion.element_type;
                        a.question = newQuestion._id;
                        newQuestion.SelectedAnswers.Add(a);
                    }
                }
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Question q = (DataContext as Question);
            if (q.SelectedAnswers == null) q.SelectedAnswers = new ObservableCollection<Answer>();

            if (q.SelectedAnswers.Count() > 0)
            {
                q.SelectedAnswers[0].answer = txtAnswer.Text;
                q.SelectedAnswers[0].response = txtAnswer.Text;
                q.SelectedAnswers[0].response1 = "none";
                q.SelectedAnswers[0].response2 = "none";
            }
            else
            {
                q.SelectedAnswers.Add(new Answer
                {
                    answer = txtAnswer.Text,
                    response = txtAnswer.Text,
                    response1 = "none",
                    response2 = "none",
                    date = DateTime.UtcNow.ToString(),
                    element_type = q.element_type,
                    key_string = q.key_string
                });
            }
        }

        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            Question q = (DataContext as Question);
            if (q != null && q.SelectedAnswers != null && q.SelectedAnswers.Count() > 0)
            {
                q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].answer) == "none" ? txtAnswer.Text : q.SelectedAnswers[0].answer;
                q.SelectedAnswers[0].answer = "none";
                q.SelectedAnswers[0].response1 = "none";
                q.SelectedAnswers[0].response2 = "none";
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox txt = sender as TextBox;
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            Question q = this.DataContext as Question;
            q.HasErrors = txt.GetBindingExpression(TextBox.TextProperty).HasValidationError;
        }
    }
}
