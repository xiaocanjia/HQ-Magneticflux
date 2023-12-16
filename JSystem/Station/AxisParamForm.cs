using System;
using Sunny.UI;

namespace JSystem.Station
{
    public partial class AxisParamForm : UIForm
    {
        private StationAxis _axis;

        public AxisParamForm()
        {
            InitializeComponent();
        }

        public AxisParamForm(StationAxis axis) : this()
        {
            _axis = axis;
            TB_MoveVelH.Text = axis?.MoveVelH.ToString();
            TB_MoveVelL.Text = axis?.MoveVelL.ToString();
            TB_ManulVel.Text = axis?.ManulVel.ToString();
            TB_MoveAcc.Text = axis?.MoveAcc.ToString();
            TB_MoveDcc.Text = axis?.MoveDcc.ToString();
            TB_Accuracy.Text = axis?.Accuracy.ToString();
            TB_HomeVelH.Text = axis?.HomeVelH.ToString();
            TB_HomeVelL.Text = axis?.HomeVelL.ToString();
            TB_HomeAcc.Text = axis?.HomeAcc.ToString();
            TB_HomeDcc.Text = axis?.HomeDcc.ToString();
            TB_HomeMode.Text = axis?.HomeMode.ToString();
            TB_HomeOffset.Text = axis?.HomeOffset.ToString();
            TB_HomeDir.Text = axis?.HomeDir.ToString();
            TB_PlusePerMM.Text = axis?.PlusePerUnit.ToString();
            Lb_Unit.Text = $"脉冲每{axis?.Unit}";
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (_axis == null)
                return;
            try
            {
                _axis.MoveVelH = Convert.ToDouble(TB_MoveVelH.Text);
                _axis.MoveVelL = Convert.ToDouble(TB_MoveVelL.Text);
                _axis.MoveAcc = Convert.ToDouble(TB_MoveAcc.Text);
                _axis.MoveDcc = Convert.ToDouble(TB_MoveDcc.Text);
                _axis.ManulVel = Convert.ToDouble(TB_ManulVel.Text);
                _axis.Accuracy = Convert.ToDouble(TB_Accuracy.Text);
                _axis.HomeVelH = Convert.ToDouble(TB_HomeVelH.Text);
                _axis.HomeVelL = Convert.ToDouble(TB_HomeVelL.Text);
                _axis.HomeAcc = Convert.ToDouble(TB_HomeAcc.Text);
                _axis.HomeDcc = Convert.ToDouble(TB_HomeDcc.Text);
                _axis.HomeMode = Convert.ToUInt32(TB_HomeMode.Text);
                _axis.HomeDir = Convert.ToUInt32(TB_HomeDir.Text);
                _axis.HomeOffset = Convert.ToDouble(TB_HomeOffset.Text);
                _axis.PlusePerUnit = Convert.ToUInt32(TB_PlusePerMM.Text);
                _axis.OnSaveParam?.Invoke();
                Close();
            }
            catch
            {
                UIMessageBox.Show("输入格式错误");
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
