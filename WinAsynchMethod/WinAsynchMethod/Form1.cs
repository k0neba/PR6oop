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

        // Делегат для асинхронного вызова
        private delegate int AsyncSumm(int a, int b);

        // Метод для сложения с задержкой
        private int Summ(int a, int b)
        {
            System.Threading.Thread.Sleep(9000); // Задержка 9 секунд
            return a + b;
        }

        // Callback-метод
        private void CallBackMethod(IAsyncResult ar)
        {
            string str;
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            str = String.Format("Сумма введенных чисел равна: {0}", summdelegate.EndInvoke(ar));
            MessageBox.Show(str, "Результат операции");
        }

        // Асинхронный метод для сложения с задержкой
        private async Task<int> SummAsync(int a, int b)
        {
            await Task.Delay(9000);  // Асинхронная задержка 9 секунд
            return a + b;
        }

        // Обработчик кнопки btnRun
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
                MessageBox.Show("При выполнении преобразования типов возникла ошибка");
                txbA.Text = txbB.Text = ""; // Очищаем текстовые поля
                return;
            }

            // Создаем новый объект BackgroundWorker
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                // Здесь выполняется длительная операция
                System.Threading.Thread.Sleep(9000);
                args.Result = a + b;
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                // После завершения работы показываем результат
                if (args.Error != null)
                {
                    MessageBox.Show($"Ошибка: {args.Error.Message}");
                }
                else
                {
                    MessageBox.Show($"Сумма: {args.Result}");
                }
            };

            worker.RunWorkerAsync();
        }

        // Обработчик кнопки btnWork
        private void btnWork_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Работа кипит!!!");
        }

        // Метод загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Код инициализации при загрузке формы
        }
    }
}
