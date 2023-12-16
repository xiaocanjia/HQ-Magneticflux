using System;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.IO
{
    public partial class DIView : UserControl
    {
        public string DIName;

        private bool _isOn = false;

        public Func<string, bool> OnGetIn;

        public DIView(string name)
        {
            InitializeComponent();
            DIName = name;
            Lbl_Name.Text = name;
            //Light_IsOn.State = OnGetIn(DIName) ? UILightState.On : UILightState.Off;
        }

        public void UpdateState()
        {
            if (OnGetIn == null || _isOn == OnGetIn(DIName))
                return;
            _isOn = !_isOn;
            if (InvokeRequired)
                BeginInvoke(new Action(() => { Light_IsOn.State = _isOn ? UILightState.On : UILightState.Off; }));
            else
                Light_IsOn.State = _isOn ? UILightState.On : UILightState.Off;
        }
    }
}
