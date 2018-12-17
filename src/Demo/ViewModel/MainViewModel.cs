using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class MainViewModel : Monica.Mvvm.BindableBase
    {
        private int _a;

        public int A
        {
            get { return _a; }
            set { SetProperty(ref _a, value); }
        }

        private int _b;

        public int B
        {
            get { return _b; }
            set { SetProperty(ref _b, value); }
        }

        private int _c;

        public int C
        {
            get { return _c; }
            set { SetProperty(ref _c, value); }
        }


        public ICommand EnterCommand { get { return new Monica.Commands.DelegateCommand(Enter); } }


        private void Enter()
        {
            C = A + B;
        }
    }
}
