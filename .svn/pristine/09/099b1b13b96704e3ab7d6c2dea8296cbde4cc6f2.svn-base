using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ShowCoaches.xaml
    /// </summary>
    public partial class ShowCoachesView : ViewBase
    {

        public ShowCoachesView()
        {
            InitializeComponent();
            ctrlTransistion.Transition = Controls.Transition.Left;
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ShowCoachViewModel>();
            base.LoadViewModel();
        }
        #region CommandDeclartion
        private RelayCommand m_MoveToPreviousCommand;
        public RelayCommand MoveToPreviousCommand
        {
            get
            {
                return m_MoveToPreviousCommand ?? (m_MoveToPreviousCommand = new RelayCommand(
                    ve => ExecuteMove(-1), (t) => true));
            }
        }
        private RelayCommand m_MoveToNextCommand;
        public RelayCommand MoveToNextCommand
        {
            get
            {
                return m_MoveToNextCommand ?? (m_MoveToNextCommand = new RelayCommand(
                    ve => ExecuteMove(1), (t) => true));
            }
        }
        private void ExecuteMove(object ve)
        {
            ShowCoachViewModel oShowCoachViewModel = this.ViewModel as ShowCoachViewModel;
            if (Convert.ToInt32(ve) == 1)
            {
                ctrlTransistion.Transition = Controls.Transition.Left;
            }
            else {
                ctrlTransistion.Transition = Controls.Transition.Right;
            }
            oShowCoachViewModel.ExecuteMove(ve);

        }
        private RelayCommand m_SaveCoachommand;
        public RelayCommand SaveCoachommand
        {
            get
            {
                return m_SaveCoachommand ?? (m_SaveCoachommand = new RelayCommand(
                    ve => SaveCoach(ve), (t) =>
                    {
                        var vm = this.ViewModel as ShowCoachViewModel;
                        if (vm.CurrentCoach == null) return false;
                        return true;
                    }));
            }
        }

        private async void SaveCoach(object ve)
        {
            ShowCoachViewModel oShowCoachViewModel = this.ViewModel as ShowCoachViewModel;
            Int32 _status = await oShowCoachViewModel.SaveCoach();
            if (_status == 0)
            {
                //App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.DashboardView, param: true);
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
        }


        #endregion
    }
}
