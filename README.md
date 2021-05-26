# Monica
A base mvvm extension for WPF, very very very simple!

# How to using

First, install Monica from NuGet.

Second, coding with fllow:

YourViewModel.cs
```
    public class MainViewModel : Monica.Mvvm.BindableBase
    {
        private int _a;
        private int _b;
        private int _c;

        public int A
        {
            get { return _a; }
            set { SetProperty(ref _a, value); }
        }

        public int B
        {
            get { return _b; }
            set { SetProperty(ref _b, value); }
        }

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
```

Enjoy it!
