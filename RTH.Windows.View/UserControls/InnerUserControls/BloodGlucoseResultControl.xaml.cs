﻿using RTH.Business.Objects;
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
    /// Interaction logic for BloodGlucoseResultControl.xaml
    /// </summary>
    public partial class BloodGlucoseResultControl : AnswerBase
    {
        public BloodGlucoseResultControl()
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
                    a.question = q._id;
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.answer = "mmol";
                    q.SelectedAnswers.Add(a);
                }
                else
                {
                    if (q.SelectedAnswers[0].answer == null || Convert.ToString(q.SelectedAnswers[0].answer) == "none") { q.SelectedAnswers[0].answer = "mmol"; }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "mmol")
                    {
                        q.SelectedAnswers[0].responsemmol_l = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToString(q.SelectedAnswers[0].response) == "" || Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "0" : Convert.ToString(q.SelectedAnswers[0].response))));
                        q.SelectedAnswers[0].responsemmol_l = q.SelectedAnswers[0].responsemmol_l == "0" ? "" : q.SelectedAnswers[0].responsemmol_l;
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "mg")
                    {
                        q.SelectedAnswers[0].responsemmol_l = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToString(q.SelectedAnswers[0].response) == "" || Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "0" : Convert.ToString(q.SelectedAnswers[0].response))));
                        q.SelectedAnswers[0].responsemmol_l = q.SelectedAnswers[0].responsemmol_l == "0" ? "" : q.SelectedAnswers[0].responsemmol_l;
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "g")
                    {
                        q.SelectedAnswers[0].responsemmol_l = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToString(q.SelectedAnswers[0].response) == "" || Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "0" : Convert.ToString(q.SelectedAnswers[0].response))));
                        q.SelectedAnswers[0].responsemmol_l = q.SelectedAnswers[0].responsemmol_l == "0" ? "" : q.SelectedAnswers[0].responsemmol_l;
                    }
                }
            }
            else
            {
                q = (Question)e.OldValue;
                q.SelectedAnswers[0].ClearResponses();
                switch (q.SelectedAnswers[0].answer.ToString())
                {
                    case "mmol":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_l;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemmol_l;

                        break;
                    case "mg":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_l;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemg_dl;

                        break;
                    case "g":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_l;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemg_g_l;

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
