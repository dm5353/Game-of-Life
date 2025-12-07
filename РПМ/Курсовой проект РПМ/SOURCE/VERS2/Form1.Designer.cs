namespace WinForms_Life
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonPlayPause = new Button();
            Save = new Button();
            Load = new Button();
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            panel2 = new Panel();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            Clear = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonPlayPause
            // 
            buttonPlayPause.Location = new Point(13, 12);
            buttonPlayPause.Name = "buttonPlayPause";
            buttonPlayPause.Size = new Size(75, 23);
            buttonPlayPause.TabIndex = 0;
            buttonPlayPause.Text = "Играть";
            buttonPlayPause.UseVisualStyleBackColor = true;
            buttonPlayPause.Click += buttonPlayPause_Click;
            // 
            // Save
            // 
            Save.Location = new Point(94, 12);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 1;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Load
            // 
            Load.Location = new Point(175, 12);
            Load.Name = "Load";
            Load.Size = new Size(75, 23);
            Load.TabIndex = 2;
            Load.Text = "Загрузить";
            Load.UseVisualStyleBackColor = true;
            Load.Click += Load_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(256, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(145, 23);
            panel1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Window;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "20x20", "40x40", "50x50" });
            comboBox1.Location = new Point(86, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(57, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "20x20";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(77, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Размер поля:";
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(407, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(159, 23);
            panel2.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.Window;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "10x10", "20x20", "40x40" });
            comboBox2.Location = new Point(99, 0);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(57, 23);
            comboBox2.TabIndex = 1;
            comboBox2.Text = "20x20";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(90, 16);
            textBox2.TabIndex = 0;
            textBox2.Text = "Размер клеток:";
            // 
            // Clear
            // 
            Clear.Location = new Point(572, 12);
            Clear.Name = "Clear";
            Clear.Size = new Size(75, 23);
            Clear.TabIndex = 5;
            Clear.Text = "Очистить";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 450);
            Controls.Add(Clear);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Load);
            Controls.Add(Save);
            Controls.Add(buttonPlayPause);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(675, 0);
            Name = "Form1";
            Text = "Моделирование игры «Life»";
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonPlayPause;
        private Button Save;
        private Button Load;
        private Panel panel1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Panel panel2;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private Button Clear;
    }
}
