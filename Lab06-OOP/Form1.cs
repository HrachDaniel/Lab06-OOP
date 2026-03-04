using System;
using System.Windows.Forms;

namespace Lab06_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обробник події завантаження форми
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Метод генерує виключення, якщо дані невірні
        private double CalculateSum(double b1, double q, int n)
        {
            // Перевірка логічної умови: n має бути більше 0
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("n", "Кількість членів (n) має бути цілим числом більше 0.");
            }

            // Обробка випадку, коли q = 1 
            if (Math.Abs(q - 1.0) < 1e-10)
            {
                return b1 * n;
            }

            // Стандартна формула: Sn = b1 * (1 - q^n) / (1 - q)
            return b1 * (1 - Math.Pow(q, n)) / (1 - q);
        }

        // ОБРОБКА НАТИСКАННЯ КНОПКИ
        private void btnCalculate_Click(object? sender, EventArgs e)
        {
            // Очищуємо попередній результат та колір
            lblResult.Text = "Результат: ";
            lblResult.ForeColor = System.Drawing.Color.Black;

            try
            {
                // Спроба зчитати та конвертувати дані
                double b1 = double.Parse(txtB1.Text);
                double q = double.Parse(txtQ.Text);
                int n = int.Parse(txtN.Text);

                // Виклик методу обчислення
                double sum = CalculateSum(b1, q, n);

                // Вивід результату
                lblResult.Text = $"Сума Sn = {sum:F4}";
            }
            // ОБРОБКА ВИКЛЮЧЕНЬ
            catch (FormatException)
            {
                // Помилка, якщо користувач ввів не число або пустий рядок
                MessageBox.Show("Помилка введення: Будь ласка, введіть коректні числові значення.",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Помилка, яку ми викинули через "throw" (якщо n <= 0)
                MessageBox.Show(ex.Message, "Математична помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Будь-які інші непередбачені помилки
                MessageBox.Show($"Виникла непередбачена помилка: {ex.Message}",
                    "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
