using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1PR6oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ���������� ��� ����� ������ ���� � TextBox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 - ��� ������� Backspace
            {
                e.Handled = true;
                MessageBox.Show("���� ������ ��������� �����");
            }
        }

        // ���������� ���������� ������ � ������� ������
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int seconds = int.Parse(e.Argument.ToString());

            for (int i = 1; i <= seconds; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                Thread.Sleep(1000); // �������� ���������� ��������

                // �������� ���������
                backgroundWorker1.ReportProgress(i * 100 / seconds);
            }
        }

        // ���������� ��� ���������� ������� ������
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Run Cancelled");
            }
            else
            {
                MessageBox.Show("Run Completed!");
            }
        }

        // ���������� ��������� ���������
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; // ���������� ���������
        }

        // ���������� ������ Start
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int seconds = int.Parse(textBox1.Text);
                backgroundWorker1.RunWorkerAsync(seconds); // ������ ������� ������
            }
            else
            {
                MessageBox.Show("������� ����� � ����");
            }
        }

        // ���������� ������ Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync(); // ������ ������� ������
        }

        // ������������� ����������
        private void Form1_Load(object sender, EventArgs e)
        {
            // ����������� ����������� ��� ������� ProgressChanged
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            // ����������� ����������� ��� ������� RunWorkerCompleted
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }
    }
}
