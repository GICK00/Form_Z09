using System;
using System.IO;
using System.Windows.Forms;

namespace Form_Z09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxResult.Text = "";
                int n = Convert.ToInt32(textBoxN.Text);
                if (n <= 0)
                    throw new Exception("Последовательность не может быть меньше 1!");
                double m = Convert.ToDouble(textBoxM.Text);
                if (m >= n)
                    throw new Exception("Число M должно быть меньше N!");

                FileStream file = new FileStream("Number.bat", FileMode.Create, FileAccess.Write);
                BinaryWriter fileOut = new BinaryWriter(file);
                double j = 0;
                for (int i = 0; i < n; i++)
                {
                    fileOut.Write(Convert.ToDouble(j += 0.1));
                }
                fileOut.Close();

                textBoxResult.Text += "Записанно.\r\n";
                file = new FileStream("Number.bat", FileMode.Open, FileAccess.Read);
                BinaryReader fileIn = new BinaryReader(file);
                long l = file.Length;
                Console.Write("| ");
                for (long i = 0; i < l; i += 8)
                {
                    file.Seek(i, SeekOrigin.Begin);
                    textBoxResult.Text += "  " + Math.Round(fileIn.ReadDouble(), 3);
                }

                textBoxResult.Text += "\r\nВыведенно.\r\n";
                Console.Write("| ");
                for (long i = 0; i < l; i += 16)
                {
                    file.Seek(i, SeekOrigin.Begin);
                    double number = Math.Round(fileIn.ReadDouble(), 3);
                    if (number > m)
                    {
                        textBoxResult.Text += "  " + number;
                    }
                }
                fileIn.Close();
                file.Close();
            }
            catch (FormatException)
            {
                textBoxResult.Text = "Некорректный ввод данных!";
            }
            catch(Exception ex)
            {
                textBoxResult.Text = ex.Message;
            }   
        }
    }
}
