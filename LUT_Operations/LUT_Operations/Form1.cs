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

namespace Kolor
{
    public partial class Form1 : Form
    {
        //UWAGA! Zadanie - zapoznać się z konstrukcją programu. Posprarawdzać które kontrolki
        //jak są nazwane i jakie procedury obsługi zdarzeń są dla nich powołane. Zadanie polega
        //na uzupełnianiu dostarczonych fragmentów. Zmienne globalne przechowujące dane obrazu są już
        //zadeklarowane i stworzone jako globalne.

        //WAŻNE
        //W przypadku problemów i niejasności należy odwoływać się do internetowej
        //pomocy w postaci dokumentacji C# (msdn), dokumentacji EmguCV oraz stron takich
        //jak stackOverflow
        //VisualStudio zamiera narzędzie podpowiadające przy pisaniu kodu. Narzedzie to
        //nazywa się intelisense i jeśli jego okno (rozwijana lista możliwych zakończeń
        //aktualnie pisanego tekstu) nie pojawia się lub znikła to skrót: CTRL + SPACE je wywoła
        //Nieco innym narzędziem są podpowiedzi co do argumentów aktualnie pisanego wywołania metody.
        //Wyskoczy wtedy okno, które poinformuje o oczekiwanych typach i kolejności przekazywanych
        //argumentów. Jak to okno zniknie to CTRL + SPACE może go już nie wywołać. Do jego
        //ponownego wyświetlenie należy wtedy np skasować i ponownie wpisać jakiś element
        //wpisanego tekstu np znak "(". Nie chodzi o kasowanie wszystkiego tylko o to by ponownie
        //zaistniały warunki jak przy pierwszym wyskoczeniu okna.
        //wtedy okno ponownie się pojawi

        //Koońcówka PB1 i PB2 odnoszą sie do nazw
        //pictureBox1 i pictureBox2
        //Deklaracja zmiennych przechowujących obrazy
        //Zmienne jedynie zadeklarowane muszą zostać jeszcze utworzone
        Image<Bgr, byte> obraz_PB1, obraz_PB2, wykres_PB1, wykres_PB2, lut_image_var;

        //Typ videocapture służyć nam będzie do łączenia się z kamerą
        VideoCapture kamera;

        Boolean Movie;

        enum Operations { tozsamosc, negatyw, jasnosc, progowanie1, progowanie2, kontrast}
        enum Zoom { IN, OUT };
        enum Quarter { First, Second, Third, Fourth}

        Operations operacja;

        Zoom zoom;
        Boolean zoom_enabled;

        Quarter quarter;

        byte[] LUT= new byte[256];

        //Tzw. konstruktor. Odpowiada za zainicjalizowanie całego okienka programu
        public Form1()
        {
            InitializeComponent();
            //Tworzenie obiektów.
            obraz_PB1 = new Image<Bgr, byte>(left_image.Size);
            obraz_PB2 = new Image<Bgr, byte>(right_image.Size);
            lut_image_var = new Image<Bgr, byte>(lut_image.Size);
            wykres_PB1 = new Image<Bgr, byte>(color_components_left_graph.Size);
            wykres_PB2 = new Image<Bgr, byte>(color_components_right_graph.Size);
            Movie = false;
            operacja = Operations.tozsamosc;
            tozsamosc_radioButton.Checked = true;
            zoom = Zoom.IN;
            zoom_enabled = false;
            left_image_x_text_box.Text = "0";
            left_image_y_text_box.Text = "0";
            right_image_x_text_box.Text = "0";
            right_image_y_text_box.Text = "0";
            prog1_text_box.Text = "0";
            prog2_text_box.Text = "0";
            //Blok try - catch. Jak nie ma kamery to próba stworzenia obiektu VideoCapture może
            //być nieudana. Z tego względu zastosujemy blok try catch, który w przypadku niepowodzenia
            //tej operacji przechwyci i wyświtli komunikat błędu, a program nie zakończy się nagle błędem
            //Blok try - catch jest elementem języka C# i nie pochodzi od EmguCV
            try
            {
                //Domyślnie połączy się z pierwszym urządzeniem video na liście urządzeń
                kamera = new VideoCapture();
                //Ustawienia wysokości i szerokości obrazu
                kamera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 320);
                kamera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 240);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Dyrektywa #region i kończoca jąa ddyrektywa #endregion służą do zwijania kawałków kodu
        //w edytorze. Dyrektywy te w żaden sposób nie wpływają na kompilacje i działanie programu.
        //NAleży jedynie pamiętać o tym by każdy #region miał do pary kończącego go #endregion
        #region Sekcja 1: Wczytywanie i czyszczenie obrazów

