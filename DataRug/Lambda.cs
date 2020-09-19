using System;

namespace DataRug
{

    public class Lambda<T1, TRet>
    {
        private Func <T1, TRet> _;

        public Lambda(Func <T1, TRet> func)
        {
            _ = func;
        }
    }

}