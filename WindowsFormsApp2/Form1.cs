using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            int n;
            string inputN = textBoxN.Text;
            bool resultN = int.TryParse(inputN, out n);
            if (!resultN || n <= 1)
            {
                MessageBox.Show($"Введите число больше 1", "Ошибка");
                return;
            }

            grid.RowCount = n;
            grid.ColumnCount = n;

            var ran = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid.Rows[i].Cells[j].Value = ran.Next(-20, 21);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var n = grid.ColumnCount;
            labelRes.Text = grid.Rows[1].Cells[1].Value.ToString();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var b = (grid.Rows[i].Cells[j].Value.ToString() == grid.Rows[j].Cells[i].Value.ToString());
                    if (!b)
                    {
                        labelRes.Text = "Матрица несимметрична";
                        return;
                    }
                }
            }
            labelRes.Text = "Матрица симметрична";
        }
    }
}
