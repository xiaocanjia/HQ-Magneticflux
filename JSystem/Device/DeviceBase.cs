using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace JSystem.Device
{
    public class DeviceBase
    {
        public string Name;

        public bool IsEnable = true;

        [JsonIgnore]
        public UserControl View;

        [JsonIgnore]
        public DevStatusPanel StatusPanel;

        [JsonIgnore]
        public Action<bool> OnUpdateStatus;

        public virtual void SetUserRight(string right) { View.Enabled = (right != "操作员"); }

        public virtual bool Connect() { return true; }

        public virtual void DisConnect() { }

        public virtual bool CheckConnection() { return true; }
    }
}
