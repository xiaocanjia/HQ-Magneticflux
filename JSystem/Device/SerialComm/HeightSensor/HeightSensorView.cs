using System;

namespace JSystem.Device
{
    public partial class HeightSensorView : SerialCommView
    {
        public HeightSensorView(HeightSensor device)
        {
            InitializeComponent();
            _device = device;
        }

        public void UpdateHeight()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateHeight(); }));
            }
            else
            {
                HeightSensor device = (HeightSensor)_device;
                Lbl_Height.Text = device.ReadHeight().ToString();
            }
        }
    }
}
