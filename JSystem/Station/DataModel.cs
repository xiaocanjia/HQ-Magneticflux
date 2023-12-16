namespace JSystem.Station
{
    public class DataModel
    {
        public PointInfo[] PointsInfo;
    }

    public class PointInfo
    {
        public PointInfo() { }

        public PointInfo(string name)
        {
            Name = name;
        }

        public string Name;

        public double[] Pos = new double[10];
    }

    public class StationInfo
    {
        public StationAxis[] AxesInfo;

        public string[] PointsName;
    }
}
