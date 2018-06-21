using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Encryption
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            
        }
        private void RSAButton_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                RSA newForm = new RSA();
                newForm.Show();
            }
        }

        private void GostButton_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                BaseForm newForm = new BaseForm();
                newForm.Show();
            }
        }

        private void RC4Button_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                RC4 newForm = new RC4();
                newForm.Show();
            }
        }

        private void AESButton_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                AES newForm = new AES();
                newForm.Show();
            }
        }

        private void El_GamalButton_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                El_Gamal newForm = new El_Gamal();
                newForm.Show();
            }
        }

        private void HelloLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TimerStartWork.Enabled)
                HelloLabel.Visible = false;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            TimerStartWork.Start();
        
            ToolTip t = new ToolTip();
            t.SetToolTip(RSAButton, " Криптографический алгоритм с открытым ключом,\n основывающийся на вычислительной сложности задачи факторизации больших целых чисел");
            t.SetToolTip(AESButton, " Симметричный алгоритм блочного шифрования\n (размер блока 128 бит, ключ  в данной реализации 256 бит)");
            t.SetToolTip(GostButton, " Симметричный алгоритм блочного шифрования\n использует ключ длиной 256 бит");
            t.SetToolTip(RC4Button, " Потоковый шифр, широко применяющийся в различных\n системах защиты информации в компьютерных сетях");
            t.SetToolTip(CamelliaButton, " Алгоритм симметричного блочного шифрования\n (размер блока и ключа в данной реализации 128 бит )");
            t.SetToolTip(El_GamalButton, " Криптосистема с открытым ключом, основанная на трудной задаче\n вычисления дискретных логарифмов в конечном поле");
        }

        private void TimerStartWork_Tick(object sender, EventArgs e)
        {
            if (HelloLabel.Text != "Выберите один из предложенных алгоритмов шифрования")
            {
                HelloLabel.Text = "Выберите один из предложенных алгоритмов шифрования";
                TimerStartWork.Start();
                return;
            }
            else
                TimerStartWork.Enabled = false;
        }

        private void CamelliaButton_Click(object sender, EventArgs e)
        {
            if (HelloLabel.Visible == false)
            {
                Camellia newForm = new Camellia();
                newForm.Show();
            }
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
