using System;
using Sunny.UI;
using System.Windows.Forms;

namespace JSystem.Station
{
    public partial class StationsPage : UIPage
    {
        private StationManager _manager;

        public StationsPage()
        {
            InitializeComponent();
        }

        public void Init(StationManager manager)
        {
            try
            {
                if (manager == null)
                    return;
                _manager = manager;
                Tab_Stations.TabPages.Clear();
                foreach (StationBase station in manager.StationList)
                {
                    TabPage page = new TabPage(station.Name);
                    Tab_Stations.TabPages.Add(page);
                    page.Controls.Add(station.View);
                    station.View.UpdatePointsInfo();
                    station.View.TopLevel = false;
                    station.View.Dock = DockStyle.Fill;
                    station.View.Show();
                    station.DebugForm?.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"工站界面初始化失败: " + ex.Message);
            }
        }
    }
}
