using System;
using System.Windows.Forms;
using Sunny.UI;
using BoardSDK;

namespace JSystem.Device
{
    public partial class BoardView : UserControl
    {
        private Board _device;

        public BoardView()
        {
            InitializeComponent();
        }

        public BoardView(Board device) : this()
        {
            _device = device;
            device.OnUpdateStatus += UpdateStatus;
        }

        public override void Refresh()
        {
            base.Refresh();
            CbB_Board_Type.Items.Clear();
            foreach (EBoardType type in Enum.GetValues(typeof(EBoardType)))
                CbB_Board_Type.Items.Add(type.ToString());
            CbB_Board_Type.SelectedIndex = _device.BoardType;
            Btn_Connect.Selected = _device.CheckConnection();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                if (!_device.Connect())
                    UIMessageBox.Show("板卡连接失败，请检查是否被占用");
            }
            else
            {
                _device.DisConnect();
            }
        }

        private void CbB_Cam_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _device.BoardType = CbB_Board_Type.SelectedIndex;
        }

        public void UpdateStatus(bool isConnected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateStatus(isConnected); }));
            }
            else
            {
                if (Btn_Connect.Selected == isConnected)
                    return;
                if (isConnected)
                {
                    Btn_Connect.Selected = true;
                    foreach (Control control in Controls)
                    {
                        if (control is UIComboBox || control is UITextBox)
                            control.Enabled = false;
                    }
                }
                else
                {
                    Btn_Connect.Selected = false;
                    foreach (Control control in Controls)
                    {
                        if (control is UIComboBox || control is UITextBox)
                            control.Enabled = true;
                    }
                }
            }
        }

        private void Btn_Rel_Move_Click(object sender, EventArgs e)
        {
            int axis = Convert.ToInt32(TB_RelMove_Axis.Text);
            double moveVelH = Convert.ToDouble(TB_RelMove_VelH.Text);
            double moveVelL = Convert.ToDouble(TB_RelMove_VelL.Text);
            double moveAcc = Convert.ToDouble(TB_RelMove_Acc.Text);
            double moveDcc = Convert.ToDouble(TB_RelMove_Dcc.Text);
            double dist = Convert.ToDouble(TB_RelMove_Dist.Text);
            _device.RelMove(axis, moveVelL, moveVelH, moveAcc, moveDcc, dist);
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            int axis = Convert.ToInt32(TB_Reset_Axis.Text);
            double resetVelH = Convert.ToDouble(TB_Reset_VelH.Text);
            double resetVelL = Convert.ToDouble(TB_Reset_VelL.Text);
            double resetAcc = Convert.ToDouble(TB_Reset_Acc.Text);
            double resetDcc = Convert.ToDouble(TB_Reset_Dcc.Text);
            uint mode = Convert.ToUInt32(TB_Reset_Mode.Text);
            uint dir = Convert.ToUInt32(TB_Reset_Dir.Text);
            _device.GoHome(axis, resetVelL, resetVelH, resetAcc, resetDcc, mode, dir);
        }
    }
}
