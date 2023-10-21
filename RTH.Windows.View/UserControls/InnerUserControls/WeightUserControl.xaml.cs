using RTH.Business.Objects;
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
    /// Interaction logic for WeightUserControl.xaml
    /// </summary>
    public partial class WeightUserControl : AnswerBase
    {
        public WeightUserControl()
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
                    a.answer = "kg";
                    q.SelectedAnswers.Add(a);
                }
                else
                {
                    if (String.IsNullOrEmpty(Convert.ToString(q.SelectedAnswers[0].answer))) { q.SelectedAnswers[0].answer = "kg"; }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "kg")
                    {
                        q.SelectedAnswers[0].responseKG = Convert.ToString(q.SelectedAnswers[0].response1) == "0"  || Convert.ToString(q.SelectedAnswers[0].response1) =="none"? "" : Convert.ToString(q.SelectedAnswers[0].response1);
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "st")
                    {
                        //q.SelectedAnswers[0].responseKG = Convert.ToString(q.SelectedAnswers[0].response) == "0" || Convert.ToString(q.SelectedAnswers[0].response) =="none"? "" : Convert.ToString(q.SelectedAnswers[0].response);
                        q.SelectedAnswers[0].responseST = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1)=="0"?"": q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1);
                        q.SelectedAnswers[0].responseSTLB= q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response2);
                    }
                    if (Convert.ToString(q.SelectedAnswers[0].answer).ToLower() == "lb")
                    {
                        q.SelectedAnswers[0].responseLB = q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1) == "0" ? "" : q.SelectedAnswers[0].AnswerIsNullOrEmpty(q.SelectedAnswers[0].response1);
                    }
                }

            }
            else
            {
                q = (Question)e.OldValue;
                q.SelectedAnswers[0].ClearResponses();
                switch (q.SelectedAnswers[0].answer.ToString())
                {
                    case "kg":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseKG;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseKG;
                        break;
                    case "st":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseKG;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseST;
                        q.SelectedAnswers[0].response2 = q.SelectedAnswers[0].responseSTLB;
                        break;
                    case "lb":
                        q.SelectedAnswers[0].response = q.SelectedAnswers[0].responseKG;
                        q.SelectedAnswers[0].response1 = q.SelectedAnswers[0].responseLB;
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
