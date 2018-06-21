using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace Algorithm_Encryption.Algorithm_El_Gamal
{
    class AlgorithmEG
    {
        /// <summary>
        /// функция получения случайного числа
        /// </summary>
        /// <returns></returns>
        private int Rand()
        {
            Random random = new Random();
            return random.Next();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"> число </param>
        /// <param name="b"> степень </param>
        /// <param name="n"> модуль </param>
        /// <returns> возвращает результат a^b mod n</returns>
        public int Power(int a, int b, int n)
        {
            int tmp = a;
            int sum = tmp;
            for (int i = 1; i < b; i++)
            {
                for (int j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }
                tmp = sum;
            }
            return tmp;
        }

        /// <summary>
        /// функция умножения a на b по модулю n
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Mul(int a, int b, int n)
        {
            int sum = 0;
            for (int i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }
            return sum;
        }

        /// <summary>
        /// нахождение открытого ключа y, используя введенный закрытый ключ x и p и g
        /// </summary>
        /// <param name="p"></param>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int PublicKey(int p, int g, int x) 
        {
            return Power(g, x, p);
        }

        /// <summary>
        /// Алгоритм шифрования строки strIn
        /// Выбирается сессионный ключ — случайное целое число К такое, что 1 < k < p-1
        /// Вычисляются числа a = g^k mod p и b = y^k M mod p.
        /// Пара чисел a b является шифротекстом.
        /// </summary>
        /// <param name="p"> закрытый ключи</param>
        /// <param name="g"> закрытый ключи</param>
        /// <param name="x"> закрытый ключи</param>
        /// <param name="y"> открытый ключ </param>
        /// <param name="strIn"> входная строка</param>
        /// <returns> вовзвращает зашифрованную строку</returns>
        public string Crypt(int p, int g, int x, int y, string strIn)
        {
            string res = "";
            IEnumerator<char> Enum = strIn.GetEnumerator();
            Enum.Reset();
            if (Enum.MoveNext())
            {
                char t = Enum.Current;
                int m = Convert.ToInt32(t);
                for (int i = 1; i <= strIn.Length; i++)
                {
                    if (m > 0)
                    {
                        t = Enum.Current;
                        m = Convert.ToInt32(t);
                        int k = Rand() % (p - 2) + 1; // 1 < k < (p-1)
                        int a = Power(g, k, p);
                        int b = Mul(Power(y, k, p), m, p);
                        res += a + " " + b + " ";
                        Enum.MoveNext();
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Дешифрование строки strIn
        /// Вычисляем исходное сообщение с помощью фолрмулы m=b*(a^x)^(-1)mod p =b*a^(p-1-x)mod p
        /// </summary>
        /// <param name="p"> открытый ключ</param>
        /// <param name="x"> закрытый ключ</param>
        /// <param name="strIn"> зашифрованная строка </param>
        /// <returns> расшифрованная стролка </returns>
        public string Decrypt(int p, int x, string strIn)
        {
            string res = "";
            if (strIn.Length > 0)
            {
                string[] strA = strIn.Split(' ');
                if (strA.Length > 0)
                {
                    for (int i = 0; i < strA.Length - 1; i += 2)
                    {
                        char[] a = new char[strA[i].Length];
                        char[] b = new char[strA[i + 1].Length];
                        int ai = 0;
                        int bi = 0;
                        a = strA[i].ToCharArray();
                        b = strA[i + 1].ToCharArray();
                        for (int j = 0; (j < a.Length); j++)
                        {
                            ai = ai * 10 + (int)(a[j] - 48);
                        }
                        for (int j = 0; (j < b.Length); j++)
                        {
                            bi = bi * 10 + (int)(b[j] - 48);
                        }
                        if ((ai != 0) && (bi != 0))
                        {
                            int deM = Mul(bi, Power(ai, p - 1 - x, p), p); // m=b*(a^x)^(-1)mod p =b*a^(p-1-x)mod p
                            char m = (char)deM;
                            res += m;
                        }
                    }
                    
                }

            }
            return res;
        }
    }
}
