using System;

namespace JSystem.Device
{
    public partial class WeightSensorView : SerialCommView
    {
        public WeightSensorView(WeightSensor device)
        {
            InitializeComponent();
            _device = device;
            device.OnUpdateDisp += UpdateWeight;
        }

        public void UpdateWeight(float[] value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateWeight(value); }));
            }
            else
            {
                Lbl_Weight1.Text = value[0].ToString();
                Lbl_Weight2.Text = value[1].ToString();
            }
        }
    }
}
