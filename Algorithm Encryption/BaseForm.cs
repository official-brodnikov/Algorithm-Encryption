using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Encryption
{
    public partial class BaseForm : Form
    {
        byte[] encrByteFile, byteKey, decrByteFile;
        int MyTime;

        private void saveKeyButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
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

        private void keyGenerateButton_Click(object sender, EventArgs e)
        {
            KeyTB.Clear();
            OutputRichTextBox.Clear();
            byte[] GenerateKey = new byte[32];
            Random RandomNumb = new Random();
            for (int i = 0; i < GenerateKey.Length; i++)
            {
                GenerateKey[i] = (byte)RandomNumb.Next(0, 255);
                KeyTB.Text += (char)GenerateKey[i];
            }
            byteKey = GenerateKey;
        }

        public byte[] FileToByte(string name)
        {
            return File.ReadAllBytes(name);
        }

        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            string file = OpenFileDialog.FileName;
            decrByteFile = FileToByte(file);
            InputRichTextBox.Text = Encoding.Default.GetString(decrByteFile);
        }

        private void fileEncryptButton_Click(object sender, EventArgs e)
        {
            Algorithm_Encryption.ГОСТ_28147.E32 e32;

            if (InputRichTextBox.Text == "")
                MessageBox.Show("Введите данные для шифрования", "Ошибка");
            else
            {
                if (!CheckInput(InputRichTextBox.Text))
                {
                    if (MessageBox.Show("В процессе шифровки может произойти потеря части текста.\n(Число символов должно быть кратно 8)\nПрервать шифровку?",
                          "Предупреждение!", MessageBoxButtons.YesNo) == DialogResult.Yes) return;
                }
                byte[] btFile = Encoding.Default.GetBytes(InputRichTextBox.Text);

                if ((byteKey == null) || (byteKey.Length != 32))
                    MessageBox.Show("Введдите 256-битный ключ.");
                else
                {
                    DateTime StartTime;
                    MyTime = 0;
                    StartTime = DateTime.Now;
                    TimerAlgorithm.Interval = 60000;//в милисекундах
                    TimerAlgorithm.Enabled = true;

                    e32 = new Algorithm_Encryption.ГОСТ_28147.E32(btFile, byteKey);
                    encrByteFile = e32.GetEncryptFile;
                    OutputRichTextBox.Clear();
                    OutputRichTextBox.Text = Encoding.Default.GetString(encrByteFile);

                    TimerAlgorithm.Enabled = false;
                    DateTime EndTime = DateTime.Now;
                    ToolStripStatusLabel.Text = "Время работы алгоритма шифрования (в миллисекундах)";
                    SecondsToolStripStatusLabel.Text = (EndTime - StartTime).TotalMilliseconds.ToString();
                }
            }
        }

        static private bool CheckInput(string input)
        {
            if (input.Length % 8 == 0) return true;
            return false;
        }

        private void fileDecryptButton_Click(object sender, EventArgs e)
        {
            Algorithm_Encryption.ГОСТ_28147.D32 d32;
            if (OutputRichTextBox.Text == "")
                MessageBox.Show("Введите данные для расшифрования", "Ошибка");
            else
            {
                byte[] btFile = encrByteFile;

                if (byteKey.Length != 32)
                    MessageBox.Show("Введдите 256-битный ключ.");
                else
                {
                    DateTime StartTime;
                    MyTime = 0;
                    StartTime = DateTime.Now;
                    TimerAlgorithm.Interval = 60000;//в милисекундах
                    TimerAlgorithm.Enabled = true;

                    d32 = new Algorithm_Encryption.ГОСТ_28147.D32(btFile, byteKey);
                    decrByteFile = d32.GetDecryptFile;
                    OutputRichTextBox.Clear(); 
                    OutputRichTextBox.Text = Encoding.Default.GetString(decrByteFile);

                    TimerAlgorithm.Enabled = false;
                    DateTime EndTime = DateTime.Now;
                    ToolStripStatusLabel.Text = "Время работы алгоритма шифрования (в миллисекундах)";
                    SecondsToolStripStatusLabel.Text = (EndTime - StartTime).TotalMilliseconds.ToString();
                }
            }
        }

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog.ShowDialog();
            InputRichTextBox.SelectionFont = FontDialog.Font;
            OutputRichTextBox.SelectionFont = FontDialog.Font;
        }

        private void InputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void KeyTB_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть текущее окно?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ГОСТ 28147 -  российский стандарт симметричного блочного шифрования. Использует ключ длиной 256 бит.\n Алгоритм имеет следующие недостатки:\n -Может применяться только для шифрования открытых текстов с длиной, кратной 64 бит\n -При шифровании одинаковых блоков открытого текста получаются одинаковые блоки шифротекста, что может дать определенную информацию криптоаналитику\nСчитается, что ГОСТ устойчив к таким широко применяемым методам, как линейный и дифференциальный криптоанализ. Обратный порядок использования ключей в последних восьми раундах обеспечивает защиту от атак скольжения (slide attack) и отражения (reflection attack).", "Об алгоритме шифрования");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Алгоритмы Шифрования создано для шифрования текста, с помощью наиболее популярных и современных алгоритмов.\n AllRightReserved ", "О программе");
        }

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
