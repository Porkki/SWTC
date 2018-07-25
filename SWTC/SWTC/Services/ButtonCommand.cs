using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWTC.Services
{
    class ButtonCommand : ICommand
    {
        private Action _Action;
        private Func<bool> _Function;

        public ButtonCommand(Action action, Func<bool> function)
        {
            _Action = action;
            _Function = function;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _Function();
        }

        public void Execute(object parameter)
        {
            _Action();
        }

    }
}