        private void image_left_button_Click(object sender, EventArgs e)
        {
            //Obrazek tworzony za pomocą metod z Emgu cv
            //CvInvoke.Rectangle - rysuje prostokąt wypełnioony lub tylko jego boki
            //new Rectangle(20, 20, 50, 50) - powołuje nowy obiekt typu Rectangle (nie CvInvoke.Rectangle tylko zwykłe Rectagle)
            //new MCvScalar(255, 200, 140)  - typ ten pochodzi z biblioteki Emgu i w tym przypadku
            //służy do utworzenia koloru - kolejne argumenty odpowiadają kolejnym składowym
            //Parametr thickness (tutaj równy -1) odpowiada grubości ramki jeśli dodatni. ujemny powoduje zamalowanie wnętrza
            CvInvoke.Rectangle(obraz_PB1, new Rectangle(20, 20, 50, 50), new MCvScalar(255, 200, 140), -1);
            //Analogicznie działają metody CvInvoke.Circle oraz CvInvoke.Line

            //UWAGA! Zadanie: Dopisać jeszcze jeden prostokąt (o innych wymiarach i kolorze niż obecny)
            //oraz dodać kółko i linie
            CvInvoke.Rectangle(obraz_PB1, new Rectangle(250, 20, 50, 50), new MCvScalar(200, 140, 255), -1);
            CvInvoke.Circle(obraz_PB1, new Point(160, 120), 30, new MCvScalar(100, 150, 200), -1);
            CvInvoke.Line(obraz_PB1, new Point(50,200), new Point(270, 200), new MCvScalar(200, 150, 100), 4);
            //Wyświetlanie obrazu na pictureBoxie
            //PictureBox trzyma obrazy jako bitmapy co jest wspierane przez typ Image. 
            //Właściwość Bitmap jest odczytywana jak po nazwie zmiennej typu Image wpiszemy
            //kropkę i następnie wpiszemy bądź wybierzemy z pomosy Intelisense frazę "Bitmap"
            left_image.Image = obraz_PB1.Bitmap;


        }

        private void from_file_left_button_Click(object sender, EventArgs e)
        {
            //EmguCV posiada dwa różne typy zdolne do przechowywania obrazu. Poza Image<>
            //istnieje nowszy typ - Mat. Mat w przeciwieństwie do Image współpracuje z wieloma
            //bardziej zaawansowanymi metodami biblioteki, natomiast dostęp do pojedynczych 
            //pikseli jest w nim utrudniony. Ze względu na to utrudnienie korzystamy z typu Image<>.

            //Możliwe jest jednak wywołanie danej metody z wykorzystaniem typu Mat, a następnie
            //przetransformowania jego danych do typu Image<>, co daje nam pełny wachlaż możliwości
            //Jedną z takich metod jest metoda do odczytywania obrazka z pliku czyli Imread;
            //Dlatego też posłużymy się pomocniczą zmienną typu Mat
            Mat temp = new Mat();
            temp = CvInvoke.Imread("./example.jpeg");
            //Obrazek moze mieć inny rozmiar od rozmiaru pictureboxa, dlatego dokonamy jego skalowania
            CvInvoke.Resize(temp, temp, left_image.Size);
            //Przypisawanie danych z Mat do Image<>
            obraz_PB1 = temp.ToImage<Bgr, byte>();

            //UWAGA! Zadanie: Na podstawie przycisku tworzącego grafikę, wyświetlić dane z obraz_PB1 na pictureboxie
            left_image.Image = obraz_PB1.Bitmap;
        }

        private void camera_left_button_Click(object sender, EventArgs e)
        {
            //Tutaj konstrukcja tworzenia obiektu "= new Mat();" Została pominięta, gdyż w przypadku
            //kiedy jakaś metoda (w tym przypadku jest to QueryFrame - metoda odczytująca klatkę 
            //obrazu z kamery) zwraca interesujący nas typ danych to oznacza to, że wewnętrznie został
            //on stworzony. Jak został stworzony to może być przypisany bez konieczności słowa "new"
            Mat temp = kamera.QueryFrame();
            CvInvoke.Resize(temp, temp, left_image.Size);

            //UWAGA! Zadanie: Dopisać kopiowanie danych z mat do image i wyświetlić na
            //pictureboxie

            obraz_PB1 = temp.ToImage<Bgr, byte>();
            left_image.Image = obraz_PB1.Bitmap;
        }

