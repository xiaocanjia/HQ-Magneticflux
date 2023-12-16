using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Station
{
    public partial class AxisPanel : UserControl
    {
        private StationAxis _axis;

        private string _moveType = "Jog";

        public AxisPanel() { }

        public AxisPanel(StationAxis axis)
        {
            InitializeComponent();
            _axis = axis;
            _axis.OnUpdateView = UpdateStatus;
        }

        public override void Refresh()
        {
            base.Refresh();
            Lbl_Axis_Name.Text = _axis.Name;
        }

        public void SetEnable(bool isEnable)
        {
            Switch_Enable.Enabled = isEnable;
            foreach (Control control in Panel_Axis.Controls)
            {
                if (control is UIButton button)
                {
                    button.Enabled = isEnable;
                }
            }
        }

        public void SetMoveType(string type)
        {
            _moveType = type;
        }

        private void Switch_Enable_ValueChanged(object sender, bool value)
        {
            _axis.SetAxisServoEnabled(value);
        }

        private void Btn_Home_Click(object sender, EventArgs e)
        {
            _axis.GoHome();
        }

        private void Btn_Move_Click(object sender, EventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType == "Jog" || btn == null)
                return;
            if (btn.Symbol == 61544)
                _axis.RelMove(-Convert.ToDouble(_moveType), _axis.ManulVel);
            else if (btn.Symbol == 61543)
                _axis.RelMove(Convert.ToDouble(_moveType), _axis.ManulVel);
        }

        private void Btn_Move_MouseDown(object sender, MouseEventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType != "Jog" || btn == null)
                return;
            _axis.JogMove(btn.Symbol == 61543, _axis.ManulVel);
        }

        private void Btn_Move_MouseUp(object sender, MouseEventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType != "Jog" || btn == null)
                return;
            _axis.EndMove();
        }

        private void Btn_Setup_Click(object sender, EventArgs e)
        {
            AxisParamForm form = new AxisParamForm(_axis);
            form.ShowDialog();
        }

        public void UpdateStatus(double cmdPos, double actPos, byte state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateStatus(cmdPos, actPos, state); }));
            }
            else
            {
                try
                {
                    Tb_CmdPos.Text = cmdPos.ToString();
                    Tb_ActPos.Text = actPos.ToString();
                    Light_Alarm.State = (state & (0x01 << 0)) > 0 ? UILightState.On : UILightState.Off;
                    Light_PL.State = (state & (0x01 << 1)) > 0 ? UILightState.On : UILightState.Off;
                    Light_NL.State = (state & (0x01 << 2)) > 0 ? UILightState.On : UILightState.Off;
                    Light_Origin.State = (state & (0x01 << 3)) > 0 ? UILightState.On : UILightState.Off;
                    Light_Emg.State = (state & (0x01 << 4)) > 0 ? UILightState.On : UILightState.Off;
                    Switch_Enable.Active = (state & (0x01 << 5)) > 0 ? true : false;
                }
                catch { }
            }
        }
    }
}
