using FileHelper;
using System;
using System.Windows.Forms;

namespace JSystem.Perform
{
    public partial class LogPanel : UserControl
    {
        LogManager _manager;

        public LogPanel()
        {
            InitializeComponent();
        }

        public void Init(LogManager manager)
        {
            _manager = manager;
            manager.OnAddLog = ShowLog;
        }

        public void ShowLog(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { ShowLog(msg); }));
            }
            else
            {
                try
                {
                    TB_Log.AppendText(msg);
                }
                catch { }
            }
        }

        private void Btn_Open_Dir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "JLog");
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "配置文件|*.log";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                TxtHelper.FileWrite(dialog.FileName, TB_Log.Text);
            }
        }
    }
}
