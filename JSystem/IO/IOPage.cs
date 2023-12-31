﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.IO
{
    public partial class IOPage : UIPage
    {
        private IOManager _manager;

        public IOPage()
        {
            InitializeComponent();
            FormClosing += IOPage_FormClosing;
        }

        private void IOPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IOPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Init(IOManager manager)
        {
            if (manager == null)
                return;
            _manager = manager;
            _manager.OnSetUserRight = SetUserRight;
            Panel_In.Controls.Clear();
            Panel_Out.Controls.Clear();
            foreach (DIParam param in _manager.IOsParams.DIsParam)
            {
                DIView view = new DIView(param.Name);
                view.OnGetIn = _manager.GetIn;
                Panel_In.Controls.Add(view);
            }
            foreach (DOParam param in _manager.IOsParams.DOsParam)
            {
                DOView view = new DOView(param.Name);
                view.OnSetOut = _manager.SetOut;
                Panel_Out.Controls.Add(view);
            }
        }

        public void StartMonitor()
        {
            if (Tab_IO.SelectedIndex == 0)
            {
                Timer_IO_Monitor.Enabled = true;
            }
            else
            {
                foreach (Control control in Panel_Out.Controls)
                {
                    if (control is DOView doView)
                        doView.UpdateState();
                }
            }
        }

        public void StopMonitor()
        {
            Timer_IO_Monitor.Enabled = false;
            if (Tab_IO.SelectedIndex == 1)
            {
                foreach (Control control in Panel_Out.Controls)
                {
                    if (control is DOView doView)
                        doView.UpdateState();
                }
            }
        }

        private void SetUserRight(string right)
        {
            foreach (Control control in Panel_Out.Controls)
            {
                if (control is DOView doView)
                    doView.SetUserRight(right);
            }
        }

        private void Tab_IO_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Tab_IO.SelectedIndex)
            {
                case 0:
                    StartMonitor();
                    break;
                case 1:
                    StopMonitor();
                    break;
            }
        }

        private void Timer_IO_Monitor_Tick(object sender, EventArgs e)
        {
            new Task(() =>
            {
                foreach (Control control in Panel_In.Controls)
                {
                    if (!Timer_IO_Monitor.Enabled)
                        return;
                    if (control is DIView diView)
                        diView.UpdateState();
                }
            }).Start();
        }
    }
}
