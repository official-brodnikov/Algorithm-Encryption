using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Algorithm_Encryption.Algorithm_AES
{
    class AlgorithmAES
    {

        public AlgorithmAES()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="ENC"> исходное сообщение </param>
        /// <param name="AES_KEY"> ключ </param>
        /// <param name="AES_IV"> вектор инициализации </param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] ENC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.None;
                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateEncryptor(AES_KEY, AES_IV), CryptoStreamMode.Write);

                CS.Write(ENC, 0, ENC.Length);
                CS.Close();

                return MS.ToArray();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="DEC"> зашифрованное сообщение </param>
        /// <param name="AES_KEY"> ключ </param>
        /// <param name="AES_IV"> вектор инициализации </param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] DEC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.None;

                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateDecryptor(AES_KEY, AES_IV), CryptoStreamMode.Write);

                CS.Write(DEC, 0, DEC.Length);
                CS.Close();

                return MS.ToArray();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns> возвращает ключ в виде массива байтов, длина ключа 256 </returns>
        public byte[] GenerateKey()
        {
            using (Rijndael AES = Rijndael.Create())
            {
                AES.GenerateKey();
                return AES.Key;
            }
        }
    }
}
