using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blomstertonden
{
    public class FrameVM
    {
        private ClearDataPackagesCmd _clear;
        public FrameVM()
        {
            _clear = new ClearDataPackagesCmd();
        }

        public ICommand Clear { get => _clear; }
    }
}
