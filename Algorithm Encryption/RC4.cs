using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Encryption
{
    public partial class RC4 : Form
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
        public string filename;
        public int MyTime;
        DateTime StartTime;
        public RC4()
        {
            InitializeComponent();
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (OutputRichTextBox.Text == "")
                MessageBox.Show("Окно для расшифровки пусто");
            else
            if (KeyTB.TextLength < 5 || KeyTB.TextLength > 256)
                MessageBox.Show("Размер ключа должен находиться в пределах от 5 до 256 символов");
            else
            {
                TimeStart();
                short[] result = new short[OutputRichTextBox.TextLength];
                for (int i = 0; i < OutputRichTextBox.TextLength; i++)
                    result[i] = (short)OutputRichTextBox.Text[i];
                short[] key = new short[KeyTB.TextLength];
                for (int i = 0; i < KeyTB.TextLength; i++)
                    key[i] = (short)KeyTB.Text[i];
                Algorithm_RC4.AlgorithmRC4 decoder = new Algorithm_RC4.AlgorithmRC4(key);
                short[] decryptedBytes = decoder.Decode(result, result.Length);
                OutputRichTextBox.Clear();
                for (int i = 0; i < decryptedBytes.Length; i++)
                    OutputRichTextBox.Text += (char)decryptedBytes[i];
                TimeStop();
            }
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

        private void TimerAlgorithm_Tick(object sender, EventArgs e)
        {
            MyTime++;
        }

        private void KeyTB_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void LoadKeyButton_Click(object sender, EventArgs e)
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
                        KeyTB.Text = sr.ReadToEnd();
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RC4 -  потоковый шифр, широко применяющийся в различных\n системах защиты информации в компьютерных сетях (например, в\n протоколах SSL и TLS, алгоритмах обеспечения безопасности\n беспроводных сетей WEP и WPA).\nОсновные преимущества шифра:\n-высокая скорость работы;\n-переменный размер ключа.", "Об алгоритме шифрования");
        }

        private void InputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void EncButton_Click(object sender, EventArgs e)
        {
            if (InputRichTextBox.Text == "")
                MessageBox.Show("Окно для ввода текста пусто");
            else
           if (KeyTB.TextLength < 5 || KeyTB.TextLength > 256)
                MessageBox.Show("Размер ключа должен находиться в пределах от 5 до 256 символов");
            else
            {
                TimeStart();
                OutputRichTextBox.Clear();
                short[] key = new short[KeyTB.TextLength];
                for (int i = 0; i < KeyTB.TextLength; i++)
                    key[i] = (short)KeyTB.Text[i];
                Algorithm_RC4.AlgorithmRC4 encoder = new Algorithm_RC4.AlgorithmRC4(key);
                string testString = InputRichTextBox.Text;
                short[] testBytes = new short[InputRichTextBox.TextLength];
                for (int i = 0; i < InputRichTextBox.TextLength; i++)
                    testBytes[i] = (short)InputRichTextBox.Text[i];
                short[] result = encoder.Encode(testBytes, testBytes.Length);
                for (int i = 0; i < result.Length; i++)
                    OutputRichTextBox.Text += (char)result[i];
                TimeStop();
            }
        }

        private void RC4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть текущее окно?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Алгоритмы Шифрования создано для шифрования текста, с помощью наиболее популярных и современных алгоритмов.\nAllRightReserved ", "О программе");
        }
        private string GenericKey()
        {
            Random rand = new Random();
            string result = "";
            int len = rand.Next(5, 256);
            for (int i = 0; i < len; i++)
            {
                result += GenerKey[rand.Next(0, GenerKey.Length - 1)];
            }
            return result;
        }

        private void GenKeyButton_Click(object sender, EventArgs e)
        {
            KeyTB.Clear();
            KeyTB.Text = GenericKey();
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
