using System;

namespace WpfApp1.UserControls
{
    internal interface IUserControl
    {
        public void MouseEnterGridBG(object o, EventArgs e);
        public void MouseLeaveGridBG(object o, EventArgs e);

        public void Open(object o, EventArgs e);
    }
}
