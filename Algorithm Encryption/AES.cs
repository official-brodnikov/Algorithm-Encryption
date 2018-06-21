using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Encryption
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AES : Form
    {
        Random rand = new Random();
        public string filename;
        public int MyTime;
        public short[] buf;
        public short[] bufkey;
        public byte[] resbuf; 
        DateTime StartTime;
        //вектор инициализации
        static byte[] IV = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00 };
        public AES()
        {
            InitializeComponent();
        }
        private void EncButton_Click(object sender, EventArgs e)
        {
            if (InputRichTextBox.TextLength == 0)
                MessageBox.Show("Введите данные для шифрования", "Ошибка");
            else
            if (KeyTB.TextLength != 32)
                MessageBox.Show("Длина ключа должна быть равна 32 символам");
            else
            if (InputRichTextBox.TextLength % 16 != 0)
                MessageBox.Show("Длина текста должна быть кратна 16");
            else
            {
                TimeStart();
                OutputRichTextBox.Clear();
                Algorithm_AES.AlgorithmAES aes = new Algorithm_AES.AlgorithmAES();
                byte[] Buffer;
                buf = new short[InputRichTextBox.TextLength];
                byte[] res = new byte[InputRichTextBox.TextLength];
                for (short i = 0; i < InputRichTextBox.TextLength; i++)
                {
                    buf[i] = (short)InputRichTextBox.Text[i];
                }
                //массив buf необходимый для равботы с символами русского алфавита
                for (short i = 0; i < InputRichTextBox.TextLength; i++)
                {
                    if (buf[i] - 1024 > 0)
                        res[i] = (byte)(buf[i] - 1024);
                    else
                        res[i] = (byte)buf[i];
                }
                bufkey = new short[KeyTB.TextLength];
                byte[] key = new byte[KeyTB.TextLength];
                for (int i = 0; i < KeyTB.TextLength; i++)
                    bufkey[i] = (short)KeyTB.Text[i];
                for (short i = 0; i < KeyTB.TextLength; i++)
                {
                    if (bufkey[i] - 1024 > 0)
                        key[i] = (byte)(bufkey[i] - 1024);
                    else
                        key[i] = (byte)bufkey[i];
                }
                Buffer = aes.Encrypt(res, key, IV);
                resbuf = Buffer;//запоминаем массив при необходимости расшифрования
                for (int i = 0; i < Buffer.Length; i++)
                    OutputRichTextBox.Text += (char)Buffer[i];
                TimeStop();
            }
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (OutputRichTextBox.Text == "")
                MessageBox.Show("Введите данные для расшифрования", "Ошибка");
            else
            if (KeyTB.TextLength != 32)
                MessageBox.Show("Длина ключа должна быть равна 32 символам");
            else
            {
                TimeStart();
                Algorithm_AES.AlgorithmAES aes = new Algorithm_AES.AlgorithmAES();
                byte[] key = new byte[KeyTB.TextLength];
                for (int i = 0; i < KeyTB.TextLength; i++)
                    key[i] = (byte)bufkey[i];
                byte[] Buffer = aes.Decrypt(resbuf, key, IV);
                OutputRichTextBox.Clear();
                for (int i = 0; i < Buffer.Length; i++)
                {
                    if (buf[i] - 1024 > 0)
                        OutputRichTextBox.Text += (char)(Buffer[i] + 1024);
                    else
                        OutputRichTextBox.Text += (char)Buffer[i];
                }
                TimeStop();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "";
            OpenFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try         //обработчик исключительных ситуаций
                {

                    //считываем из указанного в диалоговом окне файла
                    using (StreamReader sr = new StreamReader(OpenFileDialog.FileName))
                    {
                        filename = OpenFileDialog.SafeFileName;
                        //пока не дошли до конца файла
                        InputRichTextBox.Text = sr.ReadToEnd();
                    }
                    OutputRichTextBox.Text = "";
                }
                catch (Exception ex)    //если произошла ошибка
                {
                    //выводим сообщение об ошибке
                    MessageBox.Show("Ошибка открытия файла " + ex.Message);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (filename != null)
                SaveFileDialog.FileName = filename;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            //если в диалоговом окне нажали ОК
            {
                try         //обработчик исключительных ситуаций
                {
                    //используя sw (экземпляр класса StreamWriter),
                    //создаем файл с заданным
                    //в диалоговом окне именем
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog.FileName))
                    {
                        sw.WriteAsync(OutputRichTextBox.Text);
                    }

                }
                catch (Exception ex)    //перехватываем ошибку
                {
                    //выводим информацию об ошибке
                    MessageBox.Show("Ошибка сохранения " + ex.Message);
                }
            }
        }

        private void TimerAlgorithm_Tick(object sender, EventArgs e)
        {
            MyTime++;
        }

        private void InputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void KeyTB_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }
 
        private void GenKeyButton_Click(object sender, EventArgs e)
        {
            KeyTB.Clear();
            while (KeyTB.TextLength != 32)
            {
                Algorithm_AES.AlgorithmAES aes = new Algorithm_AES.AlgorithmAES();
                byte[] key = aes.GenerateKey();
                for (int i = 0; i < key.Length; i++)
                    KeyTB.Text += (char)key[i];
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            InputRichTextBox.SelectionColor = ColorDialog.Color;
            OutputRichTextBox.SelectionColor = ColorDialog.Color;
        }

        private void выбратьЦветЗаливкиТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            InputRichTextBox.SelectionBackColor = ColorDialog.Color;
            OutputRichTextBox.SelectionBackColor = ColorDialog.Color;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog.ShowDialog();
            InputRichTextBox.SelectionFont = FontDialog.Font;
            OutputRichTextBox.SelectionFont = FontDialog.Font;
        }

        private void AES_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть текущее окно?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void обалгоритмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced Encryption Standard - симметричный алгоритм блочного шифрования (размер блока 128 бит, ключ  в данной реализации 256 бит).AES является стандартом, основанным на алгоритме Rijndael. ", "Об алгоритме шифрования");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Алгоритмы Шифрования создано для шифрования текста, с помощью наиболее популярных и современных алгоритмов.\n AllRightReserved ", "О программе");
        }

        private void SaveKeyButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (filename != null)
                SaveFileDialog.FileName = filename;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            //если в диалоговом окне нажали ОК
            {
                try         //обработчик исключительных ситуаций
                {
                    //используя sw (экземпляр класса StreamWriter),
                    //создаем файл с заданным
                    //в диалоговом окне именем
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog.FileName))
                    {
                        sw.WriteAsync(KeyTB.Text);
                    }

                }
                catch (Exception ex)    //перехватываем ошибку
                {
                    //выводим информацию об ошибке
                    MessageBox.Show("Ошибка сохранения " + ex.Message);
                }
            }
        }
        private void TimeStart()
        {
            MyTime = 0;
            StartTime = DateTime.Now;
            TimerAlgorithm.Interval = 60000;//в милисекундах
            TimerAlgorithm.Enabled = true;
        }

        private void TimeStop()
        {
            TimerAlgorithm.Enabled = false;
            DateTime EndTime = DateTime.Now;
            ToolStripStatusLabel.Text = "Время работы алгоритма шифрования (в миллисекундах)";
            SecondsToolStripStatusLabel.Text = (EndTime - StartTime).TotalMilliseconds.ToString();
        }
    }
}
