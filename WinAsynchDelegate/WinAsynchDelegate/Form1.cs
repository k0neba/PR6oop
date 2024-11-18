using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAsynchDelegate
{
    public partial class Form1 : Form
    {
        private bool Cancel = false; // ���������� ���������� ��� ������

        public Form1()
        {
            InitializeComponent();
        }

        // ������� ��� TimeConsumingMethod
        private delegate void TimeConsumingMethodDelegate(int seconds);

        // ������� ��� ���������� ���������
        public delegate void SetProgressDelegate(int val);

        // ����� ��� ���������� ���������
        public void SetProgress(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
            else
            {
                progressBar1.Value = val; // ��������� ��������
            }
        }

        // ����� ��� ������ ��������
        private async Task TimeConsumingMethodAsync(int seconds)
        {
            for (int j = 1; j <= seconds; j++)
            {
                await Task.Delay(1000); // �������� 1 ������� ����������
                SetProgress((int)(j * 100) / seconds); // ���������� ���������

                if (Cancel) // �������� �� ������
                {
                    break;
                }
            }

            if (Cancel)
            {
                MessageBox.Show("Cancelled");
            }
            else
            {
                MessageBox.Show("Complete");
            }

            Cancel = false; 
        }

        // ���������� ��� ������ Go!
        private async void buttonGo_Click_1(object sender, EventArgs e)
        {
            int seconds = int.Parse(textBox1.Text);
            await TimeConsumingMethodAsync(seconds); 
        }

        // ���������� ��� ������ Cancel
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Cancel = true; 
        }
    }
}
