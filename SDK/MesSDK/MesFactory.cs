using System;

namespace MesSDK
{
    public enum EMesType
    {
        MEKTEC,
        ZR,
        HQ,
        HONOR,
        SUUNTO
    }

    public class MesFactory
    {
        public static IMes CreateMes(EMesType type)
        {
            switch (type)
            {
                case EMesType.MEKTEC:
                    return new Mektec();
                case EMesType.ZR:
                    return new ZR();
                case EMesType.HQ:
                    return new HQ();
                case EMesType.HONOR:
                    return new Honor();
                case EMesType.SUUNTO:
                    return new Sunnto();
                default:
                    throw new Exception($"IMes interface not implemented for {type}");
            }
        }
    }
}
