using RTH.Business.Objects;
using RTH.Windows.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MultiSelectDragDropUserControl.xaml
    /// </summary>
    public partial class MultiSelectDragDropUserControl : AnswerBase
    {
        ListViewDragDropManager<Option> dragMgr;

        public MultiSelectDragDropUserControl()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
            this.Loaded += MultiSelectDragDropUserControl_Loaded;
        }

        private void MultiSelectDragDropUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // This is all that you need to do, in order to use the ListViewDragManager.
            this.dragMgr = new ListViewDragDropManager<Option>(this.listView);

             // Hook up events on both ListViews to that we can drag-drop
             // items between them.
             this.listView.DragEnter += OnListViewDragEnter;
            this.listView.Drop += OnListViewDrop;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Question q = (Question)e.NewValue;
            if (q.element_type == 7)
            {
                if (q.SelectedAnswers == null)
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

        private async void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chkMultiSelect = sender as CheckBox;
            Question q = (DataContext as Question);
            dynamic _answer = (sender as CheckBox).Tag.ToString();
            bool _MoveToNextQuestion = false;
            if (chkMultiSelect.IsChecked == true)
            {
                if (q.SelectedAnswers.Any())
                {
                    if (q.SelectedAnswers[0].answer == null || (Convert.ToString(q.SelectedAnswers[0].answer) == "none") || (Convert.ToString(q.SelectedAnswers[0].answer) == ""))
                    {
                        Answer a = q.SelectedAnswers[0];
                        q.SelectedAnswers.Remove(a);
                    }
                }
                if (bool.Parse((sender as CheckBox).ToolTip.ToString()))
                {
                    q.SelectedAnswers = new ObservableCollection<Answer>();
                    _MoveToNextQuestion = true;
                }
                else
                {
                    if (q.SelectedAnswers.Any(m => m.answer_overrider == true))
                    {
                        q.SelectedAnswers.Remove((Answer)q.SelectedAnswers.Where(m => m.answer_overrider == true).FirstOrDefault());
                    }
                }
                var _getAnswer = (from _a in q.SelectedAnswers where _a.answer == _answer select _a);
                if (_getAnswer.Count() == 0)
                {
                    Answer a = new Answer();
                    a.date = null;
                    a.key_string = q.key_string;
                    a.element_type = q.element_type;
                    a.question = q._id;
                    a.answer = _answer;
                    a.answer_overrider = bool.Parse((sender as CheckBox).ToolTip.ToString());
                    q.SelectedAnswers.Add(a);
                }

            }
            else
            {
                //var _getAnswer = (from _a in q.SelectedAnswers where _a.answer == _answer select _a);
                foreach (var item in q.SelectedAnswers)
                {
                    if (item.answer.ToString() == _answer)
                    {
                        q.SelectedAnswers.Remove(item);
                        break;
                    }
                }

            }
            var ans = q.answers;
            q.answers = null;
            q.answers = ans;
            await Task.Run(() =>
            {
                if (_MoveToNextQuestion)
                {
                    Thread.Sleep(100);
                    NavigateToNextQuestion();
                }
            });
        }


        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Question q = (Question)DataContext;
            var Answer = q.SelectedAnswers;
            //foreach (var item in Answer)
            //{
            //    if(Convert.ToString(item.answer) == "none") { q.SelectedAnswers.Remove(item); }
            //}
            chk.IsChecked = false;
            chk.IsChecked = q.SelectedAnswers.Any(a => a.answer != null && a.answer.ToString() == chk.Tag.ToString());
        }

        private void NavigateToNextQuestion()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                QuestionNavigatorView questionNavigator = UIHelper.FindParent<QuestionNavigatorView>(this);
                questionNavigator.ExecuteContinueCommand(questionNavigator.DataContext);
            }));
        }

        #region dragMgr_ProcessDrop

        // Performs custom drop logic for the top ListView.
        void dragMgr_ProcessDrop(object sender, ProcessDropEventArgs<Task> e)
        {
            // This shows how to customize the behavior of a drop.
            // Here we perform a swap, instead of just moving the dropped item.

            int higherIdx = Math.Max(e.OldIndex, e.NewIndex);
            int lowerIdx = Math.Min(e.OldIndex, e.NewIndex);

            if (lowerIdx < 0)
            {
                // The item came from the lower ListView
                // so just insert it.
                e.ItemsSource.Insert(higherIdx, e.DataItem);
            }
            else
            {
                // null values will cause an error when calling Move.
                // It looks like a bug in ObservableCollection to me.
                if (e.ItemsSource[lowerIdx] == null ||
                    e.ItemsSource[higherIdx] == null)
                    return;

                // The item came from the ListView into which
                // it was dropped, so swap it with the item
                // at the target index.
                e.ItemsSource.Move(lowerIdx, higherIdx);
                e.ItemsSource.Move(higherIdx - 1, lowerIdx);
            }

            // Set this to 'Move' so that the OnListViewDrop knows to 
            // remove the item from the other ListView.
            e.Effects = DragDropEffects.Move;
        }

        #endregion // dragMgr_ProcessDrop

        #region OnListViewDragEnter

        // Handles the DragEnter event for both ListViews.
        void OnListViewDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        #endregion // OnListViewDragEnter

        #region OnListViewDrop

        // Handles the Drop event for both ListViews.
        void OnListViewDrop(object sender, DragEventArgs e)
        {
            //if (e.Effects == DragDropEffects.None)
            //    return;

            //Task task = e.Data.GetData(typeof(Task)) as Task;
            //if (sender == this.listView)
            //{
            //    if (this.dragMgr.IsDragInProgress)
            //        return;

            //    // An item was dragged from the bottom ListView into the top ListView
            //    // so remove that item from the bottom ListView.
            //    (this.listView2.ItemsSource as ObservableCollection<Task>).Remove(task);
            //}
            //else
            //{
            //    if (this.dragMgr2.IsDragInProgress)
            //        return;

            //    // An item was dragged from the top ListView into the bottom ListView
            //    // so remove that item from the top ListView.
            //    (this.listView.ItemsSource as ObservableCollection<Task>).Remove(task);
            //}
        }

        #endregion // OnListViewDrop
    }
}