        private void image_right_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie Zaimplementować rysowanie grafiki dla pictureboxa2 analogicznie
            //do pictureboxa1

            CvInvoke.Rectangle(obraz_PB2, new Rectangle(20, 20, 50, 50), new MCvScalar(255, 200, 140), -1);
            CvInvoke.Rectangle(obraz_PB2, new Rectangle(250, 20, 50, 50), new MCvScalar(255, 200, 140), -1);
            CvInvoke.Circle(obraz_PB2, new Point(160, 120), 30, new MCvScalar(200, 150, 100), -1);
            CvInvoke.Line(obraz_PB2, new Point(50, 200), new Point(270, 200), new MCvScalar(100, 150, 200), 4);
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void from_file_right_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie Zaimplementować wczytywanie obrazu z pliku dla pictureboxa2 analogicznie
            //do pictureboxa1
            Mat temp = new Mat();
            temp = CvInvoke.Imread("./example.jpeg");
            CvInvoke.Resize(temp, temp, right_image.Size);
            obraz_PB2 = temp.ToImage<Bgr, byte>();
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void camera_right_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie Zaimplementować wczytywanie obrazu z kamery dla pictureboxa2 analogicznie
            //do pictureboxa1
            Mat temp = kamera.QueryFrame();
            CvInvoke.Resize(temp, temp, right_image.Size);
            obraz_PB2 = temp.ToImage<Bgr, byte>();
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void clear_left_image_button_Click(object sender, EventArgs e)
        {
            //Metoda SetZero ustawia wartość 0 w całym obrazie. Odpowiada to kolorowi czarnemu
            //i jest równoznaczne z wyczyszczeniem go
            obraz_PB1.SetZero();
            left_image.Image = obraz_PB2.Bitmap;
        }

        private void clear_right_image_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie - zaimplementować czyszczenia dla obrazka 2
            obraz_PB2.SetZero();
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Sekcja 2 Selektywne kopiowanie składowych koloru + operacja mono

        private void left_image_Click(object sender, EventArgs e)
        {
            //Każda metoda obsługi zdażenia wywołuje się z dwoma argumantami.
            //Pierwszy: "object sender" jest to odwołanie do obiektu, który zgłosił dane zdażenie.
            //Drugi: "EventArgs e" jest to instancja klasy służącej do przekazania w zapakowany
            //sposób zbioru parametrów z jakimi dane zdażenie zostało wywołane.
            //Pierwsszy argument nie będzie teraz wykorzystywany, natomiast współrzędne kliknięcia
            //zostaną pobrane z drugiego.

            //Poniewarz jest to zdarzenie "Click" to w argumencie będą współrzędne kliknięcia
            //Aby się do nich dostać należy potraktować typ EventArgs tak jakby był typem
            //MouseEventArgs - typ ten już ma te współrzędne.
            //WAŻNE! To nie jest "całkowicie nowy obiekt" to jest tylko odwoływanie się do
            //istniejącego obiektu TAK JAKBY był innym typem. Podejście takie zadziała tak długo, jak
            //dany typ będzie wewnętrznie zgodny z tym drugim.
            MouseEventArgs me = e as MouseEventArgs;

            left_image_x_text_box.Text = me.X.ToString();

            //UWAGA! Zadanie - uzupełnić dla "Y"
            left_image_y_text_box.Text = me.Y.ToString();

            //Listing koloru
            //Typ Image<Bgr, byte> przechowuje wewnętrznie dane obrazu jako tablice trójwymiarową
            //typu byte. Dostęp do tej tablicy znajduje się pod właściwością "Data"
            //Aby odwoływanie się było wygodiejsze to zastosujemy zmienno lokalną pomocniczą
            //typu byte[,,] do której przypiszemy właściwość "Data"
            byte[,,] temp1 = obraz_PB1.Data;

            //KOLEJNOŚC indeksów:
            //temp1[Y, X, kanał koloru]: 0 - kanał niebieski, 1 - zielony, 2 - czerwony

            //Wyświetliwy wartości składowe
            //Jak w metodzie ToString przekażemy parametr "X" to liczba zostanie zamieniona na tekst
            //sformatowany szesnastkowo np FF zamiast 255
            //Formatowanie to nie doda natomiast wygodnego dla użytkownika przedrostka "0x", który
            //informuje uytkownika, że ma do czynienia z tekstem szesnastkowym
            blue_textbox_left.Text = "0x" + temp1[me.Y, me.X, 0].ToString("X");
            green_textbox_left.Text = "0x" + temp1[me.Y, me.X, 1].ToString("X");
            red_textbox_left.Text = "0x" + temp1[me.Y, me.X, 2].ToString("X");
            //UWAGA! Zadanie - uzupełnić dla pozostałych składowych
            //UWAGA! Zadanie - sprawdzić poprawność przypysania liczb do textboxów testując program w działaniu

            if(zoom_enabled)
            {
                if(me.X <= 160 && me.Y <= 120)
                {
                    quarter = Quarter.Second;
                }
                else if(me.X > 160 && me.Y <= 120)
                {
                    quarter = Quarter.First;
                }
                else if (me.X <= 160 && me.Y > 120)
                {
                    quarter = Quarter.Third;
                }
                else if (me.X > 160 && me.Y > 120)
                {
                    quarter = Quarter.Fourth;
                }

                performZoom();
            }
        }

