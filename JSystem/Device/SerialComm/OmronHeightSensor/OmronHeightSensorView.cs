using System;
using Sunny.UI;

namespace JSystem.Device
{
    public partial class OmronHeightSensorView : SerialCommView
    {
        public OmronHeightSensorView(OmronHeightSensor device)
        {
            InitializeComponent();
            _device = device;
            device.OnUpdateDisp += UpdateValue;
        }

        public override void Refresh()
        {
            base.Refresh();
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

        private void Btn_SetBank_Click(object sender, EventArgs e)
        {
            OmronHeightSensor magnetic = (OmronHeightSensor)_device;
            magnetic.ChangeBank(CB_Bank.Text);
        }
    }
}
