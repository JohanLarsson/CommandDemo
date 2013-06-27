using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandDemo.Annotations;

namespace CommandDemo
{
    public class DummyVm : INotifyPropertyChanged
    {
        public DummyVm()
        {
            IncreaseCommand = new DummyCommand<DummyVm>(this, d => d.Method(), d => d.Number < 10);
            IncreaseIfEvenCommand = new DummyCommand<DummyVm>(this, d => d.Method(), d => d.Number < 10 && d.Number%2==0);
            DecreaseCommand = new DummyCommand<DummyVm>(this, d => d.Number--, d => d.Number > 0);
        }

        public ICommand IncreaseCommand { get; private set; }
        public ICommand IncreaseIfEvenCommand { get; private set; }
        public ICommand DecreaseCommand { get; private set; }


        public void Method()
        {
            Number++;
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                if (value == _number) return;
                _number = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
