using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithm_Encryption
{
    class E24 : GenerationKeys
    {

        /// <summary>
        ///  Производит 18-ти этапную шифровку входных данных
        /// </summary>
        /// <param name="msg"> входной массив данных для расшифровки </param>
        /// <param name="eKey"> преобразованный набор ключей для расшифровки текста </param>
        /// <returns> возвращает преобразованный массив байтов </returns>

        public byte[] Encrypt(byte[] msg, ulong[] eKey)
        {
            byte[] c = new byte[msg.Length];

            ulong Ml = Bswap(BitConverter.ToUInt64(msg, 0));
            ulong Mr = Bswap(BitConverter.ToUInt64(msg, 8));
            //ассоциация, агрегация или композиция
            //зависимость

            SecondaryFunc SF = new SecondaryFunc();
           // SF.fffffff();


            ulong Cr = Ml ^ eKey[0];
            ulong Cl = Mr ^ eKey[1];

            Cl ^= SF.F128(Cr, eKey[2]);
            Cr ^= SF.F128(Cl, eKey[3]);
            Cl ^= SF.F128(Cr, eKey[4]);
            Cr ^= SF.F128(Cl, eKey[5]);
            Cl ^= SF.F128(Cr, eKey[6]);
            Cr ^= SF.F128(Cl, eKey[7]);

            Cr = SF.FL128(Cr, eKey[8]);
            Cl = SF.FLi128(Cl, eKey[9]);

            Cl ^= SF.F128(Cr, eKey[10]);
            Cr ^= SF.F128(Cl, eKey[11]);
            Cl ^= SF.F128(Cr, eKey[12]);
            Cr ^= SF.F128(Cl, eKey[13]);
            Cl ^= SF.F128(Cr, eKey[14]);
            Cr ^= SF.F128(Cl, eKey[15]);

            Cr = SF.FL128(Cr, eKey[16]);
            Cl = SF.FLi128(Cl, eKey[17]);

            Cl ^= SF.F128(Cr, eKey[18]);
            Cr ^= SF.F128(Cl, eKey[19]);
            Cl ^= SF.F128(Cr, eKey[20]);
            Cr ^= SF.F128(Cl, eKey[21]);
            Cl ^= SF.F128(Cr, eKey[22]);
            Cr ^= SF.F128(Cl, eKey[23]);

            Cl ^= eKey[24];
            Cr ^= eKey[25];

            Buffer.BlockCopy(BitConverter.GetBytes(Bswap(Cl)), 0, c, 0, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(Bswap(Cr)), 0, c, 8, 8);

            return c;
        }

    }
}
