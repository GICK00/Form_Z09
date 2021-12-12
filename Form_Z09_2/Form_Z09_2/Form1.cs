using System;
using System.IO;
using System.Windows.Forms;

namespace Form_Z09_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader fileRead = new StreamReader(new FileStream("line.txt", FileMode.Open, FileAccess.Read));

                string line;
                int i = 0;
                while ((line = fileRead.ReadLine()) != null)
                {
                    i++;
                    if (i % 2 != 0)
                        textBoxResult.Text += line + "\r\n";
                }
                fileRead.Close();
            }
            catch (FileNotFoundException)
            {
                textBoxResult.Text = "Файл не найден!";
            }
            catch (Exception ex)
            {
                textBoxResult.Text = ex.Message;
            }
        }
    }
}