﻿using System;
using System.Windows.Forms;

namespace JSystem.Device
{
    public partial class ScanningGunView : SerialCommView
    {
        public ScanningGunView(ScanningGun device)
        {
            InitializeComponent();
            _device = device;
            device.OnUpdateStatus += UpdateStatus;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Start_Command.Text = ((ScanningGun)_device).StartCommand;
            TB_End_Command.Text = ((ScanningGun)_device).EndCommand;
            TB_Max_Length.Text = ((ScanningGun)_device).MaxLength.ToString(); ;
        }

        private void Btn_Read_Click(object sender, EventArgs e)
        {
            Lb_SN.Text = ((ScanningGun)_device).ReadSN();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            try
            {
                ((ScanningGun)_device).StartCommand = TB_Start_Command.Text;
                ((ScanningGun)_device).EndCommand = TB_End_Command.Text;
                ((ScanningGun)_device).MaxLength = Convert.ToInt32(TB_Max_Length.Text);
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }
    }
}