        private void right_image_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            right_image_x_text_box.Text = me.X.ToString();
            right_image_y_text_box.Text = me.Y.ToString();
            byte[,,] temp1 = obraz_PB1.Data;
            blue_textBox_right.Text = "0x" + temp1[me.Y, me.X, 0].ToString("X");
            green_textBox_right.Text = "0x" + temp1[me.Y, me.X, 1].ToString("X");
            red_textBox_right.Text = "0x" + temp1[me.Y, me.X, 2].ToString("X");
        }

        //UWAGA! Zadanie Skopiować textboxy od współrzędnych kliknięcia i listingu koloru,
        //Powołać obsługę zdażenia Click dla picturebboxa2 i powtórzyć funkcjonalność z picturebox1

        private void left2right_copy_button_Click(object sender, EventArgs e)
        {
            //Wykorzystamy maski i operacje logiczną AND.
            //Jeśli maska jest równa 0 to operacja AND między nią a dowolną liczbą zwróci 0
            //Jeśli maska jest równa 255 (0xFF, 0b11111111) to AND między nią a dowolną liczbą typu bajt, zachowa wartość tego bajtu
            byte maska_B, maska_G, maska_R;
            maska_B = maska_G = maska_R = 0;

            if (blue_checkbox.Checked) maska_B = 0xFF;
            if (green_checkbox.Checked) maska_G = 0xFF;
            if (red_checkbox.Checked) maska_R = 0xFF;

            byte[,,] temp1 = obraz_PB1.Data;
            byte[,,] temp2 = obraz_PB2.Data;

            for (int x = 0; x < left_image.Width; x++)
            {
                for (int y = 0; y < left_image.Height; y++)
                {
                    temp2[y, x, 0] = (byte)(temp1[y, x, 0] & maska_B);
                    temp2[y, x, 1] = (byte)(temp1[y, x, 1] & maska_G);
                    temp2[y, x, 2] = (byte)(temp1[y, x, 2] & maska_R);

                    //UWAGA! zadanie - dokończyć zapis dla pozostałych kanałów koloru
                }
            }

            obraz_PB2.Data = temp2;
            right_image.Image = obraz_PB2.Bitmap;
            //UWAGA! zadanie - poprawnie wyświetlić dane na pictureboxie2
        }

        private void right2left_copy_button_Click(object sender, EventArgs e)
        {
            //Uwaga zadanie - zaimplementować operację kopiowanie wybranych kanałów koloru z prawej na lewą
            byte maska_B, maska_G, maska_R;
            maska_B = maska_G = maska_R = 0;

            if (blue_checkbox.Checked) maska_B = 0xFF;
            if (green_checkbox.Checked) maska_G = 0xFF;
            if (red_checkbox.Checked) maska_R = 0xFF;

            byte[,,] temp1 = obraz_PB1.Data;
            byte[,,] temp2 = obraz_PB2.Data;

            for (int x = 0; x < left_image.Width; x++)
            {
                for (int y = 0; y < left_image.Height; y++)
                {
                    temp1[y, x, 0] = (byte)(temp2[y, x, 0] & maska_B);
                    temp1[y, x, 1] = (byte)(temp2[y, x, 1] & maska_G);
                    temp1[y, x, 2] = (byte)(temp2[y, x, 2] & maska_R);

                    //UWAGA! zadanie - dokończyć zapis dla pozostałych kanałów koloru
                }
            }

            obraz_PB1.Data = temp1;
            left_image.Image = obraz_PB1.Bitmap;
        }

