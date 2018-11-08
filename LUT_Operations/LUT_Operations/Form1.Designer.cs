namespace Kolor
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.image_left_button = new System.Windows.Forms.Button();
            this.from_file_left_button = new System.Windows.Forms.Button();
            this.camera_left_button = new System.Windows.Forms.Button();
            this.left_image_x_text_box = new System.Windows.Forms.TextBox();
            this.left_image_y_text_box = new System.Windows.Forms.TextBox();
            this.left_image_x_label = new System.Windows.Forms.Label();
            this.left_image_y_label = new System.Windows.Forms.Label();
            this.left_image = new System.Windows.Forms.PictureBox();
            this.clear_left_image_button = new System.Windows.Forms.Button();
            this.line_graph_left_image_button = new System.Windows.Forms.Button();
            this.color_components_left_graph = new System.Windows.Forms.PictureBox();
            this.color_components_right_graph = new System.Windows.Forms.PictureBox();
            this.line_graph_right_image_button = new System.Windows.Forms.Button();
            this.clear_right_image_button = new System.Windows.Forms.Button();
            this.right_image = new System.Windows.Forms.PictureBox();
            this.right_image_y_label = new System.Windows.Forms.Label();
            this.right_image_x_label = new System.Windows.Forms.Label();
            this.right_image_y_text_box = new System.Windows.Forms.TextBox();
            this.right_image_x_text_box = new System.Windows.Forms.TextBox();
            this.camera_right_button = new System.Windows.Forms.Button();
            this.from_file_right_button = new System.Windows.Forms.Button();
            this.image_right_button = new System.Windows.Forms.Button();
            this.color_listing_label = new System.Windows.Forms.Label();
            this.blue_textbox_left = new System.Windows.Forms.TextBox();
            this.green_textbox_left = new System.Windows.Forms.TextBox();
            this.red_textbox_left = new System.Windows.Forms.TextBox();
            this.green_checkbox = new System.Windows.Forms.CheckBox();
            this.blue_checkbox = new System.Windows.Forms.CheckBox();
            this.red_checkbox = new System.Windows.Forms.CheckBox();
            this.mono_copy_button = new System.Windows.Forms.Button();
            this.right2left_copy_button = new System.Windows.Forms.Button();
            this.left2right_copy_button = new System.Windows.Forms.Button();
            this.button_Simple_Movie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.blue_textBox_right = new System.Windows.Forms.TextBox();
            this.green_textBox_right = new System.Windows.Forms.TextBox();
            this.red_textBox_right = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lut_button = new System.Windows.Forms.Button();
            this.tozsamosc_radioButton = new System.Windows.Forms.RadioButton();
            this.negatyw_radioButton = new System.Windows.Forms.RadioButton();
            this.jasnosc_radioButton = new System.Windows.Forms.RadioButton();
            this.progowanie1_radioButton = new System.Windows.Forms.RadioButton();
            this.progowanie2_radioButton = new System.Windows.Forms.RadioButton();
            this.Kontrast = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prog2_text_box = new System.Windows.Forms.TextBox();
            this.prog1_text_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_components_left_graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_components_right_graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_image)).BeginInit();
            this.SuspendLayout();
            // 
            // image_left_button
            // 
            this.image_left_button.Location = new System.Drawing.Point(12, 12);
            this.image_left_button.Name = "image_left_button";
            this.image_left_button.Size = new System.Drawing.Size(81, 32);
            this.image_left_button.TabIndex = 0;
            this.image_left_button.Text = "Grafika";
            this.image_left_button.UseVisualStyleBackColor = true;
            this.image_left_button.Click += new System.EventHandler(this.image_left_button_Click);
            // 
            // from_file_left_button
            // 
            this.from_file_left_button.Location = new System.Drawing.Point(99, 12);
            this.from_file_left_button.Name = "from_file_left_button";
            this.from_file_left_button.Size = new System.Drawing.Size(81, 32);
            this.from_file_left_button.TabIndex = 1;
            this.from_file_left_button.Text = "Z pliku";
            this.from_file_left_button.UseVisualStyleBackColor = true;
            this.from_file_left_button.Click += new System.EventHandler(this.from_file_left_button_Click);
            // 
            // camera_left_button
            // 
            this.camera_left_button.Location = new System.Drawing.Point(186, 12);
            this.camera_left_button.Name = "camera_left_button";
            this.camera_left_button.Size = new System.Drawing.Size(81, 32);
            this.camera_left_button.TabIndex = 2;
            this.camera_left_button.Text = "Kamera";
            this.camera_left_button.UseVisualStyleBackColor = true;
            this.camera_left_button.Click += new System.EventHandler(this.camera_left_button_Click);
            // 
            // left_image_x_text_box
            // 
            this.left_image_x_text_box.Location = new System.Drawing.Point(13, 51);
            this.left_image_x_text_box.Name = "left_image_x_text_box";
            this.left_image_x_text_box.Size = new System.Drawing.Size(100, 20);
            this.left_image_x_text_box.TabIndex = 3;
            // 
            // left_image_y_text_box
            // 
            this.left_image_y_text_box.Location = new System.Drawing.Point(13, 77);
            this.left_image_y_text_box.Name = "left_image_y_text_box";
            this.left_image_y_text_box.Size = new System.Drawing.Size(100, 20);
            this.left_image_y_text_box.TabIndex = 4;
            // 
            // left_image_x_label
            // 
            this.left_image_x_label.AutoSize = true;
            this.left_image_x_label.Location = new System.Drawing.Point(120, 57);
            this.left_image_x_label.Name = "left_image_x_label";
            this.left_image_x_label.Size = new System.Drawing.Size(12, 13);
            this.left_image_x_label.TabIndex = 5;
            this.left_image_x_label.Text = "x";
            // 
            // left_image_y_label
            // 
            this.left_image_y_label.AutoSize = true;
            this.left_image_y_label.Location = new System.Drawing.Point(120, 84);
            this.left_image_y_label.Name = "left_image_y_label";
            this.left_image_y_label.Size = new System.Drawing.Size(12, 13);
            this.left_image_y_label.TabIndex = 6;
            this.left_image_y_label.Text = "y";
            // 
            // left_image
            // 
            this.left_image.BackColor = System.Drawing.Color.Black;
            this.left_image.Location = new System.Drawing.Point(12, 104);
            this.left_image.Name = "left_image";
            this.left_image.Size = new System.Drawing.Size(320, 240);
            this.left_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_image.TabIndex = 7;
            this.left_image.TabStop = false;
            this.left_image.Click += new System.EventHandler(this.left_image_Click);
            // 
            // clear_left_image_button
            // 
            this.clear_left_image_button.Location = new System.Drawing.Point(12, 350);
            this.clear_left_image_button.Name = "clear_left_image_button";
            this.clear_left_image_button.Size = new System.Drawing.Size(81, 32);
            this.clear_left_image_button.TabIndex = 8;
            this.clear_left_image_button.Text = "Czyść";
            this.clear_left_image_button.UseVisualStyleBackColor = true;
            this.clear_left_image_button.Click += new System.EventHandler(this.clear_left_image_button_Click);
            // 
            // line_graph_left_image_button
            // 
            this.line_graph_left_image_button.Location = new System.Drawing.Point(251, 350);
            this.line_graph_left_image_button.Name = "line_graph_left_image_button";
            this.line_graph_left_image_button.Size = new System.Drawing.Size(81, 32);
            this.line_graph_left_image_button.TabIndex = 9;
            this.line_graph_left_image_button.Text = "Wykres linii";
            this.line_graph_left_image_button.UseVisualStyleBackColor = true;
            this.line_graph_left_image_button.Click += new System.EventHandler(this.line_graph_left_image_button_Click);
            // 
            // color_components_left_graph
            // 
            this.color_components_left_graph.BackColor = System.Drawing.Color.Black;
            this.color_components_left_graph.Location = new System.Drawing.Point(13, 388);
            this.color_components_left_graph.Name = "color_components_left_graph";
            this.color_components_left_graph.Size = new System.Drawing.Size(320, 150);
            this.color_components_left_graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_components_left_graph.TabIndex = 11;
            this.color_components_left_graph.TabStop = false;
            // 
            // color_components_right_graph
            // 
            this.color_components_right_graph.BackColor = System.Drawing.Color.Black;
            this.color_components_right_graph.Location = new System.Drawing.Point(426, 388);
            this.color_components_right_graph.Name = "color_components_right_graph";
            this.color_components_right_graph.Size = new System.Drawing.Size(320, 150);
            this.color_components_right_graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_components_right_graph.TabIndex = 22;
            this.color_components_right_graph.TabStop = false;
            // 
            // line_graph_right_image_button
            // 
            this.line_graph_right_image_button.Location = new System.Drawing.Point(664, 350);
            this.line_graph_right_image_button.Name = "line_graph_right_image_button";
            this.line_graph_right_image_button.Size = new System.Drawing.Size(81, 32);
            this.line_graph_right_image_button.TabIndex = 21;
            this.line_graph_right_image_button.Text = "Wykres linii";
            this.line_graph_right_image_button.UseVisualStyleBackColor = true;
            this.line_graph_right_image_button.Click += new System.EventHandler(this.line_graph_right_image_button_Click);
            // 
            // clear_right_image_button
            // 
            this.clear_right_image_button.Location = new System.Drawing.Point(425, 350);
            this.clear_right_image_button.Name = "clear_right_image_button";
            this.clear_right_image_button.Size = new System.Drawing.Size(81, 32);
            this.clear_right_image_button.TabIndex = 20;
            this.clear_right_image_button.Text = "Czyść";
            this.clear_right_image_button.UseVisualStyleBackColor = true;
            this.clear_right_image_button.Click += new System.EventHandler(this.clear_right_image_button_Click);
            // 
            // right_image
            // 
            this.right_image.BackColor = System.Drawing.Color.Black;
            this.right_image.Location = new System.Drawing.Point(425, 104);
            this.right_image.Name = "right_image";
            this.right_image.Size = new System.Drawing.Size(320, 240);
            this.right_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_image.TabIndex = 19;
            this.right_image.TabStop = false;
            this.right_image.Click += new System.EventHandler(this.right_image_Click);
            // 
            // right_image_y_label
            // 
            this.right_image_y_label.AutoSize = true;
            this.right_image_y_label.Location = new System.Drawing.Point(533, 84);
            this.right_image_y_label.Name = "right_image_y_label";
            this.right_image_y_label.Size = new System.Drawing.Size(12, 13);
            this.right_image_y_label.TabIndex = 18;
            this.right_image_y_label.Text = "y";
            // 
            // right_image_x_label
            // 
            this.right_image_x_label.AutoSize = true;
            this.right_image_x_label.Location = new System.Drawing.Point(533, 57);
            this.right_image_x_label.Name = "right_image_x_label";
            this.right_image_x_label.Size = new System.Drawing.Size(12, 13);
            this.right_image_x_label.TabIndex = 17;
            this.right_image_x_label.Text = "x";
            // 
            // right_image_y_text_box
            // 
            this.right_image_y_text_box.Location = new System.Drawing.Point(426, 77);
            this.right_image_y_text_box.Name = "right_image_y_text_box";
            this.right_image_y_text_box.Size = new System.Drawing.Size(100, 20);
            this.right_image_y_text_box.TabIndex = 16;
            // 
            // right_image_x_text_box
            // 
            this.right_image_x_text_box.Location = new System.Drawing.Point(426, 51);
            this.right_image_x_text_box.Name = "right_image_x_text_box";
            this.right_image_x_text_box.Size = new System.Drawing.Size(100, 20);
            this.right_image_x_text_box.TabIndex = 15;
            // 
            // camera_right_button
            // 
            this.camera_right_button.Location = new System.Drawing.Point(599, 12);
            this.camera_right_button.Name = "camera_right_button";
            this.camera_right_button.Size = new System.Drawing.Size(81, 32);
            this.camera_right_button.TabIndex = 14;
            this.camera_right_button.Text = "Kamera";
            this.camera_right_button.UseVisualStyleBackColor = true;
            this.camera_right_button.Click += new System.EventHandler(this.camera_right_button_Click);
            // 
            // from_file_right_button
            // 
            this.from_file_right_button.Location = new System.Drawing.Point(512, 12);
            this.from_file_right_button.Name = "from_file_right_button";
            this.from_file_right_button.Size = new System.Drawing.Size(81, 32);
            this.from_file_right_button.TabIndex = 13;
            this.from_file_right_button.Text = "Z pliku";
            this.from_file_right_button.UseVisualStyleBackColor = true;
            this.from_file_right_button.Click += new System.EventHandler(this.from_file_right_button_Click);
            // 
            // image_right_button
            // 
            this.image_right_button.Location = new System.Drawing.Point(425, 12);
            this.image_right_button.Name = "image_right_button";
            this.image_right_button.Size = new System.Drawing.Size(81, 32);
            this.image_right_button.TabIndex = 12;
            this.image_right_button.Text = "Grafika";
            this.image_right_button.UseVisualStyleBackColor = true;
            this.image_right_button.Click += new System.EventHandler(this.image_right_button_Click);
            // 
            // color_listing_label
            // 
            this.color_listing_label.AutoSize = true;
            this.color_listing_label.Location = new System.Drawing.Point(191, 61);
            this.color_listing_label.Name = "color_listing_label";
            this.color_listing_label.Size = new System.Drawing.Size(72, 13);
            this.color_listing_label.TabIndex = 54;
            this.color_listing_label.Text = "Listing koloru:";
            // 
            // blue_textbox_left
            // 
            this.blue_textbox_left.BackColor = System.Drawing.Color.LightSteelBlue;
            this.blue_textbox_left.Location = new System.Drawing.Point(267, 77);
            this.blue_textbox_left.Name = "blue_textbox_left";
            this.blue_textbox_left.Size = new System.Drawing.Size(36, 20);
            this.blue_textbox_left.TabIndex = 53;
            // 
            // green_textbox_left
            // 
            this.green_textbox_left.BackColor = System.Drawing.Color.PaleGreen;
            this.green_textbox_left.Location = new System.Drawing.Point(231, 77);
            this.green_textbox_left.Name = "green_textbox_left";
            this.green_textbox_left.Size = new System.Drawing.Size(36, 20);
            this.green_textbox_left.TabIndex = 52;
            // 
            // red_textbox_left
            // 
            this.red_textbox_left.BackColor = System.Drawing.Color.Salmon;
            this.red_textbox_left.Location = new System.Drawing.Point(194, 77);
            this.red_textbox_left.Name = "red_textbox_left";
            this.red_textbox_left.Size = new System.Drawing.Size(36, 20);
            this.red_textbox_left.TabIndex = 51;
            // 
            // green_checkbox
            // 
            this.green_checkbox.AutoSize = true;
            this.green_checkbox.BackColor = System.Drawing.Color.PaleGreen;
            this.green_checkbox.Location = new System.Drawing.Point(338, 162);
            this.green_checkbox.Name = "green_checkbox";
            this.green_checkbox.Size = new System.Drawing.Size(34, 17);
            this.green_checkbox.TabIndex = 60;
            this.green_checkbox.Text = "G";
            this.green_checkbox.UseVisualStyleBackColor = false;
            // 
            // blue_checkbox
            // 
            this.blue_checkbox.AutoSize = true;
            this.blue_checkbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.blue_checkbox.Location = new System.Drawing.Point(338, 185);
            this.blue_checkbox.Name = "blue_checkbox";
            this.blue_checkbox.Size = new System.Drawing.Size(33, 17);
            this.blue_checkbox.TabIndex = 59;
            this.blue_checkbox.Text = "B";
            this.blue_checkbox.UseVisualStyleBackColor = false;
            // 
            // red_checkbox
            // 
            this.red_checkbox.AutoSize = true;
            this.red_checkbox.BackColor = System.Drawing.Color.Salmon;
            this.red_checkbox.Location = new System.Drawing.Point(338, 139);
            this.red_checkbox.Name = "red_checkbox";
            this.red_checkbox.Size = new System.Drawing.Size(34, 17);
            this.red_checkbox.TabIndex = 58;
            this.red_checkbox.Text = "R";
            this.red_checkbox.UseVisualStyleBackColor = false;
            // 
            // mono_copy_button
            // 
            this.mono_copy_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mono_copy_button.Location = new System.Drawing.Point(338, 243);
            this.mono_copy_button.Name = "mono_copy_button";
            this.mono_copy_button.Size = new System.Drawing.Size(81, 29);
            this.mono_copy_button.TabIndex = 57;
            this.mono_copy_button.Text = "Mono →";
            this.mono_copy_button.UseVisualStyleBackColor = true;
            this.mono_copy_button.Click += new System.EventHandler(this.mono_copy_button_Click);
            // 
            // right2left_copy_button
            // 
            this.right2left_copy_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.right2left_copy_button.Location = new System.Drawing.Point(338, 208);
            this.right2left_copy_button.Name = "right2left_copy_button";
            this.right2left_copy_button.Size = new System.Drawing.Size(81, 29);
            this.right2left_copy_button.TabIndex = 56;
            this.right2left_copy_button.Text = "←";
            this.right2left_copy_button.UseVisualStyleBackColor = true;
            this.right2left_copy_button.Click += new System.EventHandler(this.right2left_copy_button_Click);
            // 
            // left2right_copy_button
            // 
            this.left2right_copy_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.left2right_copy_button.Location = new System.Drawing.Point(338, 104);
            this.left2right_copy_button.Name = "left2right_copy_button";
            this.left2right_copy_button.Size = new System.Drawing.Size(81, 29);
            this.left2right_copy_button.TabIndex = 55;
            this.left2right_copy_button.Text = "→";
            this.left2right_copy_button.UseVisualStyleBackColor = true;
            this.left2right_copy_button.Click += new System.EventHandler(this.left2right_copy_button_Click);
            // 
            // button_Simple_Movie
            // 
            this.button_Simple_Movie.Location = new System.Drawing.Point(338, 12);
            this.button_Simple_Movie.Name = "button_Simple_Movie";
            this.button_Simple_Movie.Size = new System.Drawing.Size(81, 32);
            this.button_Simple_Movie.TabIndex = 61;
            this.button_Simple_Movie.Text = "Prosty film";
            this.button_Simple_Movie.UseVisualStyleBackColor = true;
            this.button_Simple_Movie.Click += new System.EventHandler(this.button_Simple_Movie_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Listing koloru:";
            // 
            // blue_textBox_right
            // 
            this.blue_textBox_right.BackColor = System.Drawing.Color.LightSteelBlue;
            this.blue_textBox_right.Location = new System.Drawing.Point(684, 77);
            this.blue_textBox_right.Name = "blue_textBox_right";
            this.blue_textBox_right.Size = new System.Drawing.Size(36, 20);
            this.blue_textBox_right.TabIndex = 64;
            // 
            // green_textBox_right
            // 
            this.green_textBox_right.BackColor = System.Drawing.Color.PaleGreen;
            this.green_textBox_right.Location = new System.Drawing.Point(648, 77);
            this.green_textBox_right.Name = "green_textBox_right";
            this.green_textBox_right.Size = new System.Drawing.Size(36, 20);
            this.green_textBox_right.TabIndex = 63;
            // 
            // red_textBox_right
            // 
            this.red_textBox_right.BackColor = System.Drawing.Color.Salmon;
            this.red_textBox_right.Location = new System.Drawing.Point(611, 77);
            this.red_textBox_right.Name = "red_textBox_right";
            this.red_textBox_right.Size = new System.Drawing.Size(36, 20);
            this.red_textBox_right.TabIndex = 62;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lut_button
            // 
            this.lut_button.Location = new System.Drawing.Point(751, 12);
            this.lut_button.Name = "lut_button";
            this.lut_button.Size = new System.Drawing.Size(91, 58);
            this.lut_button.TabIndex = 66;
            this.lut_button.Text = "LUT";
            this.lut_button.UseVisualStyleBackColor = true;
            this.lut_button.Click += new System.EventHandler(this.lut_button_Click);
            // 
            // tozsamosc_radioButton
            // 
            this.tozsamosc_radioButton.AutoSize = true;
            this.tozsamosc_radioButton.Location = new System.Drawing.Point(751, 104);
            this.tozsamosc_radioButton.Name = "tozsamosc_radioButton";
            this.tozsamosc_radioButton.Size = new System.Drawing.Size(79, 17);
            this.tozsamosc_radioButton.TabIndex = 67;
            this.tozsamosc_radioButton.TabStop = true;
            this.tozsamosc_radioButton.Text = "Tożsamość";
            this.tozsamosc_radioButton.UseVisualStyleBackColor = true;
            this.tozsamosc_radioButton.CheckedChanged += new System.EventHandler(this.tozsamosc_radioButton_CheckedChanged);
            // 
            // negatyw_radioButton
            // 
            this.negatyw_radioButton.AutoSize = true;
            this.negatyw_radioButton.Location = new System.Drawing.Point(751, 127);
            this.negatyw_radioButton.Name = "negatyw_radioButton";
            this.negatyw_radioButton.Size = new System.Drawing.Size(67, 17);
            this.negatyw_radioButton.TabIndex = 68;
            this.negatyw_radioButton.TabStop = true;
            this.negatyw_radioButton.Text = "Negatyw";
            this.negatyw_radioButton.UseVisualStyleBackColor = true;
            this.negatyw_radioButton.CheckedChanged += new System.EventHandler(this.negatyw_radioButton_CheckedChanged);
            // 
            // jasnosc_radioButton
            // 
            this.jasnosc_radioButton.AutoSize = true;
            this.jasnosc_radioButton.Location = new System.Drawing.Point(751, 150);
            this.jasnosc_radioButton.Name = "jasnosc_radioButton";
            this.jasnosc_radioButton.Size = new System.Drawing.Size(64, 17);
            this.jasnosc_radioButton.TabIndex = 69;
            this.jasnosc_radioButton.TabStop = true;
            this.jasnosc_radioButton.Text = "Jasność";
            this.jasnosc_radioButton.UseVisualStyleBackColor = true;
            this.jasnosc_radioButton.CheckedChanged += new System.EventHandler(this.jasnosc_radioButton_CheckedChanged);
            // 
            // progowanie1_radioButton
            // 
            this.progowanie1_radioButton.AutoSize = true;
            this.progowanie1_radioButton.Location = new System.Drawing.Point(751, 173);
            this.progowanie1_radioButton.Name = "progowanie1_radioButton";
            this.progowanie1_radioButton.Size = new System.Drawing.Size(163, 17);
            this.progowanie1_radioButton.TabIndex = 70;
            this.progowanie1_radioButton.TabStop = true;
            this.progowanie1_radioButton.Text = "Progowanie jednopoziomowe";
            this.progowanie1_radioButton.UseVisualStyleBackColor = true;
            this.progowanie1_radioButton.CheckedChanged += new System.EventHandler(this.progowanie1_radioButton_CheckedChanged);
            // 
            // progowanie2_radioButton
            // 
            this.progowanie2_radioButton.AutoSize = true;
            this.progowanie2_radioButton.Location = new System.Drawing.Point(751, 196);
            this.progowanie2_radioButton.Name = "progowanie2_radioButton";
            this.progowanie2_radioButton.Size = new System.Drawing.Size(157, 17);
            this.progowanie2_radioButton.TabIndex = 71;
            this.progowanie2_radioButton.TabStop = true;
            this.progowanie2_radioButton.Text = "Progowanie dwupoziomowe";
            this.progowanie2_radioButton.UseVisualStyleBackColor = true;
            this.progowanie2_radioButton.CheckedChanged += new System.EventHandler(this.progowanie2_radioButton_CheckedChanged);
            // 
            // Kontrast
            // 
            this.Kontrast.AutoSize = true;
            this.Kontrast.Location = new System.Drawing.Point(751, 220);
            this.Kontrast.Name = "Kontrast";
            this.Kontrast.Size = new System.Drawing.Size(64, 17);
            this.Kontrast.TabIndex = 72;
            this.Kontrast.TabStop = true;
            this.Kontrast.Text = "Kontrast";
            this.Kontrast.UseVisualStyleBackColor = true;
            this.Kontrast.CheckedChanged += new System.EventHandler(this.Kontrast_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(858, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "P2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(858, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "P1";
            // 
            // prog2_text_box
            // 
            this.prog2_text_box.Location = new System.Drawing.Point(751, 269);
            this.prog2_text_box.Name = "prog2_text_box";
            this.prog2_text_box.Size = new System.Drawing.Size(100, 20);
            this.prog2_text_box.TabIndex = 74;
            // 
            // prog1_text_box
            // 
            this.prog1_text_box.Location = new System.Drawing.Point(751, 243);
            this.prog1_text_box.Name = "prog1_text_box";
            this.prog1_text_box.Size = new System.Drawing.Size(100, 20);
            this.prog1_text_box.TabIndex = 73;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 569);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prog2_text_box);
            this.Controls.Add(this.prog1_text_box);
            this.Controls.Add(this.Kontrast);
            this.Controls.Add(this.progowanie2_radioButton);
            this.Controls.Add(this.progowanie1_radioButton);
            this.Controls.Add(this.jasnosc_radioButton);
            this.Controls.Add(this.negatyw_radioButton);
            this.Controls.Add(this.tozsamosc_radioButton);
            this.Controls.Add(this.lut_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blue_textBox_right);
            this.Controls.Add(this.green_textBox_right);
            this.Controls.Add(this.red_textBox_right);
            this.Controls.Add(this.button_Simple_Movie);
            this.Controls.Add(this.green_checkbox);
            this.Controls.Add(this.blue_checkbox);
            this.Controls.Add(this.red_checkbox);
            this.Controls.Add(this.mono_copy_button);
            this.Controls.Add(this.right2left_copy_button);
            this.Controls.Add(this.left2right_copy_button);
            this.Controls.Add(this.color_listing_label);
            this.Controls.Add(this.blue_textbox_left);
            this.Controls.Add(this.green_textbox_left);
            this.Controls.Add(this.red_textbox_left);
            this.Controls.Add(this.color_components_right_graph);
            this.Controls.Add(this.line_graph_right_image_button);
            this.Controls.Add(this.clear_right_image_button);
            this.Controls.Add(this.right_image);
            this.Controls.Add(this.right_image_y_label);
            this.Controls.Add(this.right_image_x_label);
            this.Controls.Add(this.right_image_y_text_box);
            this.Controls.Add(this.right_image_x_text_box);
            this.Controls.Add(this.camera_right_button);
            this.Controls.Add(this.from_file_right_button);
            this.Controls.Add(this.image_right_button);
            this.Controls.Add(this.color_components_left_graph);
            this.Controls.Add(this.line_graph_left_image_button);
            this.Controls.Add(this.clear_left_image_button);
            this.Controls.Add(this.left_image);
            this.Controls.Add(this.left_image_y_label);
            this.Controls.Add(this.left_image_x_label);
            this.Controls.Add(this.left_image_y_text_box);
            this.Controls.Add(this.left_image_x_text_box);
            this.Controls.Add(this.camera_left_button);
            this.Controls.Add(this.from_file_left_button);
            this.Controls.Add(this.image_left_button);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_components_left_graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_components_right_graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button image_left_button;
        private System.Windows.Forms.Button from_file_left_button;
        private System.Windows.Forms.Button camera_left_button;
        private System.Windows.Forms.TextBox left_image_x_text_box;
        private System.Windows.Forms.TextBox left_image_y_text_box;
        private System.Windows.Forms.Label left_image_x_label;
        private System.Windows.Forms.Label left_image_y_label;
        private System.Windows.Forms.PictureBox left_image;
        private System.Windows.Forms.Button clear_left_image_button;
        private System.Windows.Forms.Button line_graph_left_image_button;
        private System.Windows.Forms.PictureBox color_components_left_graph;
        private System.Windows.Forms.PictureBox color_components_right_graph;
        private System.Windows.Forms.Button line_graph_right_image_button;
        private System.Windows.Forms.Button clear_right_image_button;
        private System.Windows.Forms.PictureBox right_image;
        private System.Windows.Forms.Label right_image_y_label;
        private System.Windows.Forms.Label right_image_x_label;
        private System.Windows.Forms.TextBox right_image_y_text_box;
        private System.Windows.Forms.TextBox right_image_x_text_box;
        private System.Windows.Forms.Button camera_right_button;
        private System.Windows.Forms.Button from_file_right_button;
        private System.Windows.Forms.Button image_right_button;
        private System.Windows.Forms.Label color_listing_label;
        private System.Windows.Forms.TextBox blue_textbox_left;
        private System.Windows.Forms.TextBox green_textbox_left;
        private System.Windows.Forms.CheckBox green_checkbox;
        private System.Windows.Forms.CheckBox blue_checkbox;
        private System.Windows.Forms.CheckBox red_checkbox;
        private System.Windows.Forms.Button mono_copy_button;
        private System.Windows.Forms.Button right2left_copy_button;
        private System.Windows.Forms.Button left2right_copy_button;
        private System.Windows.Forms.Button button_Simple_Movie;
        internal System.Windows.Forms.TextBox red_textbox_left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox blue_textBox_right;
        private System.Windows.Forms.TextBox green_textBox_right;
        internal System.Windows.Forms.TextBox red_textBox_right;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button lut_button;
        private System.Windows.Forms.RadioButton tozsamosc_radioButton;
        private System.Windows.Forms.RadioButton negatyw_radioButton;
        private System.Windows.Forms.RadioButton jasnosc_radioButton;
        private System.Windows.Forms.RadioButton progowanie2_radioButton;
        private System.Windows.Forms.RadioButton Kontrast;
        private System.Windows.Forms.RadioButton progowanie1_radioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prog2_text_box;
        private System.Windows.Forms.TextBox prog1_text_box;
    }
}

