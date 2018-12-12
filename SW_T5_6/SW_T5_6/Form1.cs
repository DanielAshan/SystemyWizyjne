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
using System.Threading;

namespace SW_T8_9_10
{
    public partial class Form1 : Form
    {
        //Podczas tego ćwiczenia właściwość sizeMode pictureboxów należy ustawić na "Normal"

        private Size desired_image_size;
        Image<Bgr, byte> image_PB1, image_PB2, image_PB3;
        VideoCapture camera;

        //Kolejki. Ułatwiają pracę z danymi przypominającymi listę zadań do wykonia czy punktów do sprawdzenie, gdzie po 
        //pobraniu wartości z kolejki, można od razu usunąć dany wpis z kolejki.
        //Metoda Enqueue służy do dodania nowego obiektu do kolejki
        //Metoda Dequeue zwraca następny obiekt z kolejki i usuwa go z niej
        Queue<Point> pix_tlace = new Queue<Point>();
        Queue<Point> pix_palace = new Queue<Point>();
        Queue<Point> pix_nadpalone = new Queue<Point>();
        Queue<Point> pix_wypalone = new Queue<Point>();
        //
        private MCvScalar aktualnie_klikniety = new MCvScalar(0, 0, 0);
        private MCvScalar cecha_palnosci = new MCvScalar(0xFF, 0xFF, 0xFF);
        private MCvScalar cecha_nadpalenia = new MCvScalar(0, 0, 0);

        private MCvScalar kolor_tlenia = new MCvScalar(51, 153, 255);
        private MCvScalar kolor_palenia = new MCvScalar(0, 0, 204);
        private MCvScalar kolor_nadpalenia = new MCvScalar(51, 204, 51);
        private MCvScalar kolor_wypalenia = new MCvScalar(100, 100, 100);
        private MCvScalar aktualny_kolor_wypalenia = new MCvScalar(100, 100, 100);

        private int nr_pozaru = 0;
        private bool skos = false;
        private bool cecha_dowolna = false;
        //

        public Form1()
        {
            InitializeComponent();
            desired_image_size = pictureBox1.Size;
            image_PB1 = new Image<Bgr, byte>(desired_image_size);
            image_PB2 = new Image<Bgr, byte>(desired_image_size);
            image_PB3 = new Image<Bgr, byte>(desired_image_size);

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
            Wyswietl_dane_pozaru();
        }

        private void button_Browse_Files_PB1_Click(object sender, EventArgs e)
        {
            textBox_Image_Path_PB1.Text = get_image_path();
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
            //Czyszczenie danych
            Wyczysc_dane_pozaru();
        }

        private Bitmap get_image_bitmap_from_file(string path, ref Image<Bgr, byte> Data)
        {
            Mat temp = CvInvoke.Imread(path);
            CvInvoke.Resize(temp, temp, desired_image_size);
            Data = temp.ToImage<Bgr, byte>();
            return Data.Bitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;

            textBox_X.Text = me.X.ToString();
            textBox_Y.Text = me.Y.ToString();

            byte[, ,] temp = image_PB1.Data;
            byte R, G, B;
            B = temp[me.Y, me.X, 0];
            G = temp[me.Y, me.X, 1];
            R = temp[me.Y, me.X, 2];

            aktualnie_klikniety.V0 = B;
            aktualnie_klikniety.V1 = G;
            aktualnie_klikniety.V2 = R;

            textBox_B.Text = "0x" + B.ToString("X");
            textBox_G.Text = "0x" + G.ToString("X");
            textBox_R.Text = "0x" + R.ToString("X");
        }

        private void button_Ustaw_Jako_Palnosc_Click(object sender, EventArgs e)
        {
            textBox_B_pal.Text = textBox_B.Text;
            textBox_G_pal.Text = textBox_G.Text;
            textBox_R_pal.Text = textBox_R.Text;

            cecha_palnosci.V0 = aktualnie_klikniety.V0;
            cecha_palnosci.V1 = aktualnie_klikniety.V1;
            cecha_palnosci.V2 = aktualnie_klikniety.V2;
        }

