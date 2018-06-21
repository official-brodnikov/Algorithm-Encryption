using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Encryption.ГОСТ_28147
{
    /// <summary>
    /// Класс, производящий расшифровку текста
    /// </summary>
    class D32 : Converter
    {
        byte[] decrByteFile;
        uint[] uintKey;
        ulong[] ulongFile;

        private D32() { }

        public D32(byte[] file, byte[] key)
        {
            uintKey = GetUIntKeyArray(key);
            ulongFile = GetULongDataArray(file);

            decrByteFile = ConvertToByte(DecryptFile());
        }

        public byte[] GetDecryptFile
        {
            get { return decrByteFile; }
        }
        /// <summary>
        /// Производит расшифровку массива данных
        /// </summary>
        /// <returns> преобразованный массив данных </returns>
        private ulong[] DecryptFile()
        {
            BasicStep[] K = new BasicStep[8];
            ulong[] ulongDecrFile = new ulong[ulongFile.Length];

            for (int k = 0; k < ulongFile.Length; k++)
            {
                ulongDecrFile[k] = ulongFile[k];

                for (int i = 0; i < K.Length; i++)
                {
                    K[i] = new BasicStep(ulongDecrFile[k], uintKey[i]);
                    ulongDecrFile[k] = K[i].BasicEncrypt(false);
                }

                for (int j = 0; j < 3; j++)
                {
                    for (int i = K.Length - 1; i >= 0; i--)
                    {
                        K[i] = new BasicStep(ulongDecrFile[k], uintKey[i]);

                        if ((j == 2) && (i == 0))
                            ulongDecrFile[k] = K[i].BasicEncrypt(true);
                        else
                            ulongDecrFile[k] = K[i].BasicEncrypt(false);
                    }
                }
            }

            return ulongDecrFile;
        }
    }
}
