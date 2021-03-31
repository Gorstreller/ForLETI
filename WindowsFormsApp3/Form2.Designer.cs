
namespace WindowsFormsApp3
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4Points = new System.Windows.Forms.RadioButton();
            this.radioButton3Points = new System.Windows.Forms.RadioButton();
            this.radioButton2Points = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1094, 601);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 82);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить диаграмму";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(25, 26);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4Points);
            this.groupBox1.Controls.Add(this.radioButton3Points);
            this.groupBox1.Controls.Add(this.radioButton2Points);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1111, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 131);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество точек";
            // 
            // radioButton4Points
            // 
            this.radioButton4Points.AutoSize = true;
            this.radioButton4Points.Location = new System.Drawing.Point(19, 83);
            this.radioButton4Points.Name = "radioButton4Points";
            this.radioButton4Points.Size = new System.Drawing.Size(78, 23);
            this.radioButton4Points.TabIndex = 2;
            this.radioButton4Points.Text = "4 точки";
            this.radioButton4Points.UseVisualStyleBackColor = true;
            this.radioButton4Points.CheckedChanged += new System.EventHandler(this.radioButton4Points_CheckedChanged);
            // 
            // radioButton3Points
            // 
            this.radioButton3Points.AutoSize = true;
            this.radioButton3Points.Location = new System.Drawing.Point(19, 54);
            this.radioButton3Points.Name = "radioButton3Points";
            this.radioButton3Points.Size = new System.Drawing.Size(78, 23);
            this.radioButton3Points.TabIndex = 1;
            this.radioButton3Points.Text = "3 точки";
            this.radioButton3Points.UseVisualStyleBackColor = true;
            this.radioButton3Points.CheckedChanged += new System.EventHandler(this.radioButton3Points_CheckedChanged);
            // 
            // radioButton2Points
            // 
            this.radioButton2Points.AutoSize = true;
            this.radioButton2Points.Checked = true;
            this.radioButton2Points.Location = new System.Drawing.Point(19, 25);
            this.radioButton2Points.Name = "radioButton2Points";
            this.radioButton2Points.Size = new System.Drawing.Size(78, 23);
            this.radioButton2Points.TabIndex = 0;
            this.radioButton2Points.TabStop = true;
            this.radioButton2Points.Text = "2 точки";
            this.radioButton2Points.UseVisualStyleBackColor = true;
            this.radioButton2Points.CheckedChanged += new System.EventHandler(this.radioButton2Points_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "2";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(357, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0,1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(524, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "4";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(474, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(44, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Начальная точка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(714, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Конечная точка";
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddLine.Location = new System.Drawing.Point(355, 664);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(169, 29);
            this.buttonAddLine.TabIndex = 9;
            this.buttonAddLine.Text = "Добавить линию";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(645, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(44, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "6";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(595, 46);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(44, 20);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "5";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(767, 46);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(44, 20);
            this.textBox7.TabIndex = 13;
            this.textBox7.Text = "8,8";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(717, 46);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(44, 20);
            this.textBox8.TabIndex = 12;
            this.textBox8.Text = "7,7";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 722);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.buttonAddLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3Points;
        private System.Windows.Forms.RadioButton radioButton2Points;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton4Points;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}