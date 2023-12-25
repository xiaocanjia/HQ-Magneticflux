using System;
using Sunny.UI;

namespace JSystem.Device
{
    public partial class MagneticFluxView : SerialCommView
    {
        public MagneticFluxView(MagneticFlux device)
        {
            InitializeComponent();
            _device = device;
            device.OnUpdateDisp += UpdateValue;
        }

        public override void Refresh()
        {
            base.Refresh();
        }
        
        private void Btn_SetRange_Click(object sender, EventArgs e)
        {
            MagneticFlux magnetic = (MagneticFlux)_device;
            if (!magnetic.SetRange(CB_Range.Text))
                UIMessageTip.ShowError("设置失败");
        }

        private void Btn_SetUnit_Click(object sender, EventArgs e)
        {
            MagneticFlux magnetic = (MagneticFlux)_device;
            if (!magnetic.SetUnit(CB_Unit.Text))
                UIMessageTip.ShowError("设置失败");
        }

        public void UpdateValue(double value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateValue(value); }));
            }
            else
            {
                Lb_Value.Text = value.ToString();
            }
        }

        private void Btn_EncoderZeroing_Click(object sender, EventArgs e)
        {
            MagneticFlux magnetic = (MagneticFlux)_device;
            if (!magnetic.ClearZero())
                UIMessageTip.ShowError("清零失败");
        }
    }
}
