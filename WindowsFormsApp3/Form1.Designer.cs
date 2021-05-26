
namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.clearPlotButton = new System.Windows.Forms.Button();
            this.OX = new System.Windows.Forms.TextBox();
            this.OY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.nameOfDiagram = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.fullDiagram = new System.Windows.Forms.Button();
            this.percentMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.formsPlot1.Location = new System.Drawing.Point(12, 12);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1149, 620);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formsPlot1_MouseMove);
            // 
            // clearPlotButton
            // 
            this.clearPlotButton.Location = new System.Drawing.Point(1314, 417);
            this.clearPlotButton.Name = "clearPlotButton";
            this.clearPlotButton.Size = new System.Drawing.Size(136, 47);
            this.clearPlotButton.TabIndex = 3;
            this.clearPlotButton.Text = "Очистить";
            this.clearPlotButton.UseVisualStyleBackColor = true;
            this.clearPlotButton.Click += new System.EventHandler(this.clearPlotButton_Click);
            // 
            // OX
            // 
            this.OX.Location = new System.Drawing.Point(359, 709);
            this.OX.Name = "OX";
            this.OX.Size = new System.Drawing.Size(166, 20);
            this.OX.TabIndex = 33;
            // 
            // OY
            // 
            this.OY.Location = new System.Drawing.Point(650, 709);
            this.OY.Name = "OY";
            this.OY.Size = new System.Drawing.Size(166, 20);
            this.OY.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(332, 692);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(230, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Процентное содержание первого вещества";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(618, 692);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(229, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Процентное содержание второго вещества";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1303, 548);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 64);
            this.button4.TabIndex = 38;
            this.button4.Text = "Добавить диаграмму";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nameOfDiagram
            // 
            this.nameOfDiagram.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameOfDiagram.Location = new System.Drawing.Point(1290, 180);
            this.nameOfDiagram.Name = "nameOfDiagram";
            this.nameOfDiagram.Size = new System.Drawing.Size(188, 29);
            this.nameOfDiagram.TabIndex = 33;
            this.nameOfDiagram.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label53.Location = new System.Drawing.Point(1286, 155);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(191, 22);
            this.label53.TabIndex = 39;
            this.label53.Text = "Название диаграммы";
            // 
            // fullDiagram
            // 
            this.fullDiagram.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullDiagram.Location = new System.Drawing.Point(1303, 666);
            this.fullDiagram.Name = "fullDiagram";
            this.fullDiagram.Size = new System.Drawing.Size(164, 63);
            this.fullDiagram.TabIndex = 40;
            this.fullDiagram.Text = "Построить";
            this.fullDiagram.UseVisualStyleBackColor = true;
            this.fullDiagram.Click += new System.EventHandler(this.fullDiagram_Click);
            // 
            // percentMode
            // 
            this.percentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.percentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentMode.FormattingEnabled = true;
            this.percentMode.Items.AddRange(new object[] {
            "Массовые проценты",
            "Мольные проценты"});
            this.percentMode.Location = new System.Drawing.Point(1290, 273);
            this.percentMode.Name = "percentMode";
            this.percentMode.Size = new System.Drawing.Size(188, 28);
            this.percentMode.TabIndex = 41;
            // 
            // Form1
            // 
            this.AcceptButton = this.fullDiagram;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 788);
            this.Controls.Add(this.percentMode);
            this.Controls.Add(this.fullDiagram);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.nameOfDiagram);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.OY);
            this.Controls.Add(this.OX);
            this.Controls.Add(this.clearPlotButton);
            this.Controls.Add(this.formsPlot1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Программный комплекс динамических образов фазовых диаграмм";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Button clearPlotButton;
        private System.Windows.Forms.TextBox OX;
        private System.Windows.Forms.TextBox OY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox nameOfDiagram;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Button fullDiagram;
        private System.Windows.Forms.ComboBox percentMode;
    }
}