        private void mono_copy_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie - zaimplementować operację kopiowanie obrazka kolorowego z picturbox1 na picturebox2
            //po drodze przzetwarzając go na obraz w skali szarości
            //Dla pikselu kolorowego w przestrzeni Bgr jego odpowiednik w skali szarości to piksel o takich samych
            //wartościach składowych koloru i równych średniej arytmetycznej skłądowych koloru piksela wejściowego.
            //(Dla każdego piksela osobno): mono = (R + G + B) / 3;
            //Maski nie będą potrzebne
            int mono;
            byte[,,] temp1 = obraz_PB1.Data;
            byte[,,] temp2 = obraz_PB2.Data;

            for (int x = 0; x < left_image.Width; x++)
            {
                for (int y = 0; y < left_image.Height; y++)
                {
                    mono = ((int)temp1[y, x, 0] + (int)temp1[y, x, 1] + (int)temp1[y, x, 2]) / 3;
                    temp2[y, x, 0] = (byte)mono;
                    temp2[y, x, 1] = (byte)mono;
                    temp2[y, x, 2] = (byte)mono;

                    //UWAGA! zadanie - dokończyć zapis dla pozostałych kanałów koloru
                }
            }

            obraz_PB2.Data = temp2;
            right_image.Image = obraz_PB2.Bitmap;
        }

        #endregion

        #region Sekcja 3 - Wykresy linii

        private void line_graph_left_image_button_Click(object sender, EventArgs e)
        {
            //Wykres linii obrazu. Celem działania jest predstawienie pojedyncxzego wiersza obrazu
            //w postaci trzech wykresów rysowanych razem, na jednym pictureboxie.
            //Dzięki temu otrzymamy wykresy zmienności składowych koloru w danym wierszu
            //Współrzędna Y określająca analizowany wiersz powinna pochodzić z okienka textBox_Y
            //Wartość każdej składowej piksela obrazu wejściowego będzie zatem współrzędną Y na 
            //odpowiadającym jej wykresie.

            //Ponieważ zakres pojedynczej składowe (głębia koloru) to bajt czyli 0 - 255, a wysokość
            //pictureboxa z wykresem jest inna to musimy odczytane wartości składowe przeskalować do
            //nowego zakresu. Dodatkowo punkt (0, 0) odpowiada lewemu górnemu rogowi pixtureboxa i 
            //wrtości współrzędnej Y narastają w dół to musimy odwrócić współrzędną Y

            wykres_PB1.SetZero();
            byte[,,] temp_obraz = obraz_PB1.Data;
            byte[,,] temp_wykres = wykres_PB1.Data;

            int wybrana_linia = int.Parse(left_image_y_text_box.Text); //UWAGA! Zadanie - odczytać liczzbę z textboxa_Y
            int wys_wykresu = color_components_left_graph.Height - 1; //"-1" aby nie przekraczać indeksów tablicy
            double scale = wys_wykresu / 255.0;

            byte B, G, R;

            for (int x = 0; x < left_image.Width; x++)
            {
                B = temp_obraz[wybrana_linia, x, 0];
                G = temp_obraz[wybrana_linia, x, 1];
                R = temp_obraz[wybrana_linia, x, 2];

                //UWAGA! Zadanie - dokończyć implementację pętli. Dokonać skalowania i odwrócenia
                //wartości odczytanych i namalować je na wykresie
                B = (byte)(wys_wykresu - (int)B * scale);
                G = (byte)(wys_wykresu - (int)G * scale);
                R = (byte)(wys_wykresu - (int)R * scale);
                //Składowa = (byte)(wysokosc - Składowa * współczynnik_skalujący)

                temp_wykres[B, x, 0] = 0xFF;
                temp_wykres[G, x, 1] = 0xFF;
                temp_wykres[R, x, 2] = 0xFF;
                //temp_wykres[przeskalowana_i_odwrocona_skladowa, x, kanal_danej_skladowej] = 0xFF;

            }
            wykres_PB1.Data = temp_wykres;
            color_components_left_graph.Image = wykres_PB1.Bitmap;
            //UWAGA! Zadanie - wyświetlić dane na wykresie
        }

        private void line_graph_right_image_button_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie - Analogicznie do linii dla obrazka 1 powtórzyć operację dla obrazka2.
            //UWAGA - współrzędną Y określającą wybraną linię pobrać z dokładnie tego samego miejsca
            //co dla obrazka 1

            wykres_PB2.SetZero();
            byte[,,] temp_obraz = obraz_PB2.Data;
            byte[,,] temp_wykres = wykres_PB2.Data;

            int wybrana_linia = int.Parse(right_image_y_text_box.Text); //UWAGA! Zadanie - odczytać liczzbę z textboxa_Y
            int wys_wykresu = color_components_right_graph.Height - 1; //"-1" aby nie przekraczać indeksów tablicy
            double scale = wys_wykresu / 255.0;

            byte B, G, R;

            for (int x = 0; x < left_image.Width; x++)
            {
                B = temp_obraz[wybrana_linia, x, 0];
                G = temp_obraz[wybrana_linia, x, 1];
                R = temp_obraz[wybrana_linia, x, 2];

                //UWAGA! Zadanie - dokończyć implementację pętli. Dokonać skalowania i odwrócenia
                //wartości odczytanych i namalować je na wykresie
                B = (byte)(wys_wykresu - (int)B * scale);
                G = (byte)(wys_wykresu - (int)G * scale);
                R = (byte)(wys_wykresu - (int)R * scale);
                //Składowa = (byte)(wysokosc - Składowa * współczynnik_skalujący)

                temp_wykres[B, x, 0] = 0xFF;
                temp_wykres[G, x, 1] = 0xFF;
                temp_wykres[R, x, 2] = 0xFF;
                //temp_wykres[przeskalowana_i_odwrocona_skladowa, x, kanal_danej_skladowej] = 0xFF;

            }
            wykres_PB2.Data = temp_wykres;
            color_components_right_graph.Image = wykres_PB2.Bitmap;
        }

        

        private void button_Simple_Movie_Click(object sender, EventArgs e)
        {
            //UWAGA! Zadanie końcowe. Wykonać dopiero wtedy gdy Sekcje od 1 do 3 są gotowe.
            //1) Dodać timer, ustawić interwał na 50ms, powołać zdażenie tick
            //2) dodać globalną zmienną typu bool, która będzie przełączana na true jeśli jest false
            //lub na false jeśli jest true, każdorazowo po każdym wciśnięciu tego przycisku.
            //3) Po przestawieniu wartości, także w tym przycisku w zależności od tego czy aktualnie
            //jzmienna bool jest true lub false to wywoływać na timerze metody Start i Stop
            //4) W obsłudze zdażenia Tick dodać kod odbierający obraz z kamery i wyrysować dla niego wykres
            //5) W tym celu należy implementację wykreślania linii skopiować do osobnej (własnoręcznie stworzonej) metody
            //która będzie wywoływana albo z przycisku albo z timera. Dzięki temu nie będzie nadmiernego kopiowania raz stworzonego kodu

            Movie = !Movie;
            if (Movie)
            {
                timer1.Start();
                left_image_x_text_box.Text = "0";
                left_image_y_text_box.Text = "0";
            } else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mat temp = kamera.QueryFrame();
            CvInvoke.Resize(temp, temp, left_image.Size);
            obraz_PB1 = temp.ToImage<Bgr, byte>();
            left_image.Image = obraz_PB1.Bitmap;
            rysujeLinie();
        }

        private void rysujeLinie()
        {
            wykres_PB1.SetZero();
            byte[,,] temp_obraz = obraz_PB1.Data;
            byte[,,] temp_wykres = wykres_PB1.Data;

            int wybrana_linia = int.Parse(left_image_y_text_box.Text); //UWAGA! Zadanie - odczytać liczzbę z textboxa_Y
            int wys_wykresu = color_components_left_graph.Height - 1; //"-1" aby nie przekraczać indeksów tablicy
            double scale = wys_wykresu / 255.0;

            byte B, G, R;

            for (int x = 0; x < left_image.Width; x++)
            {
                B = temp_obraz[wybrana_linia, x, 0];
                G = temp_obraz[wybrana_linia, x, 1];
                R = temp_obraz[wybrana_linia, x, 2];
                B = (byte)(wys_wykresu - (int)B * scale);
                G = (byte)(wys_wykresu - (int)G * scale);
                R = (byte)(wys_wykresu - (int)R * scale);

                temp_wykres[B, x, 0] = 0xFF;
                temp_wykres[G, x, 1] = 0xFF;
                temp_wykres[R, x, 2] = 0xFF;

            }
            wykres_PB1.Data = temp_wykres;
            color_components_left_graph.Image = wykres_PB1.Bitmap;
        }
        #endregion 

        private void tozsamosc_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.tozsamosc);
        }

        private void negatyw_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.negatyw);
        }

        private void jasnosc_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.jasnosc);
        }

        private void progowanie1_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.progowanie1);
        }

        private void progowanie2_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.progowanie2);
        }

        private void Kontrast_CheckedChanged(object sender, EventArgs e)
        {
            changeOperation(Operations.kontrast);
        }

        private void changeOperation(Operations new_operation)
        {
            operacja = new_operation;
        }

        private void zoom_in_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeZoom(Zoom.IN);
        }

        private void zoom_out_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            changeZoom(Zoom.OUT);
        }

        private void changeZoom(Zoom new_zoom)
        {
            zoom = new_zoom;
        }

        private void lut_button_Click(object sender, EventArgs e)
        {
            generateLUT();
            performOperation();
            lutImage();
        }

        private void zoom_button_Click(object sender, EventArgs e)
        {
            zoom_enabled = !zoom_enabled;
            if (zoom_enabled)
            {
                zoom_enabled_radioButton.Checked = true;           
            } else
            {
                zoom_enabled_radioButton.Checked = false;
            }
        }

        private void generateLUT()
        {
            int prog1 = 0;
            if (operacja != Operations.kontrast)
            {
                prog1 = int.Parse(prog1_text_box.Text);
            }
            int prog2 = int.Parse(prog2_text_box.Text);

            switch (operacja)
            {
                case Operations.tozsamosc:
                    for(int i = 0; i <= 255; i++)
                    {
                        LUT[i] = (byte)i;
                    }
                    break;
                case Operations.negatyw:
                    for (int i = 0; i <= 255; i++)
                    {
                        LUT[i] = (byte)(255 - i);
                    }
                    break;
                case Operations.jasnosc:
                    for (int i = 0; i <= 255; i++)
                    {
                        if (i + prog1 >= 255)
                        {
                            LUT[i] = (byte)255;
                        }
                        else if (i + prog1  <= 0)
                        {
                            LUT[i] = (byte)0;
                        }
                        else
                        {
                            LUT[i] = (byte)(i + prog1);
                        }                      
                    }
                    break;
                case Operations.progowanie1:
                    for (int i = 0; i <= 255; i++)
                    {
                        if(i >= prog1)
                        {
                            LUT[i] = 255;
                        }
                        else
                        {
                            LUT[i] = 0;
                        }
                        
                    }
                    break;
                case Operations.progowanie2:
                    for (int i = 0; i <= 255; i++)
                    {
                        if (i >= prog1 && i <= prog2)
                        {
                            LUT[i] = 255;
                        }
                        else
                        {
                            LUT[i] = 0;
                        }

                    }
                    break;
                case Operations.kontrast:
                    for (int i = 0; i <= 255; i++)
                    {
                        double factor = Double.Parse(prog1_text_box.Text);
                        int wartosc = (int)(factor * (i - 128)) + 128;
                        if( wartosc <= 0)
                        {
                            LUT[i] = 0;
                        }
                        else if (wartosc >= 255)
                        {
                            LUT[i] = 255;
                        }
                        else
                        {
                            LUT[i] = (byte)wartosc;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void performOperation()
        {
            byte[,,] temp1 = obraz_PB1.Data;
            byte[,,] temp2 = obraz_PB2.Data;

            for (int x = 0; x < left_image.Width; x++)
            {
                for (int y = 0; y < left_image.Height; y++)
                {
                    temp2[y, x, 0] = LUT[(int)temp1[y, x, 0]];
                    temp2[y, x, 1] = LUT[(int)temp1[y, x, 1]];
                    temp2[y, x, 2] = LUT[(int)temp1[y, x, 2]];

                    //UWAGA! zadanie - dokończyć zapis dla pozostałych kanałów koloru
                }
            }

            obraz_PB2.Data = temp2;
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void performZoom()
        {
            byte[,,] temp1 = obraz_PB1.Data;
            byte[,,] temp2 = obraz_PB2.Data;

            int x_offset = 0;
            int y_offset = 0;
            switch (quarter)
            {
                case Quarter.First:
                    x_offset = 160;
                    y_offset = 0;
                    break;
                case Quarter.Second:
                    x_offset = 0;
                    y_offset = 0;
                    break;
                case Quarter.Third:
                    x_offset = 0;
                    y_offset = 120;
                    break;
                case Quarter.Fourth:
                    x_offset = 160;
                    y_offset = 120;
                    break;
                default:
                    break;
            }
            switch (zoom)
            {
                case Zoom.IN:
                    for (int x = 0; x < 160; x++)
                    {
                        for (int y = 0; y < 120; y++)
                        {
                            temp2[2*y, 2*x, 0] = temp1[y + y_offset, x + x_offset, 0];
                            temp2[2 * y, 2*x, 1] = temp1[y + y_offset, x + x_offset, 1];
                            temp2[2 * y, 2*x, 2] = temp1[y + y_offset, x + x_offset, 2];
                            temp2[2 * y, 2*x+1, 0] = temp1[y + y_offset, x + x_offset, 0];
                            temp2[2 * y, 2*x+1, 1] = temp1[y + y_offset, x + x_offset, 1];
                            temp2[2 * y, 2*x+1, 2] = temp1[y + y_offset, x + x_offset, 2];
                            temp2[2 * y + 1, 2 * x, 0] = temp1[y + y_offset, x + x_offset, 0];
                            temp2[2 * y + 1, 2 * x, 1] = temp1[y + y_offset, x + x_offset, 1];
                            temp2[2 * y + 1, 2 * x, 2] = temp1[y + y_offset, x + x_offset, 2];
                            temp2[2 * y + 1, 2 * x + 1, 0] = temp1[y + y_offset, x + x_offset, 0];
                            temp2[2 * y + 1, 2 * x + 1, 1] = temp1[y + y_offset, x + x_offset, 1];
                            temp2[2 * y + 1, 2 * x + 1, 2] = temp1[y + y_offset, x + x_offset, 2];
                        }
                    }
                    break;
                case Zoom.OUT:
                    for (int x = 0; x < 160; x++)
                    {
                        for (int y = 0; y < 120; y++)
                        {
                            int blue_component = ((int)temp1[2 * y, 2 * x, 0] + (int)temp1[2 * y, 2 * x + 1, 0] + (int)temp1[2 * y + 1, 2 * x, 0] + (int)temp1[2 * y + 1, 2 * x + 1, 0]) / 4;
                            int green_component = ((int)temp1[2 * y, 2 * x, 1] + (int)temp1[2 * y, 2 * x + 1, 1] + (int)temp1[2 * y + 1, 2 * x, 1] + (int)temp1[2 * y + 1, 2 * x + 1, 1]) / 4;
                            int red_component = ((int)temp1[2 * y, 2 * x, 2] + (int)temp1[2 * y, 2 * x + 1, 2] + (int)temp1[2 * y + 1, 2 * x, 2] + (int)temp1[2 * y + 1, 2 * x + 1, 2]) / 4;
                            temp2[y, x, 0] = (byte)blue_component;
                            temp2[y, x, 1] = (byte)green_component;
                            temp2[y, x, 2] = (byte)red_component;

                        }
                    }
                    break;
                default:
                    break;
            }        
            

            obraz_PB2.Data = temp2;
            right_image.Image = obraz_PB2.Bitmap;
        }

        private void lutImage()
        {
            double scale;
            lut_image_var.SetValue(new Bgr(255, 255, 255));
            byte[,,] temp_lut = lut_image_var.Data;
            scale = (lut_image.Height - 1) / 255.0;
            
            for(int x = 0; x < LUT.Length; x++)
            {
                temp_lut[(int)(LUT[x] * scale), (int)((255 - x) * scale), 0] = 0;
                temp_lut[(int)(LUT[x] * scale), (int)((255 - x) * scale), 1] = 0;
                temp_lut[(int)(LUT[x] * scale), (int)((255 - x) * scale), 2] = 0;
            }


            lut_image_var.Data = temp_lut;
            lut_image.Image = lut_image_var.Bitmap;
        }
    }
}
