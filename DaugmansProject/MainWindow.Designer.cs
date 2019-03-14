namespace DaugmansProject
{
    partial class MainWindow
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.runDaugmansButton = new System.Windows.Forms.Button();
            this.minRadiusTextBox = new System.Windows.Forms.TextBox();
            this.maxRadiusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xCutoffTextBox = new System.Windows.Forms.TextBox();
            this.yCutoffTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.angleStepTextBox = new System.Windows.Forms.TextBox();
            this.cleanImageButton = new System.Windows.Forms.Button();
            this.daugmansProgressBar = new System.Windows.Forms.ProgressBar();
            this.daugmansProgressBarLabel = new System.Windows.Forms.Label();
            this.gaussianButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.standardDevTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1305, 581);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Load Image";
            this.menuItem2.Click += new System.EventHandler(this.MenuItem2_Click);
            // 
            // runDaugmansButton
            // 
            this.runDaugmansButton.Location = new System.Drawing.Point(559, 587);
            this.runDaugmansButton.Name = "runDaugmansButton";
            this.runDaugmansButton.Size = new System.Drawing.Size(149, 23);
            this.runDaugmansButton.TabIndex = 1;
            this.runDaugmansButton.Text = "Run Daugman\'s Algorithm";
            this.runDaugmansButton.UseVisualStyleBackColor = true;
            this.runDaugmansButton.Click += new System.EventHandler(this.RunDaugmansButton_Click);
            // 
            // minRadiusTextBox
            // 
            this.minRadiusTextBox.Location = new System.Drawing.Point(644, 613);
            this.minRadiusTextBox.Name = "minRadiusTextBox";
            this.minRadiusTextBox.Size = new System.Drawing.Size(64, 20);
            this.minRadiusTextBox.TabIndex = 2;
            this.minRadiusTextBox.Text = "45";
            // 
            // maxRadiusTextBox
            // 
            this.maxRadiusTextBox.Location = new System.Drawing.Point(644, 639);
            this.maxRadiusTextBox.Name = "maxRadiusTextBox";
            this.maxRadiusTextBox.Size = new System.Drawing.Size(64, 20);
            this.maxRadiusTextBox.TabIndex = 3;
            this.maxRadiusTextBox.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min Radius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 639);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Radius";
            // 
            // xCutoffTextBox
            // 
            this.xCutoffTextBox.Location = new System.Drawing.Point(644, 689);
            this.xCutoffTextBox.Name = "xCutoffTextBox";
            this.xCutoffTextBox.Size = new System.Drawing.Size(64, 20);
            this.xCutoffTextBox.TabIndex = 6;
            this.xCutoffTextBox.Text = "0.15";
            // 
            // yCutoffTextBox
            // 
            this.yCutoffTextBox.Location = new System.Drawing.Point(644, 715);
            this.yCutoffTextBox.Name = "yCutoffTextBox";
            this.yCutoffTextBox.Size = new System.Drawing.Size(64, 20);
            this.yCutoffTextBox.TabIndex = 7;
            this.yCutoffTextBox.Text = "0.15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 689);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "X-cutoff";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 715);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Y-cutoff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 663);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Angle Step (rad)";
            // 
            // angleStepTextBox
            // 
            this.angleStepTextBox.Location = new System.Drawing.Point(644, 663);
            this.angleStepTextBox.Name = "angleStepTextBox";
            this.angleStepTextBox.Size = new System.Drawing.Size(64, 20);
            this.angleStepTextBox.TabIndex = 11;
            this.angleStepTextBox.Text = "0.2";
            // 
            // cleanImageButton
            // 
            this.cleanImageButton.Location = new System.Drawing.Point(562, 746);
            this.cleanImageButton.Name = "cleanImageButton";
            this.cleanImageButton.Size = new System.Drawing.Size(75, 23);
            this.cleanImageButton.TabIndex = 12;
            this.cleanImageButton.Text = "Clean Image";
            this.cleanImageButton.UseVisualStyleBackColor = true;
            this.cleanImageButton.Click += new System.EventHandler(this.CleanImageButton_Click);
            // 
            // daugmansProgressBar
            // 
            this.daugmansProgressBar.Location = new System.Drawing.Point(726, 586);
            this.daugmansProgressBar.Name = "daugmansProgressBar";
            this.daugmansProgressBar.Size = new System.Drawing.Size(136, 23);
            this.daugmansProgressBar.Step = 1;
            this.daugmansProgressBar.TabIndex = 13;
            // 
            // daugmansProgressBarLabel
            // 
            this.daugmansProgressBarLabel.AutoSize = true;
            this.daugmansProgressBarLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daugmansProgressBarLabel.Location = new System.Drawing.Point(868, 588);
            this.daugmansProgressBarLabel.Name = "daugmansProgressBarLabel";
            this.daugmansProgressBarLabel.Size = new System.Drawing.Size(33, 19);
            this.daugmansProgressBarLabel.TabIndex = 14;
            this.daugmansProgressBarLabel.Text = "0%";
            // 
            // gaussianButton
            // 
            this.gaussianButton.Location = new System.Drawing.Point(726, 613);
            this.gaussianButton.Name = "gaussianButton";
            this.gaussianButton.Size = new System.Drawing.Size(90, 23);
            this.gaussianButton.TabIndex = 15;
            this.gaussianButton.Text = "Gaussian Filter";
            this.gaussianButton.UseVisualStyleBackColor = true;
            this.gaussianButton.Click += new System.EventHandler(this.GaussianButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(723, 642);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Standard Deviation";
            // 
            // standardDevTextBox
            // 
            this.standardDevTextBox.Location = new System.Drawing.Point(827, 635);
            this.standardDevTextBox.Name = "standardDevTextBox";
            this.standardDevTextBox.Size = new System.Drawing.Size(64, 20);
            this.standardDevTextBox.TabIndex = 17;
            this.standardDevTextBox.Text = "1.0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 771);
            this.Controls.Add(this.standardDevTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gaussianButton);
            this.Controls.Add(this.daugmansProgressBarLabel);
            this.Controls.Add(this.daugmansProgressBar);
            this.Controls.Add(this.cleanImageButton);
            this.Controls.Add(this.angleStepTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yCutoffTextBox);
            this.Controls.Add(this.xCutoffTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxRadiusTextBox);
            this.Controls.Add(this.minRadiusTextBox);
            this.Controls.Add(this.runDaugmansButton);
            this.Controls.Add(this.pictureBox);
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";
            this.Text = "Daugman\'s Algorithm GUI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Button runDaugmansButton;
        private System.Windows.Forms.TextBox minRadiusTextBox;
        private System.Windows.Forms.TextBox maxRadiusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xCutoffTextBox;
        private System.Windows.Forms.TextBox yCutoffTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox angleStepTextBox;
        private System.Windows.Forms.Button cleanImageButton;
        private System.Windows.Forms.ProgressBar daugmansProgressBar;
        private System.Windows.Forms.Label daugmansProgressBarLabel;
        private System.Windows.Forms.Button gaussianButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox standardDevTextBox;
    }
}

