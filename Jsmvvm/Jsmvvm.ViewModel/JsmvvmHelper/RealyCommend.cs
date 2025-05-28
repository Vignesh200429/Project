using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jsmvvm.ViewModel.JsmvvmHelper
{
    public class RealyCommend : ICommand 
    {

        

        public event EventHandler? CanExecuteChanged;

        public Action _execute;

        public RealyCommend (Action action)
        {
            _execute = action;
        }

        public bool CanExecute (object? parameter)
        {
            return true;
        }

        public void Execute (object? parameter)
        {
            _execute.Invoke();
        }
    }
}
