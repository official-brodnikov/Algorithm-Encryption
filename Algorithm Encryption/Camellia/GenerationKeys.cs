using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithm_Encryption
{

    class GenerationKeys
    {
        /// <summary>
        /// Набор вспомогательных ключей
        /// </summary>
        public ulong[] eKey = new ulong[26];

        /// <summary>
        /// Производит байтовую перестановку
        /// </summary>
        /// <param name="x"> 64-битное число </param>
        /// <returns> преобразованное 64-битное число </returns>
        internal static ulong Bswap(ulong x)
        {
            ulong t;
            t = ((x & 0x00ff00ff00ff00ff) << 8) | ((x >> 8) & 0x00ff00ff00ff00ff);
            t = ((t & 0x0000ffff0000ffff) << 16) | ((t >> 16) & 0x0000ffff0000ffff);
            t = ((t & 0x00000000ffffffff) << 32) | ((t >> 32) & 0x00000000ffffffff);
            return t;
        }
        /// <summary>
        /// Вычисление вспомогательных ключей для шифровки(расшифровки) текста
        /// </summary>
        /// <param name="key"> 128-битный исходный ключ </param>
        /// <returns> true - формат исходного ключа верный; false - формат ключа не верный</returns>
        public bool SetKey(byte[] key)
        {
            if (key.Length != 16) return false;

            ulong KAl, KAr;
            ulong KLl = Bswap(BitConverter.ToUInt64(key, 0));
            ulong KLr = Bswap(BitConverter.ToUInt64(key, 8));

            SecondaryFunc SF = new SecondaryFunc();

            eKey[0] = KLl;
            eKey[1] = KLr;
            eKey[4] = (KLl << 15) | (KLr >> 49);
            eKey[5] = (KLr << 15) | (KLl >> 49);
            eKey[10] = (KLl << 45) | (KLr >> 19);
            eKey[11] = (KLr << 45) | (KLl >> 19);
            eKey[13] = (KLr << 60) | (KLl >> 4);
            eKey[16] = (KLr << 13) | (KLl >> 51);
            eKey[17] = (KLl << 13) | (KLr >> 51);
            eKey[18] = (KLr << 30) | (KLl >> 34);
            eKey[19] = (KLl << 30) | (KLr >> 34);
            eKey[22] = (KLr << 47) | (KLl >> 17);
            eKey[23] = (KLl << 47) | (KLr >> 17);

            KAr = SF.F128(KLl, 0xA09E667F3BCC908B);
            KAl = SF.F128(KAr ^ KLr, 0xB67AE8584CAA73B2);
            KAr ^= SF.F128(KAl, 0xC6EF372FE94F82BE);
            KAl ^= SF.F128(KAr, 0x54FF53A5F1D36F1C);

            eKey[2] = KAl;
            eKey[3] = KAr;
            eKey[6] = (KAl << 15) | (KAr >> 49);
            eKey[7] = (KAr << 15) | (KAl >> 49);
            eKey[8] = (KAl << 30) | (KAr >> 34);
            eKey[9] = (KAr << 30) | (KAl >> 34);
            eKey[12] = (KAl << 45) | (KAr >> 19);
            eKey[14] = (KAl << 60) | (KAr >> 4);
            eKey[15] = (KAr << 60) | (KAl >> 4);
            eKey[20] = (KAr << 30) | (KAl >> 34);
            eKey[21] = (KAl << 30) | (KAr >> 34);
            eKey[24] = (KAr << 47) | (KAl >> 17);
            eKey[25] = (KAl << 47) | (KAr >> 17);

            return true;
        }
    }
}
