using RTH.Windows.ViewModels.Common;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System;

namespace RTH.Windows.Views.Controls
{
    /// <summary>
    /// Interaction logic for ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();

            this.Loaded += HRAControl_Loaded;
        }

        private void HRAControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Suggestion();
        }

        public List<string> ChatList
        {
            get { return (List<string>)GetValue(ChatListProperty); }
            set { SetValue(ChatListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChatList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatListProperty =
            DependencyProperty.Register("ChatList", typeof(List<string>), typeof(ChatControl), new PropertyMetadata(null));


        public async void ChatStrat(Func<bool> OnComplete)
        {
            if (ChatList != null && ChatList.Count > 0)
            {
                coachControl.Children.Clear();
                viewTyping.Visibility = Visibility.Visible;
                chatItrerator = 0;
                int count = ChatList.Count;
                for (chatItrerator = 0; chatItrerator < count;)
                {
                    await AsyncCall.Invoke(() =>
                    {
                        Thread.Sleep(2000);
                        if (chatWaitTime != 0)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                AddChatBlock(OnComplete);
                            });
                        }
                        chatWaitTime = 2000;
                        return true;
                    }, false);
                }
            }
            viewTyping.Visibility = Visibility.Collapsed;
        }
        private void AddChatBlock(Func<bool> OnComplete)
        {
            try
            {
                if (ChatList != null && chatItrerator < ChatList.Count)
                {
                    charScroll.ScrollToBottom();
                    coachControl.Children.Add(new ChatBox(ChatList[chatItrerator], false));
                    chatItrerator++;
                    if (chatItrerator == ChatList.Count)
                    {
                        ChatList = null;
                        viewTyping.Visibility = Visibility.Collapsed;
                        OnComplete();
                    }
                }
            }
            catch
            {

            }
        }


        private int chatWaitTime = 2000;
        private int chatItrerator = 0;
        public void MoveNext(Func<bool> OnComplete)
        {
            if (ChatList != null && chatItrerator < ChatList.Count)
            {
                chatWaitTime = 0;
                AddChatBlock(OnComplete);
            }
        }
    }
}
