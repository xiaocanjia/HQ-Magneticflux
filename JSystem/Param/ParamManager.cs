﻿using System;
using System.Linq;
using Newtonsoft.Json;
using Serilizer;
using JSystem.Perform;

namespace JSystem.Param
{
    public class ParamManager
    {
        private static BasicParam[] _paramsArray;

        public BasicParam[] ParamsArray
        {
            get
            {
                return _paramsArray;
            }
            set
            {
                for (int i = 0; i < _paramsArray.Length; i++)
                    _paramsArray[i].Value = value.FirstOrDefault((p) => p.Name == _paramsArray[i].Name)?.Value ?? _paramsArray[i].Value;
            }
        }

        [JsonIgnore]
        public Action<string> OnSetUserRight;

        public string CurrRight;

        public ParamManager()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Config//ParamsList.xml";
            _paramsArray = XMLSerilizer.Deserialize<BasicParam[]>(filePath);
        }

        public void SetUserRight(string right)
        {
            CurrRight = right;
            OnSetUserRight?.Invoke(right);
        }

        public static bool GetBoolParam(string name)
        {
            BasicParam param = _paramsArray.FirstOrDefault((p) => { return p.Name == name; });
            if (param == null)
            {
                LogManager.Instance.AddLog($"参数列表中没有{name}");
                return false;
            }
            return param.Value == "是";
        }

        public static string GetStringParam(string name)
        {
            BasicParam param = _paramsArray.FirstOrDefault((p) => { return p.Name == name; });
            if (param == null)
            {
                LogManager.Instance.AddLog($"参数列表中没有{name}");
                return "";
            }
            return param.Value;
        }

        public static int GetIntParam(string name)
        {
            BasicParam param = _paramsArray.FirstOrDefault((p) => { return p.Name == name; });
            if (param == null)
            {
                LogManager.Instance.AddLog($"参数列表中没有{name}");
                return 0;
            }
            return Convert.ToInt32(param.Value);
        }

        public static double GetDoubleParam(string name)
        {
            BasicParam param = _paramsArray.FirstOrDefault((p) => { return p.Name == name; });
            if (param == null)
            {
                LogManager.Instance.AddLog($"参数列表中没有{name}");
                return 0.0;
            }
            return Convert.ToDouble(param.Value);
        }

        public static void SetParam(string name, object value)
        {
            BasicParam param = _paramsArray.FirstOrDefault((p) => { return p.Name == name; });
            if (param == null)
            {
                LogManager.Instance.AddLog($"参数列表中没有{name}");
                return;
            }
            param.Value = value.ToString();
        }
    }
}
