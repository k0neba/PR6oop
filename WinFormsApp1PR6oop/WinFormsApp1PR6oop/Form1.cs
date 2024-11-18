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

        // Обработчик для ввода только цифр в TextBox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 - это клавиша Backspace
            {
                e.Handled = true;
                MessageBox.Show("Поле должно содержать цифры");
            }
        }

        // Обработчик длительной работы в фоновом потоке
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

                Thread.Sleep(1000); // Имитация длительной операции

                // Отправка прогресса
                backgroundWorker1.ReportProgress(i * 100 / seconds);
            }
        }

        // Обработчик для завершения фоновой работы
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

        // Обработчик изменения прогресса
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; // Обновление прогресса
        }

        // Обработчик кнопки Start
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int seconds = int.Parse(textBox1.Text);
                backgroundWorker1.RunWorkerAsync(seconds); // Запуск фоновой работы
            }
            else
            {
                MessageBox.Show("Введите число в поле");
            }
        }

        // Обработчик кнопки Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync(); // Отмена фоновой работы
        }

        // Инициализация компонента
        private void Form1_Load(object sender, EventArgs e)
        {
            // Подключение обработчика для события ProgressChanged
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            // Подключение обработчика для события RunWorkerCompleted
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }
    }
}
