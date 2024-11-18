using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAsynchMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ������� ��� ������������ ������
        private delegate int AsyncSumm(int a, int b);

        // ����� ��� �������� � ���������
        private int Summ(int a, int b)
        {
            System.Threading.Thread.Sleep(9000); // �������� 9 ������
            return a + b;
        }

        // Callback-�����
        private void CallBackMethod(IAsyncResult ar)
        {
            string str;
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            str = String.Format("����� ��������� ����� �����: {0}", summdelegate.EndInvoke(ar));
            MessageBox.Show(str, "��������� ��������");
        }

        // ����������� ����� ��� �������� � ���������
        private async Task<int> SummAsync(int a, int b)
        {
            await Task.Delay(9000);  // ����������� �������� 9 ������
            return a + b;
        }

        // ���������� ������ btnRun
        private void btnRun_Click_1(object sender, EventArgs e)
        {
            int a, b;
            try
            {
                a = Int32.Parse(txbA.Text);
                b = Int32.Parse(txbB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("��� ���������� �������������� ����� �������� ������");
                txbA.Text = txbB.Text = ""; // ������� ��������� ����
                return;
            }

            // ������� ����� ������ BackgroundWorker
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                // ����� ����������� ���������� ��������
                System.Threading.Thread.Sleep(9000);
                args.Result = a + b;
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                // ����� ���������� ������ ���������� ���������
                if (args.Error != null)
                {
                    MessageBox.Show($"������: {args.Error.Message}");
                }
                else
                {
                    MessageBox.Show($"�����: {args.Result}");
                }
            };

            worker.RunWorkerAsync();
        }

        // ���������� ������ btnWork
        private void btnWork_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("������ �����!!!");
        }

        // ����� �������� �����
        private void Form1_Load(object sender, EventArgs e)
        {
            // ��� ������������� ��� �������� �����
        }
    }
}
