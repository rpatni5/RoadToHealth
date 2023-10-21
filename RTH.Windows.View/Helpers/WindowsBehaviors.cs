using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RTH.Windows.Views.Helpers
{
    public class WindowBehaviors : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            CommandBinding CloseCommandBinding = new CommandBinding(ApplicationCommands.Close, 
                CloseCommandExecuted, CloseCommandCanExecute);
            AssociatedObject.CommandBindings.Add(CloseCommandBinding);

            CommandBinding MinimizeCommandBinding = new CommandBinding(SystemCommands.MinimizeWindowCommand,
                MinimizeCommandExecuted, MinimizeCommandCanExecute);
            AssociatedObject.CommandBindings.Add(MinimizeCommandBinding);
        }

        private void CloseCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            AssociatedObject.Close();
        }

        private void CloseCommandCanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MinimizeCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(AssociatedObject);
        }

        private void MinimizeCommandCanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }

}
