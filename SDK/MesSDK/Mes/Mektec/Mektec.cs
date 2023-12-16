using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using JLogging;
using MeasResult;

namespace MesSDK
{
    public class Mektec : IMes
    {
        private MesParam _param;

        private string _MPN;

        public bool Connect(MesParam param)
        {
            try
            {
                _param = param;
                string URL = $"http://{_param.IP}:{_param.Port}/DataUpload/GetMPN";
                string msg = Get(URL);
                if (GetValueFormJson("Result", msg) != "1")
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                LoggingIF.Log(ex.Message);
                return false;
            }
        }

        public bool DisConnect()
        {
            return true;
        }

        public bool Arrival(string sn, out string msg)
        {
            string URL = $"http://{_param.IP}:{_param.Port}/DataUpload/GetMPN/{_param.Lot}";
            msg = Get(URL);
            if (GetValueFormJson("Msg", msg) != "OK")
                return false;
            _MPN = GetValueFormJson("MPN", msg);
            return true;
        }

        public bool Departure(string sn, List<MesResult> retList, out string msg)
        {
            string URL = $"http://{_param.IP}:{_param.Port}/DataUpload/Result";
            JObject key = new JObject
            {
                new JProperty("MPN", _MPN),
                new JProperty("LotNo", _param.Lot),
                new JProperty("UserID", _param.StaffID),
                new JProperty("RouteID", _param.StationID),
                new JProperty("LineID", _param.LineID),
                new JProperty("ProgramNo", _param.Version),
                new JProperty("ShtBarcode", sn)
            };
            JObject value = new JObject
            {
                new JProperty("PcsIndex", "0"),
                new JProperty("PCSBarcode", sn),
                new JProperty("Result", retList.Find((mRet) => mRet.Decision == "FAIL") == null ? "OK" : "NG")
            };
            JObject data = new JObject
            {
                new JProperty("DeviceID", _param.DeviceID),
                new JProperty("StateID", "Add"),
                new JProperty("Key", key),
                new JProperty("Value", value),
                new JProperty("Timestamp", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+08:00"))
            };
            msg = Post(URL, data.ToString());
            return GetValueFormJson("Value", msg) == "Success";
        }

        /// <summary>
        /// GET方式发送得结果
        /// </summary>
        /// <param name="url">请求的url</param>
        private string Get(string url)
        {
            try
            {
                HttpWebRequest hwRequest = (HttpWebRequest)WebRequest.Create(url);
                hwRequest.Method = "GET";
                HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                string strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
                return strResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// POST方式发送得结果
        /// </summary>
        /// <param name="url">请求的url</param>
        private string Post(string url, string send_data)
        {
            try
            {
                HttpWebRequest hwRequest = (HttpWebRequest)WebRequest.Create(url);
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/json";
                StreamWriter writer = new StreamWriter(hwRequest.GetRequestStream());
                writer.Write(send_data);
                writer.Flush();
                HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader reader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                string strResult = reader.ReadToEnd();
                reader.Close();
                hwResponse.Close();
                return strResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 获取Json特定键的值
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="json">json文本</param>
        /// <returns>特定键的值</returns>
        private string GetValueFormJson(string ValueName, string json)
        {
            switch (ValueName)
            {
                case "Value":
                    return ((MesObject_1)JsonConvert.DeserializeObject(json, typeof(MesObject_1))).Value;
                case "Msg":
                    return ((MesObject_2)JsonConvert.DeserializeObject(json, typeof(MesObject_2))).Msg;
                case "Result":
                    return ((MesObject_Test)JsonConvert.DeserializeObject(json, typeof(MesObject_Test))).Result;
                case "MPN":
                    return ((MesObject_Test)JsonConvert.DeserializeObject(json, typeof(MesObject_Test))).MPN;
                default:
                    break;
            }
            return "";
        }
    }

    public class MESKey
    {
        public string MPN { get; set; }
        public string LotNo { get; set; }

    }
    public class MESValue
    {
        public string PicBarcode { get; set; }
        public string Result { get; set; }

    }
    public class MesObject_1
    {
        public string Deviceid { get; set; }
        public string StateID { get; set; }
        //public  List<MESKey> MesKey{ get; set; }

        //public List<MESValue> MesValue{ get; set; }
        public string Value;
        public string Timestamp { get; set; }
    }

    public class MesObject_2
    {
        public string Deviceid { get; set; }
        public string Msg { get; set; }
    }

    public class MesObject_Test
    {
        public string Result { get; set; }
        public string Msg { get; set; }

        public string MPN { get; set; }
    }

    public class TestContext
    {
        public string PcsIndex { get; set; }
        public string PCSBarcode { get; set; }
        public string ErrorCode { get; set; }
        public string Describe { get; set; }
    }

    public class ErrorContext
    {

        public string ErrorCode { get; set; }
        public string Value { get; set; }

    }

}
