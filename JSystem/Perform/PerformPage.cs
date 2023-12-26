using System;
using System.Drawing;
using System.Threading.Tasks;
using Sunny.UI;
using JSystem.Device;
using JSystem.Station;
using JSystem.Param;
using System.IO;
using FileHelper;

namespace JSystem.Perform
{
    public partial class PerformPage : UIPage
    {
        private SysController _controller;

        private int _totalCount = 0;

        private int _passCount = 0;

        private int _failCount = 0;

        public PerformPage()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void Init(SysController controller)
        {
            try
            {
                _controller = controller;
                _controller.OnUpdateState = UpdateState;
                TestStation station = (TestStation)_controller.StationMgr.StationList.Find((s) => s.Name == "测试工站");
                station.OnInitDisp = InitDisp;
                station.OnSendRets = UpdateView;
                station.OnSetCT = DispCT;
                runningMsgPanel.Init(LogManager.Instance);
                InitDisp();
            }
            catch (Exception ex)
            {
                throw new Exception("主页初始化失败：" + ex.Message);
            }
        }

        private void UpdateState(EDeviceState state)
        {
            if (InvokeRequired)
                BeginInvoke(new Action(() => { UpdateState(state); }));
            else
            {
                _controller.CurrState = state;
                switch (state)
                {
                    case EDeviceState.UNINIT:
                        StatusPanel.UpdateState(state, 0, 0, 0, 0);
                        Btn_Reset.Enabled = true;
                        Btn_Start.BringToFront();
                        break;
                    case EDeviceState.INITING:
                        StatusPanel.UpdateState(state, 0, 0, 2, 0);
                        Btn_Reset.Enabled = false;
                        DGV_Result.Rows.Clear();
                        InitDisp();
                        break;
                    case EDeviceState.INITED:
                        StatusPanel.UpdateState(state, 0, 1, 0, 0);
                        Btn_Reset.Enabled = true;
                        break;
                    case EDeviceState.RUN:
                        StatusPanel.UpdateState(state, 0, 0, 1, 0);
                        Btn_Reset.Enabled = false;
                        Btn_Pause.BringToFront();
                        break;
                    case EDeviceState.PAUSE:
                        StatusPanel.UpdateState(state, 0, 0, 2, 0);
                        Btn_Start.BringToFront();
                        break;
                    case EDeviceState.PAUSEALARM:
                        StatusPanel.UpdateState(state, 0, 2, 0, 1);
                        Btn_Reset.Enabled = false;
                        break;
                    case EDeviceState.EMERGENCY:
                        StatusPanel.UpdateState(state, 2, 0, 0, 1);
                        Btn_Reset.Enabled = true;
                        Btn_Start.BringToFront();
                        break;
                }
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                _controller.Init();
            }).Start();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            if (!_controller.Start())
                UIMessageTip.ShowError("启动失败");
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            if (!_controller.Pause(true))
                UIMessageTip.ShowError("暂停失败");
        }

        private void Btn_End_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            _controller.Stop(true);
        }

        private void Btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            _controller.DeviceMgr.OnSetOut("蜂鸣器", false);
        }

        private void InitDisp()
        {
            DGV_Result.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                DGV_Result.Rows.Add(new object[] { i + 1, "", "", "", "" });
                _controller.DeviceMgr.OnSetOut($"OK指示灯{i + 1}", true);
                _controller.DeviceMgr.OnSetOut($"NG指示灯{i + 1}", false);
            }
        }
        
        private void UpdateView(int idx, string sn, double magneticflux, double height)
        {
            try
            {
                string fielPath = ParamManager.GetStringParam("数据保存路径") + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                if (!File.Exists(fielPath))
                {
                    string header = "时间,SN,结果,磁通量,高度";
                    TxtHelper.FileWrite(ParamManager.GetStringParam("数据保存路径"), header);
                }
                DGV_Result.Rows[idx].Cells[1].Value = sn;
                DGV_Result.Rows[idx].Cells[2].Value = ParamManager.GetDoubleParam("磁通量下限");
                DGV_Result.Rows[idx].Cells[3].Value = magneticflux;
                DGV_Result.Rows[idx].Cells[4].Value = ParamManager.GetDoubleParam("磁通量上限");
                DGV_Result.Rows[idx].Cells[5].Value = ParamManager.GetDoubleParam("测高下限");
                DGV_Result.Rows[idx].Cells[6].Value = height;
                DGV_Result.Rows[idx].Cells[7].Value = ParamManager.GetDoubleParam("测高下限");
                string dec = "OK";
                if (magneticflux < ParamManager.GetDoubleParam("磁通量下限") || magneticflux > ParamManager.GetDoubleParam("磁通量上限") ||
                    height < ParamManager.GetDoubleParam("高度下限") || height > ParamManager.GetDoubleParam("高度上限"))
                    dec = "NG";
                TxtHelper.FileWrite(fielPath, DateTime.Now.ToString("HH-mm-ss") + $",{sn},{dec},{magneticflux},{height}");
                DGV_Result.Rows[idx].DefaultCellStyle.ForeColor = dec == "NG" ? Color.Red : Color.Green;
                _totalCount++;
                //mes上传
                if (dec == "OK")
                {
                    _controller.DeviceMgr.OnSetOut($"OK指示灯{idx + 1}", true);
                    _controller.DeviceMgr.OnSetOut($"NG指示灯{idx + 1}", false);
                    _passCount++;
                    DGV_Result.Rows[idx].Cells[9].Value = dec;
                }
                else
                {
                    _controller.DeviceMgr.OnSetOut($"OK指示灯{idx + 1}", false);
                    _controller.DeviceMgr.OnSetOut($"NG指示灯{idx + 1}", true);
                    _failCount++;
                    DGV_Result.Rows[idx].Cells[9].Value = dec;
                }
                Lb_OK_Pct.Text = ((_passCount / Convert.ToDouble(_totalCount)) * 100).ToString("F1") + "%";
                Lb_Total.Text = _totalCount.ToString();
                Lb_Pass.Text = _passCount.ToString();
                Lb_Fail.Text = _failCount.ToString();
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"结果显示异常{ex.Message}");
            }
        }

        private void DispCT(double ct)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => DispCT(ct)));
            }
            else
            {
                Lb_CT.Text = ct.ToString();
                Lb_UPH.Text = (3600 / ct).ToString("F1");
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            _totalCount = 0;
            _passCount = 0;
            _failCount = 0;
            Lb_Total.Text = _totalCount.ToString();
            Lb_Pass.Text = _passCount.ToString();
            Lb_Fail.Text = _failCount.ToString();
            if (_totalCount == 0)
                Lb_OK_Pct.Text = "100%";
            else
                Lb_OK_Pct.Text = ((_passCount / Convert.ToDouble(_totalCount)) * 100).ToString("F1") + "%";
        }
    }
}
