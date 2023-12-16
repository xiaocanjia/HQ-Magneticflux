using System;

namespace BoardSDK
{
    public class BoardFactory
    {
        public static IBoard CreateBoard(EBoardType type)
        {
            switch (type)
            {
                case EBoardType.GTS:
                    return new GenCard();
                case EBoardType.Advantech:
                    return new AdvantechBoard();
                case EBoardType.HYIO:
                    return new HYIOBoard();
                case EBoardType.HYAXIS:
                    return new HYAX04NBoard();
                case EBoardType.RM:
                    return new RMCEP();
                default:
                    throw new Exception($"I3DScanner interface not implemented for {type}");
            }
        }
    }
}
