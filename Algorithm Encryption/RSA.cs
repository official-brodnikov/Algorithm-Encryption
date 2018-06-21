using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace Algorithm_Encryption
{
    public partial class RSA : Form
    {
        byte[] enc;
        public int MyTime;
        BigInteger n, F, E, D;
        string filename;
        DateTime StartTime;
        public RSA()
        {
            InitializeComponent();
        }

        static private bool CheckKey(string key)
        {
            foreach (var s in key)
            {
                if (!char.IsDigit(s)) return false;
            }
            return true;
        }

        private void LoadTextButton_Click(object sender, EventArgs e) 
        {
            OpenFileDialog.ShowDialog();
            string file = OpenFileDialog.FileName;
            if (file == "") return;
            InputRichTextBox.Text = File.ReadAllText(file);
            file = "";
        }

        private void LoadCloseKeyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            string file = OpenFileDialog.FileName;
            if (file == "") return;
            string[] fileLines = File.ReadAllLines(file);
            if (fileLines.Length <= 2)
            {
                DCloseTB.Text = fileLines[0];
                NCloseTB.Text = fileLines[1];
            }
            else MessageBox.Show("Неверный формат ключа", "Ошибка");
        }

        private void SaveTextButton_Click(object sender, EventArgs e)
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseKeyLabel_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.Clear();
        }

        private void RSA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть текущее окно?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void обалгоритмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RSA - криптографический алгоритм с открытым ключом, основывающийся на вычислительной сложности задачи факторизации больших целых чисел.", "Информация об алгоритме");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Алгоритмы Шифрования создано для шифрования текста, с помощью наиболее популярных и современных алгоритмов.\n AllRightReserved ", "О программе");
        }

        private void GenButton_Click(object sender, EventArgs e)
        {
            Algorithm_RSA.AlgorithmRSA rsa = new Algorithm_RSA.AlgorithmRSA();
            BigInteger p = rsa.GeneratePrimaryLongNumber(), q = rsa.GeneratePrimaryLongNumber();

            n = p * q;
            NOpenTB.Text = n.ToString();
            NCloseTB.Text = n.ToString();

            F = (p - 1) * (q - 1);

            E = rsa.GetEpsilon(F);
            EOpenTB.Text = E.ToString();

            D = rsa.MultiplicativeInverse(E,F);
            DCloseTB.Text = D.ToString();
        }


        private void EncButton_Click(object sender, EventArgs e)
        {
            if (NOpenTB.Text == "" || EOpenTB.Text == "")
            {
                MessageBox.Show("Для зашифровки сообщения введите открытый ключ.", "Ошибка");
                return;
            }
            else if (!CheckKey(NOpenTB.Text) || !CheckKey(EOpenTB.Text))
            {
                MessageBox.Show("Открытый ключ содержит некорректные символы.", "Ошибка");
                return;
            }
            else if (InputRichTextBox.Text == "")
            {
                MessageBox.Show("Окно для ввода текста пусто", "Ошибка!");
                return;
            }
            else
            {
                TimeStart();
                Algorithm_RSA.AlgorithmRSA rsa = new Algorithm_RSA.AlgorithmRSA();

                string input = InputRichTextBox.Text;
                byte[] Enc = rsa.Encrypt(input, E, n);
                enc = Enc;
                OutputRichTextBox.Clear();
                for (int i = 0; i < enc.Length; i++) OutputRichTextBox.Text += Enc[i];

                TimeStop();
            }

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
                        sw.WriteLine(EOpenTB.Text);
                        sw.WriteLine(NOpenTB.Text);
                        sw.WriteLine(DCloseTB.Text);
                        sw.WriteLine(NCloseTB.Text);
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

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (NCloseTB.Text == "" || DCloseTB.Text == "")
            {
                MessageBox.Show("Для зашифровки сообщения введите открытый ключ.", "Ошибка");
                return;
            }
            else if (!CheckKey(NCloseTB.Text) || !CheckKey(DCloseTB.Text))
            {
                MessageBox.Show("Открытый ключ содержит некорректные символы.", "Ошибка");
                return;
            }
            else
             if (OutputRichTextBox.Text == "")
            {
                MessageBox.Show("Окно для расшифровки пусто", "Ошибка");
                return;
            }
            else
            {
                TimeStart();
                Algorithm_RSA.AlgorithmRSA rsa = new Algorithm_RSA.AlgorithmRSA();

                OutputRichTextBox.Clear();
                OutputRichTextBox.Text = rsa.Decrypt(enc, D, n);

                TimerAlgorithm.Enabled = false;
                TimeStop();
            }
        }
    }
}
