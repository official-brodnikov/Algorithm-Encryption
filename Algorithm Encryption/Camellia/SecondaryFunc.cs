using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace Algorithm_Encryption
{
    /// <summary>
    /// Класс вспомогательных функций для шифровки(расшифровки) текста
    /// </summary>
    class SecondaryFunc
    {
        /// <summary>
        /// S-блоки
        /// </summary>
        static ulong[] Stab1, Stab2, Stab3, Stab4;

        /// <summary>
        /// Конструктор, заполняющий S-блоки
        /// </summary>
        public SecondaryFunc()
        {
            STab st = new STab();

            Stab1 = st.Stab1;
            Stab2 = st.Stab2;
            Stab3 = st.Stab3;
            Stab4 = st.Stab4;
        }

        internal ulong F128(ulong x, ulong k)
        {
            ulong y;
            ulong t = x ^ k;
            y =  Stab1[(t) & 0xff] & 0xffffff00ffffff00;
            y ^= Stab4[(t >>= 8) & 0xff] & 0xffff00ffffff00ff;
            y ^= Stab3[(t >>= 8) & 0xff] & 0xff00ffffff00ffff;
            y ^= Stab2[(t >>= 8) & 0xff] & 0x00ffffff00ffffff;
            y ^= Stab4[(t >>= 8) & 0xff] & 0xffff00ff0000ffff;
            y ^= Stab3[(t >>= 8) & 0xff] & 0xff00ffff00ffff00;
            y ^= Stab2[(t >>= 8) & 0xff] & 0x00ffffffffff0000;
            y ^= Stab1[(t >>= 8) & 0xff] & 0xffffff00ff0000ff;
            return y;
        }

        internal ulong FL128(ulong x, ulong k)
        {
            uint xl = (uint)(x >> 32);
            uint xr = (uint)(x & 0xffffffff);
            uint t = xl & (uint)(k >> 32);
            xr ^= (t << 1) | (t >> 31);
            xl ^= xr | (uint)(k & 0xffffffff);
            return ((ulong)xl << 32) | xr;
        }

        internal ulong FLi128(ulong y, ulong k)
        {
            uint yl = (uint)(y >> 32);
            uint yr = (uint)(y & 0xffffffff);
            yl ^= yr | (uint)(k & 0xffffffff);
            uint t = yl & (uint)(k >> 32);
            yr ^= (t << 1) | (t >> 31);
            return ((ulong)yl << 32) | yr;
        }
    }
}
