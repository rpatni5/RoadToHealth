using RTH.Business.Objects;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
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
    /// Interaction logic for LifeStyleQuestionnaireView.xaml
    /// </summary>
    public partial class LifeStyleView : ViewBase
    {
        public LifeStyleView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.DataContext = ViewModelLocator.GetNew<LifeStyleViewModel>();
            base.LoadViewModel();
        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }

        private RelayCommand _LoadLifeStyle;
        public RelayCommand LoadLifeStyle
        {
            get
            {
                return _LoadLifeStyle ?? (_LoadLifeStyle = new RelayCommand(vm =>
                {
                    if (vm != null)
                    {
                        GlobalData.Default.ClickedHRA = vm as DiseaseData;

                        App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.QuestionNavigatorView);
                    }

                },
                vm => { return true; }));
            }
        }
    }
}
;