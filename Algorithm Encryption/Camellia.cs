using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Algorithm_Encryption
{
    public partial class Camellia : Form
    {
        char[] GenerKey = {
            '1','2','3','4','5','6','7','8','9','0', 'q','w','e','r',
            't','y','u','i','o','p','a','s','d','f','g','h','j','k','l',
            'z','x','c','v','b','n','m','Q','W','E','R','T','Y','U','I',
            'O','P','A','S','D','F','G','H','J','K','L','Z','X','C','V',
            'B','N','M','Й','Ц','У','К','Е','Н','Г','Ш','Щ','З','Х','Ъ',
            'Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э','Я','Ч','С','М',
            'И','Т','Ь','Б','Ю','й','ц','у','к','е','н','г','ш','щ','з',
            'х','ъ','ф','ы','в','а','п','р','о','л','д','ж','э','я','ч',
            'с','м','и','т','ь','б','ю'
        };
        byte[] byteKey, decrByteFile, encrByteFile;
        DateTime StartTime;
        public int MyTime;

        public Camellia()
        {
            InitializeComponent();
        }

        private void EncButton_Click(object sender, EventArgs e)
        {
            if (InputRichTextBox.Text == "")
                MessageBox.Show("Введите данные для шифрования", "Ошибка");
            else
            {
                if (!CheckInput(InputRichTextBox.Text))
                {
                    if (MessageBox.Show("В процессе шифровки может произойти потеря части текста.\n(Число символов должно быть кратно 16)\nПрервать шифровку?",
                          "Предупреждение!", MessageBoxButtons.YesNo) == DialogResult.Yes) return;
                }
                if (!CheckKey(KeyTB.Text))
                {
                    MessageBox.Show("Неверный формат ключа", "Ошибка");
                    return;
                }
                TimeStart();
                byteKey = Encoding.Default.GetBytes(KeyTB.Text);
                E24 e24 = new E24();
                string[] inputMsg = new string[InputRichTextBox.Text.Length / 16];
                int j = 0;
                for (int i = 0; i < inputMsg.Length; i++)
                {
                    inputMsg[i] = InputRichTextBox.Text.Substring(j, 16);
                    j += 16;
                }

                OutputRichTextBox.Clear();
                for (int i = 0; i < inputMsg.Length; i++)
                {
                    byte[] btFile = Encoding.Default.GetBytes(inputMsg[i]);

                    GenerationKeys newKey = new GenerationKeys();

                    if (!newKey.SetKey(byteKey))
                    {
                        MessageBox.Show("Error key!!!");
                        return;
                    }

                    encrByteFile = e24.Encrypt(btFile, newKey.eKey);
                    char[] eeee = Encoding.Default.GetChars(encrByteFile);
                    foreach (var f in eeee) OutputRichTextBox.Text += f.ToString();

                }
                TimeStop();
            }
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (OutputRichTextBox.Text == "")
                MessageBox.Show("Введите данные для расшифрования", "Ошибка");
            else
            {
                if (!CheckInput(OutputRichTextBox.Text))
                {
                    if (MessageBox.Show("В процессе шифровки может произойти потеря части текста.\n(Число символов должно быть кратно 16)\nПрервать шифровку?",
                          "Предупреждение!", MessageBoxButtons.YesNo) == DialogResult.Yes) return;
                }
                if (!CheckKey(KeyTB.Text))
                {
                    MessageBox.Show("Неверный формат ключа", "Ошибка");
                    return;
                }
                TimeStart();

                byteKey = Encoding.Default.GetBytes(KeyTB.Text);
                D24 d24 = new D24();
                string[] inputMsg = new string[OutputRichTextBox.Text.Length / 16];

                int j = 0;
                for (int i = 0; i < inputMsg.Length; i++)
                {
                    inputMsg[i] = OutputRichTextBox.Text.Substring(j, 16);
                    j += 16;
                }

                OutputRichTextBox.Clear();
                for (int i = 0; i < inputMsg.Length; i++)
                {
                    byte[] btFile = Encoding.Default.GetBytes(inputMsg[i]);

                    GenerationKeys newKey = new GenerationKeys();

                    if (!newKey.SetKey(byteKey))
                    {
                        MessageBox.Show("Error key!!!");
                        return;
                    }

                    encrByteFile = d24.Decrypt(btFile, newKey.eKey);     
                    OutputRichTextBox.Text += Encoding.Default.GetString(encrByteFile);
                }
                TimeStop();
            }
        }

        private bool CheckKey(string key)
        {
            if (key.Length == 16) return true;
            return false;
        }

        private bool CheckInput(string input)
        {
            if (input.Length % 16 == 0) return true;
            return false;
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

        private void KeyTB_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveTextButton_Click(object sender, EventArgs e)
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

        private void Camellia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть текущее окно?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void обалгоритмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Camellia - алгоритм симметричного блочного шифрования(размер блока 128 бит, ключ в данной реализации 128 бит). Структура алгоритма основана на классической цепи Фейстеля с предварительным и финальным забеливанием. Цикловая функция использует нелинейное преобразование (S-блоки), блок линейного рассеивания каждые 16 циклов (побайтовая операция XOR) и байтовую перестановку.", "Об алгоритме шифрования");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Алгоритмы Шифрования создано для шифрования текста, с помощью наиболее популярных и современных алгоритмов.\n AllRightReserved ", "О программе");
        }

        private string GenericKey()
        {
            Random rand = new Random();
            string result = "";
            for (int i = 0; i < 16; i++)
            {
                result += GenerKey[rand.Next(0, GenerKey.Length - 1)];
            }
            return result;
        }

        private void GenKeyButton_Click(object sender, EventArgs e)
        {
            KeyTB.Clear();
            KeyTB.Text = GenericKey();
            byteKey = Encoding.Default.GetBytes(KeyTB.Text);
        }

        private void SaveKeyButton_Click(object sender, EventArgs e)
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

        public byte[] FileToByte(string name)
        {
            return File.ReadAllBytes(name);
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            string file = OpenFileDialog.FileName;
            if (file == "") return;
            decrByteFile = FileToByte(file);
            InputRichTextBox.Text = Encoding.Default.GetString(decrByteFile);
            file = "";
        }
    }
}