        private void button_Ustaw_Jako_Nadpalenie_Click(object sender, EventArgs e)
        {
            textBox_B_nadpal.Text = textBox_B.Text;
            textBox_G_nadpal.Text = textBox_G.Text;
            textBox_R_nadpal.Text = textBox_R.Text;

            cecha_nadpalenia.V0 = aktualnie_klikniety.V0;
            cecha_nadpalenia.V1 = aktualnie_klikniety.V1;
            cecha_nadpalenia.V2 = aktualnie_klikniety.V2;
        }

        private void Wyczysc_dane_pozaru()
        {
            nr_pozaru = 0;
            pix_nadpalone.Clear();
            pix_palace.Clear();
            pix_tlace.Clear();
            pix_wypalone.Clear();
            Wyswietl_dane_pozaru();
        }

        private void checkBox_Skos_CheckedChanged(object sender, EventArgs e)
        {
            skos = checkBox_Skos.Checked;
        }

        private void checkBox_Cecha_dowolna_CheckedChanged(object sender, EventArgs e)
        {
            cecha_dowolna = checkBox_Cecha_dowolna.Checked;
        }


        private void Pozar_Calosci()        
        {
            byte[,,] temp1 = image_PB1.Data;

            for(int y = 0; y <= desired_image_size.Height - 1; y++)
            {
                for(int x = 0; x <= desired_image_size.Width - 1; x++)
                {
                    if(Sprawdz_czy_cecha_palnosci(temp1[y,x,0], temp1[y, x, 1], temp1[y, x, 2]))
                    {
                        nr_pozaru++;                        
                        pix_tlace.Enqueue(new Point(x, y));
                        aktualny_kolor_wypalenia.V0 = kolor_wypalenia.V0 + 2 * nr_pozaru;
                        aktualny_kolor_wypalenia.V1 = kolor_wypalenia.V1 + 6 * nr_pozaru;
                        aktualny_kolor_wypalenia.V2 = kolor_wypalenia.V2 + 8 * nr_pozaru;
                        Cykl_Pozaru();

                        temp1 = image_PB1.Data;
                    }
                }
            }

            image_PB1.Data = temp1;
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void Cykl_Pozaru()
        {

            while(pix_tlace.Count > 0)
            {
                Krok_Pozaru();
            }
        }

        private void Krok_Pozaru()
        {
            //W języku C# wszystkie tablice są tzw typami referencyjnymi. Oznacza to, że w tym przypadku
            //do metody zostanie przekazana referencja, a nie skopiowana wartość czyli zmiany dokonane w metodzie
            //będą widoczne poza nią, a wydajność nie zostanie pogorszona nadmiarowymi operacjami kopiowania.
            byte[, ,] temp = image_PB1.Data;

            Tlace_do_palacych(temp);

            foreach (Point pix in pix_palace)
            {
                Tlenie_od_palacego(temp, pix);
            }

            foreach (Point pix in pix_palace)
            {
                Nadpalenie_palacego(temp, pix);
            }

            Wypalenie_palacego(temp);

            image_PB1.Data = temp;
            pictureBox1.Image = image_PB1.Bitmap;
            Wyswietl_dane_pozaru();
            //Dokańcza kolejkę oczekujących zdarzeń interfejsu graficznego. Dodatkowy opis w "button_Krok_pozaru_Click"
            Application.DoEvents();
        }

        //
        private void Tlace_do_palacych(byte[, ,] temp)
        {
            while (pix_tlace.Count > 0)
            {
                Point p = pix_tlace.Dequeue();
                pix_palace.Enqueue(p);
                temp[p.Y, p.X, 0] = (byte)kolor_palenia.V0;
                temp[p.Y, p.X, 1] = (byte)kolor_palenia.V1;
                temp[p.Y, p.X, 2] = (byte)kolor_palenia.V2;
            }
        }

        private void Tlenie_od_palacego(byte[, ,] temp, Point pix_in)
        {
            if (Czy_piksel_w_zakresie(pix_in))
            {
                Point[] sasiedzi = Wylicz_wspolrzedne_sasiednich_pikseli(pix_in);
                foreach (Point p in sasiedzi)
                {
                    if (Sprawdz_czy_cecha_palnosci(temp[p.Y, p.X, 0], temp[p.Y, p.X, 1], temp[p.Y, p.X, 2]))
                    {
                        pix_tlace.Enqueue(new Point(p.X, p.Y));
                        temp[p.Y, p.X, 0] = (byte)kolor_tlenia.V0;
                        temp[p.Y, p.X, 1] = (byte)kolor_tlenia.V1;
                        temp[p.Y, p.X, 2] = (byte)kolor_tlenia.V2;
                    }
                }
            }
        }

        private void Nadpalenie_palacego(byte[, ,] temp, Point pix_in)
        {
            //Należy zobaczyć co się stanie z rysunkiem innym niż *.bmp i/lub takim na którym została wywołana metoda
            //resize zarówno dla cechy dowolnej (jakiejkolwiek) jak i konkretnej
            //Należy zwrócic uwagę na nieoczekiwane zmiany kolorów na modyfikowanych lub kompresowanych obrazach
            if (Czy_piksel_w_zakresie(pix_in))
            {
                Point[] sasiedzi = Wylicz_wspolrzedne_sasiednich_pikseli(pix_in);
                bool nalezy_nadpalic = false;
                foreach (Point p in sasiedzi)
                {
                    if(cecha_dowolna)
                        nalezy_nadpalic = Sprawdz_czy_jakiekolwiek_nadpalenie(temp[p.Y, p.X, 0], temp[p.Y, p.X, 1], temp[p.Y, p.X, 2]);
                    else
                        nalezy_nadpalic = Sprawdz_czy_cecha_nadpalenia(temp[p.Y, p.X, 0], temp[p.Y, p.X, 1], temp[p.Y, p.X, 2]);
                    if (nalezy_nadpalic)
                    {
                        pix_nadpalone.Enqueue(new Point(p.X, p.Y));
                        temp[p.Y, p.X, 0] = (byte)kolor_nadpalenia.V0;
                        temp[p.Y, p.X, 1] = (byte)kolor_nadpalenia.V1;
                        temp[p.Y, p.X, 2] = (byte)kolor_nadpalenia.V2;
                    }
                }
            }
        }

        private void Wypalenie_palacego(byte[, ,] temp)
        {
            while (pix_palace.Count > 0)
            {
                Point p = pix_palace.Dequeue();
                pix_wypalone.Enqueue(p);
                temp[p.Y, p.X, 0] = (byte)(aktualny_kolor_wypalenia.V0);
                temp[p.Y, p.X, 1] = (byte)(aktualny_kolor_wypalenia.V1);
                temp[p.Y, p.X, 2] = (byte)(aktualny_kolor_wypalenia.V2);
            }
        }

        private Point[] Wylicz_wspolrzedne_sasiednich_pikseli(Point pix_in)
        {
            List<Point> sasiedzi = new List<Point>();
            sasiedzi.Add(new Point(pix_in.X - 1, pix_in.Y));
            sasiedzi.Add(new Point(pix_in.X + 1, pix_in.Y));
            sasiedzi.Add(new Point(pix_in.X, pix_in.Y - 1));
            sasiedzi.Add(new Point(pix_in.X, pix_in.Y + 1));

            if (skos)
            {
                sasiedzi.Add(new Point(pix_in.X - 1, pix_in.Y - 1));
                sasiedzi.Add(new Point(pix_in.X + 1, pix_in.Y + 1));
                sasiedzi.Add(new Point(pix_in.X - 1, pix_in.Y + 1));
                sasiedzi.Add(new Point(pix_in.X + 1, pix_in.Y - 1));
            }

            return sasiedzi.ToArray();
        }

        private bool Czy_piksel_w_zakresie(Point pix_in)
        {
            int max_W, max_H;
            max_W = desired_image_size.Width - 1;
            max_H = desired_image_size.Height - 1;
            if (pix_in.X > 0 && pix_in.X < max_W && pix_in.Y > 0 && pix_in.Y < max_H)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_cecha_palnosci(byte B, byte G, byte R)
        {
            if (B == cecha_palnosci.V0 && G == cecha_palnosci.V1 && R == cecha_palnosci.V2)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_cecha_nadpalenia(byte B, byte G, byte R)
        {
            if (B == cecha_nadpalenia.V0 && G == cecha_nadpalenia.V1 && R == cecha_nadpalenia.V2)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_jakiekolwiek_nadpalenie(byte B, byte G, byte R)
        {
            if (B == cecha_palnosci.V0 && G == cecha_palnosci.V1 && R == cecha_palnosci.V2)
                return false;
            else if (B == cecha_nadpalenia.V0 && G == cecha_nadpalenia.V1 && R == cecha_nadpalenia.V2)
                return true;
            else if (B == kolor_tlenia.V0 && G == kolor_tlenia.V1 && R == kolor_tlenia.V2)
                return false;
            else if (B == kolor_nadpalenia.V0 && G == kolor_nadpalenia.V1 && R == kolor_nadpalenia.V2)
                return false;
            else if (B == kolor_palenia.V0 && G == kolor_palenia.V1 && R == kolor_palenia.V2)
                return false;
            else if (B == aktualny_kolor_wypalenia.V0 && G == aktualny_kolor_wypalenia.V1 && R == aktualny_kolor_wypalenia.V2)
                return false;
            else
                return true;
        }

        private void button_Krok_pozaru_Click(object sender, EventArgs e)
        {
            //Za wzgledu na wykorzystanie metody Application.DoEvents(), ktora powoduje, że dokładnie w tym momencie
            //dokończone zostaną wszelkie oczekujące operacje dotyczące interfejsu graficznego 
            //(przerysowanie pictureboxa, zmiana tekstu w etykiecie, odskoczenie przycisku) należy zablokować mozliwość przedwczesnego
            //ponownego kliknięcia na przycisk np, za pomocą właściwości Enabled. 
            button_Krok_pozaru.Enabled = false;
            Krok_Pozaru();
            Wyswietl_dane_pozaru();
            button_Krok_pozaru.Enabled = true;
        }

        private void button_Cykl_pozaru_Click(object sender, EventArgs e)
        {
            button_Cykl_pozaru.Enabled = false;
            Cykl_Pozaru();
            Wyswietl_dane_pozaru();
            button_Cykl_pozaru.Enabled = true;
        }

        private void button_Pozar_calosci_Click(object sender, EventArgs e)
        {
            button_Pozar_calosci.Enabled = false;
            Wyczysc_dane_pozaru();
            Application.DoEvents();

            Pozar_Calosci();
            Wyswietl_dane_pozaru();

            numericUpDown_Numer_obiektu.Value = 1;
            if (nr_pozaru >= 1)
                numericUpDown_Numer_obiektu.Maximum = nr_pozaru;
            else
                numericUpDown_Numer_obiektu.Maximum = 1;

            button_Pozar_calosci.Enabled = true;
        }

        private void button_Rozpocznij_pozar_Click(object sender, EventArgs e)
        {
            int X, Y;
            byte[, ,] temp = image_PB1.Data;
            X = Convert.ToInt32(textBox_X.Text);
            Y = Convert.ToInt32(textBox_Y.Text);

            if (Sprawdz_czy_cecha_palnosci(temp[Y, X, 0], temp[Y, X, 1], temp[Y, X, 2]))
            {
                pix_tlace.Enqueue(new Point(X, Y));
                temp[Y, X, 0] = (byte)kolor_tlenia.V0;
                temp[Y, X, 1] = (byte)kolor_tlenia.V1;
                temp[Y, X, 2] = (byte)kolor_tlenia.V2;
            }

            Wyswietl_dane_pozaru();
            image_PB1.Data = temp;
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void Wyswietl_dane_pozaru()
        {
            label_Tlace.Text = "Liczba pikseli tlacych: " + pix_tlace.Count();
            label_Palace.Text = "Liczba pikseli palacych: " + pix_palace.Count();
            label_Nadpalone.Text = "Liczba pikseli nadpalonych: " + pix_nadpalone.Count();
            label_Wypalone.Text = "Liczba pikseli wypalonych: " + pix_wypalone.Count();
            label_Liczba_obiektow.Text = "Liczba obiektów: " + nr_pozaru;
        }

        private void button_Pokaz_obiekt_Click(object sender, EventArgs e)
        {
            Narysuj_wybrany_obiekt((int)numericUpDown_Numer_obiektu.Value);
        }

        private void Narysuj_wybrany_obiekt(int nr)
        {
            image_PB2.SetZero();
            byte[, ,] temp1 = image_PB1.Data;
            byte[, ,] temp2 = image_PB2.Data;

            MCvScalar kolor = new MCvScalar();
            kolor.V0 = kolor_wypalenia.V0 + 2 * nr;
            kolor.V1 = kolor_wypalenia.V1 + 6 * nr;
            kolor.V2 = kolor_wypalenia.V2 + 8 * nr;

            for (int y = 1; y < desired_image_size.Height - 2; y++)
            {
                for (int x = 1; x < desired_image_size.Width - 2; x++)
                {
                    if (temp1[y,x,0] == kolor.V0 && temp1[y,x,1] == kolor.V1 && temp1[y,x,2] == kolor.V2)
                    {
                        temp2[y, x, 0] = 0xFF;
                        temp2[y, x, 1] = 0xFF;
                        temp2[y, x, 2] = 0xFF;
                    }
                }
            }

            image_PB2.Data = temp2;
            pictureBox2.Image = image_PB2.Bitmap;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                CvInvoke.Circle(image_PB1, e.Location, 20, new MCvScalar(255, 255, 255), -1);
                pictureBox1.Image = image_PB1.Bitmap;
            }
        }

        private void button_Czysc_Click(object sender, EventArgs e)
        {
            image_PB1.SetZero();
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_Image_Path_PB1_TextChanged(object sender, EventArgs e)
        {

        }

        //Mechanika
        private void button_Mechanika_Click(object sender, EventArgs e)
        {
            listView_Dane_Mechanika.Items.Clear();
            image_PB3.Data = image_PB2.Data;

            //Reczne liczenie
            double F, Sx, Sy, x0, y0;
            double Jx0, Jy0, Jx0y0, Jx, Jy, Jxy, Je_0, Jt_0;
            double alfa_e, alfa_t, alfa_e_deg, alfa_t_deg;
            F = Sx = Sy = Jx0 = Jy0 = Jx0y0 = Jx = Jy = Jxy = Je_0 = Jt_0 = alfa_e = alfa_t = alfa_e_deg = alfa_t_deg = x0 = y0 = 0;

            //Odciecie ewentualnego stykania sie z krawedzia obrazu
            CvInvoke.Rectangle(image_PB3, new Rectangle(0, 0, desired_image_size.Width, desired_image_size.Height), new MCvScalar(0, 0, 0), 2);
            pictureBox3.Image = image_PB3.Bitmap;
            Application.DoEvents();

            //Wyliczenie momentow 1 i 2 stopnia
            byte[, ,] temp = image_PB3.Data;
            for (int X = 0; X < desired_image_size.Width; X++)
            {
                for (int Y = 0; Y < desired_image_size.Height; Y++)
                {
                    if (temp[Y, X, 0] == 0xFF && temp[Y, X, 1] == 0xFF && temp[Y, X, 2] == 0xFF)
                    {
                        F = F + 1;
                        Sx = Sx + Y;
                        Sy = Sy + X;
                        Jx = Jx + Math.Pow(Y, 2);
                        Jy = Jy + Math.Pow(X, 2);
                        Jxy = Jxy + X * Y;
                    }
                }
            }
            //Obliczenie środka cieżkości
            if (F > 0)
            {
                x0 = Sy / F;
                y0 = Sx / F;
            }
            //Obliczenie momentów centralnych
            Jx0 = Jx - F * Math.Pow(y0, 2);
            Jy0 = Jy - F * Math.Pow(x0, 2);
            Jx0y0 = Jxy - F * x0 * y0;

            Je_0 = (Jx0 + Jy0) / 2 + Math.Sqrt(0.25 * Math.Pow(Jy0 - Jx0, 2) + Math.Pow(Jx0y0, 2));
            Jt_0 = (Jx0 + Jy0) / 2 - Math.Sqrt(0.25 * Math.Pow(Jy0 - Jx0, 2) + Math.Pow(Jx0y0, 2));

            if (Jy0 != Je_0)
                alfa_e = Math.Atan(Jx0y0 / (Jy0 - Je_0));
            else
                alfa_e = Math.PI / 2;

            if (Jy0 != Jt_0)
                alfa_t = Math.Atan(Jx0y0 / (Jy0 - Jt_0));
            else
                alfa_t = Math.PI / 2;


            //Przykład wykorzystania biblioteki Emgu
            //Image<Gray, byte> image_mech = image_PB3.Convert<Gray, byte>();
            //MCvMoments m = CvInvoke.Moments(image_mech, true);
            //
            //Point srodek_ciezkosci = new Point();
            //srodek_ciezkosci.X = (int)(m.M10 / m.M00);
            //srodek_ciezkosci.Y = (int)(m.M01 / m.M00);
            //
            //double moment20 = CvInvoke.cvGetCentralMoment(ref m, 2, 0);
            //double moment02 = CvInvoke.cvGetCentralMoment(ref m, 0, 2);
            //double moment11 = CvInvoke.cvGetCentralMoment(ref m, 1, 1);
            //double tang2alfa;
            //double katObrotuUkladu;
            //
            //tang2alfa = 2 * moment11 / (moment02 - moment20);
            //katObrotuUkladu = Math.Atan(tang2alfa);
            //katObrotuUkladu = katObrotuUkladu / 2;
            //katObrotuUkladu = (Math.PI / 2) - katObrotuUkladu;
            //
            //double[] wektor_czerw = new double[2];
            //double[] wektor_nieb = new double[2];
            //wektor_czerw[0] = Math.Cos(katObrotuUkladu);
            //wektor_czerw[1] = Math.Sin(katObrotuUkladu);
            //
            //wektor_nieb[0] = Math.Cos(katObrotuUkladu - Math.PI / 2);
            //wektor_nieb[1] = Math.Sin(katObrotuUkladu - Math.PI / 2);

            double[] wektor_czerw = new double[2];
            double[] wektor_nieb = new double[2];

            wektor_czerw[0] = Math.Cos(alfa_e);
            wektor_czerw[1] = Math.Sin(alfa_e);

            wektor_nieb[0] = Math.Cos(alfa_t);
            wektor_nieb[1] = Math.Sin(alfa_t);

            System.Console.Write(alfa_e);
            System.Console.Write(alfa_t);

            //Rysowanie punktów przeciecia
            Point P1, P2, P3, P4, Pc;
            P1 = new Point();
            P2 = new Point();
            P3 = new Point();
            P4 = new Point();
            Pc = new Point((int)x0, (int)y0);
            bool czarny = false;
            int i, zakres;
            zakres = 320;
            i = 0;
            while (czarny == false && i > -zakres && i < zakres)
            {
                int X = (int)(Pc.X + i * wektor_czerw[0]);
                int Y = (int)(Pc.Y + i * wektor_czerw[1]);
                if(temp[Y, X, 0] == 0)
                {
                    P1.X = X;
                    P1.Y = Y;
                    CvInvoke.Circle(image_PB3, P1, 6, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.PutText(image_PB3, "P1", P1, Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 2);
                    czarny = true;
                }
                i++;
            }

            czarny = false;
            i = 0;

            while (czarny == false && i > -zakres && i < zakres)
            {
                int X = (int)(Pc.X + i * wektor_czerw[0]);
                int Y = (int)(Pc.Y + i * wektor_czerw[1]);
                if (temp[Y, X, 0] == 0)
                {
                    P2.X = X;
                    P2.Y = Y;
                    CvInvoke.Circle(image_PB3, P2, 6, new MCvScalar(0, 255, 255), 2);
                    CvInvoke.PutText(image_PB3, "P2", P2, Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 2);
                    czarny = true;
                }
                i--;
            }

            czarny = false;
            i = 0;

            while (czarny == false && i > -zakres && i < zakres)
            {
                int X = (int)(Pc.X + i * wektor_nieb[0]);
                int Y = (int)(Pc.Y + i * wektor_nieb[1]);
                if (temp[Y, X, 0] == 0)
                {
                    P3.X = X;
                    P3.Y = Y;
                    CvInvoke.Circle(image_PB3, P3, 6, new MCvScalar(0, 255, 0), 2);
                    CvInvoke.PutText(image_PB3, "P3", P3, Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 2);
                    czarny = true;
                }
                i++;
            }

            czarny = false;
            i = 0;

            while (czarny == false && i > -zakres && i < zakres)
            {
                int X = (int)(Pc.X + i * wektor_nieb[0]);
                int Y = (int)(Pc.Y + i * wektor_nieb[1]);
                if (temp[Y, X, 0] == 0)
                {
                    P4.X = X;
                    P4.Y = Y;
                    CvInvoke.Circle(image_PB3, P4, 6, new MCvScalar(255, 255, 0), 2);
                    CvInvoke.PutText(image_PB3, "P4", P4, Emgu.CV.CvEnum.FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 2);
                    czarny = true;
                }
                i--;
            }


            //Dokończyć

            //Długość
            double d1, d2, dlugosc;
            d1 = d2 = dlugosc = 0;

            d1 = Math.Sqrt(Math.Pow(Math.Abs(P1.X - P2.X), 2) + Math.Pow(Math.Abs(P1.Y - P2.Y), 2));
            d2 = Math.Sqrt(Math.Pow(Math.Abs(P3.X - P4.X), 2) + Math.Pow(Math.Abs(P3.Y - P4.Y), 2));



            if (d1 >= d2)
                dlugosc = d1;
            else
                dlugosc = d2;



            //Dokończyć
            CvInvoke.Circle(image_PB3, Pc, 6, new MCvScalar(255, 0, 0), 2);

            CvInvoke.Line(image_PB3, Pc, new Point((int)(Pc.X + 120), (int)(Pc.Y)), new MCvScalar(0, 255, 0), 2);
            CvInvoke.Line(image_PB3, Pc, new Point((int)(Pc.X + 100 * wektor_czerw[0]), (int)(Pc.Y + 100 * wektor_czerw[1])), new MCvScalar(0, 0, 255), 2);
            CvInvoke.Line(image_PB3, Pc, new Point((int)(Pc.X + 100 * wektor_nieb[0]), (int)(Pc.Y + 100 * wektor_nieb[1])), new MCvScalar(255, 0, 0), 2);

            image_PB3.Data = temp;
            pictureBox3.Image = image_PB3.Bitmap;


            listView_Dane_Mechanika.Items.Add("Powierzchnia: " + F.ToString());
            listView_Dane_Mechanika.Items.Add("Srodek ciezkosci: " + Pc.ToString());
            listView_Dane_Mechanika.Items.Add("Dlugosc: " + dlugosc.ToString());
            alfa_e_deg = alfa_e * (180.0 / Math.PI);
            alfa_t_deg = alfa_t * (180.0 / Math.PI);
            listView_Dane_Mechanika.Items.Add("Kat nachyl. czerwony: " + alfa_e_deg.ToString());
            listView_Dane_Mechanika.Items.Add("Kat nachyl. niebieski: " + alfa_t_deg.ToString());
            //Dokończyć

        }

        private void button_Obrysuj_Click(object sender, EventArgs e)
        {

            //Dokończyć
        }
    }
}
