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
                int m = Convert.ToInt32(textBoxM.Text);
                if (m >= n)
                    throw new Exception("Число M должно быть меньше N!");

                FileStream file = new FileStream("Number.bat", FileMode.Create, FileAccess.Write);
                BinaryWriter fileOut = new BinaryWriter(file);
                for (int i = 0; i < n; i++)
                {
                    fileOut.Write(i + 1);
                }
                fileOut.Close();

                file = new FileStream("Number.bat", FileMode.Open, FileAccess.Read);
                BinaryReader fileIn = new BinaryReader(file);
                long l = file.Length;
                for (long i = 0; i < l; i += 8)
                {
                    if (fileIn.ReadInt32() > m / 2)
                    {
                        file.Seek(i, SeekOrigin.Begin);
                        textBoxResult.Text += " " + fileIn.ReadInt32();
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
