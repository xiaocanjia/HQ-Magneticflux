using Newtonsoft.Json;

namespace JSystem.IO
{
    public class IOsParam
    {
        public DIParam[] DIsParam;  //输入

        public DOParam[] DOsParam;  //输出
    }

    public class DIParam
    {
        public string BoardName = "";

        public int AxisIndex = 0;

        public int PointIndex = 0;

        public string Name = "";

        [JsonIgnore]
        public bool State = false;
    }

    public class DOParam
    {
        public string BoardName = "";

        public int AxisIndex = 0;

        public int PointIndex = 0;

        public string Name = "";
    }
}
