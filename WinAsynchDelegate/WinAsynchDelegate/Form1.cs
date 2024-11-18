using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAsynchDelegate
{
    public partial class Form1 : Form
    {
        private bool Cancel = false; // Логическая переменная для отмены

        public Form1()
        {
            InitializeComponent();
        }

        // Делегат для TimeConsumingMethod
        private delegate void TimeConsumingMethodDelegate(int seconds);

        // Делегат для обновления прогресса
        public delegate void SetProgressDelegate(int val);

        // Метод для обновления прогресса
        public void SetProgress(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
            else
            {
                progressBar1.Value = val; // Обновляем прогресс
            }
        }

        // Метод для долгой операции
        private async Task TimeConsumingMethodAsync(int seconds)
        {
            for (int j = 1; j <= seconds; j++)
            {
                await Task.Delay(1000); // Ожидание 1 секунду асинхронно
                SetProgress((int)(j * 100) / seconds); // Обновление прогресса

                if (Cancel) // Проверка на отмену
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

        // Обработчик для кнопки Go!
        private async void buttonGo_Click_1(object sender, EventArgs e)
        {
            int seconds = int.Parse(textBox1.Text);
            await TimeConsumingMethodAsync(seconds); 
        }

        // Обработчик для кнопки Cancel
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Cancel = true; 
        }
    }
}
