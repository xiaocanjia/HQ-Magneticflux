using System;

namespace JSystem.Device
{
    public partial class WeightSensorView : SerialCommView
    {
        public WeightSensorView(WeightSensor device)
        {
            InitializeComponent();
            _device = device;
        }

        public void UpdateWeight()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateWeight(); }));
            }
            else
            {
                WeightSensor device = (WeightSensor)_device;
                float[] weightList = device.ReadWeight();
                Lbl_Weight1.Text = weightList[0].ToString();
                Lbl_Weight2.Text = weightList[1].ToString();
            }
        }
    }
}
