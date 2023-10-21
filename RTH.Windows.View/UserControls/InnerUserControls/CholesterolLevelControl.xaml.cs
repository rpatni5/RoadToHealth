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
    /// Interaction logic for CholesterolLevelControl.xaml
    /// </summary>
    public partial class CholesterolLevelControl : AnswerBase
    {
        public CholesterolLevelControl()
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
                    a.answer = "mmol";
                    q.SelectedAnswers.Add(a);
                }
                else
                {
                    q.SelectedAnswers[0].answer = Convert.ToString(q.SelectedAnswers[0].answer) == "" || Convert.ToString(q.SelectedAnswers[0].answer) == "none" ? "mmol" : q.SelectedAnswers[0].answer;
                    if (Convert.ToString(q.SelectedAnswers[0].answer) == "mmol")
                    {
                        q.SelectedAnswers[0].responsemmol_lTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1);
                        q.SelectedAnswers[0].responsemmol_lHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2);
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer) == "mg")
                    {
                        q.SelectedAnswers[0].responsemg_dlTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1);
                        q.SelectedAnswers[0].responsemg_dlHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2);
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer) == "g")
                    {
                        q.SelectedAnswers[0].responsemg_g_lTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1) =="0"?"": q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1);
                        q.SelectedAnswers[0].responsemg_g_lHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2) == "0"?"": q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2);
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
                        //q.SelectedAnswers[0].responsemmol_lTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lTotalCholesterol);
                        //q.SelectedAnswers[0].responsemmol_lHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lHDL);
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_lHDL == "0" ? "0" : Convert.ToString(decimal.Parse(q.SelectedAnswers[0].responsemmol_lTotalCholesterol) / decimal.Parse(q.SelectedAnswers[0].responsemmol_lHDL));
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemmol_lTotalCholesterol;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responsemmol_lHDL;
                        break;
                    case "mg":
                        //q.SelectedAnswers[0].responsemmol_lTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lTotalCholesterol);
                        //q.SelectedAnswers[0].responsemmol_lHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lHDL);
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_lHDL == "0" ? "0" : Convert.ToString(decimal.Parse(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lTotalCholesterol)) / decimal.Parse(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lHDL)));
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemg_dlTotalCholesterol;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responsemg_dlHDL;

                        break;
                    case "g":
                        //q.SelectedAnswers[0].responsemmol_lTotalCholesterol = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lTotalCholesterol);
                        //q.SelectedAnswers[0].responsemmol_lHDL = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lHDL);
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responsemmol_lHDL == "0" ? "0" : Convert.ToString(decimal.Parse(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lTotalCholesterol)) / decimal.Parse(q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].responsemmol_lHDL))); ;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responsemg_g_lTotalCholesterol;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responsemg_g_lHDL;

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
