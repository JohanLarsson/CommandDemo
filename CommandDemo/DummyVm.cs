using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandDemo
{
    public class DummyVm
    {
        public DummyVm()
        {
            DummyCommand= new DelegateCommand()
        }
        public ICommand DummyCommand { get; private set; }
    }
}
