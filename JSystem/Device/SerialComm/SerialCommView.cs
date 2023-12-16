﻿using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace JSystem.Device
{
    public partial class SerialCommView : UserControl
    {
        protected SerialComm _device;

        public string _msgList = "";

        public SerialCommView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        public SerialCommView(SerialComm device) : this()
        {
            _device = device;
        }

        public override void Refresh()
        {
            base.Refresh();
            _device.OnUpdateStatus += UpdateStatus;
            _device.OnDispMsg += DispMsg;
            CbB_Port_Name.Items.Clear();
            CbB_Port_Name.Items.AddRange(SerialPort.GetPortNames());
            CbB_Port_Name.SelectedItem = _device.PortName;
            CbB_BaudRate.SelectedItem = _device.BaudRate.ToString();
            CbB_DataBits.SelectedItem = _device.DataBits.ToString();
            CbB_StopBits.SelectedIndex = (int)_device.StopBits;
            CbB_Parity.SelectedIndex = (int)_device.Parity;
            Btn_Connect.Selected = _device.CheckConnection();
            CB_Enabled.Checked = _device.IsEnable;
            CB_Enabled.CheckedChanged += new EventHandler(CB_Enabled_CheckedChanged);
            CbB_Port_Name.SelectedIndexChanged += new EventHandler(CbB_Com_SelectedIndexChanged);
            CbB_DataBits.SelectedIndexChanged += new EventHandler(CbB_Com_SelectedIndexChanged);
            CbB_BaudRate.SelectedIndexChanged += new EventHandler(CbB_Com_SelectedIndexChanged);
            CbB_Parity.SelectedIndexChanged += new EventHandler(CbB_Com_SelectedIndexChanged);
            CbB_StopBits.SelectedIndexChanged += new EventHandler(CbB_Com_SelectedIndexChanged);
        }

        private void CB_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            _device.IsEnable = CB_Enabled.Checked;
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                if (!_device.Connect())
                {
                    UIMessageBox.Show("串口连接失败，可能被占用或者串口信息填写错误");
                    return;
                }
                Btn_Connect.Selected = true;
                foreach (Control control in Controls)
                {
                    if (control is UIComboBox)
                        control.Enabled = false;
                }
            }
            else
            {
                _device.DisConnect();
                Btn_Connect.Selected = false;
                foreach (Control control in Controls)
                {
                    if (control is UIComboBox)
                        control.Enabled = true;
                }
            }
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
                        if (control is UIComboBox)
                            control.Enabled = false;
                    }
                }
                else
                {
                    Btn_Connect.Selected = false;
                    foreach (Control control in Controls)
                    {
                        if (control is UIComboBox)
                            control.Enabled = true;
                    }
                }
            }
        }

        private void CbB_Port_Name_ButtonClick(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            if (names.Length == CbB_Port_Name.Items.Count)
                return;
            CbB_Port_Name.Items.Clear();
            CbB_Port_Name.Items.AddRange(SerialPort.GetPortNames());
        }

        private void CbB_Com_SelectedIndexChanged(object sender, EventArgs e)
        {
            _device.PortName = CbB_Port_Name.Text;
            _device.BaudRate = Convert.ToInt32(CbB_BaudRate.SelectedItem);
            _device.DataBits = Convert.ToInt32(CbB_DataBits.SelectedItem);
            _device.StopBits = (StopBits)CbB_StopBits.SelectedIndex;
            _device.Parity = (Parity)CbB_Parity.SelectedIndex;
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (_device.IsHex)
                {
                    string[] cmd = TB_Send.Text.Split(' ');
                    List<byte> dataBytes = new List<byte>();
                    foreach (string c in cmd)
                        dataBytes.Add(Convert.ToByte("0x" + c, 16));
                    _device.WriteCommand(dataBytes.ToArray());
                }
                else
                {
                    _device.WriteCommand(TB_Send.Text);
                }
                DispMsg("发->" + TB_Send.Text);
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        protected void DispMsg(string msg)
        {
            _msgList += $"{DateTime.Now.ToString("HH:mm:ss:fff")}   {msg}{Environment.NewLine}";
        }

        private void CB_Disp_Sync_CheckedChanged(object sender, EventArgs e)
        {
            Timer_Monitor.Enabled = CB_Disp_Sync.Checked;
            _device.IsDisplay = CB_Disp_Sync.Checked;
        }

        private void CB_Is_Hex_CheckedChanged(object sender, EventArgs e)
        {
            _device.IsHex = CB_Is_Hex.Checked;
        }

        private void Timer_Monitor_Tick(object sender, EventArgs e)
        {
            TB_Log.AppendText(_msgList);
            _msgList = "";
        }
    }
}
