﻿using RTH.Business.Objects;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for QuealthCoachView.xaml
    /// </summary>
    public partial class QuealthCoachView : ViewBase
    {
        public QuealthCoachView()
        {
            InitializeComponent();
        }
        DispatcherTimer _tmr = new DispatcherTimer();
        private bool IsAnimate;
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<TermsAndConditionsViewModel>();
            IsAnimate = true;
        }
        public override void OnViewLoaded()
        {
            ((App)Application.Current).SetApplicationTheme();
        }

        public void CoachSuggestion(object param)
        {
            if (param.Equals("BeforeLogin"))
            {
                ViewModelBase.conversationAnswer.Clear();
                SuggestionBeforeLogin();
            }
            else if (param.Equals("AfterLogin"))
            {
                SuggestionAfterLogin();
            }
        }
        List<Question> ListCon;
        public Question Current { set; get; }
        private bool IsBeforeLogin;
        private async void SuggestionBeforeLogin()
        {
            coachControl.Children.Clear();
            responseControl.Children.Clear();
            Reset();
            await AsyncCall.Invoke(() =>
            {
                ListCon = (this.ViewModel as TermsAndConditionsViewModel).GetPreConversation();
                return true;
            });
            GetEnumerator(null);
            lstChat = FetchData();
            DisplayChat(lstChat, IsBeforeLogin = true);

        }
        private int chatWaitTime = 2000;
        private int chatItrerator = 0;
        private async void DisplayChat(List<string> lstChat, bool isBeforeLogin)
        {
            viewTyping.Visibility = Visibility.Visible;
            chatScroll.ScrollToBottom();
            chatItrerator = 0;
            int count = lstChat.Count;
            for (chatItrerator = 0; chatItrerator < count;)
            {
                await AsyncCall.Invoke(() =>
                {
                    Thread.Sleep(chatWaitTime);
                    if (chatWaitTime != 0)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            AddChatBlock();
                        });
                    }
                    chatWaitTime = 2000;
                    return true;
                }, false);
            }
        }

        private void AddChatBlock()
        {
            try
            {
                if (lstChat != null && chatItrerator < lstChat.Count)
                {
                    chatScroll.ScrollToBottom();
                    coachControl.Children.Add(new ChatBox(lstChat[chatItrerator], false));
                    ViewModelBase.conversationAnswer.Add(GetAnswerBag());
                    chatItrerator++;
                    if (chatItrerator == lstChat.Count)
                    {
                        lstChat = null;
                        viewTyping.Visibility = Visibility.Collapsed;
                        ButtonSignUp(IsBeforeLogin);
                    }
                }
            }
            catch
            {

            }
        }


        private async void SuggestionAfterLogin()
        {
            responseControl.Children.Clear();
            if (ViewModelBase.conversationAnswer.Count > 0)
                ViewModelBase.SubmitChatHRA(ViewModelBase.conversationAnswer);
            viewTyping.Visibility = Visibility.Visible;
            coachControl.Children.Clear();
            Reset();
            await AsyncCall.Invoke(() =>
            {
                ListCon = (this.ViewModel as TermsAndConditionsViewModel).GetPostConversation();
                return true;
            });
            GetEnumerator(null);
            lstChat = FetchData();
            DisplayChat(lstChat, IsBeforeLogin = false);
        }
        private List<string> FetchData()
        {
            string str = ((Question)(Current)).question;
            return str.Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
        private Answer GetAnswerBag()
        {
            Option AnswerOption = ((Question)(Current)).answers[0];
            return new Answer
            {
                answer_text = AnswerOption.answer_text,
                answer_label = AnswerOption.answer_label,
                answer_value = AnswerOption.answer_value,
                _id = AnswerOption._id,
                answer_overrider = AnswerOption.answer_overrider,
                key_string = ((Question)(Current)).key_string,
                element_type = ((Question)(Current)).element_type,
                question = ((Question)(Current))._id
            };

        }
        private void ButtonSignUp(bool IsBeforeLogin)
        {
            List<Option> lstOption = ((Question)(Current)).answers.ToList();
            lstOption.ForEach(c =>
            {
                ChatResponseButton btn = new ChatResponseButton(c.answer_text);
                btn.DataContext = c;
                btn.Content = c.answer_text;
                responseControl.Children.Add(btn);
                chatScroll.ScrollToBottom();
                if (IsBeforeLogin)
                {
                    btn.Click += btnGetStarted_Click;
                }
                else
                {
                    btn.Click += btnLetsGo_Click;
                }
            });



            //btn.SetValue(VisibilityProperty, Visibility.Visible);
            //Storyboard qSB = new Storyboard();
            //ThicknessAnimation da = new ThicknessAnimation(new Thickness(300, 10, 0, 10), new Thickness(0, 10, 0, 10), TimeSpan.FromSeconds(0.50));
            //Storyboard.SetTarget(da, btn);
            //Storyboard.SetTargetProperty(da, new PropertyPath(Border.MarginProperty));
            //qSB.Children.Add(da);
            //qSB.Begin();
        }
        public bool MoveNext(string id)
        {
            var obj = ListCon.FirstOrDefault(x => x.dependency.dependency_answer.Any(y => (string)y == id));
            if (obj != null)
            {
                Current = obj;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            ListCon = null;
        }
        public void GetEnumerator(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Current = ListCon.FirstOrDefault(x => x.dependency.dependency_question == null);
            }
            else
            {
                Current = ListCon.FirstOrDefault(x => x.dependency.dependency_answer.Any(y => (string)y == id));
            }
        }
        private void btnGetStarted_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);

            if (MoveNext((btn.DataContext as Option)._id))
            {
                coachControl.Children.Add(new ChatBox(btn.Content.ToString(), true));
                responseControl.Children.Clear();
                lstChat = FetchData();
                DisplayChat(lstChat, IsBeforeLogin = true);
            }
            else
            {
                App.SharedValues.WindowMain.LoadView(ViewEnum.UserRegistrationView);
            }
        }
        List<string> lstChat;
        private void btnLetsGo_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            if (MoveNext((btn.DataContext as Option)._id))
            {
                coachControl.Children.Add(new ChatBox(btn.Content.ToString(), true));
                responseControl.Children.Clear();
                lstChat = FetchData();
                DisplayChat(lstChat, IsBeforeLogin = false);
            }
            else
            {

                ViewModelBase.SubmitChatHRA(ViewModelBase.conversationAnswer);
                ViewModelBase.conversationAnswer.Clear();
                App.SharedValues.WindowMain.LoadView(ViewEnum.MotivationView);
            }
        }

        private void ViewBase_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstChat != null && chatItrerator < lstChat.Count)
            {
                chatWaitTime = 0;
                AddChatBlock();
            }
        }
    }
}
