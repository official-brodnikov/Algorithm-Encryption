using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithm_Encryption
{
    class D24 : GenerationKeys
    {
        /// <summary>
        /// Производит 18-ти этапную расшифровку входных данных
        /// </summary>
        /// <param name="msg"> входной массив данных для расшифровки </param>
        /// <param name="eKey"> преобразованный набор ключей для расшифровки текста </param>
        /// <returns> возвращает преобразованный массив байтов </returns>

        public byte[] Decrypt(byte[] msg, ulong[] eKey)
        {
            byte[] c = new byte[msg.Length];

            ulong Ml = Bswap(BitConverter.ToUInt64(msg, 0));
            ulong Mr = Bswap(BitConverter.ToUInt64(msg, 8));

            SecondaryFunc SF = new SecondaryFunc();

            ulong Cr = Ml ^ eKey[24];
            ulong Cl = Mr ^ eKey[25];

            Cl ^= SF.F128(Cr, eKey[23]);
            Cr ^= SF.F128(Cl, eKey[22]);
            Cl ^= SF.F128(Cr, eKey[21]);
            Cr ^= SF.F128(Cl, eKey[20]);
            Cl ^= SF.F128(Cr, eKey[19]);
            Cr ^= SF.F128(Cl, eKey[18]);

            Cr = SF.FL128(Cr, eKey[17]);
            Cl = SF.FLi128(Cl, eKey[16]);

            Cl ^= SF.F128(Cr, eKey[15]);
            Cr ^= SF.F128(Cl, eKey[14]);
            Cl ^= SF.F128(Cr, eKey[13]);
            Cr ^= SF.F128(Cl, eKey[12]);
            Cl ^= SF.F128(Cr, eKey[11]);
            Cr ^= SF.F128(Cl, eKey[10]);

            Cr = SF.FL128(Cr, eKey[9]);
            Cl = SF.FLi128(Cl, eKey[8]);

            Cl ^= SF.F128(Cr, eKey[7]);
            Cr ^= SF.F128(Cl, eKey[6]);
            Cl ^= SF.F128(Cr, eKey[5]);
            Cr ^= SF.F128(Cl, eKey[4]);
            Cl ^= SF.F128(Cr, eKey[3]);
            Cr ^= SF.F128(Cl, eKey[2]);

            Cl ^= eKey[0];
            Cr ^= eKey[1];

            Buffer.BlockCopy(BitConverter.GetBytes(Bswap(Cl)), 0, c, 0, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(Bswap(Cr)), 0, c, 8, 8);

            return c;
        }

    }
}
