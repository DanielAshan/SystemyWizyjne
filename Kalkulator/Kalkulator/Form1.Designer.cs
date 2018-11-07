namespace Kalkulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataAndResultGroup = new System.Windows.Forms.GroupBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultField = new System.Windows.Forms.TextBox();
            this.secondNumberField = new System.Windows.Forms.TextBox();
            this.firstNumberField = new System.Windows.Forms.TextBox();
            this.secondNumberRadio = new System.Windows.Forms.RadioButton();
            this.firstNumberRadio = new System.Windows.Forms.RadioButton();
            this.operationsGroup = new System.Windows.Forms.GroupBox();
            this.squarerootOperationRadio = new System.Windows.Forms.RadioButton();
            this.squareOperationRadio = new System.Windows.Forms.RadioButton();
            this.cosinusOperationRadio = new System.Windows.Forms.RadioButton();
            this.sinusOperationRadio = new System.Windows.Forms.RadioButton();
            this.moduloOperationRadio = new System.Windows.Forms.RadioButton();
            this.divideOperationRadio = new System.Windows.Forms.RadioButton();
            this.multiplyOperationRadio = new System.Windows.Forms.RadioButton();
            this.substractOperationRadio = new System.Windows.Forms.RadioButton();
            this.addOperationRadio = new System.Windows.Forms.RadioButton();
            this.keyboardGroup = new System.Windows.Forms.GroupBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.addOperationButton = new System.Windows.Forms.Button();
            this.zeroNumberButton = new System.Windows.Forms.Button();
            this.commaCharButton = new System.Windows.Forms.Button();
            this.oneNumberButton = new System.Windows.Forms.Button();
            this.twoNumberButton = new System.Windows.Forms.Button();
            this.threeNumberButton = new System.Windows.Forms.Button();
            this.fourNumberButton = new System.Windows.Forms.Button();
            this.fiveNumberButton = new System.Windows.Forms.Button();
            this.sixNumberButton = new System.Windows.Forms.Button();
            this.sevenNumberButton = new System.Windows.Forms.Button();
            this.eightNumberButton = new System.Windows.Forms.Button();
            this.nineNumberButton = new System.Windows.Forms.Button();
            this.moduloOperationButton = new System.Windows.Forms.Button();
            this.divideOperationButton = new System.Windows.Forms.Button();
            this.substractOperationButton = new System.Windows.Forms.Button();
            this.multiplyOperationButton = new System.Windows.Forms.Button();
            this.sinusOperationButton = new System.Windows.Forms.Button();
            this.cosinusOperationButton = new System.Windows.Forms.Button();
            this.squareOperationButton = new System.Windows.Forms.Button();
            this.sqrtOperationButton = new System.Windows.Forms.Button();
            this.clearHistoryButton = new System.Windows.Forms.Button();
            this.historyList = new System.Windows.Forms.ListView();
            this.Historia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataAndResultGroup.SuspendLayout();
            this.operationsGroup.SuspendLayout();
            this.keyboardGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataAndResultGroup
            // 
            this.dataAndResultGroup.Controls.Add(this.resultLabel);
            this.dataAndResultGroup.Controls.Add(this.resultField);
            this.dataAndResultGroup.Controls.Add(this.secondNumberField);
            this.dataAndResultGroup.Controls.Add(this.firstNumberField);
            this.dataAndResultGroup.Controls.Add(this.secondNumberRadio);
            this.dataAndResultGroup.Controls.Add(this.firstNumberRadio);
            this.dataAndResultGroup.Location = new System.Drawing.Point(12, 12);
            this.dataAndResultGroup.Name = "dataAndResultGroup";
            this.dataAndResultGroup.Size = new System.Drawing.Size(256, 101);
            this.dataAndResultGroup.TabIndex = 0;
            this.dataAndResultGroup.TabStop = false;
            this.dataAndResultGroup.Text = "Dane i wynik";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(37, 72);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(37, 13);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Wynik";
            // 
            // resultField
            // 
            this.resultField.Location = new System.Drawing.Point(79, 72);
            this.resultField.Name = "resultField";
            this.resultField.Size = new System.Drawing.Size(166, 20);
            this.resultField.TabIndex = 4;
            // 
            // secondNumberField
            // 
            this.secondNumberField.Location = new System.Drawing.Point(79, 46);
            this.secondNumberField.Name = "secondNumberField";
            this.secondNumberField.Size = new System.Drawing.Size(166, 20);
            this.secondNumberField.TabIndex = 3;
            this.secondNumberField.Text = "0";
            // 
            // firstNumberField
            // 
            this.firstNumberField.Location = new System.Drawing.Point(79, 20);
            this.firstNumberField.Name = "firstNumberField";
            this.firstNumberField.Size = new System.Drawing.Size(166, 20);
            this.firstNumberField.TabIndex = 2;
            this.firstNumberField.Text = "0";
            // 
            // secondNumberRadio
            // 
            this.secondNumberRadio.AutoSize = true;
            this.secondNumberRadio.Location = new System.Drawing.Point(7, 43);
            this.secondNumberRadio.Name = "secondNumberRadio";
            this.secondNumberRadio.Size = new System.Drawing.Size(65, 17);
            this.secondNumberRadio.TabIndex = 1;
            this.secondNumberRadio.TabStop = true;
            this.secondNumberRadio.Text = "Liczba 2";
            this.secondNumberRadio.UseVisualStyleBackColor = true;
            // 
            // firstNumberRadio
            // 
            this.firstNumberRadio.AutoSize = true;
            this.firstNumberRadio.Location = new System.Drawing.Point(7, 20);
            this.firstNumberRadio.Name = "firstNumberRadio";
            this.firstNumberRadio.Size = new System.Drawing.Size(65, 17);
            this.firstNumberRadio.TabIndex = 0;
            this.firstNumberRadio.TabStop = true;
            this.firstNumberRadio.Text = "Liczba 1";
            this.firstNumberRadio.UseVisualStyleBackColor = true;
            // 
            // operationsGroup
            // 
            this.operationsGroup.Controls.Add(this.squarerootOperationRadio);
            this.operationsGroup.Controls.Add(this.squareOperationRadio);
            this.operationsGroup.Controls.Add(this.cosinusOperationRadio);
            this.operationsGroup.Controls.Add(this.sinusOperationRadio);
            this.operationsGroup.Controls.Add(this.moduloOperationRadio);
            this.operationsGroup.Controls.Add(this.divideOperationRadio);
            this.operationsGroup.Controls.Add(this.multiplyOperationRadio);
            this.operationsGroup.Controls.Add(this.substractOperationRadio);
            this.operationsGroup.Controls.Add(this.addOperationRadio);
            this.operationsGroup.Location = new System.Drawing.Point(12, 120);
            this.operationsGroup.Name = "operationsGroup";
            this.operationsGroup.Size = new System.Drawing.Size(256, 100);
            this.operationsGroup.TabIndex = 1;
            this.operationsGroup.TabStop = false;
            this.operationsGroup.Text = "groupBox1";
            // 
            // squarerootOperationRadio
            // 
            this.squarerootOperationRadio.AutoSize = true;
            this.squarerootOperationRadio.Location = new System.Drawing.Point(158, 65);
            this.squarerootOperationRadio.Name = "squarerootOperationRadio";
            this.squarerootOperationRadio.Size = new System.Drawing.Size(83, 17);
            this.squarerootOperationRadio.TabIndex = 8;
            this.squarerootOperationRadio.TabStop = true;
            this.squarerootOperationRadio.Text = "Prws. kwad.";
            this.squarerootOperationRadio.UseVisualStyleBackColor = true;
            // 
            // squareOperationRadio
            // 
            this.squareOperationRadio.AutoSize = true;
            this.squareOperationRadio.Location = new System.Drawing.Point(158, 42);
            this.squareOperationRadio.Name = "squareOperationRadio";
            this.squareOperationRadio.Size = new System.Drawing.Size(64, 17);
            this.squareOperationRadio.TabIndex = 7;
            this.squareOperationRadio.TabStop = true;
            this.squareOperationRadio.Text = "Kwadrat";
            this.squareOperationRadio.UseVisualStyleBackColor = true;
            // 
            // cosinusOperationRadio
            // 
            this.cosinusOperationRadio.AutoSize = true;
            this.cosinusOperationRadio.Location = new System.Drawing.Point(158, 19);
            this.cosinusOperationRadio.Name = "cosinusOperationRadio";
            this.cosinusOperationRadio.Size = new System.Drawing.Size(62, 17);
            this.cosinusOperationRadio.TabIndex = 6;
            this.cosinusOperationRadio.TabStop = true;
            this.cosinusOperationRadio.Text = "Cosinus";
            this.cosinusOperationRadio.UseVisualStyleBackColor = true;
            // 
            // sinusOperationRadio
            // 
            this.sinusOperationRadio.AutoSize = true;
            this.sinusOperationRadio.Location = new System.Drawing.Point(91, 65);
            this.sinusOperationRadio.Name = "sinusOperationRadio";
            this.sinusOperationRadio.Size = new System.Drawing.Size(51, 17);
            this.sinusOperationRadio.TabIndex = 5;
            this.sinusOperationRadio.TabStop = true;
            this.sinusOperationRadio.Text = "Sinus";
            this.sinusOperationRadio.UseVisualStyleBackColor = true;
            // 
            // moduloOperationRadio
            // 
            this.moduloOperationRadio.AutoSize = true;
            this.moduloOperationRadio.Location = new System.Drawing.Point(91, 42);
            this.moduloOperationRadio.Name = "moduloOperationRadio";
            this.moduloOperationRadio.Size = new System.Drawing.Size(58, 17);
            this.moduloOperationRadio.TabIndex = 4;
            this.moduloOperationRadio.TabStop = true;
            this.moduloOperationRadio.Text = "Reszta";
            this.moduloOperationRadio.UseVisualStyleBackColor = true;
            // 
            // divideOperationRadio
            // 
            this.divideOperationRadio.AutoSize = true;
            this.divideOperationRadio.Location = new System.Drawing.Point(91, 19);
            this.divideOperationRadio.Name = "divideOperationRadio";
            this.divideOperationRadio.Size = new System.Drawing.Size(68, 17);
            this.divideOperationRadio.TabIndex = 2;
            this.divideOperationRadio.TabStop = true;
            this.divideOperationRadio.Text = "Dzielenie";
            this.divideOperationRadio.UseVisualStyleBackColor = true;
            // 
            // multiplyOperationRadio
            // 
            this.multiplyOperationRadio.AutoSize = true;
            this.multiplyOperationRadio.Location = new System.Drawing.Point(6, 65);
            this.multiplyOperationRadio.Name = "multiplyOperationRadio";
            this.multiplyOperationRadio.Size = new System.Drawing.Size(71, 17);
            this.multiplyOperationRadio.TabIndex = 3;
            this.multiplyOperationRadio.TabStop = true;
            this.multiplyOperationRadio.Text = "Mnożenie";
            this.multiplyOperationRadio.UseVisualStyleBackColor = true;
            // 
            // substractOperationRadio
            // 
            this.substractOperationRadio.AutoSize = true;
            this.substractOperationRadio.Location = new System.Drawing.Point(6, 42);
            this.substractOperationRadio.Name = "substractOperationRadio";
            this.substractOperationRadio.Size = new System.Drawing.Size(89, 17);
            this.substractOperationRadio.TabIndex = 2;
            this.substractOperationRadio.TabStop = true;
            this.substractOperationRadio.Text = "Odejmowanie";
            this.substractOperationRadio.UseVisualStyleBackColor = true;
            // 
            // addOperationRadio
            // 
            this.addOperationRadio.AutoSize = true;
            this.addOperationRadio.Location = new System.Drawing.Point(6, 19);
            this.addOperationRadio.Name = "addOperationRadio";
            this.addOperationRadio.Size = new System.Drawing.Size(79, 17);
            this.addOperationRadio.TabIndex = 1;
            this.addOperationRadio.TabStop = true;
            this.addOperationRadio.Text = "Dodawanie";
            this.addOperationRadio.UseVisualStyleBackColor = true;
            // 
            // keyboardGroup
            // 
            this.keyboardGroup.Controls.Add(this.enterButton);
            this.keyboardGroup.Controls.Add(this.addOperationButton);
            this.keyboardGroup.Controls.Add(this.zeroNumberButton);
            this.keyboardGroup.Controls.Add(this.commaCharButton);
            this.keyboardGroup.Controls.Add(this.oneNumberButton);
            this.keyboardGroup.Controls.Add(this.twoNumberButton);
            this.keyboardGroup.Controls.Add(this.threeNumberButton);
            this.keyboardGroup.Controls.Add(this.fourNumberButton);
            this.keyboardGroup.Controls.Add(this.fiveNumberButton);
            this.keyboardGroup.Controls.Add(this.sixNumberButton);
            this.keyboardGroup.Controls.Add(this.sevenNumberButton);
            this.keyboardGroup.Controls.Add(this.eightNumberButton);
            this.keyboardGroup.Controls.Add(this.nineNumberButton);
            this.keyboardGroup.Controls.Add(this.moduloOperationButton);
            this.keyboardGroup.Controls.Add(this.divideOperationButton);
            this.keyboardGroup.Controls.Add(this.substractOperationButton);
            this.keyboardGroup.Controls.Add(this.multiplyOperationButton);
            this.keyboardGroup.Controls.Add(this.sinusOperationButton);
            this.keyboardGroup.Controls.Add(this.cosinusOperationButton);
            this.keyboardGroup.Controls.Add(this.squareOperationButton);
            this.keyboardGroup.Controls.Add(this.sqrtOperationButton);
            this.keyboardGroup.Location = new System.Drawing.Point(12, 227);
            this.keyboardGroup.Name = "keyboardGroup";
            this.keyboardGroup.Size = new System.Drawing.Size(256, 353);
            this.keyboardGroup.TabIndex = 2;
            this.keyboardGroup.TabStop = false;
            this.keyboardGroup.Text = "Klawiatura";
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(189, 243);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(53, 104);
            this.enterButton.TabIndex = 22;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // addOperationButton
            // 
            this.addOperationButton.Location = new System.Drawing.Point(189, 131);
            this.addOperationButton.Name = "addOperationButton";
            this.addOperationButton.Size = new System.Drawing.Size(53, 106);
            this.addOperationButton.TabIndex = 21;
            this.addOperationButton.Text = "+";
            this.addOperationButton.UseVisualStyleBackColor = true;
            this.addOperationButton.Click += new System.EventHandler(this.addOperationButton_Click);
            // 
            // zeroNumberButton
            // 
            this.zeroNumberButton.Location = new System.Drawing.Point(12, 297);
            this.zeroNumberButton.Name = "zeroNumberButton";
            this.zeroNumberButton.Size = new System.Drawing.Size(112, 50);
            this.zeroNumberButton.TabIndex = 20;
            this.zeroNumberButton.Text = "0";
            this.zeroNumberButton.UseVisualStyleBackColor = true;
            this.zeroNumberButton.Click += new System.EventHandler(this.zeroNumberButton_Click);
            // 
            // commaCharButton
            // 
            this.commaCharButton.Location = new System.Drawing.Point(130, 297);
            this.commaCharButton.Name = "commaCharButton";
            this.commaCharButton.Size = new System.Drawing.Size(53, 50);
            this.commaCharButton.TabIndex = 19;
            this.commaCharButton.Text = ",";
            this.commaCharButton.UseVisualStyleBackColor = true;
            this.commaCharButton.Click += new System.EventHandler(this.commaCharButton_Click);
            // 
            // oneNumberButton
            // 
            this.oneNumberButton.Location = new System.Drawing.Point(12, 243);
            this.oneNumberButton.Name = "oneNumberButton";
            this.oneNumberButton.Size = new System.Drawing.Size(53, 50);
            this.oneNumberButton.TabIndex = 18;
            this.oneNumberButton.Text = "1";
            this.oneNumberButton.UseVisualStyleBackColor = true;
            this.oneNumberButton.Click += new System.EventHandler(this.oneNumberButton_Click);
            // 
            // twoNumberButton
            // 
            this.twoNumberButton.Location = new System.Drawing.Point(71, 243);
            this.twoNumberButton.Name = "twoNumberButton";
            this.twoNumberButton.Size = new System.Drawing.Size(53, 50);
            this.twoNumberButton.TabIndex = 17;
            this.twoNumberButton.Text = "2";
            this.twoNumberButton.UseVisualStyleBackColor = true;
            this.twoNumberButton.Click += new System.EventHandler(this.twoNumberButton_Click);
            // 
            // threeNumberButton
            // 
            this.threeNumberButton.Location = new System.Drawing.Point(130, 243);
            this.threeNumberButton.Name = "threeNumberButton";
            this.threeNumberButton.Size = new System.Drawing.Size(53, 50);
            this.threeNumberButton.TabIndex = 16;
            this.threeNumberButton.Text = "3";
            this.threeNumberButton.UseVisualStyleBackColor = true;
            this.threeNumberButton.Click += new System.EventHandler(this.threeNumberButton_Click);
            // 
            // fourNumberButton
            // 
            this.fourNumberButton.Location = new System.Drawing.Point(12, 187);
            this.fourNumberButton.Name = "fourNumberButton";
            this.fourNumberButton.Size = new System.Drawing.Size(53, 50);
            this.fourNumberButton.TabIndex = 15;
            this.fourNumberButton.Text = "4";
            this.fourNumberButton.UseVisualStyleBackColor = true;
            this.fourNumberButton.Click += new System.EventHandler(this.fourNumberButton_Click);
            // 
            // fiveNumberButton
            // 
            this.fiveNumberButton.Location = new System.Drawing.Point(71, 187);
            this.fiveNumberButton.Name = "fiveNumberButton";
            this.fiveNumberButton.Size = new System.Drawing.Size(53, 50);
            this.fiveNumberButton.TabIndex = 14;
            this.fiveNumberButton.Text = "5";
            this.fiveNumberButton.UseVisualStyleBackColor = true;
            this.fiveNumberButton.Click += new System.EventHandler(this.fiveNumberButton_Click);
            // 
            // sixNumberButton
            // 
            this.sixNumberButton.Location = new System.Drawing.Point(130, 187);
            this.sixNumberButton.Name = "sixNumberButton";
            this.sixNumberButton.Size = new System.Drawing.Size(53, 50);
            this.sixNumberButton.TabIndex = 13;
            this.sixNumberButton.Text = "6";
            this.sixNumberButton.UseVisualStyleBackColor = true;
            this.sixNumberButton.Click += new System.EventHandler(this.sixNumberButton_Click);
            // 
            // sevenNumberButton
            // 
            this.sevenNumberButton.Location = new System.Drawing.Point(12, 131);
            this.sevenNumberButton.Name = "sevenNumberButton";
            this.sevenNumberButton.Size = new System.Drawing.Size(53, 50);
            this.sevenNumberButton.TabIndex = 12;
            this.sevenNumberButton.Text = "7";
            this.sevenNumberButton.UseVisualStyleBackColor = true;
            this.sevenNumberButton.Click += new System.EventHandler(this.sevenNumberButton_Click);
            // 
            // eightNumberButton
            // 
            this.eightNumberButton.Location = new System.Drawing.Point(71, 131);
            this.eightNumberButton.Name = "eightNumberButton";
            this.eightNumberButton.Size = new System.Drawing.Size(53, 50);
            this.eightNumberButton.TabIndex = 11;
            this.eightNumberButton.Text = "8";
            this.eightNumberButton.UseVisualStyleBackColor = true;
            this.eightNumberButton.Click += new System.EventHandler(this.eightNumberButton_Click);
            // 
            // nineNumberButton
            // 
            this.nineNumberButton.Location = new System.Drawing.Point(130, 131);
            this.nineNumberButton.Name = "nineNumberButton";
            this.nineNumberButton.Size = new System.Drawing.Size(53, 50);
            this.nineNumberButton.TabIndex = 10;
            this.nineNumberButton.Text = "9";
            this.nineNumberButton.UseVisualStyleBackColor = true;
            this.nineNumberButton.Click += new System.EventHandler(this.nineNumberButton_Click);
            // 
            // moduloOperationButton
            // 
            this.moduloOperationButton.Location = new System.Drawing.Point(12, 75);
            this.moduloOperationButton.Name = "moduloOperationButton";
            this.moduloOperationButton.Size = new System.Drawing.Size(53, 50);
            this.moduloOperationButton.TabIndex = 9;
            this.moduloOperationButton.Text = "%";
            this.moduloOperationButton.UseVisualStyleBackColor = true;
            this.moduloOperationButton.Click += new System.EventHandler(this.moduloOperationButton_Click);
            // 
            // divideOperationButton
            // 
            this.divideOperationButton.Location = new System.Drawing.Point(71, 75);
            this.divideOperationButton.Name = "divideOperationButton";
            this.divideOperationButton.Size = new System.Drawing.Size(53, 50);
            this.divideOperationButton.TabIndex = 8;
            this.divideOperationButton.Text = "/";
            this.divideOperationButton.UseVisualStyleBackColor = true;
            this.divideOperationButton.Click += new System.EventHandler(this.divideOperationButton_Click);
            // 
            // substractOperationButton
            // 
            this.substractOperationButton.Location = new System.Drawing.Point(189, 75);
            this.substractOperationButton.Name = "substractOperationButton";
            this.substractOperationButton.Size = new System.Drawing.Size(52, 50);
            this.substractOperationButton.TabIndex = 7;
            this.substractOperationButton.Text = "-";
            this.substractOperationButton.UseVisualStyleBackColor = true;
            this.substractOperationButton.Click += new System.EventHandler(this.substractOperationButton_Click);
            // 
            // multiplyOperationButton
            // 
            this.multiplyOperationButton.Location = new System.Drawing.Point(130, 75);
            this.multiplyOperationButton.Name = "multiplyOperationButton";
            this.multiplyOperationButton.Size = new System.Drawing.Size(53, 50);
            this.multiplyOperationButton.TabIndex = 6;
            this.multiplyOperationButton.Text = "*";
            this.multiplyOperationButton.UseVisualStyleBackColor = true;
            this.multiplyOperationButton.Click += new System.EventHandler(this.multiplyOperationButton_Click);
            // 
            // sinusOperationButton
            // 
            this.sinusOperationButton.Location = new System.Drawing.Point(12, 19);
            this.sinusOperationButton.Name = "sinusOperationButton";
            this.sinusOperationButton.Size = new System.Drawing.Size(53, 50);
            this.sinusOperationButton.TabIndex = 5;
            this.sinusOperationButton.Text = "sin";
            this.sinusOperationButton.UseVisualStyleBackColor = true;
            this.sinusOperationButton.Click += new System.EventHandler(this.sinusOperationButton_Click);
            // 
            // cosinusOperationButton
            // 
            this.cosinusOperationButton.Location = new System.Drawing.Point(71, 19);
            this.cosinusOperationButton.Name = "cosinusOperationButton";
            this.cosinusOperationButton.Size = new System.Drawing.Size(53, 50);
            this.cosinusOperationButton.TabIndex = 4;
            this.cosinusOperationButton.Text = "cos";
            this.cosinusOperationButton.UseVisualStyleBackColor = true;
            this.cosinusOperationButton.Click += new System.EventHandler(this.cosinusOperationButton_Click);
            // 
            // squareOperationButton
            // 
            this.squareOperationButton.Location = new System.Drawing.Point(189, 19);
            this.squareOperationButton.Name = "squareOperationButton";
            this.squareOperationButton.Size = new System.Drawing.Size(52, 50);
            this.squareOperationButton.TabIndex = 3;
            this.squareOperationButton.Text = "sqr";
            this.squareOperationButton.UseVisualStyleBackColor = true;
            this.squareOperationButton.Click += new System.EventHandler(this.squareOperationButton_Click);
            // 
            // sqrtOperationButton
            // 
            this.sqrtOperationButton.Location = new System.Drawing.Point(130, 19);
            this.sqrtOperationButton.Name = "sqrtOperationButton";
            this.sqrtOperationButton.Size = new System.Drawing.Size(53, 50);
            this.sqrtOperationButton.TabIndex = 2;
            this.sqrtOperationButton.Text = "sqrt";
            this.sqrtOperationButton.UseVisualStyleBackColor = true;
            this.sqrtOperationButton.Click += new System.EventHandler(this.sqrtOperationButton_Click);
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            this.clearHistoryButton.Location = new System.Drawing.Point(290, 524);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(305, 50);
            this.clearHistoryButton.TabIndex = 21;
            this.clearHistoryButton.Text = "Wyczyść historię";
            this.clearHistoryButton.UseVisualStyleBackColor = true;
            this.clearHistoryButton.Click += new System.EventHandler(this.clearHistoryButton_Click);
            // 
            // historyList
            // 
            this.historyList.CheckBoxes = true;
            this.historyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Historia});
            this.historyList.Location = new System.Drawing.Point(290, 13);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(305, 505);
            this.historyList.TabIndex = 22;
            this.historyList.UseCompatibleStateImageBehavior = false;
            this.historyList.View = System.Windows.Forms.View.Details;
            // 
            // Historia
            // 
            this.Historia.Text = "Historia";
            this.Historia.Width = 300;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 613);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.historyList);
            this.Controls.Add(this.clearHistoryButton);
            this.Controls.Add(this.keyboardGroup);
            this.Controls.Add(this.operationsGroup);
            this.Controls.Add(this.dataAndResultGroup);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dataAndResultGroup.ResumeLayout(false);
            this.dataAndResultGroup.PerformLayout();
            this.operationsGroup.ResumeLayout(false);
            this.operationsGroup.PerformLayout();
            this.keyboardGroup.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox dataAndResultGroup;
        private System.Windows.Forms.RadioButton secondNumberRadio;
        private System.Windows.Forms.RadioButton firstNumberRadio;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultField;
        private System.Windows.Forms.TextBox secondNumberField;
        private System.Windows.Forms.TextBox firstNumberField;
        private System.Windows.Forms.GroupBox operationsGroup;
        private System.Windows.Forms.RadioButton sinusOperationRadio;
        private System.Windows.Forms.RadioButton moduloOperationRadio;
        private System.Windows.Forms.RadioButton divideOperationRadio;
        private System.Windows.Forms.RadioButton multiplyOperationRadio;
        private System.Windows.Forms.RadioButton substractOperationRadio;
        private System.Windows.Forms.RadioButton addOperationRadio;
        private System.Windows.Forms.RadioButton cosinusOperationRadio;
        private System.Windows.Forms.RadioButton squarerootOperationRadio;
        private System.Windows.Forms.RadioButton squareOperationRadio;
        private System.Windows.Forms.GroupBox keyboardGroup;
        private System.Windows.Forms.Button sinusOperationButton;
        private System.Windows.Forms.Button cosinusOperationButton;
        private System.Windows.Forms.Button squareOperationButton;
        private System.Windows.Forms.Button sqrtOperationButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button addOperationButton;
        private System.Windows.Forms.Button zeroNumberButton;
        private System.Windows.Forms.Button commaCharButton;
        private System.Windows.Forms.Button oneNumberButton;
        private System.Windows.Forms.Button twoNumberButton;
        private System.Windows.Forms.Button threeNumberButton;
        private System.Windows.Forms.Button fourNumberButton;
        private System.Windows.Forms.Button fiveNumberButton;
        private System.Windows.Forms.Button sixNumberButton;
        private System.Windows.Forms.Button sevenNumberButton;
        private System.Windows.Forms.Button eightNumberButton;
        private System.Windows.Forms.Button nineNumberButton;
        private System.Windows.Forms.Button moduloOperationButton;
        private System.Windows.Forms.Button divideOperationButton;
        private System.Windows.Forms.Button substractOperationButton;
        private System.Windows.Forms.Button multiplyOperationButton;
        private System.Windows.Forms.Button clearHistoryButton;
        private System.Windows.Forms.ListView historyList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader Historia;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

