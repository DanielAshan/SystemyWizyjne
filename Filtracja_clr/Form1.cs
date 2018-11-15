using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace Filtracja
{
    public partial class Form1 : Form
    {
        //Zmienna typu Size moze byc przez nas dowolnie 
        //powołana i wykorzystana w kodzie. Dzieki temu
        //mozna zdefiniowac zadany rozmiar obrazku z wewnatrz kodu.
        //Właściwość StrechImage będzie odpowiedzialna za dopasowanie
        //rozmiarow
        private Size desired_image_size;
        Image<Bgr, byte> image_PB1, image_PB2;
        Image<Bgr, byte>[] image_buffers;
        double[] filter_coeff;
        VideoCapture camera;

        //Konstruktor klasy Form1. Odpowiada za inicjalizację wszystkich
        //komponentów (kontrolki i ich rozmieszczenie i właściwości)
        //na oknie aplikacji
        public Form1()
        {
            InitializeComponent();
            desired_image_size = new Size(320, 240);
            image_PB1 = new Image<Bgr, byte>(desired_image_size);
            image_PB2 = new Image<Bgr, byte>(desired_image_size);

            filter_coeff = new double[9];

            image_buffers = new Image<Bgr, byte>[3];
            for (int i = 0; i < image_buffers.Length; i++)
            {
                image_buffers[i] = new Image<Bgr, byte>(desired_image_size);
            }

            //Blok try catch aby przechwycić ewentualne niepowodzenie
            //tworzenia nowej instancji obiektu VideoCapture. Potrzebny, gdyz
            //w chwili tworzenia następuje próba połączenia się z kamerą która
            //może zakończyć się niepowodzeniem.
            try
            {
                camera = new VideoCapture();
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, desired_image_size.Width);
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, desired_image_size.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button_From_CvInvoke_PB1_Click(object sender, EventArgs e)
        {

        }

        private void button_From_CvInvoke_PB2_Click(object sender, EventArgs e)
        {

        }

        private void button_Clr_PB1_Click(object sender, EventArgs e)
        {
            //Możliwe jest przekazanie obiektów jakie chcemy zmodyfikować
            //jako argumenty metody.
            //Obiekty w C# są domyślnie przekazywane jako referencje. Są to tzw. typy referencyjne
            //Oznacza to, że zmiany dokonane na tak przekazanych obiektach "przeniosą się"
            //poza metodę, w której te modyfikacje były dokonane
            //PS: zmienne typów int, double itd to tzw typy wartościowe, a nie referencyjne.
            //Oznacza to, że te typy są kopiowane do metody.
            clear_image(pictureBox1, image_PB1);
        }

        private void button_Clr_PB2_Click(object sender, EventArgs e)
        {
            clear_image(pictureBox2, image_PB2);
        }

        private void clear_image(PictureBox PB, Image<Bgr, byte> Image)
        {
            //Zmienne typu PictureBox i Image<Bgr, byte> to instancje klas.
            //Zostały zatem "pod maską" przekazane do metody jako referencje.
            Image.SetZero();
            PB.Image = Image.Bitmap;
        }

        private void button_Browse_Files_PB1_Click(object sender, EventArgs e)
        {
            textBox_Image_Path_PB1.Text = get_image_path();
        }

        private void button_Browse_Files_PB2_Click(object sender, EventArgs e)
        {
            textBox_Image_Path_PB2.Text = get_image_path();
        }

        private string get_image_path()
        {
            string ret = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Wybierz obrazek.";
            //Jeśli wszystko przebiegło ok to pobiera nazwę pliku
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                ret = openFileDialog1.FileName;
            }

            return ret;
        }

        private void button_From_File_PB1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = get_image_bitmap_from_file(textBox_Image_Path_PB1.Text, ref image_PB1);
        }

        private void button_From_File_PB2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = get_image_bitmap_from_file(textBox_Image_Path_PB2.Text, ref image_PB2);
        }

        private Bitmap get_image_bitmap_from_file(string path, ref Image<Bgr, byte> Data)
        {
            Mat temp = CvInvoke.Imread(path);
            CvInvoke.Resize(temp, temp, desired_image_size);
            Data = temp.ToImage<Bgr, byte>();
            return Data.Bitmap;
        }

        private void button_From_Camera_PB1_Click(object sender, EventArgs e)
        {
            Mat temp = camera.QueryFrame();
            CvInvoke.Resize(temp, temp, image_PB1.Size);

            image_PB1 = temp.ToImage<Bgr, byte>();
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void button_From_Camera_PB2_Click(object sender, EventArgs e)
        {
            Mat temp = camera.QueryFrame();
            CvInvoke.Resize(temp, temp, image_PB2.Size);

            image_PB2 = temp.ToImage<Bgr, byte>();
            pictureBox2.Image = image_PB2.Bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        //Bufory
        private void button_Buf1_To_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[0], image_PB1);
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void button_Buf1_From_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB1, image_buffers[0]);
            pictureBox_BUF1.Image = image_buffers[0].Bitmap;
        }

        private void button_Buf2_To_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[1], image_PB1);
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void button_Buf2_From_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB1, image_buffers[1]);
            pictureBox_BUF2.Image = image_buffers[1].Bitmap;
        }

        private void button_Buf3_To_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[2], image_PB1);
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void button_Buf3_From_PB1_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB1, image_buffers[2]);
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }

        private void button_Buf1_To_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[0], image_PB2);
            pictureBox2.Image = image_PB2.Bitmap;
        }

        private void button_Buf1_From_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB2, image_buffers[0]);
            pictureBox_BUF1.Image = image_buffers[0].Bitmap;
        }

        private void button_Buf2_To_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[1], image_PB2);
            pictureBox2.Image = image_PB2.Bitmap;
        }

        private void button_Buf2_From_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB2, image_buffers[1]);
            pictureBox_BUF2.Image = image_buffers[1].Bitmap;
        }

        private void button_Buf3_To_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_buffers[2], image_PB2);
            pictureBox2.Image = image_PB2.Bitmap;
        }

        private void button_Buf3_From_PB2_Click(object sender, EventArgs e)
        {
            copy_image_data(image_PB2, image_buffers[2]);
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }

        private void copy_image_data(Image<Bgr, byte> src, Image<Bgr, byte> dest)
        {
            src.CopyTo(dest);
        }

        private void button_Logical_Operation_Click(object sender, EventArgs e)
        {
            byte[, ,] b1, b2, b3;
            b1 = image_buffers[0].Data;
            b2 = image_buffers[1].Data;
            b3 = image_buffers[2].Data;
            for (int x = 0; x < desired_image_size.Width; x++)
            {
                for (int y = 0; y < desired_image_size.Height; y++)
                {
                    if(radioButton_buf_AND.Checked == true)
                    {
                        b3[y, x, 0] = (byte)((int)b1[y, x, 0] & (int)b2[y, x, 0]);
                        b3[y, x, 1] = (byte)((int)b1[y, x, 1] & (int)b2[y, x, 1]);
                        b3[y, x, 2] = (byte)((int)b1[y, x, 2] & (int)b2[y, x, 2]);
                    } else if (radioButton_buf_OR.Checked == true) {                        
                            b3[y, x, 0] = (byte)((int)b1[y, x, 0] | (int)b2[y, x, 0]);
                            b3[y, x, 1] = (byte)((int)b1[y, x, 1] | (int)b2[y, x, 1]);
                            b3[y, x, 2] = (byte)((int)b1[y, x, 2] | (int)b2[y, x, 2]);                        
                    } else if (radioButton_buf_XOR.Checked == true) {
                        b3[y, x, 0] = (byte)((int)b1[y, x, 0] ^ (int)b2[y, x, 0]);
                        b3[y, x, 1] = (byte)((int)b1[y, x, 1] ^ (int)b2[y, x, 1]);
                        b3[y, x, 2] = (byte)((int)b1[y, x, 2] ^ (int)b2[y, x, 2]);
                    }
                }
            }
            image_buffers[2].Data = b3;
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }

        //Filtry

        private void button_Low_Pass_Coeff_Click(object sender, EventArgs e)
        {
            numericUpDown_Filtr_Param11.Value = int.Parse("1");
            numericUpDown_Filtr_Param12.Value = int.Parse("2");
            numericUpDown_Filtr_Param13.Value = int.Parse("1");
            numericUpDown_Filtr_Param21.Value = int.Parse("2");
            numericUpDown_Filtr_Param22.Value = int.Parse("4");
            numericUpDown_Filtr_Param23.Value = int.Parse("2");
            numericUpDown_Filtr_Param31.Value = int.Parse("1");
            numericUpDown_Filtr_Param32.Value = int.Parse("2");
            numericUpDown_Filtr_Param33.Value = int.Parse("4");

        }

        private void button_High_Pass_Coeff_Click(object sender, EventArgs e)
        {
            numericUpDown_Filtr_Param11.Value = int.Parse("1");
            numericUpDown_Filtr_Param12.Value = int.Parse("1");
            numericUpDown_Filtr_Param13.Value = int.Parse("0");
            numericUpDown_Filtr_Param21.Value = int.Parse("1");
            numericUpDown_Filtr_Param22.Value = int.Parse("0");
            numericUpDown_Filtr_Param23.Value = int.Parse("-1");
            numericUpDown_Filtr_Param31.Value = int.Parse("0");
            numericUpDown_Filtr_Param32.Value = int.Parse("-1");
            numericUpDown_Filtr_Param33.Value = int.Parse("-1");
        }

        private void button_Apply_Filter_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void filter()
        {
            int w11 = (int)numericUpDown_Filtr_Param11.Value;
            int w12 = (int)numericUpDown_Filtr_Param12.Value;
            int w13 = (int)numericUpDown_Filtr_Param13.Value;
            int w21 = (int)numericUpDown_Filtr_Param21.Value;
            int w22 = (int)numericUpDown_Filtr_Param22.Value;
            int w23 = (int)numericUpDown_Filtr_Param23.Value;
            int w31 = (int)numericUpDown_Filtr_Param31.Value;
            int w32 = (int)numericUpDown_Filtr_Param32.Value;
            int w33 = (int)numericUpDown_Filtr_Param33.Value;
            //Dodać kod
            byte[,,] temp1 = image_buffers[1].Data;
            byte[,,] temp2 = image_buffers[2].Data;

            float wsp = 0;
            float ws = w11 + w12 + w13 + w21 + w22 + w23 + w31 + w32 + w33;
            if ( ws != 0 )
            {
                wsp = 1 / ws;
            } else
            {
                wsp = 1;
            }
            for (int x = 1; x < desired_image_size.Width - 1; x++)
            {
                for (int y = 1; y < desired_image_size.Height - 1; y++)
                {
                    //Dodać kod
                    for(int i = 0; i <= 2; i++)
                    {
                        int v_11 = w11 * (int)temp1[y - 1, x - 1, i];
                        int v_12 = w12 * (int)temp1[y - 1, x, i];
                        int v_13 = w13 * (int)temp1[y - 1, x + 1, i];
                        int v_21 = w21 * (int)temp1[y, x - 1, i];
                        int v_22 = w22 * (int)temp1[y, x, i];
                        int v_23 = w23 * (int)temp1[y, x + 1, i];
                        int v_31 = w31 * (int)temp1[y + 1, x - 1, i];
                        int v_32 = w32 * (int)temp1[y + 1, x, i];
                        int v_33 = w33 * (int)temp1[y + 1, x + 1, i];
                        temp2[y, x, i] = (byte)((int)(wsp * (v_11 + v_12 + v_13 + v_21 + v_22 + v_23 + v_31 + v_32 + v_33)));
                    }
                }
            }
            image_buffers[2].Data = temp2;
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }

        private void button_Thresh_Click(object sender, EventArgs e)
        {
            Threshold();
        }

        private void Threshold()
        {

        }

        private void button_Dilate_Click(object sender, EventArgs e)
        {
            Dilate();
        }

        private void button_Erode_Click(object sender, EventArgs e)
        {
            Erode();
        }

        private void Dilate()
        {
            double R, G, B;

            byte[, ,] temp1 = image_buffers[1].Data;
            byte[, ,] temp2 = image_buffers[2].Data;

            for (int x = 1; x < desired_image_size.Width - 1; x++)
            {
                for (int y = 1; y < desired_image_size.Height - 1; y++)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        int[] tab = { (int)temp1[y - 1, x - 1, i], (int)temp1[y - 1, x, i], (int)temp1[y - 1, x + 1, i],
                        (int)temp1[y, x - 1, i], (int)temp1[y, x, i], (int)temp1[y, x + 1, i],
                        (int)temp1[y + 1, x - 1, i], (int)temp1[y + 1, x, i], (int)temp1[y + 1, x + 1, i] };
                        temp2[y, x, i] = (byte)(tab.Max());
                    }
                }
            }
            image_buffers[2].Data = temp2;
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Erode()
        {
            double R, G, B;

            byte[, ,] temp1 = image_buffers[1].Data;
            byte[, ,] temp2 = image_buffers[2].Data;

            for (int x = 1; x < desired_image_size.Width - 1; x++)
            {
                for (int y = 1; y < desired_image_size.Height - 1; y++)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        int[] tab = { (int)temp1[y - 1, x - 1, i], (int)temp1[y - 1, x, i], (int)temp1[y - 1, x + 1, i],
                        (int)temp1[y, x - 1, i], (int)temp1[y, x, i], (int)temp1[y, x + 1, i],
                        (int)temp1[y + 1, x - 1, i], (int)temp1[y + 1, x, i], (int)temp1[y + 1, x + 1, i] };
                        temp2[y, x, i] = (byte)(tab.Min());
                    }
                }
            }
            image_buffers[2].Data = temp2;
            pictureBox_BUF3.Image = image_buffers[2].Bitmap;
        }
    }
}
