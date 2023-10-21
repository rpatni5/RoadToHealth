using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ExploreChatHistoryView.xaml
    /// </summary>
    public partial class ExploreChatHistoryView : ViewBase
    {
        public ExploreChatHistoryView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            vm = ViewModelLocator.GetNew<ExploreChatHistoryViewModel>();
            this.ViewModel = vm;
            base.LoadViewModel();
        }
        ExploreChatHistoryViewModel vm;
        public void StartChat(Engagement obj)
        {
            AsyncCall.Invoke(() =>
            {
                List<Engagement> lst = vm.GetHistoryDesc(obj._id);

                lst.ForEach(c =>
                {
                    List<string> lstChat = FetchData(c.engage_statement);
                    lstChat.ForEach(i =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            chatScroll.ScrollToBottom();
                            var chatBox = new ChatBox(i, false);
                            coachControl.Children.Add(chatBox);
                        });
                    });
                    if (!string.IsNullOrEmpty(c.option))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            ChatResponseButton btn = new ChatResponseButton(c.option);
                            btn.DataContext = c;
                            btn.Content = c.option;
                            coachControl.Children.Add(btn);
                            chatScroll.ScrollToBottom();
                        });
                    }
                    if (c == lst.Last())
                    {
                        Dispatcher.Invoke(() =>
                        {
                            coachControl.Children.Add(new ChatBox("End of the Chat", false));
                        });
                    }
                });

                Dispatcher.Invoke(() =>
                {
                    ChatResponseButton btn = new ChatResponseButton("Back");
                    btn.DataContext = null;
                    responseControl.Children.Add(btn);
                    chatScroll.ScrollToBottom();
                    btn.Click += btn_Click;
                });
            });
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Click -= btn_Click;
            responseControl.Children.Clear();

            if (btn.DataContext == null)
            {
                App.SharedValues.WindowMain.BackCommand.Execute(null);
            }
        }

        private List<string> FetchData(string str)
        {
            return str.Split('\n').ToList();
        }

    }

}
