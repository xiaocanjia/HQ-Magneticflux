using System;
using Sunny.UI;

namespace JSystem.Device
{
    public partial class ZimmerGripperView : TCPClientView
    {
        public ZimmerGripperView(ZimmerGripper device)
        {
            InitializeComponent();
            CbB_Channel.SelectedIndex = 0;
            _device = device;
        }

        private void Btn_Tighten_Click(object sender, EventArgs e)
        {
            int channel = CbB_Channel.SelectedIndex;
            ushort teachPos = 0;
            byte tolerance = 0;
            byte force =0;
            try
            {
                teachPos = Convert.ToUInt16(TB_Teach_Pos.Text);
                tolerance = Convert.ToByte(TB_Tolerance.Text);
                force = Convert.ToByte(TB_Force.Text);
            }
            catch
            {
                UIMessageBox.Show("参数格式填写错误，请检查！");
                return;
            }
            ((ZimmerGripper)_device).SwitchGripper(channel, true, teachPos, tolerance, force);
        }

        private void Btn_Release_Click(object sender, EventArgs e)
        {
            int channel = CbB_Channel.SelectedIndex;
            ushort teachPos = 0;
            byte tolerance = 0;
            byte force = 0;
            try
            {
                teachPos = Convert.ToUInt16(TB_Teach_Pos.Text);
                tolerance = Convert.ToByte(TB_Tolerance.Text);
                force = Convert.ToByte(TB_Force.Text);
            }
            catch
            {
                UIMessageBox.Show("参数格式填写错误，请检查！");
                return;
            }
            ((ZimmerGripper)_device).SwitchGripper(channel, false, teachPos, tolerance, force);
        }

        private void Btn_Read_Click(object sender, EventArgs e)
        {
            ushort[] input = ((ZimmerGripper)_device).GetStatus(CbB_Channel.SelectedIndex);
            Lbl_Status.Text = input[0].ToString("X2");
            Label_Error.Text = input[1].ToString("X2");
            Lbl_Pos.Text = input[2].ToString("X2");
        }
    }
}
