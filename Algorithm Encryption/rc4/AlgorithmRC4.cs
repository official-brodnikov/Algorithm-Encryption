using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Encryption.Algorithm_RC4
{
    class AlgorithmRC4
    {
        short[] S = new short[256];
        int x = 0;
        int y = 0;

        /// <summary>
        /// Для начальной инициализация вектора-перестановки ключём, используется алгоритм ключевого расписания(Key-Scheduling Algorithm)
        /// Этот алгоритм использует ключ, подаваемый на вход пользователем, сохранённый в Key, и имеющий длину key.Length байт. 
        /// Инициализация начинается с заполнения массива S, далее этот массив перемешивается путём перестановок, определяемых ключом.
        /// </summary>
        /// <param name="key"> ключ, в виде массива(кодов символов)</param>
        private void Init(short[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (short)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                Swap(S, i, j);
            }
        }
        public AlgorithmRC4(short[] key)
        {
            Init(key);
        }

        /// <summary>
        /// Генератор псевдослучайной последовательности (Pseudo-Random Generation Algorithm). 
        /// При каждом вызове метод будет выплевывать последующий байт ключевого потока, который мы и будем объединять xor'ом c байтом исходных данных.
        /// В одном цикле RC4 определяется одно n-битное слово K из ключевого потока. 
        /// В дальнейшем ключевое слово будет сложено по модулю два с исходным текстом, которое пользователь хочет зашифровать, и получен зашифрованный текст.
        /// </summary>
        /// <returns></returns>
        private short KeyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            Swap(S, x, y);

            return S[(S[x] + S[y]) % 256];
        }

        /// <summary>
        /// Для каждого байта массива/потока входных незашифрованных данных запрашиваем байт ключа и объединяем их при помощи xor (^):
        /// </summary>
        /// <param name="dataB"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public short[] Encode(short[] dataB, int size)
        {
            short[] data = dataB.Take(size).ToArray();

            short[] cipher = new short[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (short)(data[m] ^ KeyItem());
            }

            return cipher;
        }

        public short[] Decode(short[] dataB, int size)
        {
            return Encode(dataB, size);
        }

        public void Swap(short[] array, int index1, int index2)
        {
            short temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
