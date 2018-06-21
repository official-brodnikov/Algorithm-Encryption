using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Algorithm_Encryption.Algorithm_RSA
{
    public class AlgorithmRSA
    {
        private const int DefaultLength = 256;

        private int MaxLength
        {
            get
            {
                return DefaultLength / 4;
            }
        }

        private static readonly int[] Primes =
        {
            2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,
            73,79,83,89,97,101,103,107,109,113,127,131,137,139,149,151,157,163,167,173,
            179,181,191,193,197,199,211,223,227,229,233,239,241,251,257,263,269,271,277,281,
            283,293,307,311,313,317,331,337,347,349,353,359,367,373,379,383,389,397,401,409,
            419,421,431,433,439,443,449,457,461,463,467,479,487,491,499,503,509,521,523,541,
            547,557,563,569,571,577,587,593,599,601,607,613,617,619,631,641,643,647,653,659,
            661,673,677,683,691,701,709,719,727,733,739,743,751,757,761,769,773,787,797,809,
            811,821,823,827,829,839,853,857,859,863,877,881,883,887,907,911,919,929,937,941,
            947,953,967,971,977,983,991,997,1009,1013,1019,1021,1031,1033,1039,1049,1051,1061,1063,1069,
            1087,1091,1093,1097,1103,1109,1117,1123,1129,1151,1153,1163,1171,1181,1187,1193,1201,1213,1217,1223,
            1229,1231,1237,1249,1259,1277,1279,1283,1289,1291,1297,1301,1303,1307,1319,1321,1327,1361,1367,1373,
            1381,1399,1409,1423,1427,1429,1433,1439,1447,1451,1453,1459,1471,1481,1483,1487,1489,1493,1499,1511,
            1523,1531,1543,1549,1553,1559,1567,1571,1579,1583,1597,1601,1607,1609,1613,1619,1621,1627,1637,1657,
            1663,1667,1669,1693,1697,1699,1709,1721,1723,1733,1741,1747,1753,1759,1777,1783,1787,1789,1801,1811,
            1823,1831,1847,1861,1867,1871,1873,1877,1879,1889,1901,1907,1913,1931,1933,1949,1951,1973,1979,1987,
            1993,1997,1999
        };

        private static readonly int[] Ferma =
        {
            17, 257, 65537      
        };


        public AlgorithmRSA(){}

        private void Create()
        {
            
            Log.Write("RSA CREATE\n");
            BigInteger p = GeneratePrimaryLongNumber(), q = GeneratePrimaryLongNumber();

            Log.Write("p: " + p.ToString());
            Log.Write("q: " + q.ToString());

            BigInteger n = p * q;
            Log.Write("n: " + n.ToString());
            BigInteger F = (p - 1) * (q - 1);
            Log.Write("F: " + F.ToString());
            BigInteger e = GetEpsilon(F);
            Log.Write("e: " + e.ToString());
            BigInteger d = MultiplicativeInverse(e, F);
            Log.Write("d: " + d.ToString());
        }

        public BigInteger GeneratePrimaryLongNumber(int length = DefaultLength)
        {
            BigInteger result;
            do
            {
                result = GenerateLongNumber(length);
                if (result.IsEven)
                    result++;
            }
            while (!MillerRabinPrimalityTest(result));
            return result;
        }


        private static BigInteger GenerateLongNumber(int length = DefaultLength)
        {
            byte[] temp = new byte[DefaultLength / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(temp);
            }
            return BigInteger.Abs(new BigInteger(temp));
        }

        private static BigInteger GenerateLongNumber(BigInteger max, int length = DefaultLength)
        {
            BigInteger result;
            do
                result = GenerateLongNumber(length);
            while (result > max);
            return result;
        }

        private static bool MillerRabinPrimalityTest(BigInteger number, int k = 5)
        {
            if (IsHasDividers(number)) return false;
            int s = 0;
            BigInteger temp = number - 1;
            while (temp % 2 == 0)
            {
                s++;
                temp /= 2;
            }
            Random rand = new Random();
            BigInteger t = number / BigInteger.Pow(2, s);
            for (int i = 0; i < k; i++)
            {
                BigInteger a = GenerateLongNumber(number);
                BigInteger x = BigInteger.ModPow(a, t, number);
                if (x.IsOne || x == number - 1) continue;
                bool isANext = false;
                for (int j = 0; j < s - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x.IsOne) return false;
                    if (x == number - 1)
                    {
                        isANext = true;
                        break;
                    }
                }
                if (!isANext)
                    return false;
            }
            return true;
        }

        private static bool IsHasDividers(BigInteger number)
        {
            foreach (var x in Primes)
                if (number % x == 0) return true;
            return false;
        }

        public BigInteger GetEpsilon(BigInteger F)
        {
            foreach (var x in Ferma)
                if (BigInteger.GreatestCommonDivisor(x, F) == 1)
                    return x;
            foreach (var x in Primes)
                if (BigInteger.GreatestCommonDivisor(x, F) == 1)
                    return x;
            BigInteger result;
            do
                result = GenerateLongNumber();
            while (BigInteger.GreatestCommonDivisor(result, F) != 1);
            return result;
        }

        public BigInteger MultiplicativeInverse(BigInteger e, BigInteger F)
        {
            BigInteger x = new BigInteger(), y = new BigInteger();
            ExtendedEuclideanAlgorithm(e, F, ref x, ref y);
            if (x.Sign == -1)
                x += F;
            return x;
        }

        private static BigInteger ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
        {
            BigInteger g = 1, u, v, A = 1, B = 0, C = 0, D = 1;
            while (((a & 1) | (b & 1)) == 0)
            {
                a >>= 1;
                b >>= 1;
                g <<= 1;
            }
            u = a;
            v = b;
            while (u != 0)
            {
                while ((u & 1) == 0)
                {
                    u >>= 1;
                    if (((A & 1) | (B & 1)) == 0)
                    {
                        A >>= 1;
                        B >>= 1;
                    }
                    else
                    {
                        A = (A + b) >> 1;
                        B = (B - a) >> 1;
                    }
                }
                while ((v & 1) == 0)
                {
                    v >>= 1;
                    if (((C & 1) | (D & 1)) == 0)
                    {
                        C >>= 1;
                        D >>= 1;
                    }
                    else
                    {
                        C = (C + b) >> 1;
                        D = (D - a) >> 1;
                    }
                }

                if (u >= v)
                {
                    u -= v;
                    A -= C;
                    B -= D;
                }
                else
                {
                    v -= u;
                    C -= A;
                    D -= B;
                }
            }
            x = C;
            y = D;
            return g * v;
        }

        public byte[] Encrypt(string input, BigInteger e, BigInteger n)
        {
            int count = Encoding.Unicode.GetByteCount(input);
            int ost = (MaxLength - count % MaxLength) % MaxLength;
            if (ost != 0)
            {
                StringBuilder builder = new StringBuilder(input);
                builder.Append('\0', ost / 2);
                input = builder.ToString();
            }
            Log.Write("Шифруется: " + input);
            List<byte> result = new List<byte>();
            byte[] bytes = Encoding.Unicode.GetBytes(input);
            Log.WriteByteArray(bytes, "Исходный массив");
            byte[][] temp = Split(bytes);
            for (int i = 0; i < temp.Length; i++)
            {
                BigInteger enc = new BigInteger(temp[i]);
                if (enc > n)
                {
                    Create();
                    i--;
                    continue;
                }

                BigInteger sec = BigInteger.ModPow(enc, e, n);
                byte[] insert = AddZero(sec.ToByteArray());
                result.AddRange(insert);
            }
            return result.ToArray();
        }

        public string Decrypt(byte[] input, BigInteger d, BigInteger n)
        {
            BigInteger calc = new BigInteger(input);
            byte[][] temp = Split(calc.ToByteArray());
            List<byte> result = new List<byte>();
            for (int i = 0; i < temp.Length; i++)
            {
                BigInteger esc = new BigInteger(temp[i]);
                byte[] insert = AddZero(BigInteger.ModPow(esc, d, n).ToByteArray());
                result.AddRange(insert);
            }
           
            string resultString = new string(Encoding.Unicode.GetChars(result.ToArray()));
            return resultString;
        }

        private byte[][] Split(byte[] data)
        {
            int count = (int)Math.Ceiling((double)data.Length / MaxLength);
            return Enumerable.Range(0, count).Select(i => data.Skip(i * MaxLength).Take(MaxLength).ToArray()).ToArray();
        }

        private byte[] AddZero(byte[] data)
        {
            if (data.Length == MaxLength) return data;
            List<byte> x = data.ToList();
            while (x.Count < MaxLength)
                x.Add(0);
            return x.ToArray();
        }
    }
}
