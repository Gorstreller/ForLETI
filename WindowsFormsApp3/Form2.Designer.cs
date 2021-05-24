
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
            this.components = new System.ComponentModel.Container();
            this.buttonAddDiagram = new System.Windows.Forms.Button();
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonChangeNumberOfPoints = new System.Windows.Forms.Button();
            this.nameOfDiagram = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteLineButton = new System.Windows.Forms.Button();
            this.numberOfColorGroup1 = new System.Windows.Forms.TextBox();
            this.numberOfColorGroup2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddDiagram
            // 
            this.buttonAddDiagram.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDiagram.Location = new System.Drawing.Point(1246, 662);
            this.buttonAddDiagram.Name = "buttonAddDiagram";
            this.buttonAddDiagram.Size = new System.Drawing.Size(155, 82);
            this.buttonAddDiagram.TabIndex = 0;
            this.buttonAddDiagram.Text = "Добавить диаграмму";
            this.buttonAddDiagram.UseVisualStyleBackColor = true;
            this.buttonAddDiagram.Click += new System.EventHandler(this.buttonAddDiagram_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(591, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(641, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "1539";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(710, 41);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "0,26";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(760, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(44, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "1520";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Начальная точка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(929, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Конечная точка";
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddLine.Location = new System.Drawing.Point(326, 662);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(169, 29);
            this.buttonAddLine.TabIndex = 9;
            this.buttonAddLine.Text = "Добавить линию";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(823, 41);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(44, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "6";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(873, 41);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(44, 20);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "5";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(932, 41);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(44, 20);
            this.textBox7.TabIndex = 13;
            this.textBox7.Text = "0,51";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(982, 41);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(44, 20);
            this.textBox8.TabIndex = 12;
            this.textBox8.Text = "1499";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2 точки",
            "3 точки",
            "4 точки"});
            this.comboBox1.Location = new System.Drawing.Point(1111, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 22);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(12, 17);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(532, 462);
            this.formsPlot1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(559, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "1";
            // 
            // buttonChangeNumberOfPoints
            // 
            this.buttonChangeNumberOfPoints.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeNumberOfPoints.Location = new System.Drawing.Point(1235, 17);
            this.buttonChangeNumberOfPoints.Name = "buttonChangeNumberOfPoints";
            this.buttonChangeNumberOfPoints.Size = new System.Drawing.Size(157, 71);
            this.buttonChangeNumberOfPoints.TabIndex = 17;
            this.buttonChangeNumberOfPoints.Text = "Выставить количество точек";
            this.buttonChangeNumberOfPoints.UseVisualStyleBackColor = true;
            this.buttonChangeNumberOfPoints.Click += new System.EventHandler(this.buttonChangeNumberOfPoints_Click);
            // 
            // nameOfDiagram
            // 
            this.nameOfDiagram.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameOfDiagram.Location = new System.Drawing.Point(1225, 136);
            this.nameOfDiagram.Name = "nameOfDiagram";
            this.nameOfDiagram.Size = new System.Drawing.Size(205, 30);
            this.nameOfDiagram.TabIndex = 18;
            this.nameOfDiagram.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1230, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Название диаграммы";
            // 
            // deleteLineButton
            // 
            this.deleteLineButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLineButton.Location = new System.Drawing.Point(326, 706);
            this.deleteLineButton.Name = "deleteLineButton";
            this.deleteLineButton.Size = new System.Drawing.Size(169, 29);
            this.deleteLineButton.TabIndex = 20;
            this.deleteLineButton.Text = "Удалить линию";
            this.deleteLineButton.UseVisualStyleBackColor = true;
            this.deleteLineButton.Click += new System.EventHandler(this.deleteLineButton_Click);
            // 
            // numberOfColorGroup1
            // 
            this.numberOfColorGroup1.Location = new System.Drawing.Point(1043, 42);
            this.numberOfColorGroup1.Name = "numberOfColorGroup1";
            this.numberOfColorGroup1.Size = new System.Drawing.Size(28, 20);
            this.numberOfColorGroup1.TabIndex = 21;
            this.numberOfColorGroup1.Text = "1";
            // 
            // numberOfColorGroup2
            // 
            this.numberOfColorGroup2.Location = new System.Drawing.Point(1077, 42);
            this.numberOfColorGroup2.Name = "numberOfColorGroup2";
            this.numberOfColorGroup2.Size = new System.Drawing.Size(28, 20);
            this.numberOfColorGroup2.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1246, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 82);
            this.button1.TabIndex = 23;
            this.button1.Text = "Предпросмотр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 768);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numberOfColorGroup2);
            this.Controls.Add(this.numberOfColorGroup1);
            this.Controls.Add(this.deleteLineButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameOfDiagram);
            this.Controls.Add(this.buttonChangeNumberOfPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.comboBox1);
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
            this.Controls.Add(this.buttonAddDiagram);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDiagram;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.ComboBox comboBox1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonChangeNumberOfPoints;
        private System.Windows.Forms.TextBox nameOfDiagram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteLineButton;
        private System.Windows.Forms.TextBox numberOfColorGroup1;
        private System.Windows.Forms.TextBox numberOfColorGroup2;
        private System.Windows.Forms.Button button1;
    }
}