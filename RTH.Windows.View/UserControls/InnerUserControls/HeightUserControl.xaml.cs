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
    /// Interaction logic for HeightUserControl.xaml
    /// </summary>
    public partial class HeightUserControl : AnswerBase

    {
        public HeightUserControl()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
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
                    a.date = Convert.ToString(DateTime.Now.Ticks);
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;
                    a.answer = "cm";
                    q.SelectedAnswers.Add(a);
                }
                else
                {
                    if (String.IsNullOrEmpty(Convert.ToString(q.SelectedAnswers[0].answer))) { q.SelectedAnswers[0].answer = "cm"; }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "m")
                    {
                        q.SelectedAnswers[0].responseCM =
                            Convert.ToString((Math.Round(Convert.ToDecimal(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1))) * 100) + Math.Round(Convert.ToDecimal(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2))));
                        q.SelectedAnswers[0].responseCM = q.SelectedAnswers[0].responseCM == "0" ? "" : q.SelectedAnswers[0].responseCM;
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "cm")
                    {
                        q.SelectedAnswers[0].responseCM = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToString(q.SelectedAnswers[0].response1) == "" || Convert.ToString(q.SelectedAnswers[0].response1) == "none" ? "0" : Convert.ToString(q.SelectedAnswers[0].response1))));
                        q.SelectedAnswers[0].responseCM = q.SelectedAnswers[0].responseCM == "0" ? "" : q.SelectedAnswers[0].responseCM;
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "feet")
                    {
                        q.SelectedAnswers[0].responseFT = Convert.ToString(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1));
                        q.SelectedAnswers[0].responseINCH = Convert.ToString(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2));
                    }
                }

            }
            else
            {
                q = (Question)e.OldValue;
                q.SelectedAnswers[0].ClearResponses();
                if (string.IsNullOrEmpty(Convert.ToString(q.SelectedAnswers[0].answer)))
                {
                    q.SelectedAnswers[0].answer = "m";
                }
                switch (q.SelectedAnswers[0].answer.ToString())
                {
                    case "cm":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseM;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseCM;
                        q.SelectedAnswers[0].answer = "cm";
                        break;
                    case "m":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseM;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseM;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responseMCM == "" ? "0" : q.SelectedAnswers[0].responseMCM;
                        q.SelectedAnswers[0].answer = "m";
                        break;
                    case "feet":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseM;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseFT;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responseINCH;
                        q.SelectedAnswers[0].answer = "feet";
                        break;
                    default:
                        break;
                }
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