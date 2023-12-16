using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
using JSystem.Perform;
using System.Threading.Tasks;
using Popup;

namespace JSystem.Station
{
    public partial class StationView : UIPage
    {
        StationBase _station;

        public StationView()
        {
            InitializeComponent();
        }

        public StationView(StationBase station) : this()
        {
            _station = station;
            foreach (StationAxis axis in station.Axes)
            {
                AxisPanel panel = axis.View;
                axis.View.Refresh();
                Panel_Axes.Controls.Add(panel);
                Panel_Axes.Height += (panel.Height + 3);
                Panel_PointInfo.Location = new Point(Panel_PointInfo.Location.X, Panel_PointInfo.Location.Y + panel.Height + 3);
                Panel_PointInfo.Height = Page_Point.Height - Panel_Axes.Height - 15;
                DGV_PointInfo.Columns.Add(axis.Name, axis.Name);
                DGV_PointInfo.Columns[DGV_PointInfo.Columns.Count - 1].Width = 90;
                DGV_PointInfo.Columns[DGV_PointInfo.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (station.DebugForm != null)
            {
                Page_Debug.Controls.Add(station.DebugForm);
                station.DebugForm.Dock = DockStyle.Fill;
            }
            else
            {
                Page_Debug.Parent = null;
            }
        }

        public void UpdatePointsInfo()
        {
            try
            {
                if (_station.Model.PointsInfo == null)
                    return;
                DGV_PointInfo.Rows.Clear();
                foreach (PointInfo point in _station.Model.PointsInfo)
                {
                    object[] info = new object[_station.Axes.Length + 1];
                    info[0] = point.Name;
                    int idx = 1;
                    for (int i = 1; i <= _station.Axes.Length; i++)
                    {
                        info[idx] = double.IsNaN(point.Pos[i - 1]) ? "/" : point.Pos[i - 1].ToString();
                        idx++;
                    }
                    DGV_PointInfo.Rows.Add(info);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog("点位更新异常" + ex.Message);
            }
        }

        public void SetEnable(bool isEnable)
        {
            foreach (StationAxis axis in _station.Axes)
                axis.View.SetEnable(isEnable);
            DGV_PointInfo.ReadOnly = !isEnable;
            foreach (Control control in Panel_PointInfo.Controls)
            {
                if (control is UIButton button)
                    button.Enabled = isEnable;
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            for (int i = 0; i < DGV_PointInfo.Rows.Count; i++)
            {
                for (int j = 0; j < _station.Axes.Length; j++)
                    _station.Model.PointsInfo[i].Pos[j] = DGV_PointInfo.Rows[i].Cells[j + 1].Value.ToString() == "/" ? double.NaN : Convert.ToDouble(DGV_PointInfo.Rows[i].Cells[j + 1].Value);
            }
            UIMessageTip.Show("应用成功");
            LogManager.Instance.AddLog("点位应用成功");
        }

        private void Btn_Record_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            if (DGV_PointInfo.CurrentRow == null)
                return;
            if (!UIMessageBox.ShowAsk($"请确认是否将当前坐标记录到{DGV_PointInfo.CurrentRow.Cells[0].Value}"))
                return;
            for (int i = 0; i < _station.Axes.Length; i++)
                DGV_PointInfo.CurrentRow.Cells[i + 1].Value = _station.Axes[i].GetCmdPos();
        }

        private void Btn_SingleAxisMove_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
            {
                UIMessageBox.Show("请先选择您想要运动的轴");
                return;
            }
            if (DGV_PointInfo.CurrentCell == null || DGV_PointInfo.CurrentCell.Value.ToString() == "/")
                return;
            int idx = DGV_PointInfo.CurrentCell.ColumnIndex - 1;
            if (idx < 0) return;
            _station.Axes[idx].AbsMove(Convert.ToDouble(DGV_PointInfo.CurrentCell.Value), _station.Axes[idx].ManulVel);
        }

        private void Btn_AllAxisMove_Click(object sender, EventArgs e)
        {
            if (!UIMessageBox.ShowAsk("即将进行多轴运动，请确保没有撞机风险"))
                return;
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            if (DGV_PointInfo.CurrentRow == null)
                return;
            for (int i = 0; i < _station.Axes.Length; i++)
            {
                if (DGV_PointInfo.CurrentRow.Cells[i + 1].Value.ToString() == "/")
                    continue;
                _station.Axes[i].AbsMove(Convert.ToDouble(DGV_PointInfo.CurrentRow.Cells[i + 1].Value), _station.Axes[i].ManulVel);
            }
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            foreach (StationAxis axis in _station.Axes)
                axis.EndMove();
        }

        private void CbB_MoveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (StationAxis axis in _station.Axes)
                axis.View.SetMoveType(CbB_MoveType.Text);
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            if (!UIMessageBox.ShowAsk("请确定是否进行单工站复位"))
                return;
            new Task(() =>
            {
                _station.Reset();
            }).Start();
        }

        public DialogResult DispAlarm(string msg)
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<DialogResult>(() => { return DispAlarm(msg); }));
            }
            else
            {
                _station.OnPause(false);
                DialogResult ret = WarningForm.Show(_station.Name, msg);
                if (ret == DialogResult.Abort)
                    _station.OnStop(true);
                else
                    _station.OnStart();
                return ret;
            }
        }

        public void DispConfirm(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { DispConfirm(msg); }));
            }
            else
            {
                ConfirmForm.Show(_station.Name, msg);
            }
        }
    }
}
