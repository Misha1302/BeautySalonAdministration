namespace BeautySalonAdministration
{
    partial class HolidaysForm
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            comboBox3 = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Выходные";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" });
            comboBox1.Location = new Point(12, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(254, 33);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 76);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(254, 33);
            comboBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(12, 154);
            button1.Name = "button1";
            button1.Size = new Size(254, 34);
            button1.TabIndex = 3;
            button1.Text = "Установить выходные";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 115);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(254, 33);
            comboBox3.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(12, 194);
            button2.Name = "button2";
            button2.Size = new Size(254, 34);
            button2.TabIndex = 5;
            button2.Text = "Установить рабочие дни";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // HolidaysForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 244);
            Controls.Add(button2);
            Controls.Add(comboBox3);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "HolidaysForm";
            Text = "HolidaysForm";
            FormClosing += HolidaysForm_FormClosing;
            Load += HolidaysForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private ComboBox comboBox3;
        private Button button2;
    }
}