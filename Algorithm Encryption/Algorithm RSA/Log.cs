using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Algorithm_Encryption.Algorithm_RSA
{
    static public class Log
    {
        public static void WriteByteArray(byte[] data, string text = "")
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("[{0}]: {1}", DateTime.Now.ToShortTimeString(), text);
                foreach (var x in data)
                    writer.Write(x);
                writer.Write("\n");
                writer.WriteLine();
                writer.Close();
            }
        }

        public static void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("[{0}]: {1}", DateTime.Now.ToShortTimeString(), text);
                writer.Close();
            }
        }
    }
}
