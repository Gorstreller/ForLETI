using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommand commandForGettingPoint = null;
        private string queryForGettingPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            sqlConnection.Open();
            /*if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено!");
            }*/
        }

        private double[,] MakeSystem(double[,] xyTable, int basis)
        {
            double[,] matrix = new double[basis, basis + 1];
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < xyTable.Length / 2; k++)
                    {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
                        sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, basis] = sumB;
                }
            }
            return matrix;
        }

        private double[] lagrangeForSevenPoints()
        {
            double x0, x1, x2, x3, x4, x5, x6, y0, y1, y2, y3, y4, y5, y6;
            // Вытаскиваем значения из полей
            if (double.TryParse(this.x0.Text, out x0) &&
                double.TryParse(this.y0.Text, out y0) &&
                double.TryParse(this.x1.Text, out x1) &&
                double.TryParse(this.y1.Text, out y1) &&
                double.TryParse(this.x2.Text, out x2) &&
                double.TryParse(this.y2.Text, out y2) &&
                double.TryParse(this.x3.Text, out x4) &&
                double.TryParse(this.y3.Text, out y3) &&
                double.TryParse(this.x4.Text, out x4) &&
                double.TryParse(this.y4.Text, out y4) &&
                double.TryParse(this.x5.Text, out x5) &&
                double.TryParse(this.y5.Text, out y5) &&
                double.TryParse(this.x6.Text, out x6) &&
                double.TryParse(this.y6.Text, out y6))
            {
                double stepX = Math.Abs((x6 - x0) / 1000);
                double[] arrayX = new double[1000];
                double[] arrayY = new double[1000];
                for (int i = 0; i < 1000; i++)
                {
                    arrayX[i] = x0 + (stepX * i);

                }

            }
                double[] a = new double[] { };
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] dataX_AB = new double[] { 0, 0.16, 0.25, 0.39, 0.51 };
            double[] dataY_AB = new double[] { 1539, 1530, 1523, 1512, 1499 };
            double[] dataX_BC = new double[] { 0.51, 1.5, 2, 3, 4.3 };
            double[] dataY_BC = new double[] { 1499, 1450, 1415, 1308, 1147 };
            double[] dataX_CD = new double[] { 4.3, 4.5, 5, 5.5, 6, 6.67 };
            double[] dataY_CD = new double[] { 1147, 1225, 1344, 1437, 1519, 1600 };
            double[] dataX_DL = new double[] { 6.67, 6.67 };
            double[] dataY_DL = new double[] { 1600, 600 };
            double[] dataX_AH = new double[] { 0, 0.1 };
            double[] dataY_AH = new double[] { 1539, 1499 };
            double[] dataX_HB = new double[] { 0.1, 0.51 };
            double[] dataY_HB = new double[] { 1499, 1499 };
            double[] dataX_EF = new double[] { 2.14, 6.67 };
            double[] dataY_EF = new double[] { 1147, 1147 };
            double[] dataX_NH = new double[] { 0, 0.05, 0.08, 0.095, 0.1 };
            double[] dataY_NH = new double[] { 1392, 1422, 1450, 1465, 1499 };
            double[] dataX_NJ = new double[] { 0, 0.1, 0.13, 0.15, 0.16 };
            double[] dataY_NJ = new double[] { 1392, 1425, 1450, 1480, 1499 };
            double[] dataX_JE = new double[] { 0.16, 0.5, 1, 1.5, 2.14 };
            double[] dataY_JE = new double[] { 1499, 1425, 1338, 1250, 1147 };
            double[] dataX_SE = new double[] { 0.8, 1.15, 1.42, 1.78, 2.14 };
            double[] dataY_SE = new double[] { 727, 850, 950, 1050, 1147 };
            double[] dataX_PK = new double[] { 0.2, 6.67 };
            double[] dataY_PK = new double[] { 727, 727 };
            double[] dataX_GS = new double[] { 0, 0.2, 0.4, 0.57, 0.8 };
            double[] dataY_GS = new double[] { 911, 850, 800, 768, 727 };
            double[] dataX_GP = new double[] { 0, 0.05, 0.1, 0.16, 0.2 };
            double[] dataY_GP = new double[] { 911, 850, 800, 750, 727 };
            double[] dataX_QP = new double[] { 0.05, 0.09, 0.15, 0.2 };
            double[] dataY_QP = new double[] { 600, 650, 700, 727 };
            formsPlot1.plt.PlotScatter(dataX_AB, dataY_AB, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_BC, dataY_BC, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_CD, dataY_CD, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_DL, dataY_DL, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_AH, dataY_AH, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_HB, dataY_HB, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_EF, dataY_EF, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_NH, dataY_NH, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_NJ, dataY_NJ, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_JE, dataY_JE, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_SE, dataY_SE, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_PK, dataY_PK, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_GS, dataY_GS, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_GP, dataY_GP, markerSize: 0, color: Color.Green);
            formsPlot1.plt.PlotScatter(dataX_QP, dataY_QP, markerSize: 0, color: Color.Green);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            formsPlot1.Render();
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            OX.Text = Math.Round(mouseCoordX, 2).ToString();
            OY.Text = Math.Round(mouseCoordY, 2).ToString();
            formsPlot1.Render();
        }

            private void button2_Click(object sender, EventArgs e)
        {
            // Задаём координаты точек для построения
            float[] dataX_AB = new float[] { 0, 0.16f, 0.25f, 0.39f, 0.51f };
            float[] dataY_AB = new float[] { 1539, 1530, 1523, 1512, 1499 };
            float[] dataX_BC = new float[] { 0.51f, 1.5f, 2, 3, 4.3f };
            float[] dataY_BC = new float[] { 1499, 1450, 1415, 1308, 1147 };
            float[] dataX_CD = new float[] { 4.3f, 4.5f, 5, 5.5f, 6, 6.67f };
            float[] dataY_CD = new float[] { 1147, 1225, 1344, 1437, 1519, 1600 };
            double[] dataX_DL = new double[] { 6.67, 6.67 };
            double[] dataY_DL = new double[] { 1600, 600 };
            float[] dataX_AH = new float[] { 0, 0.1f };
            float[] dataY_AH = new float[] { 1539, 1499 };
            double[] dataX_HB = new double[] { 0.1, 0.51 };
            double[] dataY_HB = new double[] { 1499, 1499 };
            double[] dataX_EF = new double[] { 2.14, 6.67 };
            double[] dataY_EF = new double[] { 1147, 1147 };
            float[] dataX_NH = new float[] { 0, 0.05f, 0.08f, 0.095f, 0.1f };
            float[] dataY_NH = new float[] { 1392, 1422, 1450, 1465, 1499 };
            float[] dataX_NJ = new float[] { 0, 0.1f, 0.13f, 0.15f, 0.16f };
            float[] dataY_NJ = new float[] { 1392, 1425, 1450, 1480, 1499 };
            float[] dataX_JE = new float[] { 0.16f, 0.5f, 1, 1.5f, 2.14f };
            float[] dataY_JE = new float[] { 1499, 1425, 1338, 1250, 1147 };
            float[] dataX_SE = new float[] { 0.8f, 1.15f, 1.42f, 1.78f, 2.14f };
            float[] dataY_SE = new float[] { 727, 850, 950, 1050, 1147 };
            double[] dataX_PK = new double[] { 0.2, 6.67 };
            double[] dataY_PK = new double[] { 727, 727 };
            float[] dataX_GS = new float[] { 0, 0.2f, 0.4f, 0.57f, 0.8f };
            float[] dataY_GS = new float[] { 911, 850, 800, 768, 727 };
            float[] dataX_GP = new float[] { 0, 0.05f, 0.1f, 0.16f, 0.2f };
            float[] dataY_GP = new float[] { 911, 850, 800, 750, 727 };
            float[] dataX_QP = new float[] { 0.05f, 0.09f, 0.15f, 0.2f };
            float[] dataY_QP = new float[] { 600, 650, 700, 727 };
            // Объявляем промежуточные переменные для применения метода FitParametric()
            float[] dataX_AB_float, dataY_AB_float,
                dataX_BC_float, dataY_BC_float,
                dataX_CD_float, dataY_CD_float,
                dataX_AH_float, dataY_AH_float,
                dataX_NH_float, dataY_NH_float,
                dataX_NJ_float, dataY_NJ_float,
                dataX_JE_float, dataY_JE_float,
                dataX_SE_float, dataY_SE_float,
                dataX_GS_float, dataY_GS_float,
                dataX_GP_float, dataY_GP_float,
                dataX_QP_float, dataY_QP_float;
            CubicSpline.FitParametric(dataX_AB, dataY_AB, 100, out dataX_AB_float, out dataY_AB_float);
            CubicSpline.FitParametric(dataX_BC, dataY_BC, 100, out dataX_BC_float, out dataY_BC_float);
            CubicSpline.FitParametric(dataX_CD, dataY_CD, 100, out dataX_CD_float, out dataY_CD_float);
            CubicSpline.FitParametric(dataX_AH, dataY_AH, 100, out dataX_AH_float, out dataY_AH_float);
            CubicSpline.FitParametric(dataX_NH, dataY_NH, 100, out dataX_NH_float, out dataY_NH_float);
            CubicSpline.FitParametric(dataX_NJ, dataY_NJ, 100, out dataX_NJ_float, out dataY_NJ_float);
            CubicSpline.FitParametric(dataX_JE, dataY_JE, 100, out dataX_JE_float, out dataY_JE_float);
            CubicSpline.FitParametric(dataX_SE, dataY_SE, 100, out dataX_SE_float, out dataY_SE_float);
            CubicSpline.FitParametric(dataX_GS, dataY_GS, 100, out dataX_GS_float, out dataY_GS_float);
            CubicSpline.FitParametric(dataX_GP, dataY_GP, 100, out dataX_GP_float, out dataY_GP_float);
            CubicSpline.FitParametric(dataX_QP, dataY_QP, 100, out dataX_QP_float, out dataY_QP_float);
            // Переводим все массивы из float в double
            double[] dataX_AB_double = Array.ConvertAll(dataX_AB_float, u => (double)u);
            double[] dataY_AB_double = Array.ConvertAll(dataY_AB_float, u => (double)u);
            double[] dataX_BC_double = Array.ConvertAll(dataX_BC_float, u => (double)u);
            double[] dataY_BC_double = Array.ConvertAll(dataY_BC_float, u => (double)u);
            double[] dataX_CD_double = Array.ConvertAll(dataX_CD_float, u => (double)u);
            double[] dataY_CD_double = Array.ConvertAll(dataY_CD_float, u => (double)u);
            double[] dataX_AH_double = Array.ConvertAll(dataX_AH_float, u => (double)u);
            double[] dataY_AH_double = Array.ConvertAll(dataY_AH_float, u => (double)u);
            double[] dataX_NH_double = Array.ConvertAll(dataX_NH_float, u => (double)u);
            double[] dataY_NH_double = Array.ConvertAll(dataY_NH_float, u => (double)u);
            double[] dataX_NJ_double = Array.ConvertAll(dataX_NJ_float, u => (double)u);
            double[] dataY_NJ_double = Array.ConvertAll(dataY_NJ_float, u => (double)u);
            double[] dataX_JE_double = Array.ConvertAll(dataX_JE_float, u => (double)u);
            double[] dataY_JE_double = Array.ConvertAll(dataY_JE_float, u => (double)u);
            double[] dataX_SE_double = Array.ConvertAll(dataX_SE_float, u => (double)u);
            double[] dataY_SE_double = Array.ConvertAll(dataY_SE_float, u => (double)u);
            double[] dataX_GS_double = Array.ConvertAll(dataX_GS_float, u => (double)u);
            double[] dataY_GS_double = Array.ConvertAll(dataY_GS_float, u => (double)u);
            double[] dataX_GP_double = Array.ConvertAll(dataX_GP_float, u => (double)u);
            double[] dataY_GP_double = Array.ConvertAll(dataY_GP_float, u => (double)u);
            double[] dataX_QP_double = Array.ConvertAll(dataX_QP_float, u => (double)u);
            double[] dataY_QP_double = Array.ConvertAll(dataY_QP_float, u => (double)u);
            // Строим всё это безобразие
            formsPlot1.plt.PlotScatter(dataX_AB_double, dataY_AB_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_BC_double, dataY_BC_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_CD_double, dataY_CD_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_AH_double, dataY_AH_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_NH_double, dataY_NH_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_NJ_double, dataY_NJ_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_JE_double, dataY_JE_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_SE_double, dataY_SE_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_GS_double, dataY_GS_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_GP_double, dataY_GP_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.PlotScatter(dataX_QP_double, dataY_QP_double, markerSize: 0, color: Color.Red);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            formsPlot1.Render();
        }

        private void DrawBezierPoint(PaintEventArgs e)
        {
            Point[] p =
            {
                new Point(10, 100),
                new Point(75, 10),
                new Point(80, 50),
                new Point(100, 150),
                new Point(125, 80),
                new Point(175, 200),
                new Point(200, 80)
            };
            Pen pen = new Pen(Color.Blue);
            e.Graphics.DrawBeziers(pen, p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formsPlot1.plt.Clear();
            formsPlot1.Render();
        }

        private void mainBuildingButton_Click(object sender, EventArgs e)
        {
            bezierBuilding();

            /*Func<double, double> bezier = x => x * 2;
            Console.WriteLine(bezier(2));
            double[] cordinateX = new[] { 0d };
            for (double i = 0.01; i <= 2; i += 0.01)
            {
                cordinateX.Append(i);
            }
            double[] cordinateY = new[] { bezier(0d) };
            for (int j = 1; j <= cordinateX.Length; j++)
            {
                cordinateY.Append(bezier(cordinateX[j]));
            }*/
        }


        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            //
        }

        private void bezierBuilding()
        {
            double P0x, P1xBefore, P3x, P0y, Py, P3y;
            if (double.TryParse(this.P0x.Text, out P0x) &&
                double.TryParse(this.P0y.Text, out P0y) &&
                double.TryParse(this.P1x.Text, out P1xBefore) &&
                double.TryParse(this.P1y.Text, out Py) &&
                double.TryParse(this.P2x.Text, out P3x) &&
                double.TryParse(this.P2y.Text, out P3y))
            {
                double[] arrayForCheckY = new double[10001];
                double[] arrayForCheckX = new double[10001];
                // Создаём два массива для значений по обеим осям + счётчик номера элемента
                double[] arrayX = new double[10001];
                double[] arrayY = new double[10001];
                int i;

                double P1yBefore, P1x, P1y, P2x, P2y;
                for (double j = 0.50; j < 0.999; j += 0.001)
                {
                    // Высчитываем координату y для одной направляющей точки
                    P1yBefore = ((Py - (0.25 * P0y)) / j);
                    // Пересчитываем координаты для двух направляющих точек
                    P1x = P0x + ((2 * (P1xBefore - P0x)) / 3);
                    P1y = P0y + ((2 * (P1yBefore - P0y)) / 3);
                    P2x = P1xBefore + ((P3x - P1xBefore) / 3);
                    P2y = P1yBefore + ((P3y - P1yBefore) / 3);
                    i = 0;
                    // Заполняем массивы по формулам построения кривых Безье
                    for (double t = 0; t <= 1; t += 0.0001)
                    {
                        arrayX[i] = Math.Pow((1 - t), 3) * P0x + 3 * t * Math.Pow((1 - t), 2) * P1x
                            + 3 * Math.Pow(t, 2) * (1 - t) * P2x + Math.Pow(t, 3) * P3x;
                        arrayY[i] = Math.Pow((1 - t), 3) * P0y + 3 * t * Math.Pow((1 - t), 2) * P1y
                            + 3 * Math.Pow(t, 2) * (1 - t) * P2y + Math.Pow(t, 3) * P3y;


                        arrayForCheckX[i] = Math.Round(arrayX[i], 2);
                        arrayForCheckY[i] = Math.Round(arrayY[i]);

                        i++;
                    }

                    if (arrayForCheckX.Contains(P1xBefore) && arrayForCheckY[Array.IndexOf(arrayForCheckX, P1xBefore)] == Py)
                    {
                        formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Aqua, markerSize: 0);
                        formsPlot1.plt.Axis(0, 4.4, 1100, 1550);
                        formsPlot1.plt.AxisBounds(0, 4.4, 1100, 1550);
                        formsPlot1.Render();
                        break;
                    }
                }
            }
            else
            {
                this.x0.Text = "Вы ввели неверное значение!";
            }
        }

        private void fullDiagram_Click(object sender, EventArgs e)
        {
            string queryForCount = String.Format("SELECT COUNT(*) FROM {0}", nameOfDiagram.Text);
            SqlCommand commandForCount = new SqlCommand(queryForCount, sqlConnection);
            int numberOfRows = (int) commandForCount.ExecuteScalar();

            for (int i = 3; i <= 3; i++)
            {
                double X0 = getPointFromDB("X0", i);
                double Y0 = getPointFromDB("Y0", i);
                double X1 = getPointFromDB("X1", i);
                double Y1 = getPointFromDB("Y1", i);
                double X2 = getPointFromDB("X2", i);
                double Y2 = getPointFromDB("Y2", i);
                double X3 = getPointFromDB("X3", i);
                double Y3 = getPointFromDB("Y3", i);

                pointX0.Text = X0.ToString();
                pointY0.Text = Y0.ToString();
                pointX1.Text = X1.ToString();
                pointY1.Text = Y1.ToString();
                pointX2.Text = X2.ToString();
                pointY2.Text = Y2.ToString();
                pointX3.Text = X3.ToString();
                pointY3.Text = Y3.ToString();
            }

            /*for (int i = 1; i <= 5; i++)
            {
                
            }*/
            /*SqlCommand command = new SqlCommand();
            string query1 = "SELECT X0 FROM Test1 WHERE Id = 4";
            command.CommandText = query1;
            command.Connection = sqlConnection;

            var result = command.ExecuteScalar().ToString();*/
            /*
                        nameOfDiagram.Text = result;*/

            SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Test1", sqlConnection);
            int count = (int) command1.ExecuteScalar();
            nameOfDiagram.Text = count.ToString();

            /*string new = dataAdapter*/
        }

        private double getPointFromDB(string nameOfPoint, int id)
        {
            queryForGettingPoint = String.Format("SELECT {0} FROM Test1 WHERE Id = {1}", nameOfPoint, id);
            commandForGettingPoint = new SqlCommand(queryForGettingPoint, sqlConnection);
            return (double) commandForGettingPoint.ExecuteScalar();
        }
    }
}
